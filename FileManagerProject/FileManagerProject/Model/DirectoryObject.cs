using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileManagerProject.Model {
    public class DirectoryObject : FileObject {
        public DirectoryInfo DirectoryInfo { get; set; }
    }
}
