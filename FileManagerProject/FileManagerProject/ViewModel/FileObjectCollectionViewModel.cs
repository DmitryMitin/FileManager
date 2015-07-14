using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using FileManagerProject.Model;

namespace FileManagerProject.ViewModel {
    public class FileObjectCollectionViewModel {
        public virtual BindingList<FileObject> Files { get; set; }
        public virtual string Path { get; set; }
        public virtual FileObject SelectedFile { get; set; }
        protected void OnSelectedFileChanged() {
            Messenger.Default.Send(SelectedFile);
        }
        protected void OnPathChanged() {
            Files = new BindingList<FileObject>();
            if(Directory.Exists(Path)) {
                var directories = Directory.GetDirectories(Path);
                foreach(var item in directories) {
                    Files.Add(new FileObject() { Name = item });
                }
                var files = Directory.GetFiles(Path);
                foreach(var item in files) {
                    FileInfo info = new FileInfo(item);
                    Files.Add(new FileObject()
                    {
                        Name = System.IO.Path.GetFileNameWithoutExtension(info.Name),
                        Ext = info.Extension,
                        Size = info.Length,
                        Date = info.CreationTime
                    });
                }
            }
        }
    }
}
