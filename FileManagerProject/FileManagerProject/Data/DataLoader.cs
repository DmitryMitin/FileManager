using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FileManagerProject.Model;

namespace FileManagerProject.Data {
    public static class DataLoader {
        public static void GetDataAsync(string path, Action<List<FileObject>> callback, string searchPattern = "*") {
            var taksGetDirectories = Task.Factory.StartNew<List<FileObject>>( () => GetDirectories(path));
            var taksGetFiles = Task.Factory.StartNew<List<FileObject>>(() => GetFiles(path, searchPattern));
            taksGetDirectories.ContinueWith(tasks => callback(taksGetDirectories.Result), TaskScheduler.FromCurrentSynchronizationContext());
            taksGetFiles.ContinueWith(tasks => callback(taksGetFiles.Result), TaskScheduler.FromCurrentSynchronizationContext());
        }
        public static List<FileObject> GetFiles(string path, string searchPattern) {
            var files = Directory.GetFiles(path, searchPattern);
            List<FileObject> result = new List<FileObject>();
            foreach(var item in files) {
                FileInfo info = new FileInfo(item);
                result.Add(new FileObject()
                {
                    Name = System.IO.Path.GetFileNameWithoutExtension(info.Name),
                    Ext = info.Extension,
                    Size = info.Length,
                    Date = info.CreationTime,
                    FileInfo = info

                });
            }
            return result;
        }
        public static List<FileObject> GetDirectories(string path) {
            var directories = Directory.GetDirectories(path);
            List<FileObject> result = new List<FileObject>();
            foreach(var item in directories) {
                DirectoryInfo info = new DirectoryInfo(item);
                result.Add(new DirectoryObject()
                {
                    Name = System.IO.Path.GetFileName(item),
                    Ext = "[DIR]",
                    Date = info.CreationTime,
                    DirectoryInfo = info
                });
            }
            return result;
        }
    }

}
