using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using DevExpress.Mvvm;
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
            if(FilterExt == null) FilterExt = new List<string>();
            if(value)
                FilterExt.Add(filter);
            else
                FilterExt.Remove(filter);
            FilesFiltered = GetFilesFiltered();
        }
        BindingList<FileObject> GetFilesFiltered() {
            if(Files == null) return null;
            string filter = string.Empty;
            foreach(string f in FilterExt)
                filter += f;
            if(string.IsNullOrEmpty(filter)) return Files;
            BindingList<FileObject> filteredFiles = new BindingList<FileObject>();
            foreach(FileObject file in Files) {
                if(filter.Contains(file.Ext))
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
            if(directory.DirectoryInfo == null)
                Path = string.Empty;
            else
                Path = directory.DirectoryInfo.FullName;
        }
        public virtual bool CanForward(FileObject file) {
            return file is DirectoryObject;
        }
        public virtual void Back() {
            Path = CurrentDirectory.Parent.FullName;
        }
        public virtual bool CanBack() {
            return CurrentDirectory != null && (CurrentDirectory.Parent != null || CurrentDirectory.Root.Name == CurrentDirectory.Name);
        }
        object lockObject = new object();
        protected void AddFiles(List<FileObject> files) {
            Files.RaiseListChangedEvents = false;
            foreach(var item in files) {
                Files.Add(item);
            }
            List<FileObject> sortedList = Files.OrderBy(x => x.Name).OrderByDescending(x => x.FileInfo == null).ToList();
            Files = new BindingList<FileObject>(sortedList);
            FilesFiltered = new BindingList<FileObject>(Files);
            Files.RaiseListChangedEvents = true;
            Files.ResetBindings();
        }
        protected void OnPathChanged() {
            LoadData();
        }
        public void LoadData() {
            Files = new BindingList<FileObject>();
            if(Directory.Exists(Path)) {
                CurrentDirectory = new DirectoryInfo(Path);
                AddBackItem();
                DataLoader.GetDataAsync(Path, AddFiles);
            }
            else {
                var items = Directory.GetLogicalDrives();
                foreach(var item in items) {
                    Files.Add(new DirectoryObject()
                    {
                        Name = item,
                        DirectoryInfo = new DirectoryInfo(item)
                    });

                }
            }
        }
        void AddBackItem() {
            if(CanBack()) {
                Files.Add(new DirectoryObject()
                {
                    Name = "...",
                    DirectoryInfo = CurrentDirectory.Parent,
                    Date = CurrentDirectory.Parent != null ? CurrentDirectory.Parent.CreationTime : new DateTime(2010, 1, 1),
                    Ext = "[DIR]"
                });
            }
        }
    }
}
