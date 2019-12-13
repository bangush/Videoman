using System;
using System.Text;
using System.Windows.Forms;

namespace Videoman
{
    public partial class UI : Form
    {
        CryptoProvider cryptoProvider;
        public UI()
        {
            InitializeComponent();
            cryptoProvider = new CryptoProvider(this, ref mediaPlayer, ref progressBar1);
        }
        private String file;

        private void SelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog.FileName;
                selectFile.Enabled = false;
                resetBtn.Enabled = false;
                runBtn.Enabled = true;
                fileNameBox.Text = file;
                runBtn.Text = file.Contains(".cypher") ? "Decrypt" : "Encrypt";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bufferType.SelectedItem = "MiB";
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            cryptoProvider.Cancel();
            EnableUI(true);
        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            // UTF-32 does have a fixed lenght for all characters and support accents
            if (passBox.Text != "")
            {
                cryptoProvider.Cypher(file, bufferMultiplier(bufferType.Text) * (int)bufferSize.Value, Encoding.UTF32.GetBytes(passBox.Text),
                    removeFileCheck.Checked, encFileCheck.Checked);
                runBtn.Enabled = false;
                resetBtn.Enabled = true;
            }
            else MessageBox.Show("Por favor, insira uma senha", "Erro");
        }

        private int bufferMultiplier(String name)
        {
            switch (name)
            {
                case "KiB":
                    return 1024;
                case "MiB":
                    return 1024 * 1024;
                case "GiB":
                    return 1024 * 1024 * 1024;
                default:
                    return 0;
            }
        }

        public void EnableUI(bool value)
        {
            selectFile.Enabled = value;
            resetBtn.Enabled = !value;
            runBtn.Enabled = !value;
            if (value)
            {
                progressBar1.Value = 0;
                file = "";
                fileNameBox.Text = "";
            }
            encFileCheck.Enabled = value;
            removeFileCheck.Enabled = value;
        }

        private void ShowPassBtn_MouseDown(object sender, MouseEventArgs e)
        {
            passBox.PasswordChar = '\0';
        }

        private void ShowPassBtn_MouseUp(object sender, MouseEventArgs e)
        {
            passBox.PasswordChar = '•';
        }
    }
}
