using System;
using System.Text;
using System.Windows.Forms;

namespace Videoman
{
    public partial class Form1 : Form
    {
        CryptoProvider cryptoProvider;
        public Form1()
        {
            InitializeComponent();
            cryptoProvider = new CryptoProvider(ref mediaPlayer, ref progressBar1);
        }

        private String file;

        private void SelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog.FileName;
                selectFile.Enabled = false;
                resetBtn.Enabled = true;
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
            selectFile.Enabled = true;
            resetBtn.Enabled = false;
            runBtn.Enabled = false;
            progressBar1.Value = 0;
            cryptoProvider.Cancel();
            file = "";
        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            if (passBox.Text != "")
                cryptoProvider.Cypher(file, bufferMultiplier(bufferType.Text) * (int)bufferSize.Value, Encoding.UTF32.GetBytes(passBox.Text));
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
    }
}
