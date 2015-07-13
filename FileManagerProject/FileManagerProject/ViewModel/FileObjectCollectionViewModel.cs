using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm.DataAnnotations;
using FileManagerProject.Model;

namespace FileManagerProject.ViewModel {
    public class FileObjectCollectionViewModel {
        public virtual BindingList<FileObject> Files { get; set; }
        public virtual string Path { get; set; }
        protected void OnPathChanged() {
            Files = new BindingList<FileObject>();
            if(Directory.Exists(Path)) {
                var directories  =  Directory.GetDirectories(Path);
                foreach(var item in directories) {
                    Files.Add(new FileObject() { Name = item });
                }
                var files = Directory.GetFiles(Path);
                foreach(var item in files) {
                    Files.Add(new FileObject() { Name = item });
                }
            }
        }
    }
}
