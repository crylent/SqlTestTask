using System.ComponentModel;
using SqlTestTask.Data;

namespace SqlTestTask.Forms;

public partial class DateRangeForm : Form
{
    public DateTime Start
    {
        get => calendar.SelectionStart;
        set => calendar.SelectionStart = value;
    }
    
    public DateTime End
    {
        get => calendar.SelectionEnd;
        set => calendar.SelectionEnd = value;
    }

    private TaskCompletionSource<DateRange>? _selectCompletion;
    
    public DateRangeForm()
    {
        InitializeComponent();
        calendar.MaxDate = DateTime.Today;
    }

    public void Reset()
    {
        calendar.SetDate(DateTime.Today);
    }
    
    public Task<DateRange> WaitForSelection()
    {
        _selectCompletion = new TaskCompletionSource<DateRange>();
        return _selectCompletion.Task;
    }

    private void ConfirmSelection(object? sender, EventArgs eventArgs)
    {
        _selectCompletion?.SetResult(new DateRange(Start, End));
        Hide();
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        e.Cancel = true;
        _selectCompletion?.SetCanceled();
        Hide();
    }
}