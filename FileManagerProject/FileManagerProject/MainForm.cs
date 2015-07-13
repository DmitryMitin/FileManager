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
using FileManagerProject.ViewModel;

namespace FileManagerProject {
    public partial class MainForm : XtraForm {
        public MainForm() {
            InitializeComponent();
            var viewModel = mvvmContext1.GetViewModel<FileObjectCollectionViewModel>();
            viewModel.Path = @"c:\";
            var fluentAPI = mvvmContext1.OfType<FileObjectCollectionViewModel>();
            fluentAPI.SetBinding(gridControl1, gControl => gControl.DataSource, x => x.Files);
        }
    }
}
