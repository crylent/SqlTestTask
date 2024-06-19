using System.Data;
using System.Resources;
using Microsoft.Data.SqlClient;
using SqlTestTask.Data;
using SqlTestTask.Enums;
using SqlTestTask.Services;

namespace SqlTestTask.Forms;

public partial class StaffViewer : Form
{
    private readonly DbConnectionForm _connectionForm;
    private readonly DateRangeForm _dateRangeForm;
    
    private readonly IDatabaseService _db;
    private readonly ICatalogService _catalogs;

    private readonly ResourceManager _rm = new(typeof(StaffViewer));

    private DateRange? _dateRange;

    public StaffViewer(DbConnectionForm connectionForm, DateRangeForm dateRangeForm, IDatabaseService db, ICatalogService catalogs)
    {
        _connectionForm = connectionForm;
        _dateRangeForm = dateRangeForm;
        _db = db;
        _catalogs = catalogs;
        _dateRangeForm = dateRangeForm;
        
        InitializeComponent();
        employmentUnemploymentDate.SelectedIndex = 0;
        LocalizeItems(employmentUnemploymentDate.Items);
        
        OnStart();
    }

    private async void OnStart()
    {
        await RequestConnection();
        await LoadCatalogs();
        await UpdateTable();
    }

    private async Task RequestConnection()
    {
        WindowState = FormWindowState.Minimized;
        ShowInTaskbar = false;
        await _connectionForm.RequestConnection();
        WindowState = FormWindowState.Maximized;
        ShowInTaskbar = true;
    }

    private void LocalizeItems(ComboBox.ObjectCollection items)
    {
        for (var i = 0; i < items.Count; i++)
        {
            if (items[i] is string item && _rm.GetString(item) is { } str) items[i] = str;
        }
    }

    private async Task LoadCatalogs()
    {
        await _catalogs.LoadCatalogs();
        UpdateCatalog(department, _catalogs.Departments);
        UpdateCatalog(status, _catalogs.Statuses);
        UpdateCatalog(post, _catalogs.Posts);
    }

    private void UpdateCatalog(ComboBox comboBox, Catalog catalog)
    {
        var items = comboBox.Items;
        items.Clear();
        items.Add(_rm.GetString("comboBox_default") ?? string.Empty);
        items.AddRange(catalog.Keys.ToArray<object>());
        comboBox.SelectedIndex = 0;
    }

    private async Task UpdateTable(bool filter = false)
    {
        var table = await _db.SelectTable(StoredProcedure.GetStaffList, filter ? CreateParameters() : null);
        _ = UpdateTotal();
        foreach (DataColumn column in table.Columns)
        {
            var columnName = _rm.GetString(column.ColumnName);
            if (columnName is not null) column.ColumnName = columnName;
        }
        staffTable.DataSource = table;
        matchingEmployees.Text = table.Rows.Count.ToString();
    }

    private async Task UpdateTotal()
    {
        var total = await _db.SelectValue<int>(StoredProcedure.GetTotalEmployees);
        totalEmployees.Text = total.ToString();
    }

    private SqlParameter[] CreateParameters() =>
    [
        new SqlParameter("last_name", name.Text),
        new SqlParameter("status", GetVal(_catalogs.Statuses, status)),
        new SqlParameter("dep", GetVal(_catalogs.Departments, department)),
        new SqlParameter("post", GetVal(_catalogs.Posts, post)),
        new SqlParameter("employed_from", GetDate(0, false)),
        new SqlParameter("employed_until", GetDate(0, true)),
        new SqlParameter("unemployed_from", GetDate(1, false)),
        new SqlParameter("unemployed_until", GetDate(1, true)),
    ];

    private static int? GetVal(Catalog catalog, ComboBox comboBox)
    {
        var val = catalog.GetValueOrDefault(comboBox.Text);
        return val != default ? val : null;
    }

    private DateTime? GetDate(int requiredIndex, bool endDate)
    {
        if (_dateRange is null || employmentUnemploymentDate.SelectedIndex != requiredIndex) return null;
        return endDate ? _dateRange.End : _dateRange.Start;
    }

    private async void ApplyFilters(object? sender, EventArgs eventArgs) => await UpdateTable(true);

    private async void SelectDateRange(object? sender, EventArgs e)
    {
        if (_dateRange is not null)
        {
            _dateRangeForm.Start = _dateRange.Start;
            _dateRangeForm.End = _dateRange.End;
        }
        else _dateRangeForm.Reset();
        _dateRangeForm.Show();
        try
        {
            _dateRange = await _dateRangeForm.WaitForSelection();
        }
        catch (TaskCanceledException) {}

        if (_dateRange is null) return;
        selectDate.Text = string.Format(
            _rm.GetString("selectDateButtonText") ?? "{0}—{1}", 
            _dateRange.Start.ToShortDateString(),
            _dateRange.End.ToShortDateString()
            );
    }

    private void ResetDateRange(object? sender, EventArgs eventArgs)
    {
        _dateRange = null;
        selectDate.Text = "";
    }
}