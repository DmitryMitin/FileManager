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
        public virtual BindingList<FileObject> FilesFiltered { get; set; }
        public virtual bool FilterCS { get; set; }
        public virtual bool FilterVB { get; set; }
        public virtual List<string> FilterExt { get; set; }
        public virtual string Path { get; set; }
        public virtual FileObject SelectedFile { get; set; }
        protected void OnSelectedFileChanged() {
            Messenger.Default.Send(SelectedFile);
        }
        protected void OnFilterCSChanged() {
            OnFilterChanged(FilterCS, ".cs");
        }
        protected void OnFilterVBChanged() {
            OnFilterChanged(FilterVB, ".vb");
        }
        void OnFilterChanged(bool value, string filter) {
            if (FilterExt == null) FilterExt = new List<string>();
            if (value)
                FilterExt.Add(filter);
            else
                FilterExt.Remove(filter);
            FilesFiltered = GetFilesFiltered();
        }
        BindingList<FileObject> GetFilesFiltered() {
            if (Files == null) return null;
            string filter = string.Empty;
            foreach (string f in FilterExt)
                filter += f;
            if (string.IsNullOrEmpty(filter)) return Files;
            BindingList<FileObject> filteredFiles = new BindingList<FileObject>();
            foreach (FileObject file in Files) {
                if (filter.Contains(file.Ext))
                    filteredFiles.Add(file);
            }
            return filteredFiles;
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
<<<<<<< HEAD
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
                FilesFiltered = new BindingList<FileObject>(Files);
            }            
=======
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
>>>>>>> 162ae867b1c5f6a25853e4b07ef065cb830678dd
        }
    }
}
