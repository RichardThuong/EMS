using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Electric_Management_System.App_Code;
using Electric_Management_System.Properties;
using Electric_Management_System.Reports;

namespace Electric_Management_System
{
    public partial class hoaDonCuForm : Form
    {
        private PrintInvoice printHD;
        private PrintInvoiceSX3 hd2;
        private String currentMode = string.Empty;
        private int soKhachTrongTram = 0;
        private int currentCustomer = 0;

        public hoaDonCuForm()
        {
            InitializeComponent();
        }

        private void hoaDonCuForm_Load(object sender, EventArgs e)
        {
            if (Settings.Default.savePath == null)
            {
                Settings.Default.savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                Settings.Default.Save();
            }
            pathTextBox.Text = Settings.Default.savePath;
            thangComboBox.Text = DateTime.Today.Month.ToString();
            namComboBox.Text = DateTime.Today.Year.ToString();
            normalMode();
            fillTram();
        }

        private void thoatButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void suaHoaDonButton_Click(object sender, EventArgs e)
        {
            currentCustomer = soThuTuComboBox.SelectedIndex;
            clearDataBindings();
            if (checkSTTKH())
            {
                editMode();
                autoIdentify();
            }
        }

        private void xuatHoaDonButton_Click(object sender, EventArgs e)
        {
             if (checkSTTKH())
            {
                try
                {
                    if (mayInCheckBox.Checked == false && vanBanCheckBox.Checked == false)
                    {
                        MessageBox.Show("Bạn hãy chọn cách xuất hóa đơn (xuất ra máy in hoặc file văn bản).", "Xuất hóa đơn không thành công", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        if (mayInCheckBox.Checked)
                        {
                            if (sanXuat3RadioButton.Checked)
                            {
                                hd2 = new PrintInvoiceSX3();
                                Program.tinhHoaDon(tramComboBox.Text.Split(' '), int.Parse(soMoiTextBox.Text), int.Parse(soCuTextBox.Text), int.Parse(soMoi2TextBox.Text), int.Parse(soCu2TextBox.Text), int.Parse(heSoNhanTextBox.Text), poorRadioButton.Checked, giaPoorLabel.Text, lowIncomeRadioButton.Checked, giaLowIncome.Text, sinhHoatRadioButton.Checked, DataTier.getPrice("e00f133e-f43c-4dc5-8ebb-a747200416c9").Split(','), hanhChinhRadioButton.Checked, giaHCLabel.Text, kinhDoanh1RadioButton.Checked, giaKD1Label.Text, kinhDoanh2RadioButton.Checked, giaKD2Label.Text, sanXuat1RadioButton.Checked, giaSX1Label.Text, sanXuat2RadioButton.Checked, giaSX2Label.Text, sanXuat3RadioButton.Checked, giaSX3Label.Text, thangComboBox.Text, namComboBox.Text, int.Parse(noCuTextBox.Text));
                                Program.fillPrintHDSX3(hoaDonIDTextBox.Text, hd2);
                                hd2.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                                hd2.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                hd2.PrintToPrinter(1, false, 1, 1);
                                MessageBox.Show("Hóa đơn đã được in.", "In hóa đơn thành công", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                hd2.Dispose();
                            }
                            else
                            {
                                printHD = new PrintInvoice();
                                Program.tinhHoaDon(tramComboBox.Text.Split(' '), int.Parse(soMoiTextBox.Text), int.Parse(soCuTextBox.Text), int.Parse(soMoi2TextBox.Text), int.Parse(soCu2TextBox.Text), int.Parse(heSoNhanTextBox.Text), poorRadioButton.Checked, giaPoorLabel.Text, lowIncomeRadioButton.Checked, giaLowIncome.Text, sinhHoatRadioButton.Checked, DataTier.getPrice("e00f133e-f43c-4dc5-8ebb-a747200416c9").Split(','), hanhChinhRadioButton.Checked, giaHCLabel.Text, kinhDoanh1RadioButton.Checked, giaKD1Label.Text, kinhDoanh2RadioButton.Checked, giaKD2Label.Text, sanXuat1RadioButton.Checked, giaSX1Label.Text, sanXuat2RadioButton.Checked, giaSX2Label.Text, sanXuat3RadioButton.Checked, giaSX3Label.Text, thangComboBox.Text, namComboBox.Text, int.Parse(noCuTextBox.Text));
                                Program.fillPrintHD(hoaDonIDTextBox.Text, printHD);
                                printHD.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                                printHD.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                printHD.PrintToPrinter(1, false, 1, 1);
                                MessageBox.Show("Hóa đơn đã được in.", "In hóa đơn thành công", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                printHD.Dispose();
                            }
                        }
                        if (vanBanCheckBox.Checked)
                        {
                            if (sanXuat3RadioButton.Checked)
                            {
                                hd2 = new PrintInvoiceSX3();
                                Program.tinhHoaDon(tramComboBox.Text.Split(' '), int.Parse(soMoiTextBox.Text), int.Parse(soCuTextBox.Text), int.Parse(soMoi2TextBox.Text), int.Parse(soCu2TextBox.Text), int.Parse(heSoNhanTextBox.Text), poorRadioButton.Checked, giaPoorLabel.Text, lowIncomeRadioButton.Checked, giaLowIncome.Text, sinhHoatRadioButton.Checked, DataTier.getPrice("e00f133e-f43c-4dc5-8ebb-a747200416c9").Split(','), hanhChinhRadioButton.Checked, giaHCLabel.Text, kinhDoanh1RadioButton.Checked, giaKD1Label.Text, kinhDoanh2RadioButton.Checked, giaKD2Label.Text, sanXuat1RadioButton.Checked, giaSX1Label.Text, sanXuat2RadioButton.Checked, giaSX2Label.Text, sanXuat3RadioButton.Checked, giaSX3Label.Text, thangComboBox.Text, namComboBox.Text, int.Parse(noCuTextBox.Text));
                                Program.fillPrintHDSX3(hoaDonIDTextBox.Text, hd2);
                                string invoiceName = "HD Số thứ tự " + soThuTuComboBox.Text + " - " + tramComboBox.Text + " - Tháng " + thangComboBox.Text + " - Năm " + namComboBox.Text + ".doc";
                                hd2.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                                hd2.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                                hd2.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.WordForWindows, pathTextBox.Text + "\\" + invoiceName);
                                MessageBox.Show("Hóa đơn đã được xuất ra thư mục \"" + pathTextBox.Text + "\" \nvà có tên là \"" + invoiceName + "\"", "Xuất hóa đơn thành công", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                hd2.Dispose();
                            }
                            else
                            {
                                printHD = new PrintInvoice();
                                Program.tinhHoaDon(tramComboBox.Text.Split(' '), int.Parse(soMoiTextBox.Text), int.Parse(soCuTextBox.Text), int.Parse(soMoi2TextBox.Text), int.Parse(soCu2TextBox.Text), int.Parse(heSoNhanTextBox.Text), poorRadioButton.Checked, giaPoorLabel.Text, lowIncomeRadioButton.Checked, giaLowIncome.Text, sinhHoatRadioButton.Checked, DataTier.getPrice("e00f133e-f43c-4dc5-8ebb-a747200416c9").Split(','), hanhChinhRadioButton.Checked, giaHCLabel.Text, kinhDoanh1RadioButton.Checked, giaKD1Label.Text, kinhDoanh2RadioButton.Checked, giaKD2Label.Text, sanXuat1RadioButton.Checked, giaSX1Label.Text, sanXuat2RadioButton.Checked, giaSX2Label.Text, sanXuat3RadioButton.Checked, giaSX3Label.Text, thangComboBox.Text, namComboBox.Text, int.Parse(noCuTextBox.Text));
                                Program.fillPrintHD(hoaDonIDTextBox.Text, printHD);
                                string invoiceName = "HD Số thứ tự " + soThuTuComboBox.Text + " - " + tramComboBox.Text + " - Tháng " + thangComboBox.Text + " - Năm " + namComboBox.Text + ".doc";
                                printHD.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                                printHD.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                                printHD.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.WordForWindows, pathTextBox.Text + "\\" + invoiceName);
                                MessageBox.Show("Hóa đơn đã được xuất ra thư mục \"" + pathTextBox.Text + "\" \nvà có tên là \"" + invoiceName + "\"", "Xuất hóa đơn thành công", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                printHD.Dispose();
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    //MessageBox.Show("Xuất hóa đơn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void viewInvoiceButton_Click(object sender, EventArgs e)
        {
            if (checkSTTKH())
            {
                Program.tinhHoaDon(tramComboBox.Text.Split(' '), int.Parse(soMoiTextBox.Text), int.Parse(soCuTextBox.Text), int.Parse(soMoi2TextBox.Text), int.Parse(soCu2TextBox.Text), int.Parse(heSoNhanTextBox.Text), poorRadioButton.Checked, giaPoorLabel.Text, lowIncomeRadioButton.Checked, giaLowIncome.Text, sinhHoatRadioButton.Checked, DataTier.getPrice("e00f133e-f43c-4dc5-8ebb-a747200416c9").Split(','), hanhChinhRadioButton.Checked, giaHCLabel.Text, kinhDoanh1RadioButton.Checked, giaKD1Label.Text, kinhDoanh2RadioButton.Checked, giaKD2Label.Text, sanXuat1RadioButton.Checked, giaSX1Label.Text, sanXuat2RadioButton.Checked, giaSX2Label.Text, sanXuat3RadioButton.Checked, giaSX3Label.Text, thangComboBox.Text, namComboBox.Text, int.Parse(noCuTextBox.Text));
                xemHoaDonForm hoaDon = new xemHoaDonForm();
                hoaDon.hoaDonID = hoaDonIDTextBox.Text;
                hoaDon.hoaDonSX3 = sanXuat3RadioButton.Checked;
                hoaDon.ShowDialog();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (checkSTTKH())
            {
                if (checkInput())
                {
                    if (int.Parse(soMoiTextBox.Text) < int.Parse(soCuTextBox.Text))
                    {
                        DialogResult = MessageBox.Show("Số công tơ mới nhỏ hơn số công tơ cũ!\n\nNếu bạn chắc chắn đã nhập đúng thì hãy nhấn nút OK, chương trình sẽ tự động tính theo trường hợp công tơ hết vòng số.\nCòn nếu bạn phát hiện đây là nhầm lẫn, hãy bấm Cancel và sửa lại.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        if (DialogResult == DialogResult.OK)
                        {
                            if (congToChetCheckBox.Checked)
                            {
                                if (int.Parse(soMoi2TextBox.Text) < int.Parse(soCu2TextBox.Text))
                                {
                                    DialogResult = MessageBox.Show("Số công tơ mới nhỏ hơn số công tơ cũ trong công tơ thay thế!\n\nNếu bạn chắc chắn đã nhập đúng thì hãy nhấn nút OK, chương trình sẽ tự động tính theo trường hợp công tơ hết vòng số.\nCòn nếu bạn phát hiện đây là nhầm lẫn, hãy bấm Cancel và sửa lại.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                                    if (DialogResult == DialogResult.OK)
                                    {
                                        saveInvoice();
                                    }
                                    else
                                    {
                                        soMoi2TextBox.Focus();
                                        soMoi2TextBox.SelectAll();
                                    }
                                }
                                else
                                {
                                    saveInvoice();
                                }
                            }
                            else
                            {
                                saveInvoice();
                            }
                        }
                        else
                        {
                            soMoiTextBox.Focus();
                            soMoiTextBox.SelectAll();
                        }
                    }
                    else if (congToChetCheckBox.Checked)
                    {
                        if (int.Parse(soMoi2TextBox.Text) < int.Parse(soCu2TextBox.Text))
                        {
                            DialogResult = MessageBox.Show("Số công tơ mới nhỏ hơn số công tơ cũ trong công tơ thay thế!\n\nNếu bạn chắc chắn đã nhập đúng thì hãy nhấn nút OK, chương trình sẽ tự động tính theo trường hợp công tơ hết vòng số.\nCòn nếu bạn phát hiện đây là nhầm lẫn, hãy bấm Cancel và sửa lại.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            if (DialogResult == DialogResult.OK)
                            {
                                saveInvoice();
                            }
                            else
                            {
                                soMoi2TextBox.Focus();
                                soMoi2TextBox.SelectAll();
                            }
                        }
                        else
                        {
                            saveInvoice();
                        }
                    }
                    else
                    {
                        saveInvoice();
                    }
                }
            }
            fillSTTKH();
            soThuTuComboBox.SelectedIndex = currentCustomer;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            normalMode();
            fillSTTKH();
            soThuTuComboBox.SelectedIndex = currentCustomer;
            identifyMDSD();
        }

        private void suaSoCuCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (suaSoCuCheckBox.Checked)
            {
                soCuTextBox.Enabled = true;
                soCuTextBox.Focus();
                soCuTextBox.SelectAll();
            }
            else
            {
                soCuTextBox.Enabled = false;
            }
        }

        private void heSoNhanCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (heSoNhanCheckBox.Checked)
            {
                heSoNhanTextBox.Enabled = true;
                heSoNhanTextBox.Focus();
                heSoNhanTextBox.SelectAll();
            }
            else
            {
                heSoNhanTextBox.Enabled = false;
            }
        }

        private void congToChetCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (congToChetCheckBox.Checked)
            {
                congToChetGroupBox.Visible = true;
            }
            else
            {
                congToChetGroupBox.Visible = false;
            }
        }

        private void soCuTextBox_Leave(object sender, EventArgs e)
        {
            suaSoCuCheckBox.Checked = false;
        }

        private void heSoNhanTextBox_Leave(object sender, EventArgs e)
        {
            heSoNhanCheckBox.Checked = false;
        }

        private void vanBanCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (vanBanCheckBox.Checked)
            {
                pathTextBox.Enabled = true;
                changePathButton.Enabled = true;
                changePathToolStripMenuItem.Enabled = true;
            }
            else
            {
                pathTextBox.Enabled = false;
                changePathButton.Enabled = false;
                changePathToolStripMenuItem.Enabled = false;
            }
        }

        private void changePathButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.savePath = folderBrowserDialog.SelectedPath;
                Settings.Default.Save();
                pathTextBox.Text = Settings.Default.savePath;
            }
        }

        private void tramComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (tramComboBox.Items.Count > 0)
            {
                fillSTTKH();
            }
        }

        private void thangComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (tramComboBox.Items.Count > 0)
            {
                fillSTTKH();
            }
        }

        private void namComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (tramComboBox.Items.Count > 0)
            {
                fillSTTKH();
            }
        }

        private void soThuTuComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if (soThuTuComboBox.Items.Count > 0)
                {
                    fillKHDetails();
                    fillHoaDonDetails();
                }
            }
            catch (Exception)
            {
            }
        }

        private void mucDichIDTextBox_TextChanged(object sender, EventArgs e)
        {
            identifyMDSD();
        }

        //private void suaGiaButton_Click(object sender, EventArgs e)
        //{
        //    suaGiaDienForm suaGiaDien = new suaGiaDienForm();
        //    suaGiaDien.hoaDonDaLap = true;
        //    suaGiaDien.hoaDonID = hoaDonIDTextBox.Text;
        //    suaGiaDien.mucDichID = int.Parse(mucDichIDTextBox.Text);
        //    suaGiaDien.hoaDon = "(Số thứ tự: " + soThuTuComboBox.Text + ", " + tramComboBox.Text + ", " + thangComboBox.Text + "/" + namComboBox.Text + ")";
        //    if (sinhHoatRadioButton.Checked)
        //    {
        //        suaGiaDien.giaDien = giaSHLabel.Text;
        //    }
        //    else if (congCongRadioButton.Checked)
        //    {
        //        suaGiaDien.giaDien = giaCCLabel.Text;
        //    }
        //    else if (hanhChinhRadioButton.Checked)
        //    {
        //        suaGiaDien.giaDien = giaHCLabel.Text;
        //    }
        //    else if (kinhDoanh1RadioButton.Checked)
        //    {
        //        suaGiaDien.giaDien = giaKD1Label.Text;
        //    }
        //    else if (kinhDoanh2RadioButton.Checked)
        //    {
        //        suaGiaDien.giaDien = giaKD2Label.Text;
        //    }
        //    else if (sanXuat1RadioButton.Checked)
        //    {
        //        suaGiaDien.giaDien = giaSX1Label.Text;
        //    }
        //    else if (sanXuat2RadioButton.Checked)
        //    {
        //        suaGiaDien.giaDien = giaSX2Label.Text;
        //    }
        //    else if (sanXuat3RadioButton.Checked)
        //    {
        //        suaGiaDien.giaDien = giaSX3Label.Text;
        //    }
        //    else if (sanXuat4RadioButton.Checked)
        //    {
        //        suaGiaDien.giaDien = giaSX4Label.Text;
        //    }
        //    suaGiaDien.ShowDialog();
        //}

        private void hoaDonIDTextBox_TextChanged(object sender, EventArgs e)
        {
            fillHoaDonDetails();
        }

        private void normalMode()
        {
            errorProvider.Clear();
            currentMode = "normal";
            tramComboBox.Enabled = true;
            thangComboBox.Enabled = true;
            namComboBox.Enabled = true;
            soThuTuComboBox.Enabled = true;
            tenKhachTextBox.Enabled = false;
            diaChiTextBox.Enabled = false;
            soHoKhauTextBox.Enabled = false;
            maSoThueTextBox.Enabled = false;
            poorRadioButton.Enabled = false;
            lowIncomeRadioButton.Enabled = false;
            sinhHoatRadioButton.Enabled = false;
            sanXuat1RadioButton.Enabled = false;
            sanXuat2RadioButton.Enabled = false;
            sanXuat3RadioButton.Enabled = false;
            hanhChinhRadioButton.Enabled = false;
            kinhDoanh1RadioButton.Enabled = false;
            kinhDoanh2RadioButton.Enabled = false;
            soMoiTextBox.Enabled = false;
            noCuTextBox.Enabled = false;
            soCu2TextBox.Enabled = false;
            soMoi2TextBox.Enabled = false;
            heSoNhanCheckBox.Enabled = false;
            suaSoCuCheckBox.Enabled = false;
            congToChetCheckBox.Enabled = false;
            mayInCheckBox.Enabled = true;
            vanBanCheckBox.Enabled = true;
            closeToolStripMenuItem.Enabled = true;
            xuatHoaDonButton.Visible = true;
            printToolStripMenuItem.Enabled = true;
            suaHoaDonButton.Visible = true;
            editToolStripMenuItem.Enabled = true;
            saveButton.Visible = false;
            saveToolStripMenuItem.Enabled = false;
            cancelButton.Visible = false;
            cancelToolStripMenuItem.Enabled = false;
            suaSoCuCheckBox.Checked = false;
            heSoNhanCheckBox.Checked = false;
            viewInvoiceButton.Visible = true;
            viewToolStripMenuItem.Enabled = true;
        }

        private void editMode()
        {
            errorProvider.Clear();
            currentMode = "edit";
            tramComboBox.Enabled = false;
            thangComboBox.Enabled = false;
            namComboBox.Enabled = false;
            soThuTuComboBox.Enabled = false;
            tenKhachTextBox.Enabled = true;
            diaChiTextBox.Enabled = true;
            soHoKhauTextBox.Enabled = true;
            maSoThueTextBox.Enabled = true;
            poorRadioButton.Enabled = true;
            lowIncomeRadioButton.Enabled = true;
            sinhHoatRadioButton.Enabled = true;
            sanXuat1RadioButton.Enabled = true;
            sanXuat2RadioButton.Enabled = true;
            sanXuat3RadioButton.Enabled = true;
            hanhChinhRadioButton.Enabled = true;
            kinhDoanh1RadioButton.Enabled = true;
            kinhDoanh2RadioButton.Enabled = true;
            soMoiTextBox.Enabled = true;
            noCuTextBox.Enabled = true;
            soCu2TextBox.Enabled = true;
            soMoi2TextBox.Enabled = true;
            heSoNhanCheckBox.Enabled = true;
            suaSoCuCheckBox.Enabled = true;
            congToChetCheckBox.Enabled = true;
            mayInCheckBox.Enabled = false;
            vanBanCheckBox.Enabled = false;
            closeToolStripMenuItem.Enabled = false;
            xuatHoaDonButton.Visible = false;
            printToolStripMenuItem.Enabled = false;
            suaHoaDonButton.Visible = false;
            editToolStripMenuItem.Enabled = false;
            saveButton.Visible = true;
            saveToolStripMenuItem.Enabled = true;
            cancelButton.Visible = true;
            cancelToolStripMenuItem.Enabled = true;
            suaSoCuCheckBox.Checked = false;
            heSoNhanCheckBox.Checked = false;
            viewInvoiceButton.Visible = false;
            viewToolStripMenuItem.Enabled = false;

            poorRadioButton.BackColor = System.Drawing.Color.Transparent;
            lowIncomeRadioButton.BackColor = System.Drawing.Color.Transparent;
            sinhHoatRadioButton.BackColor = System.Drawing.Color.Transparent;
            hanhChinhRadioButton.BackColor = System.Drawing.Color.Transparent;
            kinhDoanh1RadioButton.BackColor = System.Drawing.Color.Transparent;
            kinhDoanh2RadioButton.BackColor = System.Drawing.Color.Transparent;
            sanXuat1RadioButton.BackColor = System.Drawing.Color.Transparent;
            sanXuat2RadioButton.BackColor = System.Drawing.Color.Transparent;
            sanXuat3RadioButton.BackColor = System.Drawing.Color.Transparent;
        }

        private void fillTram()
        {
            tramComboBox.DataSource = DataTier.getStation();
            tramComboBox.DisplayMember = "Name";
            tramComboBox.ValueMember = "StationID";
            if (tramComboBox.Items.Count > 0)
            {
                tramComboBox.SelectedIndex = 0;
                fillSTTKH();
            }
            else
            {
                soThuTuComboBox.DataSource = null;
                soThuTuComboBox.Items.Clear();
                clearTextBoxes();
            }
            fillGiaDien();
        }

        private void fillSTTKH()
        {
            if (currentMode != "edit" && tramComboBox.Items.Count > 0)
            {
                DataTable khachHangDLHD = DataTier.getBilledCustomer(tramComboBox.SelectedValue.ToString(), int.Parse(thangComboBox.Text), int.Parse(namComboBox.Text));
                soThuTuComboBox.DataSource = khachHangDLHD;
                soThuTuComboBox.DisplayMember = "CustomerNumber";
                soThuTuComboBox.ValueMember = "CustomerID";
                hoaDonIDTextBox.DataBindings.Clear();
                hoaDonIDTextBox.DataBindings.Add("Text", khachHangDLHD, "InvoiceID");
                if (soThuTuComboBox.Items.Count > 0)
                {
                    soThuTuComboBox.SelectedIndex = 0;
                    fillKHDetails();
                    fillHoaDonDetails();
                    xuatHoaDonButton.Visible = true;
                    printToolStripMenuItem.Enabled = true;
                    suaHoaDonButton.Visible = true;
                    editToolStripMenuItem.Enabled = true;
                    viewInvoiceButton.Visible = true;
                    viewToolStripMenuItem.Enabled = true;
                    mayInCheckBox.Enabled = true;
                    vanBanCheckBox.Enabled = true;
                }
                else
                {
                    soThuTuComboBox.Text = string.Empty;
                    clearTextBoxes();
                    xuatHoaDonButton.Visible = false;
                    printToolStripMenuItem.Enabled = false;
                    suaHoaDonButton.Visible = false;
                    editToolStripMenuItem.Enabled = false;
                    viewInvoiceButton.Visible = false;
                    viewToolStripMenuItem.Enabled = false;
                    mayInCheckBox.Enabled = false;
                    vanBanCheckBox.Enabled = false;
                }
                soKhachTrongTram = DataTier.XacDinhSTTMax(tramComboBox.SelectedValue.ToString());
                messageLabel.Text = "Có " + khachHangDLHD.Rows.Count.ToString() + " khách đã lập hóa đơn trong tháng " + thangComboBox.Text + "/" + namComboBox.Text;
            }
        }

        private void fillKHDetails()
        {
            tenKhachTextBox.DataBindings.Clear();
            diaChiTextBox.DataBindings.Clear();
            soHoKhauTextBox.DataBindings.Clear();
            maSoThueTextBox.DataBindings.Clear();

            Object khachHangDetails = DataTier.getCustomerDetails(soThuTuComboBox.SelectedValue.ToString());
            tenKhachTextBox.DataBindings.Add("Text", khachHangDetails, "Name");
            diaChiTextBox.DataBindings.Add("Text", khachHangDetails, "Address");
            soHoKhauTextBox.DataBindings.Add("Text", khachHangDetails, "HKNumber");
            maSoThueTextBox.DataBindings.Add("Text", khachHangDetails, "TaxNumber");
        }

        private void fillHoaDonDetails()
        {
            soCuTextBox.DataBindings.Clear();
            soMoiTextBox.DataBindings.Clear();
            soCu2TextBox.DataBindings.Clear();
            soMoi2TextBox.DataBindings.Clear();
            heSoNhanTextBox.DataBindings.Clear();
            noCuTextBox.DataBindings.Clear();
            mucDichIDTextBox.DataBindings.Clear();

            Object hoaDonDetails = DataTier.getHoaDonDetails(hoaDonIDTextBox.Text);
            soCuTextBox.DataBindings.Add("Text", hoaDonDetails, "OldNumber");
            soMoiTextBox.DataBindings.Add("Text", hoaDonDetails, "NewNumber");
            soCu2TextBox.DataBindings.Add("Text", hoaDonDetails, "OldNumber2");
            soMoi2TextBox.DataBindings.Add("Text", hoaDonDetails, "NewNumber2");
            heSoNhanTextBox.DataBindings.Add("Text", hoaDonDetails, "Multiplier");
            noCuTextBox.DataBindings.Add("Text", hoaDonDetails, "Debt");
            mucDichIDTextBox.DataBindings.Add("Text", hoaDonDetails, "PurposeID");

            if (soMoi2TextBox.Text != "0")
            {
                congToChetCheckBox.Checked = true;
            }
            else
            {
                congToChetCheckBox.Checked = false;
            }
        }

        private void fillGiaDien()
        {
            giaPoorLabel.Text = DataTier.getPrice("a770acf2-0f54-43ce-8695-10c7c4072c64");
            giaLowIncome.Text = DataTier.getPrice("7e17ce3d-ea0c-4a6a-9048-47c563991fd6");
            String[] giaSH = DataTier.getPrice("e00f133e-f43c-4dc5-8ebb-a747200416c9").Split(',');
            giaSH1Label.Text = giaSH[0];
            giaSH2Label.Text = giaSH[1];
            giaSH3Label.Text = giaSH[2];
            giaSH4Label.Text = giaSH[3];
            giaSH5Label.Text = giaSH[4];
            giaSH6Label.Text = giaSH[5];
            giaHCLabel.Text = DataTier.getPrice("068b5479-814c-4576-86ea-8684b07ffb4a");
            giaKD1Label.Text = DataTier.getPrice("0cd8fc10-1369-4b21-9c59-806ada969bdb");
            giaKD2Label.Text = DataTier.getPrice("3f4627cb-3ae3-4fcf-86e1-117b1dfcac4d");
            giaSX1Label.Text = DataTier.getPrice("a8794644-b056-41dd-b515-bec60477947a");
            giaSX2Label.Text = DataTier.getPrice("d4770373-51bb-4d7a-90d1-327c7043cdeb");
            giaSX3Label.Text = DataTier.getPrice("422cf080-b750-411d-a895-9550b8950b66");
        }

        private void identifyMDSD()
        {
            if (mucDichIDTextBox.Text == "a770acf2-0f54-43ce-8695-10c7c4072c64")
            {
                poorRadioButton.Checked = true;

                poorRadioButton.BackColor = System.Drawing.Color.AliceBlue;
                lowIncomeRadioButton.BackColor = System.Drawing.Color.Transparent;
                sinhHoatRadioButton.BackColor = System.Drawing.Color.Transparent;
                hanhChinhRadioButton.BackColor = System.Drawing.Color.Transparent;
                kinhDoanh1RadioButton.BackColor = System.Drawing.Color.Transparent;
                kinhDoanh2RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat1RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat2RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat3RadioButton.BackColor = System.Drawing.Color.Transparent;
            }
            else if (mucDichIDTextBox.Text == "7e17ce3d-ea0c-4a6a-9048-47c563991fd6")
            {
                lowIncomeRadioButton.Checked = true;

                poorRadioButton.BackColor = System.Drawing.Color.Transparent;
                lowIncomeRadioButton.BackColor = System.Drawing.Color.AliceBlue;
                sinhHoatRadioButton.BackColor = System.Drawing.Color.Transparent;
                hanhChinhRadioButton.BackColor = System.Drawing.Color.Transparent;
                kinhDoanh1RadioButton.BackColor = System.Drawing.Color.Transparent;
                kinhDoanh2RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat1RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat2RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat3RadioButton.BackColor = System.Drawing.Color.Transparent;
            }
            else if (mucDichIDTextBox.Text == "e00f133e-f43c-4dc5-8ebb-a747200416c9")
            {
                sinhHoatRadioButton.Checked = true;

                poorRadioButton.BackColor = System.Drawing.Color.Transparent;
                lowIncomeRadioButton.BackColor = System.Drawing.Color.Transparent;
                sinhHoatRadioButton.BackColor = System.Drawing.Color.AliceBlue;
                hanhChinhRadioButton.BackColor = System.Drawing.Color.Transparent;
                kinhDoanh1RadioButton.BackColor = System.Drawing.Color.Transparent;
                kinhDoanh2RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat1RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat2RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat3RadioButton.BackColor = System.Drawing.Color.Transparent;
            }
            else if (mucDichIDTextBox.Text == "068b5479-814c-4576-86ea-8684b07ffb4a")
            {
                hanhChinhRadioButton.Checked = true;

                poorRadioButton.BackColor = System.Drawing.Color.Transparent;
                lowIncomeRadioButton.BackColor = System.Drawing.Color.Transparent;
                sinhHoatRadioButton.BackColor = System.Drawing.Color.Transparent;
                hanhChinhRadioButton.BackColor = System.Drawing.Color.AliceBlue;
                kinhDoanh1RadioButton.BackColor = System.Drawing.Color.Transparent;
                kinhDoanh2RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat1RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat2RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat3RadioButton.BackColor = System.Drawing.Color.Transparent;
            }
            else if (mucDichIDTextBox.Text == "0cd8fc10-1369-4b21-9c59-806ada969bdb")
            {
                kinhDoanh1RadioButton.Checked = true;

                poorRadioButton.BackColor = System.Drawing.Color.Transparent;
                lowIncomeRadioButton.BackColor = System.Drawing.Color.Transparent;
                sinhHoatRadioButton.BackColor = System.Drawing.Color.Transparent;
                hanhChinhRadioButton.BackColor = System.Drawing.Color.Transparent;
                kinhDoanh1RadioButton.BackColor = System.Drawing.Color.AliceBlue;
                kinhDoanh2RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat1RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat2RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat3RadioButton.BackColor = System.Drawing.Color.Transparent;
            }
            else if (mucDichIDTextBox.Text == "3f4627cb-3ae3-4fcf-86e1-117b1dfcac4d")
            {
                kinhDoanh2RadioButton.Checked = true;

                poorRadioButton.BackColor = System.Drawing.Color.Transparent;
                lowIncomeRadioButton.BackColor = System.Drawing.Color.Transparent;
                sinhHoatRadioButton.BackColor = System.Drawing.Color.Transparent;
                hanhChinhRadioButton.BackColor = System.Drawing.Color.Transparent;
                kinhDoanh1RadioButton.BackColor = System.Drawing.Color.Transparent;
                kinhDoanh2RadioButton.BackColor = System.Drawing.Color.AliceBlue;
                sanXuat1RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat2RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat3RadioButton.BackColor = System.Drawing.Color.Transparent;
            }
            else if (mucDichIDTextBox.Text == "a8794644-b056-41dd-b515-bec60477947a")
            {
                sanXuat1RadioButton.Checked = true;

                poorRadioButton.BackColor = System.Drawing.Color.Transparent;
                lowIncomeRadioButton.BackColor = System.Drawing.Color.Transparent;
                sinhHoatRadioButton.BackColor = System.Drawing.Color.Transparent;
                hanhChinhRadioButton.BackColor = System.Drawing.Color.Transparent;
                kinhDoanh1RadioButton.BackColor = System.Drawing.Color.Transparent;
                kinhDoanh2RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat1RadioButton.BackColor = System.Drawing.Color.AliceBlue;
                sanXuat2RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat3RadioButton.BackColor = System.Drawing.Color.Transparent;
            }
            else if (mucDichIDTextBox.Text == "d4770373-51bb-4d7a-90d1-327c7043cdeb")
            {
                sanXuat2RadioButton.Checked = true;

                poorRadioButton.BackColor = System.Drawing.Color.Transparent;
                lowIncomeRadioButton.BackColor = System.Drawing.Color.Transparent;
                sinhHoatRadioButton.BackColor = System.Drawing.Color.Transparent;
                hanhChinhRadioButton.BackColor = System.Drawing.Color.Transparent;
                kinhDoanh1RadioButton.BackColor = System.Drawing.Color.Transparent;
                kinhDoanh2RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat1RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat2RadioButton.BackColor = System.Drawing.Color.AliceBlue;
                sanXuat3RadioButton.BackColor = System.Drawing.Color.Transparent;
            }
            else if (mucDichIDTextBox.Text == "422cf080-b750-411d-a895-9550b8950b66")
            {
                sanXuat3RadioButton.Checked = true;

                poorRadioButton.BackColor = System.Drawing.Color.Transparent;
                lowIncomeRadioButton.BackColor = System.Drawing.Color.Transparent;
                sinhHoatRadioButton.BackColor = System.Drawing.Color.Transparent;
                hanhChinhRadioButton.BackColor = System.Drawing.Color.Transparent;
                kinhDoanh1RadioButton.BackColor = System.Drawing.Color.Transparent;
                kinhDoanh2RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat1RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat2RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat3RadioButton.BackColor = System.Drawing.Color.AliceBlue;
            }
            else
            {
                poorRadioButton.Checked = false;
                lowIncomeRadioButton.Checked = false;
                sinhHoatRadioButton.Checked = false;
                hanhChinhRadioButton.Checked = false;
                kinhDoanh1RadioButton.Checked = false;
                kinhDoanh2RadioButton.Checked = false;
                sanXuat1RadioButton.Checked = false;
                sanXuat2RadioButton.Checked = false;
                sanXuat3RadioButton.Checked = false;

                poorRadioButton.BackColor = System.Drawing.Color.Transparent;
                lowIncomeRadioButton.BackColor = System.Drawing.Color.Transparent;
                sinhHoatRadioButton.BackColor = System.Drawing.Color.Transparent;
                hanhChinhRadioButton.BackColor = System.Drawing.Color.Transparent;
                kinhDoanh1RadioButton.BackColor = System.Drawing.Color.Transparent;
                kinhDoanh2RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat1RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat2RadioButton.BackColor = System.Drawing.Color.Transparent;
                sanXuat3RadioButton.BackColor = System.Drawing.Color.Transparent;
            }
        }

        private void clearTextBoxes()
        {
            tenKhachTextBox.Clear();
            diaChiTextBox.Clear();
            soHoKhauTextBox.Clear();
            maSoThueTextBox.Clear();
            soCuTextBox.Clear();
            soMoiTextBox.Clear();
            noCuTextBox.Clear();
            //dienCCTextBox.Clear();
            soCu2TextBox.Clear();
            soMoi2TextBox.Clear();
            heSoNhanTextBox.Clear();
            mucDichIDTextBox.Clear();
        }

        private void clearDataBindings()
        {
            tenKhachTextBox.DataBindings.Clear();
            diaChiTextBox.DataBindings.Clear();
            soHoKhauTextBox.DataBindings.Clear();
            maSoThueTextBox.DataBindings.Clear();
            soCuTextBox.DataBindings.Clear();
            soMoiTextBox.DataBindings.Clear();
            heSoNhanTextBox.DataBindings.Clear();
            noCuTextBox.DataBindings.Clear();
            //dienCCTextBox.DataBindings.Clear();
            soCu2TextBox.DataBindings.Clear();
            soMoi2TextBox.DataBindings.Clear();
            mucDichIDTextBox.DataBindings.Clear();
        }

        private bool checkSTTKH()
        {
            bool result = false;
            if (soThuTuComboBox.Text == string.Empty)
            {
                errorProvider.SetError(soThuTuComboBox, "Số thứ tự không thể bỏ trống, bạn hãy nhập lại!");
                errorProvider.SetIconAlignment(soThuTuComboBox, ErrorIconAlignment.MiddleLeft);
            }
            else
            {
                try
                {
                    if (int.Parse(soThuTuComboBox.Text) <= 0 || int.Parse(soThuTuComboBox.Text) > soKhachTrongTram)
                    {
                        errorProvider.SetError(soThuTuComboBox, "Không có khách hàng nào có số thứ tự là \"" + soThuTuComboBox.Text + "\" trong trạm này!");
                        errorProvider.SetIconAlignment(soThuTuComboBox, ErrorIconAlignment.MiddleLeft);
                    }
                    else
                    {
                        if (soThuTuComboBox.SelectedValue == null)
                        {
                            errorProvider.SetError(soThuTuComboBox, "Số thứ tự khách hàng không đúng với tên khách, bạn hãy chọn lại!\n\nSau khi nhập số thứ tự khách hàng, bạn phải bấm phím mũi tên xuống\nđể chương trình tải đúng khách hàng với số thứ tự mà bạn vừa nhập vào.");
                            errorProvider.SetIconAlignment(soThuTuComboBox, ErrorIconAlignment.MiddleLeft);
                        }
                        else
                        {
                            result = true;
                        }
                    }
                }
                catch
                {
                    errorProvider.SetError(soThuTuComboBox, "Số thứ tự khách hàng phải là số nguyên!");
                    errorProvider.SetIconAlignment(soThuTuComboBox, ErrorIconAlignment.MiddleLeft);
                }
            }
            return result;
        }

        private bool checkInput()
        {
            bool result = false;
            if (tenKhachTextBox.Text == string.Empty)
            {
                errorProvider.SetError(tenKhachTextBox, "Tên khách không thể bỏ trống, mời bạn nhập lại!");
                errorProvider.SetIconAlignment(tenKhachTextBox, ErrorIconAlignment.MiddleLeft);
                tenKhachTextBox.Focus();
            }
            else if (poorRadioButton.Checked == false && lowIncomeRadioButton.Checked == false && sinhHoatRadioButton.Checked == false && hanhChinhRadioButton.Checked == false && kinhDoanh1RadioButton.Checked == false && kinhDoanh2RadioButton.Checked == false && sanXuat1RadioButton.Checked == false && sanXuat2RadioButton.Checked == false && sanXuat3RadioButton.Checked == false)
            {
                errorProvider.SetError(mucDichGroupBox, "Bạn chưa chọn mục đích sử dụng điện!");
            }
            else if (soCuTextBox.Text == string.Empty)
            {
                errorProvider.SetError(soCuTextBox, "Số công tơ cũ không thể bỏ trống!");
            }
            else if (soMoiTextBox.Text == string.Empty)
            {
                errorProvider.SetError(soMoiTextBox, "Số công tơ mới không thể bỏ trống!");
            }
            else if (heSoNhanTextBox.Text == string.Empty)
            {
                errorProvider.SetError(heSoNhanTextBox, "Hệ số nhân không thể bỏ trống!");
            }
            else
            {
                try
                {
                    if (int.Parse(soCuTextBox.Text) < 0)
                    {
                        errorProvider.SetError(soCuTextBox, "Số công tơ cũ phải lớn hơn hoặc bằng 0!");
                    }
                    else
                    {
                        try
                        {
                            if (int.Parse(soMoiTextBox.Text) < 0)
                            {
                                errorProvider.SetError(soMoiTextBox, "Số công tơ mới phải lớn hơn hoặc bằng 0!");
                            }
                            else
                            {
                                try
                                {
                                    if (int.Parse(heSoNhanTextBox.Text) <= 0)
                                    {
                                        errorProvider.SetError(heSoNhanTextBox, "Hệ số nhân phải lớn hơn 0!");
                                    }
                                    else
                                    {
                                        if (congToChetCheckBox.Checked)
                                        {
                                            if (soCu2TextBox.Text == string.Empty)
                                            {
                                                errorProvider.SetError(soCu2TextBox, "Số công tơ cũ thay thế không thể bỏ trống!");
                                                errorProvider.SetIconAlignment(soCu2TextBox, ErrorIconAlignment.MiddleLeft);
                                            }
                                            else if (soMoi2TextBox.Text == string.Empty)
                                            {
                                                errorProvider.SetError(soMoi2TextBox, "Số công tơ mới thay thế không thể bỏ trống!");
                                                errorProvider.SetIconAlignment(soMoi2TextBox, ErrorIconAlignment.MiddleLeft);
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    if (int.Parse(soCu2TextBox.Text) < 0)
                                                    {
                                                        errorProvider.SetError(soCu2TextBox, "Số công tơ cũ thay thế phải lớn hơn hoặc bằng 0!");
                                                        errorProvider.SetIconAlignment(soCu2TextBox, ErrorIconAlignment.MiddleLeft);
                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            if (int.Parse(soMoi2TextBox.Text) < 0)
                                                            {
                                                                errorProvider.SetError(soMoi2TextBox, "Số công tơ mới thay thế phải lớn hơn hoặc bằng 0!");
                                                                errorProvider.SetIconAlignment(soMoi2TextBox, ErrorIconAlignment.MiddleLeft);
                                                            }
                                                            else
                                                            {
                                                                try
                                                                {
                                                                    if (noCuTextBox.Text == String.Empty)
                                                                    {
                                                                        noCuTextBox.Text = "0";
                                                                        result = true;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (int.Parse(noCuTextBox.Text) < 0)
                                                                        {
                                                                            errorProvider.SetError(noCuTextBox, "Số nợ cũ phải lớn hơn hoặc bằng 0!");
                                                                            errorProvider.SetIconAlignment(noCuTextBox, ErrorIconAlignment.MiddleLeft);
                                                                        }
                                                                        else
                                                                        {
                                                                            result = true;
                                                                        }
                                                                    }
                                                                }
                                                                catch
                                                                {
                                                                    errorProvider.SetError(noCuTextBox, "Số nợ cũ phải là số nguyên!");
                                                                    errorProvider.SetIconAlignment(noCuTextBox, ErrorIconAlignment.MiddleLeft);
                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            errorProvider.SetError(soMoi2TextBox, "Số công tơ mới thay thế phải là số nguyên!");
                                                            errorProvider.SetIconAlignment(soMoi2TextBox, ErrorIconAlignment.MiddleLeft);
                                                        }
                                                    }
                                                }
                                                catch
                                                {
                                                    errorProvider.SetError(soCu2TextBox, "Số công tơ cũ thay thế phải là số nguyên!");
                                                    errorProvider.SetIconAlignment(soCu2TextBox, ErrorIconAlignment.MiddleLeft);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                if (noCuTextBox.Text == String.Empty)
                                                {
                                                    noCuTextBox.Text = "0";
                                                    result = true;
                                                }
                                                else
                                                {
                                                    if (int.Parse(noCuTextBox.Text) < 0)
                                                    {
                                                        errorProvider.SetError(noCuTextBox, "Số nợ cũ phải lớn hơn hoặc bằng 0!");
                                                        errorProvider.SetIconAlignment(noCuTextBox, ErrorIconAlignment.MiddleLeft);
                                                    }
                                                    else
                                                    {
                                                        result = true;
                                                    }
                                                }
                                            }
                                            catch
                                            {
                                                errorProvider.SetError(noCuTextBox, "Số nợ cũ phải là số nguyên!");
                                                errorProvider.SetIconAlignment(noCuTextBox, ErrorIconAlignment.MiddleLeft);
                                            }
                                        }
                                    }
                                }
                                catch
                                {
                                    errorProvider.SetError(heSoNhanTextBox, "Hệ số nhân phải là số nguyên!");
                                }
                            }
                        }
                        catch
                        {
                            errorProvider.SetError(soMoiTextBox, "Số công tơ mới phải là số nguyên!");
                        }
                    }
                }
                catch
                {
                    errorProvider.SetError(soCuTextBox, "Số công tơ cũ phải là số nguyên!");
                }
            }
            return result;
        }

        private void saveInvoice()
        {
            string mucDichID = "";
            if (poorRadioButton.Checked)
            {
                mucDichID = "a770acf2-0f54-43ce-8695-10c7c4072c64";
            }
            else if (lowIncomeRadioButton.Checked)
            {
                mucDichID = "7e17ce3d-ea0c-4a6a-9048-47c563991fd6";
            }
            else if (sinhHoatRadioButton.Checked)
            {
                mucDichID = "e00f133e-f43c-4dc5-8ebb-a747200416c9";
            }
            else if (hanhChinhRadioButton.Checked)
            {
                mucDichID = "068b5479-814c-4576-86ea-8684b07ffb4a";
            }
            else if (kinhDoanh1RadioButton.Checked)
            {
                mucDichID = "0cd8fc10-1369-4b21-9c59-806ada969bdb";
            }
            else if (kinhDoanh2RadioButton.Checked)
            {
                mucDichID = "3f4627cb-3ae3-4fcf-86e1-117b1dfcac4d";
            }
            else if (sanXuat1RadioButton.Checked)
            {
                mucDichID = "a8794644-b056-41dd-b515-bec60477947a";
            }
            else if (sanXuat2RadioButton.Checked)
            {
                mucDichID = "d4770373-51bb-4d7a-90d1-327c7043cdeb";
            }
            else if (sanXuat3RadioButton.Checked)
            {
                mucDichID = "422cf080-b750-411d-a895-9550b8950b66";
            }
            Invoice hd = new Invoice(hoaDonIDTextBox.Text, mucDichID.ToString(), int.Parse(soCuTextBox.Text), int.Parse(soMoiTextBox.Text), int.Parse(soCu2TextBox.Text), int.Parse(soMoi2TextBox.Text), int.Parse(heSoNhanTextBox.Text), int.Parse(noCuTextBox.Text), 0);
            if (hd.editHoaDon())
            {
                Customer kh = new Customer(soThuTuComboBox.SelectedValue.ToString(), tenKhachTextBox.Text, diaChiTextBox.Text, soHoKhauTextBox.Text, maSoThueTextBox.Text);
                if (kh.edit())
                {
                    mucDichIDTextBox.Text = mucDichID.ToString();
                    normalMode();
                }
                else
                {
                    MessageBox.Show("Sửa hóa đơn thất bại! Bạn hãy kiểm tra lại dữ liệu nhập vào.", "Sửa thông tin khách hàng thất bại!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("Sửa hóa đơn thất bại! Bạn hãy kiểm tra lại dữ liệu nhập vào.", "Sửa thông tin khách hàng thất bại!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void poorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (poorRadioButton.Checked == true)
            {
                hanhChinhRadioButton.Checked = false;
                kinhDoanh1RadioButton.Checked = false;
                kinhDoanh2RadioButton.Checked = false;
                sanXuat1RadioButton.Checked = false;
                sanXuat2RadioButton.Checked = false;
                sanXuat3RadioButton.Checked = false;
            }
        }

        private void lowIncomeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (lowIncomeRadioButton.Checked == true)
            {
                hanhChinhRadioButton.Checked = false;
                kinhDoanh1RadioButton.Checked = false;
                kinhDoanh2RadioButton.Checked = false;
                sanXuat1RadioButton.Checked = false;
                sanXuat2RadioButton.Checked = false;
                sanXuat3RadioButton.Checked = false;
            }
        }

        private void sinhHoatRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sinhHoatRadioButton.Checked == true)
            {
                hanhChinhRadioButton.Checked = false;
                kinhDoanh1RadioButton.Checked = false;
                kinhDoanh2RadioButton.Checked = false;
                sanXuat1RadioButton.Checked = false;
                sanXuat2RadioButton.Checked = false;
                sanXuat3RadioButton.Checked = false;
            }
        }

        private void hanhChinhRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (hanhChinhRadioButton.Checked == true)
            {
                poorRadioButton.Checked = false;
                lowIncomeRadioButton.Checked = false;
                sinhHoatRadioButton.Checked = false;
            }
        }

        private void kinhDoanh1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (kinhDoanh1RadioButton.Checked == true)
            {
                poorRadioButton.Checked = false;
                lowIncomeRadioButton.Checked = false;
                sinhHoatRadioButton.Checked = false;
            }
        }

        private void kinhDoanh2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (kinhDoanh2RadioButton.Checked == true)
            {
                poorRadioButton.Checked = false;
                lowIncomeRadioButton.Checked = false;
                sinhHoatRadioButton.Checked = false;
            }
        }

