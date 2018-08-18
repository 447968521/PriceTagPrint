using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PriceTagPrint.Util;

namespace PriceTagPrint
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        #region API
		//获取 SDK 版本号
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_GetSDKVersion(byte[] ListFilePath);
		//获取 SDK 支持的打印机类型
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_GetSupportPrinters(byte[] lpPrinters, Int32 len);
		//连接打印机
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_ConnectDevices(string prtName, String port, int timeout);
		//关闭打印机
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_CloseDevices(int objCode);
		//查询打印机状态
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_QueryStatus(int objCode);
		//查询打印状态
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_QueryPrintStatus(int objCode, int timeout);
		//开启打印模式，任何打印模式都需要调用该方法
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_PageStart(int objCode, bool graphicMode, int width, int height);
		//缓存图像和文本数据
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_PageEnd(int objCode, int tm);
		//黑标检测
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 ASCII_CtrlBlackMark(int objCode);
        //设置打印模式
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 ASCII_CtrlFormatString(int objCode, bool bFont, bool bThick, bool bExWidth, bool bExHeight, bool bUnderLine);
		//打印文本
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 ASCII_PrintText(int objCode, string szText);
		//发送打印数据
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 ASCII_Print1DBarcode(int objCode, int bcType, int iWidth, int iHeight, int hri, string strData);
		//打印二维条码
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 ASCII_Print2DBarcode(int objCode, int type2D, string strPrint, int version, int ecc, int size);
		//选择切刀模式并切纸
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 ASCII_CtrlCutPaper(int objCode, int cutWay, int postion);
		//缓存数据的发送，发送完并清除缓存
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_PageSend(int objCode);
		//打印文件
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_PrintFile(int objCode, string szPath);
		//位图打印处理函数
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_PrintBMPBuffer(int objCode, int width, int height, byte[] buffer);
		//查询固件版本
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_QueryPrinterFirmware(int objCode, byte[] szFirmware, int len);
		//开始记录
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_StartRecord(string path);
		//结束记录
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_EndRecord();
		//通过端口直接 IO 操作
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_DirectIO(int iObjcode, byte[] btIn, out int inPut, byte[] btOut, out int outPut);
        //标签打印CPCL
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CPCL_PageStart(int objCode, int width, int height, int padLeft, int preFeed);
		//打印字符串
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CPCL_PrintText(int objCode, int x, int y, int width, int height, int rotate, int font, string lpString);
		//打印
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CPCL_PageEnd(int objCode, int tm, int postFeed);
		//画线命令
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CPCL_Line(int iObjCode, int x0, int y0, int x1, int y1, int width);
		//画矩形命令
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CPCL_Rectangle(int iObjCode, int x0, int y0, int x1, int y1, int width);
		//字符串格式
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]        
        public static extern Int32 CPCL_FormatString(int iObjCode, int bold, int inverse, int underline);
		//标签打印机专用 API
		//设置字符间距属性
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CPCL_FontSpace(int objCode, int space);
		//打印一维条码
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CPCL_Print1DBarcode(int objCode, int x, int y, int width, int ratio, int height, string strType, string strPrint);
		//打印二维条码
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CPCL_Print2DBarcode(int objCode, int type2D, int x, int y, int version, int ecc, int size, string strPrint);

        //图像函数
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 DRAW_PrintText(int objCode, int x, int y, string text, int fntWidth, int fntHeight, string fntName);
		//绘制 QR 码
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 DRAW_QRPrint(int objCode, int x, int y, int nLevel, int nVersion, string szText, int scale);
		//绘制 128 码打印
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 DRAW_Code128Print(int objCode, int x, int y, int width, int height, string szText);
		//设置字体打印模式
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 DRAW_SetFont(int objCode, int width, int height, bool bold, bool italic, bool underline, string fntName);
		//绘制文本
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 DRAW_PrintText2(int objCode, int x, int y, string text);
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 DRAW_PrintBmp(int objCode, int x, int y, string pszPath);
        #endregion
        void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            CheckState check = (sender as DevExpress.XtraEditors.CheckEdit).CheckState;
            if (check == CheckState.Checked)
            {
                var chk = (CheckEdit)sender;
                chk.Checked = true;

            }
        }
        #region GridControl 全选

        /// <summary>
        /// 是否选中
        /// </summary>
        private static bool chkState = false;

        //复选框列名称
        private static string chkFileName = "chk";
        //复选框列宽
        private static int chkWidth = 30;
        //GridView 
        public static DevExpress.XtraGrid.Views.Grid.GridView GView = null;

        private DevExpress.XtraGrid.Views.Grid.GridView gView
        {
            get
            {
                if (GView == null)
                {
                    GView = new DevExpress.XtraGrid.Views.Grid.GridView();
                }
                return GView;
            }
            set { this.gView = value; }
        }

        public void GridCheckEdit(DevExpress.XtraGrid.Views.Grid.GridView gv, string checkFileName, int checkWidth)
        {
            if (gv != null)
            {
                chkFileName = checkFileName;
                chkWidth = checkWidth;
                GView = gv;
                //不显示复选框的列标题
                gv.Columns[chkFileName].OptionsColumn.ShowCaption = false;

                //复选框的形状   gv.Columns[chkFileName].ColumnEdit 实例是 repositoryItemCheckEdit1              
                //repositoryItemCheckEdit1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
                ////复选框加载的状态     实心   空心   空心打勾
                repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
                //点击事件
                gv.Click += new System.EventHandler(gv_Click);
                //画列头CheckEdit
                gv.CustomDrawColumnHeader +=
                    new DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventHandler(gv_CustomDrawColumnHeader);
                gv.DataSourceChanged += new EventHandler(gv_DataSourceChanged);

            }
        }

        private void gv_Click(object sender, EventArgs e)
        {
            if (ClickGridCheckBox(GView, chkFileName, chkState))
            {
                chkState = !chkState;

            }
        }

        private void gv_CustomDrawColumnHeader(object sender,
            DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == chkFileName)
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e, chkState);
                e.Handled = true;
            }
        }

        private void gv_DataSourceChanged(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Columns.GridColumn column = GView.Columns.ColumnByFieldName(chkFileName);
            if (column != null)
            {
                column.Width = chkWidth;
                column.OptionsColumn.ShowCaption = false;
                column.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            }
        }

        private void DrawCheckBox(DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e, bool chk)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryCheck =
                e.Column.ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit;
            if (repositoryCheck != null)
            {
                System.Drawing.Graphics g = e.Graphics;
                System.Drawing.Rectangle r = e.Bounds;

                DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
                DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
                DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;
                info = repositoryCheck.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;

                painter = repositoryCheck.CreatePainter() as DevExpress.XtraEditors.Drawing.CheckEditPainter;
                info.EditValue = chk;
                info.Bounds = r;
                info.CalcViewInfo(g);
                args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info,
                    new DevExpress.Utils.Drawing.GraphicsCache(g), r);
                painter.Draw(args);
                args.Cache.Dispose();
            }
        }

        private bool ClickGridCheckBox(DevExpress.XtraGrid.Views.Grid.GridView gridView, string fieldName,
            bool currentStatus)
        {
            bool result = false;
            if (gridView != null)
            {
                //禁止排序 
                gridView.ClearSorting();

                gridView.PostEditor();
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info;
                System.Drawing.Point pt = gridView.GridControl.PointToClient(Control.MousePosition);
                info = gridView.CalcHitInfo(pt);
                if (info.InColumn && info.Column != null && info.Column.FieldName == fieldName)
                {
                    for (int i = 0; i < gridView.RowCount; i++)
                    {
                        gridView.SetRowCellValue(i, fieldName, !currentStatus);
                    }

                    return true;
                }
            }
            return result;
        }

        #endregion
        private Int32 m_objID;
        private string m_strPath;

        /// <summary>
        /// 打印机列表
        /// </summary>
        public List<string> PrintList=new List<string>();
        /// <summary>
        /// 消息列表
        /// </summary>
        public List<string> msgList=new List<string>();
        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                dgv.Init(gridView1);
                gridView1.SetAutoFilterRow();
                gridView1.OptionsBehavior.Editable = true;
                gridView1.OptionsSelection.MultiSelect = true;
                gridView1.OptionsSelection.MultiSelectMode =
                    DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
                repositoryItemCheckEdit2.CheckedChanged += new EventHandler(repositoryItemCheckEdit1_CheckedChanged);

                GridCheckEdit(gridView1, chkFileName, 30);var group=new Data.GetData().GetGroups();
                cmbGroup.Properties.DataSource = group;
                if (group.Rows.Count > 0)
                {
                    cmbGroup.ItemIndex = 0;
                }
                byte[] btListFilePath = new byte[1024];
                Int32 len = CON_GetSDKVersion(btListFilePath);
                string str = Encoding.Unicode.GetString(btListFilePath, 0, (len) * 2);
                this.Text += "_" + str;

                len = CON_GetSupportPrinters(btListFilePath, 1024);
                str = Encoding.Unicode.GetString(btListFilePath, 0, (len) * 2);
                string[] strPrints = str.Split(new Char[] { ',' });
                for (int i = 0; i < strPrints.Length; ++i)
                {
                    PrintList.Add(strPrints[i]);
                }
                OpenPrint();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenPrint()
        {
            try
            {
                Int32 iRet = 0;
                //记录日志
                CON_StartRecord("Log.txt");
                var btnOpne = "Open";
                if (btnOpne == "Open")
                {
                    iRet = CON_ConnectDevices(PrintList[0], "USB", 500);
                    if (iRet > 0)
                    {
                        m_objID = iRet;
                        msgList.Add("端口打开成功");

                        byte[] btVersion = new byte[256];
                        Int32 len = CON_QueryPrinterFirmware(m_objID, btVersion, 256);
                        string str = Encoding.Unicode.GetString(btVersion, 0, (len) * 2);
                        msgList.Add(string.Format(@"【打印机状态】{0}", str));
                    }
                    else
                    {
                        MessageBox.Show("端口打开失败");
                    }
                }
                else
                {
                    msgList.Add("端口关闭");
                    btnOpne = "Close";
                    CON_CloseDevices(m_objID);
                    m_objID = 0;
                    CON_EndRecord();
                    MessageBox.Show("打印机连接失败!");}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrintMsg_Click(object sender, EventArgs e)
        {
            var msg = string.Empty;
            foreach (var p in msgList)
            {
                msg += p;
                msg += "\r\n";
            }

            MessageBox.Show(msg);}

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            if (cmbGroup.EditValue == null)
            {
                MessageBox.Show("请选择品类组!");
                return;
            }
            var groupNo = cmbGroup.EditValue.ToString();
            var dt=new Data.GetData().GetGroupItemDetail(groupNo);
            dt.Columns.Add("chk", System.Type.GetType("System.Boolean"));
            dgv.DataSource = dt;
            gridView1.BestFitColumns();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.DataSource == null)
                {
                    MessageBox.Show("未检测到数据源!");
                    return;
                }
                var dt = (DataTable)dgv.DataSource;
                var dtRow = dt.Clone();
                foreach (DataRow row1 in dt.Rows)
                {
                    if (row1["chk"].ToString().Contains("True"))
                    {
                        dtRow.ImportRow(row1);
                    }

                }
                if (dtRow.Rows.Count == 0)
                {
                    MessageBox.Show("请选择数据!");
                    return;
                }
                Int32 repeat, tick;
                string strRepeat, strErr = "", strMess;
                //重复打印次数
                strRepeat = "1";
                repeat = Convert.ToInt32(strRepeat);
                int iRet;
                bool bSucc = false;

                for (int i = 0; i < repeat; ++i)
                {
                    //是否输出日志
                    if (true)
                    {
                        CON_StartRecord("Log.txt");
                    }

                    tick = Environment.TickCount;
                    iRet = CON_PageStart(m_objID, false, 0, 0);
                    //是否黑签纸
                    //if (radioPaperBlack.Checked)
                    //    ASCII_CtrlBlackMark(m_objID);
                    

                    var printTime = dt.Rows[dt.Rows.Count - 1]["时间"].ToString();
                    ASCII_PrintText(m_objID, "补货单".PadLeft(25,' ')+"\r\n");
                    ASCII_PrintText(m_objID, string.Format("日期:{0}   时间:{1}  录入时间:{2}\r\n", DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("HH:mm:ss"), printTime));
                    ASCII_PrintText(m_objID, string.Format("{0}{1}{2}{3}\r\n", "商品条码".PadRight(10, ' '), "库存数量".PadRight(10, ' '), "箱规".PadRight(10, ' '), "补货数量".PadRight(10, ' ')));


                    foreach (DataRow row1 in dtRow.Rows)
                    {
                        if (row1["chk"].ToString().Contains("True"))
                        {
                            var barcode = row1["条码"].ToString();
                            var date = row1["日期"].ToString();
                            var time = row1["时间"].ToString();var item = row1["商品编号"].ToString();
                            var stock = row1["库存"].ToString();
                            var unit = row1["箱规"].ToString();
                            var qty = row1["补货数量"].ToString();
                            ASCII_PrintText(m_objID, string.Format("{0}    {1}\r\n", row1["商品名称"], item));
                            ASCII_PrintText(m_objID, string.Format("{0}{1}{2}{3}\r\n", barcode.PadRight(15, ' '), stock.PadRight(15, ' '), unit.PadRight(15, ' '), qty.PadRight(15, ' ')));
                        }
                        
                    }
                    //打印条码
                    //ASCII_Print1DBarcode(m_objID, 73, 1, 50, 2, "CODE128 TEST");
                    //ASCII_Print2DBarcode(m_objID, 2, "rego北京瑞工科技", 1, 1, 3);
                    //ASCII_Print2DBarcode(m_objID,
                    //    2,
                    //    "33010201VPGNJw/qCWr1MiTqfJIkaR7Vj/pMA4zlQwWqX6aKP0uFeIRTK1ptgrttEptDUoyToXM6OO8zgn6cvTE226HTR9cr1txcLto2p7zrUQXbO7RBuTedTxrud8w6wUNX+2H4nZudWzt/r0ZxKL4K/gpDdXBFCLtGXGfVSn/57Td3T+4=",
                    //    0,
                    //    0,
                    //    3);
                    //是否切纸
                    if (true)
                        ASCII_CtrlCutPaper(m_objID, 66, 0);

                    CON_PageEnd(m_objID, 0);

                    bSucc = false;
                    switch (CON_PageSend(m_objID))
                    {
                        case 0:
                            //端口操作失败
                            strErr = "(%d)CON_PageSend failure(IO failure)，occur: %d(ms)\r\n";
                            break;
                        case 1:
                            //未验证
                            strErr = "(%d)CON_PageSend failure(unverify)，occur: %d(ms)\r\n";
                            break;
                        case 2:
                            {
                                //成功
                                switch (CON_QueryPrintStatus(m_objID, 5000))
                                {
                                    case 0:
                                        //端口操作失败
                                        MessageBox.Show("端口操作失败!");
                                        strErr = "(%d)CON_QueryPrintStatus failure(IO error)，occur: %d(ms)\r\n";
                                        break;
                                    case 1:
                                        //超时
                                        MessageBox.Show("超时");
                                        strErr = "(%d)CON_QueryPrintStatus failure(overtime)，occur: %d(ms)\r\n";
                                        break;
                                    case 2:
                                        //成功
                                        MessageBox.Show("成功");
                                        strErr = "{0:G}success, occur: {1:G}(ms)\r\n";
                                        bSucc = true;
                                        break;
                                }
                            }
                            break;
                    }
                    strMess = String.Format(strErr, i + 1, Environment.TickCount - tick);

                    msgList.Add(strMess);

                    //重要***
                    //在这里最后结束，如果上述操作没有成功，表示打印机或连接出现问题
                    //需要再次查询状态以便确认问题的最终原因
                    if (!bSucc)
                    {
                        switch (CON_QueryStatus(m_objID))
                        {
                            case 0:
                                MessageBox.Show("打印机状态正常");
                                msgList.Add("打印机状态正常");
                                bSucc = true;
                                break;
                            case 1:
                                MessageBox.Show("打印机无纸");
                                msgList.Add("打印机无纸");
                                break;
                            case 2:
                                MessageBox.Show("打印纸将尽");
                                msgList.Add("打印纸将尽");
                                break;
                            case 3:
                                MessageBox.Show("打印机未连接");
                                msgList.Add("打印机未连接");
                                break;
                        }
                    }

                    if (!bSucc)
                        break;

                    //if (chkLog.Checked)
                    CON_EndRecord();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        }
}
