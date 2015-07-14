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
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;

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
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            mainViewModel.Path = @"C:\Code";
        }
        void InitMainViewModel() {
            mainViewModel = mvvmContext1.GetViewModel<FileObjectCollectionViewModel>();
            //mainViewModel.LoadData();
            

            var fluentAPI = mvvmContext1.OfType<FileObjectCollectionViewModel>();            

            fluentAPI.SetBinding(gridControl1, gControl => gControl.DataSource, x => x.Files);
            fluentAPI.SetBinding(barCheckItem1, cItem1 => cItem1.Checked, x => x.FilterCS);
            fluentAPI.SetBinding(barCheckItem2, cItem2 => cItem2.Checked, x => x.FilterVB);

            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView1, "FocusedRowObjectChanged")
             .SetBinding(x => x.SelectedFile, args => args.Row as FileObject, (view, entity) => view.FocusedRowHandle = view.FindRow(entity));

            fluentAPI.WithEvent<KeyEventArgs>(gridView1, "KeyDown").EventToCommand(x => x.Open(null), x => x.SelectedFile, e => e.KeyCode == Keys.Enter);
            fluentAPI.WithEvent<KeyEventArgs>(gridView1, "KeyDown").EventToCommand(x => x.Forward(null), x => x.SelectedFile, e => e.KeyCode == Keys.Enter);

            fluentAPI.WithEvent<KeyEventArgs>(gridView1, "KeyDown").EventToCommand(x => x.Back(), x => x.SelectedFile, e => e.KeyCode == Keys.Back);

            fluentAPI.WithEvent<DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs>(gridView1, "RowCellClick")
                .EventToCommand(x => x.Open(null), x => x.SelectedFile,
                args => (args.Clicks == 2) && (args.Button == MouseButtons.Left));
            fluentAPI.WithEvent<DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs>(gridView1, "RowCellClick")
                .EventToCommand(x => x.Forward(null), x => x.SelectedFile,
                args => (args.Clicks == 2) && (args.Button == MouseButtons.Left));
        }
    }
}
