using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelV4.aclass;
using HotelV4.bclass;
using System.Globalization;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace HotelV4
{
    public partial class fPrintBill : Form
    {
        public fPrintBill()
        {
            InitializeComponent();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }
        public void SetPrintBill(int idBill, string dateOfCreate)
        {
            ShowBillPreView(idBill);
            ShowInfo(idBill);
            lblIDBill.Text = idBill.ToString();
            lblDateCreate.Text = dateOfCreate;
            lblStaffSetUp.Text = AccountB.Instance.GetStaffSetUp(idBill).DisplayName;
        }
        public fPrintBill(int idRoom, int idBill)
        {
            InitializeComponent();
            ShowBillPreView(idBill);
            ShowInfo(idBill);
            lblIDBill.Text = idBill.ToString();
            lblDateCreate.Text = DateTime.Now.ToString();
            lblStaffSetUp.Text = AccountB.Instance.GetStaffSetUp(idBill).DisplayName;
        }
        int id = 0;
        public void ShowBillPreView(int idBill)
        {
            listViewUseService.Items.Clear();
            DataTable dataTable = BillDAO.Instance.ShowBillPreView(idBill);
            CultureInfo cultureInfo = new CultureInfo("lo-LA");
            int _totalPrice = 0;
            foreach (DataRow item in dataTable.Rows)
            {
                ListViewItem listViewItem = new ListViewItem(id.ToString());
                id++;

                ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem(listViewItem, item["Tên dịch vụ"].ToString());
                ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Đơn giá"]).ToString("c0", cultureInfo));
                ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Số lượng"]).ToString());
                ListViewItem.ListViewSubItem subItem4 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Thành tiền"]).ToString("c0", cultureInfo));


                _totalPrice += (int)item["Thành tiền"];

                listViewItem.SubItems.Add(subItem1);
                listViewItem.SubItems.Add(subItem2);
                listViewItem.SubItems.Add(subItem3);
                listViewItem.SubItems.Add(subItem4);

                listViewUseService.Items.Add(listViewItem);
            }

            ListViewItem listViewItemTotalPrice = new ListViewItem();
            ListViewItem.ListViewSubItem subItemTotalPrice = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, _totalPrice.ToString("c0", cultureInfo));
            ListViewItem.ListViewSubItem _subItem1 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
            ListViewItem.ListViewSubItem _subItem2 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
            ListViewItem.ListViewSubItem _subItem3 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
            listViewItemTotalPrice.SubItems.Add(_subItem1);
            listViewItemTotalPrice.SubItems.Add(_subItem2);
            listViewItemTotalPrice.SubItems.Add(_subItem3);
            listViewItemTotalPrice.SubItems.Add(subItemTotalPrice);
            listViewUseService.Items.Add(listViewItemTotalPrice);

            id = 1;
        }
        public bool IsExistsBill(int idRoom)
        {
            return BillDAO.Instance.IsExistsBill(idRoom);
        }
        public void ShowInfo(int idBill)
        {
            string query = "USP_ShowBillInfo @idBill";
            DataRow data = cdb.Instance.ExecuteQuery(query, new object[] { idBill }).Rows[0];
            CultureInfo cultureInfo = new CultureInfo("lo-LA");
            lblCustomerName.Text = data["HoTen"].ToString();
            lblIDCard.Text = data["CMND"].ToString();
            lblPhoneNumber.Text = ((int)data["SDT"]).ToString();
            lblCustomerTypeName.Text = data["LoaiKH"].ToString();
            lblAddress.Text = data["DiaChi"].ToString();
            lblNationality.Text = data["QuocTich"].ToString();
            lblRoomName.Text = data["TenPhong"].ToString();
            lblRoomTypeName.Text = data["LoaiPhong"].ToString();
            lblRoomPrice_.Text = ((int)data["DonGia"]).ToString("c0", cultureInfo);
            lblDateCheckIn.Text = ((DateTime)data["NgayDen"]).ToString().Split(' ')[0];
            DateTime dateCheckIn = (DateTime)data["NgayDen"];
            DateTime dateCheckOut = (DateTime)data["NgayDi"];
            int days = dateCheckOut.Subtract(dateCheckIn).Days;
            lblDays.Text = days.ToString();
            lblPeoples.Text = RoomDAO.Instance.GetPeoples(idBill).ToString();
            lblSurcharge.Text = ((int)data["PhuThu"]).ToString("c0", cultureInfo);
            lblServicePrice.Text = ((int)data["TienDichVu"]).ToString("c0", cultureInfo);
            lblRoomPrice.Text = ((int)data["TienPhong"]).ToString("c0", cultureInfo);
            lblTotalPrice.Text = ((int)data["ThanhTien"]).ToString("c0", cultureInfo);
            lblFinalPrice.Text = ((int)data["ThanhTien"] * ((100 - (int)data["GiamGia"]) / 100.0)).ToString("c0", cultureInfo);
            lblDiscount.Text = ((int)data["GiamGia"]).ToString() + " %";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private Bitmap bitmap;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (Graphics graphics = this.CreateGraphics())
            {
                bitmap = new Bitmap(708, 647, graphics);
                using (Graphics _graphics = Graphics.FromImage(bitmap))
                {
                    _graphics.CopyFromScreen(this.Location.X, this.Location.Y + 28, 0, 0, new Size(708, 647));
                }
                string filePath = Application.StartupPath + @"\Bill.png";
                bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                bitmap = new Bitmap(filePath);
            }

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
