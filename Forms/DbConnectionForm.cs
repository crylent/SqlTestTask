using System.Security;
using Microsoft.Data.SqlClient;
using SqlTestTask.Services;

namespace SqlTestTask.Forms;

public partial class DbConnectionForm : Form
{
    private readonly IDatabaseService _db;

    private readonly TaskCompletionSource _connectionCompletion = new();
    
    public DbConnectionForm(IDatabaseService db)
    {
        _db = db;
        InitializeComponent();
        FormBorderStyle = FormBorderStyle.FixedDialog;
    }

    public async Task RequestConnection()
    {
        Show();
        await _connectionCompletion.Task;
        Close();
    }

    private void useWindowsCredentials_CheckedChanged(object sender, EventArgs e)
    {
        var dontUse = !useWindowsCredentials.Checked;
        user.Enabled = dontUse;
        password.Enabled = dontUse;
        UpdateState();
    }

    private void user_TextChanged(object sender, EventArgs e)
    {
        UpdateState();
    }

    private void password_TextChanged(object sender, EventArgs e)
    {
        UpdateState();
    }

    private async void connect_Click(object sender, EventArgs e)
    {
        errorProvider.Clear();
        connect.Enabled = false;
        Cursor.Current = Cursors.WaitCursor;
        var creds = useWindowsCredentials.Checked ? null : CreateCredential();
        var connected = await _db.Connect(creds);
        creds?.Password.Dispose();
        Cursor.Current = Cursors.Default;
        if (!connected) errorProvider.SetError(connect, _db.Error);
        else if (await _db.TestConnection() is { } error) errorProvider.SetError(connect, error.Message);
        else _connectionCompletion.SetResult();
    }

    private SqlCredential CreateCredential()
    {
        var securePass = new SecureString();
        foreach (var c in password.Text.ToCharArray())
        {
            securePass.AppendChar(c);
        }
        securePass.MakeReadOnly();
        return new SqlCredential(user.Text, securePass);
    }

    private void UpdateState()
    {
        var useWinCreds = useWindowsCredentials.Checked;
        if (useWinCreds) connect.Enabled = true;
        else
        {
            connect.Enabled = user.Text.Length > 0 && password.Text.Length > 0;
        }
    }
}