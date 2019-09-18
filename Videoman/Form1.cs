using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        private CancellationTokenSource encryptCancel;

        private void SelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog.FileName;
                selectFile.Enabled = false;
                resetBtn.Enabled = true;
                runBtn.Enabled = true;
            }
        }

        private async Task encrypt(String path, int chunksize, String output, CancellationToken cancelToken)
        {
            using (FileStream fw = new FileStream(output, FileMode.Create, FileAccess.Write))
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                // Get file full size in bytes
                long fullsize = fs.Length;

                // Prevents buffer bigger than file
                chunksize = chunksize <= fullsize ? chunksize : (int)fullsize;
                // Get the number of steps used in the progressbar
                long maximum = fullsize / chunksize;
                // Need to invoke action because we're in an async thread and it has no access to main thread's progressBar1
                progressBar1.Invoke(new Action(() =>
                {
                    progressBar1.Maximum = (int) maximum + 1;
                }));
                int bytesRead;
                long currentBytesRemaining = fullsize;
                // Current Buffer prevents from creating a file bigger than the original
                long currentBuffer;
                var buffer = new byte[chunksize];
                axWindowsMediaPlayer1.URL = output;
                while ((bytesRead = fs.Read(buffer, 0, chunksize <= currentBytesRemaining ? chunksize : (int)currentBytesRemaining)) > 0)
                {
                    currentBuffer = chunksize <= currentBytesRemaining ? chunksize : (int)currentBytesRemaining;
                    foreach (byte b in buffer)
                    {
                        // TODO: Actually encrypt data
                        if (currentBuffer > 0)
                        {
                            fw.WriteByte((byte)(b ^ 0x7c));
                            currentBuffer--;
                        }
                        cancelToken.ThrowIfCancellationRequested();
                    }
                    currentBytesRemaining -= chunksize <= currentBytesRemaining ? chunksize : (int)currentBytesRemaining;
                    progressBar1.Invoke(new Action(() =>
                    {
                        progressBar1.PerformStep();
                    })); 
                }
            }
            progressBar1.Invoke(new Action(() =>
            {
                progressBar1.Value = 0;
            }));

        }

        // go() needs to be async 'cause you can only call an async Thread while in an async context
        private async void go(int bufferMultiplierValue)
        {
            //try
            //{
                await Task.Run(() => encrypt(file, (int)bufferSize.Value * bufferMultiplierValue, file + ".out.mp4", encryptCancel.Token));
            //} catch (Exception)
            //{
            //    MessageBox.Show("Thread Cancelled");
            //} 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bufferType.SelectedItem = "MiB";
            encryptCancel = new CancellationTokenSource();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            file = "";
            selectFile.Enabled = true;
            resetBtn.Enabled = false;
            runBtn.Enabled = false;
            if (!encryptCancel.IsCancellationRequested)
                encryptCancel.Cancel();
        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            go(bufferMultiplier(bufferType.Text));
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
