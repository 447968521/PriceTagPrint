namespace PriceTagPrint
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnPrintMsg = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnRef = new DevExpress.XtraEditors.SimpleButton();
            this.cmbGroup = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dgv = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnPrintMsg);
            this.groupPanel1.Controls.Add(this.btnPrint);
            this.groupPanel1.Controls.Add(this.btnRef);
            this.groupPanel1.Controls.Add(this.cmbGroup);
            this.groupPanel1.Controls.Add(this.labelControl1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(747, 46);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel1.TabIndex = 2;
            // 
            // btnPrintMsg
            // 
            this.btnPrintMsg.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomLeft;
            this.btnPrintMsg.Location = new System.Drawing.Point(361, 4);
            this.btnPrintMsg.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintMsg.Name = "btnPrintMsg";
            this.btnPrintMsg.Size = new System.Drawing.Size(73, 30);
            this.btnPrintMsg.TabIndex = 4;
            this.btnPrintMsg.Text = "打印消息";
            this.btnPrintMsg.Click += new System.EventHandler(this.btnPrintMsg_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(264, 5);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(73, 30);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRef
            // 
            this.btnRef.Image = ((System.Drawing.Image)(resources.GetObject("btnRef.Image")));
            this.btnRef.Location = new System.Drawing.Point(167, 4);
            this.btnRef.Margin = new System.Windows.Forms.Padding(2);
            this.btnRef.Name = "btnRef";
            this.btnRef.Size = new System.Drawing.Size(73, 30);
            this.btnRef.TabIndex = 2;
            this.btnRef.Text = "刷新";
            this.btnRef.Click += new System.EventHandler(this.btnRef_Click);
            // 
            // cmbGroup
            // 
            this.cmbGroup.Location = new System.Drawing.Point(49, 10);
            this.cmbGroup.Margin = new System.Windows.Forms.Padding(2);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbGroup.Properties.DisplayMember = "品类组名";
            this.cmbGroup.Properties.DropDownRows = 14;
            this.cmbGroup.Properties.ValueMember = "品类组号";
            this.cmbGroup.Size = new System.Drawing.Size(105, 20);
            this.cmbGroup.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 12);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "品类组";
            // 
            // dgv
            // 
            this.dgv.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.dgv.Location = new System.Drawing.Point(0, 46);
            this.dgv.MainView = this.gridView1;
            this.dgv.Margin = new System.Windows.Forms.Padding(2);
            this.dgv.Name = "dgv";
            this.dgv.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2});
            this.dgv.Size = new System.Drawing.Size(747, 309);
            this.dgv.TabIndex = 3;
            this.dgv.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.check,
            this.col10,
            this.col1,
            this.col2,
            this.col8,
            this.col9,
            this.col3,
            this.col4,
            this.col5,
            this.col6,
            this.col7});
            this.gridView1.GridControl = this.dgv;
            this.gridView1.Name = "gridView1";
            // 
            // check
            // 
            this.check.Caption = "chk";
            this.check.ColumnEdit = this.repositoryItemCheckEdit2;
            this.check.FieldName = "chk";
            this.check.Name = "check";
            this.check.Visible = true;
            this.check.VisibleIndex = 0;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Caption = "Check";
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // col10
            // 
            this.col10.Caption = "提货单号";
            this.col10.FieldName = "提货单号";
            this.col10.Name = "col10";
            this.col10.Visible = true;
            this.col10.VisibleIndex = 1;
            // 
            // col1
            // 
            this.col1.Caption = "日期";
            this.col1.FieldName = "日期";
            this.col1.Name = "col1";
            this.col1.Visible = true;
            this.col1.VisibleIndex = 2;
            // 
            // col2
            // 
            this.col2.Caption = "时间";
            this.col2.FieldName = "时间";
            this.col2.Name = "col2";
            this.col2.Visible = true;
            this.col2.VisibleIndex = 3;
            // 
            // col8
            // 
            this.col8.Caption = "商品名称";
            this.col8.FieldName = "商品名称";
            this.col8.Name = "col8";
            this.col8.Visible = true;
            this.col8.VisibleIndex = 4;
            // 
            // col9
            // 
            this.col9.Caption = "商品编号";
            this.col9.FieldName = "商品编号";
            this.col9.Name = "col9";
            this.col9.Visible = true;
            this.col9.VisibleIndex = 5;
            // 
            // col3
            // 
            this.col3.Caption = "条码";
            this.col3.FieldName = "条码";
            this.col3.Name = "col3";
            this.col3.Visible = true;
            this.col3.VisibleIndex = 6;
            // 
            // col4
            // 
            this.col4.Caption = "库存";
            this.col4.FieldName = "库存";
            this.col4.Name = "col4";
            this.col4.Visible = true;
            this.col4.VisibleIndex = 7;
            // 
            // col5
            // 
            this.col5.Caption = "箱规";
            this.col5.FieldName = "箱规";
            this.col5.Name = "col5";
            this.col5.Visible = true;
            this.col5.VisibleIndex = 8;
            // 
            // col6
            // 
            this.col6.Caption = "补货数量";
            this.col6.FieldName = "补货数量";
            this.col6.Name = "col6";
            this.col6.Visible = true;
            this.col6.VisibleIndex = 9;
            // 
            // col7
            // 
            this.col7.Caption = "是否打印";
            this.col7.FieldName = "是否打印";
            this.col7.Name = "col7";
            this.col7.Visible = true;
            this.col7.VisibleIndex = 10;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 355);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.groupPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提货单";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevExpress.XtraEditors.LookUpEdit cmbGroup;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl dgv;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraGrid.Columns.GridColumn col1;
        private DevExpress.XtraGrid.Columns.GridColumn col2;
        private DevExpress.XtraGrid.Columns.GridColumn col3;
        private DevExpress.XtraGrid.Columns.GridColumn col4;
        private DevExpress.XtraGrid.Columns.GridColumn col5;
        private DevExpress.XtraGrid.Columns.GridColumn col6;
        private DevExpress.XtraGrid.Columns.GridColumn col7;
        private DevExpress.XtraEditors.SimpleButton btnRef;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraGrid.Columns.GridColumn col8;
        private DevExpress.XtraGrid.Columns.GridColumn col9;
        private DevExpress.XtraGrid.Columns.GridColumn col10;
        private DevExpress.XtraEditors.SimpleButton btnPrintMsg;
        private DevExpress.XtraGrid.Columns.GridColumn check;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
    }
}

