using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chsakell_SPA.Infrastructure.core
{
    public class FileUploadResult
    {
        public string LocalFilePath { get; set; }
        public string FileName { get; set; }
        public long FileLength { get; set; }
    }
}