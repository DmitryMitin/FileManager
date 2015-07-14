using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using FileManagerProject.Model;

namespace FileManagerProject.ViewModel {
    public class FileObjectViewModel {
        public FileObjectViewModel() {
            RegisterAsFileObjectMessageRecepient();
        }
        public virtual FileObject File { get; set; }
        public virtual void Update() { }
        public void RegisterAsFileObjectMessageRecepient() {
            Messenger.Default.Register<FileObject>(this, OnFileMessage);
        }
        protected void OnFileMessage(FileObject file) {
            File = file;
        }
    }
}
