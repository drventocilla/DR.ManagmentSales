using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Core.Archivos
{
   public static class FIleCompression
    {
        public static MemoryStream Compress(this List<ExportObject> files)
        {
            if (files.Any())
            {
                var ms = new MemoryStream();
                using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, leaveOpen: true))
                {
                    foreach (var file in files)
                    {
                        var entry = archive.add(file);
                    }
                }
                ms.Position = 0;
                return ms;
            }
            return null;
        }

        private static ZipArchiveEntry add(this ZipArchive archive, ExportObject file)
        {
            var entry = archive.CreateEntry(file.fileName, CompressionLevel.Fastest);

            using (var originalFileStream = new MemoryStream(file.ms))
            {
                using (var stream = entry.Open())
                {

                    originalFileStream.CopyTo(stream);
                }
            }

            return entry;
        }
    }
}
