using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class FileUpload
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FullFilePath { get; set; }
        public string Owner { get; set; }
        public string FileType { get; set; }
        public int Size { get; set; }
        public bool IsImage { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime? Expires { get; set; } = null;

    }
}
