using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using FileManagerProject.Model;
using FileManagerProject.ViewModel;

namespace FileManagerProject {
    public partial class MainForm : XtraForm {
        FileObjectCollectionViewModel mainViewModel;
        public MainForm() {
            InitializeComponent();
            InitMainViewModel();
            InitFileViewModel();
        }
        void InitFileViewModel() {
            var fileViewModel = mvvmContext2.GetViewModel<FileObjectViewModel>();
            var fluentAPI = mvvmContext2.OfType<FileObjectViewModel>();
            fluentAPI.SetObjectDataSourceBinding(fileObjectBindingSource, x => x.File, x => x.Update());
        }
        void InitMainViewModel() {
            mainViewModel = mvvmContext1.GetViewModel<FileObjectCollectionViewModel>();
            mainViewModel.Path = @"c:\";
            var fluentAPI = mvvmContext1.OfType<FileObjectCollectionViewModel>();
            fluentAPI.SetBinding(gridControl1, gControl => gControl.DataSource, x => x.Files);
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView1, "FocusedRowObjectChanged")
             .SetBinding(x => x.SelectedFile, args => args.Row as FileObject, null);
            }
    }
}
