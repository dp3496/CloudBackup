using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace CloudBackup.Library.Util
{
    public static class StreamExtensions
    {
        public static async Task<Stream> ConvertToStream(this IRandomAccessStreamWithContentType fStream)
        {
            var reader = new DataReader(fStream.GetInputStreamAt(0));
            var bytes = new byte[fStream.Size];
            await reader.LoadAsync((uint)fStream.Size);
            reader.ReadBytes(bytes);

            return new MemoryStream(bytes);
        }
    }
}
