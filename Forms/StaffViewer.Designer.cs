using System.ComponentModel;

namespace SqlTestTask.Forms;

partial class StaffViewer
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        ComponentResourceManager resources = new ComponentResourceManager(typeof(StaffViewer));
        staffTable = new DataGridView();
        filtering = new GroupBox();
        applyFilters = new Button();
        filtersLayout = new TableLayoutPanel();
        post = new ComboBox();
        department = new ComboBox();
        statusLabel = new Label();
        departmentLabel = new Label();
        postLabel = new Label();
        name = new TextBox();
        status = new ComboBox();
        nameLabel = new Label();
        employmentUnemploymentDate = new ComboBox();
        splitContainer = new SplitContainer();
        selectDate = new Button();
        resetDate = new Button();
        resultBox = new GroupBox();
        tableLayoutPanel2 = new TableLayoutPanel();
        totalEmployees = new Label();
        matchingEmployees = new LinkLabel();
        matchingEmployeesLabel = new Label();
        totalEmployeesLabel = new Label();
        ((ISupportInitialize)staffTable).BeginInit();
        filtering.SuspendLayout();
        filtersLayout.SuspendLayout();
        ((ISupportInitialize)splitContainer).BeginInit();
        splitContainer.Panel1.SuspendLayout();
        splitContainer.Panel2.SuspendLayout();
        splitContainer.SuspendLayout();
        resultBox.SuspendLayout();
        tableLayoutPanel2.SuspendLayout();
        SuspendLayout();
        // 
        // staffTable
        // 
        staffTable.AllowUserToAddRows = false;
        staffTable.AllowUserToDeleteRows = false;
        staffTable.AllowUserToResizeRows = false;
        resources.ApplyResources(staffTable, "staffTable");
        staffTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        staffTable.BackgroundColor = SystemColors.ControlLight;
        staffTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        staffTable.EditMode = DataGridViewEditMode.EditProgrammatically;
        staffTable.Name = "staffTable";
        staffTable.ReadOnly = true;
        staffTable.RowTemplate.Height = 27;
        // 
        // filtering
        // 
        resources.ApplyResources(filtering, "filtering");
        filtering.Controls.Add(applyFilters);
        filtering.Controls.Add(filtersLayout);
        filtering.Name = "filtering";
        filtering.TabStop = false;
        // 
        // applyFilters
        // 
        resources.ApplyResources(applyFilters, "applyFilters");
        applyFilters.Name = "applyFilters";
        applyFilters.UseVisualStyleBackColor = true;
        applyFilters.Click += ApplyFilters;
        // 
        // filtersLayout
        // 
        resources.ApplyResources(filtersLayout, "filtersLayout");
        filtersLayout.Controls.Add(post, 1, 3);
        filtersLayout.Controls.Add(department, 1, 2);
        filtersLayout.Controls.Add(statusLabel, 0, 1);
        filtersLayout.Controls.Add(departmentLabel, 0, 2);
        filtersLayout.Controls.Add(postLabel, 0, 3);
        filtersLayout.Controls.Add(name, 1, 0);
        filtersLayout.Controls.Add(status, 1, 1);
        filtersLayout.Controls.Add(nameLabel, 0, 0);
        filtersLayout.Controls.Add(employmentUnemploymentDate, 0, 4);
        filtersLayout.Controls.Add(splitContainer, 1, 4);
        filtersLayout.Name = "filtersLayout";
        // 
        // post
        // 
        resources.ApplyResources(post, "post");
        post.FormattingEnabled = true;
        post.Name = "post";
        // 
        // department
        // 
        resources.ApplyResources(department, "department");
        department.FormattingEnabled = true;
        department.Name = "department";
        // 
        // statusLabel
        // 
        resources.ApplyResources(statusLabel, "statusLabel");
        statusLabel.Name = "statusLabel";
        // 
        // departmentLabel
        // 
        resources.ApplyResources(departmentLabel, "departmentLabel");
        departmentLabel.Name = "departmentLabel";
        // 
        // postLabel
        // 
        resources.ApplyResources(postLabel, "postLabel");
        postLabel.Name = "postLabel";
        // 
        // name
        // 
        resources.ApplyResources(name, "name");
        name.Name = "name";
        // 
        // status
        // 
        resources.ApplyResources(status, "status");
        status.FormattingEnabled = true;
        status.Name = "status";
        // 
        // nameLabel
        // 
        resources.ApplyResources(nameLabel, "nameLabel");
        nameLabel.Name = "nameLabel";
        // 
        // employmentUnemploymentDate
        // 
        employmentUnemploymentDate.FormattingEnabled = true;
        employmentUnemploymentDate.Items.AddRange(new object[] { resources.GetString("employmentUnemploymentDate.Items"), resources.GetString("employmentUnemploymentDate.Items1") });
        resources.ApplyResources(employmentUnemploymentDate, "employmentUnemploymentDate");
        employmentUnemploymentDate.Name = "employmentUnemploymentDate";
        // 
        // splitContainer
        // 
        resources.ApplyResources(splitContainer, "splitContainer");
        splitContainer.Name = "splitContainer";
        // 
        // splitContainer.Panel1
        // 
        splitContainer.Panel1.Controls.Add(selectDate);
        // 
        // splitContainer.Panel2
        // 
        splitContainer.Panel2.Controls.Add(resetDate);
        splitContainer.TabStop = false;
        // 
        // selectDate
        // 
        resources.ApplyResources(selectDate, "selectDate");
        selectDate.Name = "selectDate";
        selectDate.UseVisualStyleBackColor = true;
        selectDate.Click += SelectDateRange;
        // 
        // resetDate
        // 
        resources.ApplyResources(resetDate, "resetDate");
        resetDate.Name = "resetDate";
        resetDate.UseVisualStyleBackColor = true;
        resetDate.Click += ResetDateRange;
        // 
        // resultBox
        // 
        resources.ApplyResources(resultBox, "resultBox");
        resultBox.Controls.Add(tableLayoutPanel2);
        resultBox.Name = "resultBox";
        resultBox.TabStop = false;
        // 
        // tableLayoutPanel2
        // 
        resources.ApplyResources(tableLayoutPanel2, "tableLayoutPanel2");
        tableLayoutPanel2.Controls.Add(totalEmployees, 1, 1);
        tableLayoutPanel2.Controls.Add(matchingEmployees, 1, 0);
        tableLayoutPanel2.Controls.Add(matchingEmployeesLabel, 0, 0);
        tableLayoutPanel2.Controls.Add(totalEmployeesLabel, 0, 1);
        tableLayoutPanel2.Name = "tableLayoutPanel2";
        // 
        // totalEmployees
        // 
        resources.ApplyResources(totalEmployees, "totalEmployees");
        totalEmployees.Name = "totalEmployees";
        // 
        // matchingEmployees
        // 
        resources.ApplyResources(matchingEmployees, "matchingEmployees");
        matchingEmployees.Name = "matchingEmployees";
        matchingEmployees.TabStop = true;
        matchingEmployees.LinkClicked += ShowPerDay;
        // 
        // matchingEmployeesLabel
        // 
        resources.ApplyResources(matchingEmployeesLabel, "matchingEmployeesLabel");
        matchingEmployeesLabel.Name = "matchingEmployeesLabel";
        // 
        // totalEmployeesLabel
        // 
        resources.ApplyResources(totalEmployeesLabel, "totalEmployeesLabel");
        totalEmployeesLabel.Name = "totalEmployeesLabel";
        // 
        // StaffViewer
        // 
        AcceptButton = applyFilters;
        resources.ApplyResources(this, "$this");
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(resultBox);
        Controls.Add(filtering);
        Controls.Add(staffTable);
        Name = "StaffViewer";
        WindowState = FormWindowState.Maximized;
        ((ISupportInitialize)staffTable).EndInit();
        filtering.ResumeLayout(false);
        filtersLayout.ResumeLayout(false);
        filtersLayout.PerformLayout();
        splitContainer.Panel1.ResumeLayout(false);
        splitContainer.Panel2.ResumeLayout(false);
        ((ISupportInitialize)splitContainer).EndInit();
        splitContainer.ResumeLayout(false);
        resultBox.ResumeLayout(false);
        tableLayoutPanel2.ResumeLayout(false);
        tableLayoutPanel2.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView staffTable;
    private GroupBox filtering;
    private TableLayoutPanel filtersLayout;
    private Label nameLabel;
    private Label statusLabel;
    private Label departmentLabel;
    private Label postLabel;
    private TextBox name;
    private ComboBox status;
    private ComboBox post;
    private ComboBox department;
    private Button applyFilters;
    private ComboBox employmentUnemploymentDate;
    private SplitContainer splitContainer;
    private Button selectDate;
    private Button resetDate;
    private GroupBox resultBox;
    private TableLayoutPanel tableLayoutPanel2;
    private Label matchingEmployeesLabel;
    private Label totalEmployeesLabel;
    private Label totalEmployees;
    private LinkLabel matchingEmployees;
}