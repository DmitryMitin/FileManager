using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using FileManagerProject.Data;
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
            Path = CurrentDirectory.Parent.FullName;
        }
        public virtual bool CanBack() {
            return CurrentDirectory != null && CurrentDirectory.Parent != null;
        }
        object lockObject = new object();
        protected void AddFiles(List<FileObject> files) {
            Files.RaiseListChangedEvents = false;
            foreach(var item in files) {
                Files.Add(item);
            }
            List<FileObject> sortedList = Files.OrderBy(x => x.Name).OrderByDescending(x => x.FileInfo == null).ToList();
            Files = new BindingList<FileObject>(sortedList);
            Files.RaiseListChangedEvents = true;
            Files.ResetBindings();
        }
        protected void OnPathChanged() {
            if(Directory.Exists(Path)) {
                Files = new BindingList<FileObject>();
                CurrentDirectory = new DirectoryInfo(Path);
                AddBackItem();
                DataLoader.GetDataAsync(Path, AddFiles);
            }
        }
        void AddBackItem() {
            if(CanBack()) {
                Files.Add(new DirectoryObject()
                {
                    Name = "...",
                    DirectoryInfo = CurrentDirectory.Parent,
                    Date = CurrentDirectory.Parent.CreationTime,
                    Ext = "[DIR]"
                });
            }
        }
    }
}