        private void sanXuat1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sanXuat1RadioButton.Checked == true)
            {
                poorRadioButton.Checked = false;
                lowIncomeRadioButton.Checked = false;
                sinhHoatRadioButton.Checked = false;
            }
        }

        private void sanXuat2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sanXuat2RadioButton.Checked == true)
            {
                poorRadioButton.Checked = false;
                lowIncomeRadioButton.Checked = false;
                sinhHoatRadioButton.Checked = false;
            }
        }

        private void sanXuat3RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sanXuat3RadioButton.Checked == true)
            {
                poorRadioButton.Checked = false;
                lowIncomeRadioButton.Checked = false;
                sinhHoatRadioButton.Checked = false;
                SX3Label.Text = "30% giá " + giaKD1Label.Text + ", 70% giá " + giaSX3Label.Text;
            }
            else
            {
                SX3Label.Text = "";
            }
        }

        private void autoIdentify()
        {
            try
            {
                int dienNangTT = Program.tinhDienNangTT(int.Parse(soMoiTextBox.Text), int.Parse(soCuTextBox.Text), int.Parse(soMoi2TextBox.Text), int.Parse(soCu2TextBox.Text), int.Parse(heSoNhanTextBox.Text));
                if (dienNangTT > 50)
                {
                    poorRadioButton.Enabled = false;
                    lowIncomeRadioButton.Enabled = false;
                    if (poorRadioButton.Checked == true || lowIncomeRadioButton.Checked == true)
                    {
                        poorRadioButton.Checked = false;
                        lowIncomeRadioButton.Checked = false;
                        sinhHoatRadioButton.Checked = true;
                    }
                }
                else
                {
                    poorRadioButton.Enabled = true;
                    lowIncomeRadioButton.Enabled = true;
                }
            }
            catch
            {

            }
        }

        private void soMoiTextBox_TextChanged(object sender, EventArgs e)
        {
            if (currentMode == "edit")
            {
                autoIdentify();
            }
        }
    }
}