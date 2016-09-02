using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Electric_Management_System.App_Code;
using Electric_Management_System.Reports;
using Electric_Management_System.Properties;

namespace Electric_Management_System
{
    public partial class xemBaoCaoForm : Form
    {
        public string reportType = "";
        public string monthlyReportType = "";
        public string soTram = "";
        public string tramID = "";
        public int thang = 0;
        public int nam = 0;
        public int soHoSH = 0;
        public int soHoMDK = 0;
        public int tongDienNhan = 0;
        public int tongNhanSH = 0;
        public int tongNhanHoNgheo = 0;
        public int tongNhanHoTNT = 0;
        public int tongNhanMDK = 0;
        public long tongTienThanhToan = 0;
        MonthlyReport_SH shReport;
        MonthlyReport_MDK mdkReport;
        TotalReport bcth;

        public xemBaoCaoForm()
        {
            InitializeComponent();
        }

        private void xemBaoCaoForm_Load(object sender, EventArgs e)
        {
            if (reportType == "monthly")
            {
                this.Text = "EMS - Báo Cáo Điện " + monthlyReportType + " Tháng " + thang.ToString() + ", Năm " + nam.ToString() + ", Trạm Số " + soTram;
                if (monthlyReportType == "Sinh Hoạt")
                {
                    shReport = new MonthlyReport_SH();
                    shReport.SetDataSource(DataTier.fillMonthlyReport(tramID, thang, nam, 1));
                    string[] giaSH = DataTier.getPrice("e00f133e-f43c-4dc5-8ebb-a747200416c9").Split(',');
                    shReport.SetParameterValue("giaDienMuc1", giaSH[0]);
                    shReport.SetParameterValue("giaDienMuc2", giaSH[1]);
                    shReport.SetParameterValue("giaDienMuc3", giaSH[2]);
                    shReport.SetParameterValue("giaDienMuc4", giaSH[3]);
                    shReport.SetParameterValue("giaDienMuc5", giaSH[4]);
                    shReport.SetParameterValue("giaDienMuc6", giaSH[5]);
                    shReport.SetParameterValue("soTram", soTram);
                    shReport.SetParameterValue("ngayBatDau", DataTier.getDuration(tramID));
                    shReport.SetParameterValue("ngayKetThuc", DataTier.getDuration(tramID));
                    if (thang == 1)
                    {
                        shReport.SetParameterValue("thangBatDau", "12");
                        shReport.SetParameterValue("namBatDau", (nam - 1).ToString());
                    }
                    else
                    {
                        shReport.SetParameterValue("thangBatDau", (thang - 1).ToString());
                        shReport.SetParameterValue("namBatDau", nam.ToString());
                    }
                    shReport.SetParameterValue("thangKetThuc", thang.ToString());
                    shReport.SetParameterValue("namKetThuc", nam.ToString());
                    shReport.SetParameterValue("ngayKy", DataTier.getReportDate(tramID));
                    shReport.SetParameterValue("thangKy", thang.ToString());
                    shReport.SetParameterValue("namKy", nam.ToString());
                    double tongTien = DataTier.getTongTienPhatSinh(tramID, thang, nam, "1") + DataTier.getTongNo(tramID, thang, nam, "1");
                    shReport.SetParameterValue("moneyReader", Program.moneyReader(System.Math.Round(tongTien).ToString()));
                    crvReport.ReportSource = shReport;
                }
                else if (monthlyReportType == "Mục Đích Khác")
                {
                    mdkReport = new MonthlyReport_MDK();
                    mdkReport.SetDataSource(DataTier.fillMonthlyReport(tramID, thang, nam, 0));
                    mdkReport.SetParameterValue("giaHC", DataTier.getPrice("068b5479-814c-4576-86ea-8684b07ffb4a"));
                    mdkReport.SetParameterValue("giaKD1", DataTier.getPrice("0cd8fc10-1369-4b21-9c59-806ada969bdb"));
                    mdkReport.SetParameterValue("giaKD2", DataTier.getPrice("3f4627cb-3ae3-4fcf-86e1-117b1dfcac4d"));
                    mdkReport.SetParameterValue("giaSX1", DataTier.getPrice("a8794644-b056-41dd-b515-bec60477947a"));
                    mdkReport.SetParameterValue("giaSX2", DataTier.getPrice("d4770373-51bb-4d7a-90d1-327c7043cdeb"));
                    mdkReport.SetParameterValue("gia30SX3", DataTier.getPrice("0cd8fc10-1369-4b21-9c59-806ada969bdb"));
                    mdkReport.SetParameterValue("gia70SX3", DataTier.getPrice("422cf080-b750-411d-a895-9550b8950b66"));
                    mdkReport.SetParameterValue("soTram", soTram);
                    mdkReport.SetParameterValue("ngayBatDau", DataTier.getDuration(tramID));
                    mdkReport.SetParameterValue("ngayKetThuc", DataTier.getDuration(tramID));
                    if (thang == 1)
                    {
                        mdkReport.SetParameterValue("thangBatDau", "12");
                        mdkReport.SetParameterValue("namBatDau", (nam - 1).ToString());
                    }
                    else
                    {
                        mdkReport.SetParameterValue("thangBatDau", (thang - 1).ToString());
                        mdkReport.SetParameterValue("namBatDau", nam.ToString());
                    }
                    mdkReport.SetParameterValue("thangKetThuc", thang.ToString());
                    mdkReport.SetParameterValue("namKetThuc", nam.ToString());
                    mdkReport.SetParameterValue("ngayKy", DataTier.getReportDate(tramID));
                    mdkReport.SetParameterValue("thangKy", thang.ToString());
                    mdkReport.SetParameterValue("namKy", nam.ToString());
                    double tongTien = DataTier.getTongTienPhatSinh(tramID, thang, nam, "0") + DataTier.getTongNo(tramID, thang, nam, "0");
                    mdkReport.SetParameterValue("moneyReader", Program.moneyReader(System.Math.Round(tongTien).ToString()));
                    crvReport.ReportSource = mdkReport;
                }
            }
            else if (reportType == "tongHop")
            {
                this.Text = "EMS - Báo Cáo Tổng Hợp Tháng " + thang.ToString() + ", Năm " + nam.ToString() + ", Trạm Số " + soTram;
                bcth = new TotalReport();
                bcth.SetParameterValue("thang", thang.ToString());
                bcth.SetParameterValue("nam", nam.ToString());
                bcth.SetParameterValue("ngayKy", DataTier.getReportDate(tramID));
                bcth.SetParameterValue("soTram", "Số " + soTram);
                bcth.SetParameterValue("tongHoSH", soHoSH);
                bcth.SetParameterValue("tongHoMDK", soHoMDK);
                bcth.SetParameterValue("tongDienNhan", tongDienNhan);
                bcth.SetParameterValue("dienSH", tongNhanSH);
                bcth.SetParameterValue("dienMDK", tongNhanMDK);
                bcth.SetParameterValue("tongThanhToan", tongTienThanhToan);
                int tongDienThu = DataTier.getTongDienByMD(tramID, thang, nam, "all");
                bcth.SetParameterValue("tongDienThu", tongDienThu);
                bcth.SetParameterValue("dienThuSH", DataTier.getTongDienByMD(tramID, thang, nam, "e00f133e-f43c-4dc5-8ebb-a747200416c9"));
                bcth.SetParameterValue("dienThuMDK", DataTier.getTongDienByMD(tramID, thang, nam, "0"));
                double tyLeTonThat = tongDienNhan - tongDienThu;
                tyLeTonThat = tyLeTonThat / tongDienNhan;
                tyLeTonThat = tyLeTonThat * 100;
                bcth.SetParameterValue("tyLeTonThat", tyLeTonThat.ToString("N2") + "%");
                bcth.SetParameterValue("tienPhatSinh", DataTier.getTongTienPhatSinh(tramID, thang, nam, "all"));
                bcth.SetParameterValue("tienNoCu", DataTier.getTongNo(tramID, thang, nam, "all"));
                crvReport.ReportSource = bcth;
            }
            else if (reportType == "thuChi")
            {
                this.Text = "EMS - Báo Cáo Thu Chi";
            }
        }

        private void xemBaoCaoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (crvReport.ReportSource == shReport)
            {
                shReport.Dispose();
            }
            else if (crvReport.ReportSource == mdkReport)
            {
                mdkReport.Dispose();
            }
            else if (crvReport.ReportSource == bcth)
            {
                bcth.Dispose();
            }
        }
    }
}