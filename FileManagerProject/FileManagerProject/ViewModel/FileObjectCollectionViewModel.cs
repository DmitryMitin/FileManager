using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using FileManagerProject.Model;

namespace FileManagerProject.ViewModel {
    public class FileObjectCollectionViewModel {
        public virtual DirectoryInfo CurrentDirectory { get; set; }
        public virtual BindingList<FileObject> Files { get; set; }
        public virtual string Path { get; set; }
        public virtual FileObject SelectedFile { get; set; }
        protected void OnSelectedFileChanged() {
            Messenger.Default.Send(SelectedFile);
        }
        public virtual void Open(FileObject file) {
            Process.Start(file.FileInfo.FullName);
        }
        public virtual bool CanOpen(FileObject file) {
            return !(file is DirectoryObject);
        }
        public virtual void Forward(FileObject file) {
            DirectoryObject directory = file as DirectoryObject;
            Path = directory.DirectoryInfo.FullName;
        }
        public virtual bool CanForward(FileObject file) {
            return file is DirectoryObject;
        }
        public virtual void Back() {
            if(CurrentDirectory != null && CurrentDirectory.Parent != null) { 
                Path = CurrentDirectory.Parent.FullName;
            }
        }
        public virtual bool CanBack() {
            return CurrentDirectory != null && CurrentDirectory.Parent != null;
        }
        protected void OnPathChanged() {
            if(Directory.Exists(Path)) {
                Files = new BindingList<FileObject>();
                CurrentDirectory = new DirectoryInfo(Path);
                if(CanBack()) {
                    Files.Add(new DirectoryObject()
                    {
                        Name = "...",
                        DirectoryInfo = CurrentDirectory.Parent,
                        Date = CurrentDirectory.Parent.CreationTime,
                        Ext = "[DIR]"
                    });
                }
                var directories = Directory.GetDirectories(Path);
                foreach(var item in directories) {
                    DirectoryInfo info = new DirectoryInfo(item);
                    Files.Add(new DirectoryObject()
                    {
                        Name = System.IO.Path.GetFileName(item),
                        Ext = "[DIR]",
                        Date = info.CreationTime,
                        DirectoryInfo = info
                    });
                }
                var files = Directory.GetFiles(Path);
                foreach(var item in files) {
                    FileInfo info = new FileInfo(item);
                    Files.Add(new FileObject()
                    {
                        Name = System.IO.Path.GetFileNameWithoutExtension(info.Name),
                        Ext = info.Extension,
                        Size = info.Length,
                        Date = info.CreationTime,
                        FileInfo = info
                    });
                }
            }
        }
    }
}
