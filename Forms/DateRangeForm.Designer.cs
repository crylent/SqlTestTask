using System.ComponentModel;

namespace SqlTestTask.Forms;

partial class DateRangeForm
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
        ComponentResourceManager resources = new ComponentResourceManager(typeof(DateRangeForm));
        calendar = new MonthCalendar();
        okButton = new Button();
        SuspendLayout();
        // 
        // calendar
        // 
        resources.ApplyResources(calendar, "calendar");
        calendar.MaxSelectionCount = 400;
        calendar.Name = "calendar";
        calendar.ScrollChange = 3;
        // 
        // okButton
        // 
        resources.ApplyResources(okButton, "okButton");
        okButton.Name = "okButton";
        okButton.UseVisualStyleBackColor = true;
        okButton.Click += ConfirmSelection;
        // 
        // DateRangeForm
        // 
        AcceptButton = okButton;
        resources.ApplyResources(this, "$this");
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(okButton);
        Controls.Add(calendar);
        MaximizeBox = false;
        Name = "DateRangeForm";
        ResumeLayout(false);
    }

    #endregion

    private MonthCalendar calendar;
    private Button okButton;
}