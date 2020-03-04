using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitQuiz.Examples
{
    public class AsynchronousOperations
    {
        public Task<byte[]> DownloadImageAsync(string url)
        {
            var client = new HttpClient();
            return client.GetByteArrayAsync(url);
        }

        public async Task SaveImageAsync(byte[] bytes, string imagePath)
        {
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await fileStream.WriteAsync(bytes, 0, bytes.Length);
            }
        }
    }
}
