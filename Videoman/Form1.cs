using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Videoman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private String file;

        private void SelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                String odf = openFileDialog.FileName;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    String sfd = saveFileDialog1.FileName;
                    encrypt(odf, (int)bufferSize.Value * 1024 * 1024, sfd);
                }
                
            }
        }

        private void encrypt(String path, int chunksize, String output)
        {
            using (FileStream fw = new FileStream(output, FileMode.Create, FileAccess.Write))
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                // Get file full size in bytes
                long fullsize = fs.Length;

                // Get the number of steps used in the progressbar
                long maximum = fullsize / chunksize;
                progressBar1.Maximum = (int) maximum + 1;
                int bytesRead;
                var buffer = new byte[chunksize];
                axWindowsMediaPlayer1.URL = output;
                while ((bytesRead = fs.Read(buffer, 0, chunksize)) > 0)
                {
                    foreach (byte b in buffer)
                    {
                        fw.WriteByte((byte)(b ^ 0x7c));
                        axWindowsMediaPlayer1.settings.autoStart = true;
                    }
                    progressBar1.PerformStep();
                }
            }
            progressBar1.Value = 0;
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
        }
    }
}
