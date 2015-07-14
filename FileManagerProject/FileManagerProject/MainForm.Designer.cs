namespace FileManagerProject {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.mvvmContext2 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.NameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.fileObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SizeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ExtTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSize = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForExt = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDate = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileObjectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExtTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForExt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDate)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(749, 428);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colSize,
            this.colExt,
            this.colDate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colSize
            // 
            this.colSize.FieldName = "Size";
            this.colSize.Name = "colSize";
            this.colSize.Visible = true;
            this.colSize.VisibleIndex = 1;
            // 
            // colExt
            // 
            this.colExt.FieldName = "Ext";
            this.colExt.Name = "colExt";
            this.colExt.Visible = true;
            this.colExt.VisibleIndex = 2;
            // 
            // colDate
            // 
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 3;
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            this.mvvmContext1.ViewModelType = typeof(FileManagerProject.ViewModel.FileObjectCollectionViewModel);
            // 
            // mvvmContext2
            // 
            this.mvvmContext2.ContainerControl = this;
            this.mvvmContext2.ViewModelType = typeof(FileManagerProject.ViewModel.FileObjectViewModel);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.NameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.SizeTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ExtTextEdit);
            this.dataLayoutControl1.Controls.Add(this.DateDateEdit);
            this.dataLayoutControl1.DataSource = this.fileObjectBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataLayoutControl1.Location = new System.Drawing.Point(749, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(284, 428);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // NameTextEdit
            // 
            this.NameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.fileObjectBindingSource, "Name", true));
            this.NameTextEdit.Location = new System.Drawing.Point(42, 12);
            this.NameTextEdit.Name = "NameTextEdit";
            this.NameTextEdit.Size = new System.Drawing.Size(230, 20);
            this.NameTextEdit.StyleController = this.dataLayoutControl1;
            this.NameTextEdit.TabIndex = 4;
            // 
            // fileObjectBindingSource
            // 
            this.fileObjectBindingSource.DataSource = typeof(FileManagerProject.Model.FileObject);
            // 
            // SizeTextEdit
            // 
            this.SizeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.fileObjectBindingSource, "Size", true));
            this.SizeTextEdit.Location = new System.Drawing.Point(42, 36);
            this.SizeTextEdit.Name = "SizeTextEdit";
            this.SizeTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.SizeTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.SizeTextEdit.Properties.Mask.EditMask = "N0";
            this.SizeTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.SizeTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.SizeTextEdit.Size = new System.Drawing.Size(230, 20);
            this.SizeTextEdit.StyleController = this.dataLayoutControl1;
            this.SizeTextEdit.TabIndex = 5;
            // 
            // ExtTextEdit
            // 
            this.ExtTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.fileObjectBindingSource, "Ext", true));
            this.ExtTextEdit.Location = new System.Drawing.Point(42, 60);
            this.ExtTextEdit.Name = "ExtTextEdit";
            this.ExtTextEdit.Size = new System.Drawing.Size(230, 20);
            this.ExtTextEdit.StyleController = this.dataLayoutControl1;
            this.ExtTextEdit.TabIndex = 6;
            // 
            // DateDateEdit
            // 
            this.DateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.fileObjectBindingSource, "Date", true));
            this.DateDateEdit.EditValue = null;
            this.DateDateEdit.Location = new System.Drawing.Point(42, 84);
            this.DateDateEdit.Name = "DateDateEdit";
            this.DateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateDateEdit.Size = new System.Drawing.Size(230, 20);
            this.DateDateEdit.StyleController = this.dataLayoutControl1;
            this.DateDateEdit.TabIndex = 7;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(284, 428);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForName,
            this.ItemForSize,
            this.ItemForExt,
            this.ItemForDate});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(264, 408);
            // 
            // ItemForName
            // 
            this.ItemForName.Control = this.NameTextEdit;
            this.ItemForName.Location = new System.Drawing.Point(0, 0);
            this.ItemForName.Name = "ItemForName";
            this.ItemForName.Size = new System.Drawing.Size(264, 24);
            this.ItemForName.Text = "Name";
            this.ItemForName.TextSize = new System.Drawing.Size(27, 13);
            // 
            // ItemForSize
            // 
            this.ItemForSize.Control = this.SizeTextEdit;
            this.ItemForSize.Location = new System.Drawing.Point(0, 24);
            this.ItemForSize.Name = "ItemForSize";
            this.ItemForSize.Size = new System.Drawing.Size(264, 24);
            this.ItemForSize.Text = "Size";
            this.ItemForSize.TextSize = new System.Drawing.Size(27, 13);
            // 
            // ItemForExt
            // 
            this.ItemForExt.Control = this.ExtTextEdit;
            this.ItemForExt.Location = new System.Drawing.Point(0, 48);
            this.ItemForExt.Name = "ItemForExt";
            this.ItemForExt.Size = new System.Drawing.Size(264, 24);
            this.ItemForExt.Text = "Ext";
            this.ItemForExt.TextSize = new System.Drawing.Size(27, 13);
            // 
            // ItemForDate
            // 
            this.ItemForDate.Control = this.DateDateEdit;
            this.ItemForDate.Location = new System.Drawing.Point(0, 72);
            this.ItemForDate.Name = "ItemForDate";
            this.ItemForDate.Size = new System.Drawing.Size(264, 336);
            this.ItemForDate.Text = "Date";
            this.ItemForDate.TextSize = new System.Drawing.Size(27, 13);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 428);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileObjectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExtTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForExt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext2;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.TextEdit NameTextEdit;
        private System.Windows.Forms.BindingSource fileObjectBindingSource;
        private DevExpress.XtraEditors.TextEdit SizeTextEdit;
        private DevExpress.XtraEditors.TextEdit ExtTextEdit;
        private DevExpress.XtraEditors.DateEdit DateDateEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSize;
        private DevExpress.XtraLayout.LayoutControlItem ItemForExt;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDate;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colSize;
        private DevExpress.XtraGrid.Columns.GridColumn colExt;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
    }
}