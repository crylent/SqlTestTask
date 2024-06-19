namespace SqlTestTask.Forms;

partial class DbConnectionForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DbConnectionForm));
        useWindowsCredentials = new CheckBox();
        user = new TextBox();
        userLabel = new Label();
        password = new TextBox();
        passwordLabel = new Label();
        connect = new Button();
        panel = new Panel();
        tableLayout = new TableLayoutPanel();
        errorProvider = new ErrorProvider(components);
        panel.SuspendLayout();
        tableLayout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        SuspendLayout();
        // 
        // useWindowsCredentials
        // 
        resources.ApplyResources(useWindowsCredentials, "useWindowsCredentials");
        useWindowsCredentials.Checked = true;
        useWindowsCredentials.CheckState = CheckState.Checked;
        useWindowsCredentials.Name = "useWindowsCredentials";
        useWindowsCredentials.UseVisualStyleBackColor = true;
        useWindowsCredentials.CheckedChanged += useWindowsCredentials_CheckedChanged;
        // 
        // user
        // 
        resources.ApplyResources(user, "user");
        user.Name = "user";
        user.TextChanged += user_TextChanged;
        // 
        // userLabel
        // 
        resources.ApplyResources(userLabel, "userLabel");
        userLabel.Name = "userLabel";
        // 
        // password
        // 
        resources.ApplyResources(password, "password");
        password.Name = "password";
        password.TextChanged += password_TextChanged;
        // 
        // passwordLabel
        // 
        resources.ApplyResources(passwordLabel, "passwordLabel");
        passwordLabel.Name = "passwordLabel";
        // 
        // connect
        // 
        resources.ApplyResources(connect, "connect");
        connect.Name = "connect";
        connect.UseVisualStyleBackColor = true;
        connect.Click += connect_Click;
        // 
        // panel
        // 
        panel.Controls.Add(tableLayout);
        panel.Controls.Add(connect);
        panel.Controls.Add(useWindowsCredentials);
        resources.ApplyResources(panel, "panel");
        panel.Name = "panel";
        // 
        // tableLayout
        // 
        resources.ApplyResources(tableLayout, "tableLayout");
        tableLayout.Controls.Add(userLabel, 0, 0);
        tableLayout.Controls.Add(password, 1, 1);
        tableLayout.Controls.Add(passwordLabel, 0, 1);
        tableLayout.Controls.Add(user, 1, 0);
        tableLayout.Name = "tableLayout";
        // 
        // errorProvider
        // 
        errorProvider.ContainerControl = this;
        // 
        // DbConnectionForm
        // 
        AcceptButton = connect;
        resources.ApplyResources(this, "$this");
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(panel);
        Name = "DbConnectionForm";
        panel.ResumeLayout(false);
        panel.PerformLayout();
        tableLayout.ResumeLayout(false);
        tableLayout.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private CheckBox useWindowsCredentials;
    private TextBox user;
    private Label userLabel;
    private TextBox password;
    private Label passwordLabel;
    private Button connect;
    private Panel panel;
    private ErrorProvider errorProvider;
    private TableLayoutPanel tableLayout;
}