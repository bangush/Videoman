using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace Videoman
{
    class CryptoProvider
    {
        private CancellationTokenSource cypherCancelToken;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
        private System.Windows.Forms.ProgressBar progressBar;
        public CryptoProvider(ref AxWMPLib.AxWindowsMediaPlayer mediaPlayer, ref System.Windows.Forms.ProgressBar progressBar)
        {
            this.mediaPlayer = mediaPlayer;
            this.progressBar = progressBar;
        }

        public async void Cypher(String path, int bufferSize, byte[] key)
        {
            cypherCancelToken = new CancellationTokenSource();
            String output = path.Contains(".cypher") ? path.Replace(".cypher", ".mp4") : path.Replace(".mp4", ".cypher");
            try
            {
                await Task.Run(() => RunCypher(path, bufferSize, output, key, cypherCancelToken.Token));
            } catch (OperationCanceledException)
            {
                File.Delete(output);
            }
            cypherCancelToken.Dispose();
        }

        public void Cancel()
        {
            if (!cypherCancelToken.IsCancellationRequested)
                cypherCancelToken.Cancel();
        }

        private async Task RunCypher(String path, int chunksize, String output, byte[] key, CancellationToken cancelToken)
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
                progressBar.Invoke(new Action(() =>
                {
                    progressBar.Maximum = (int)maximum + 1;
                }));
                int bytesRead;
                long currentBytesRemaining = fullsize;
                // Current Buffer prevents from creating a file bigger than the original
                long currentBuffer;
                int i;
                var buffer = new byte[chunksize];

                //Task updateVideo = DelayUpdateVideoURL(output, 5000);

                while ((bytesRead = fs.Read(buffer, 0, chunksize <= currentBytesRemaining ? chunksize : (int)currentBytesRemaining)) > 0)
                {
                    currentBuffer = chunksize <= currentBytesRemaining ? chunksize : (int)currentBytesRemaining;
                    for (i = 0; i < chunksize && currentBuffer > 0; i++)
                    {
                        fw.WriteByte((byte)(buffer[i] ^ key[i % key.Length]));
                        currentBuffer--;
                        cancelToken.ThrowIfCancellationRequested();
                    }
                    currentBytesRemaining -= chunksize <= currentBytesRemaining ? chunksize : (int)currentBytesRemaining;
                    progressBar.Invoke(new Action(() =>
                    {
                        progressBar.PerformStep();
                    }));
                }

            }
            progressBar.Invoke(new Action(() =>
            {
                progressBar.Value = 0;
            }));
            Task updateVideo = DelayUpdateVideoURL(output, 0);
        }

        private async Task DelayUpdateVideoURL(String url, int delay)
        {
            await Task.Delay(delay);
            mediaPlayer.URL = url;
        }
    }
}
