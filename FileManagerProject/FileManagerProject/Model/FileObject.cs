using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerProject.Model {
    public class FileObject {
        public string Name { get; set; }
        public long Size { get; set; }
        public string Ext { get; set; }
        public DateTime Date { get; set; }
    }
}
