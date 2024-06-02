using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;

using HotelV4.aclass;
using HotelV4.bclass;

namespace HotelV4
{
  
    public partial class service_payment : Form
    {
        string staffSetUp;
        int id = 1;
        int totalPrice = 0;
        public service_payment(string username)
        {
            InitializeComponent();
            FormMover.Moveform(this);
            staffSetUp = username;
            LoadData();
        }
        private void LoadData()
        {
            LoadListServiceType();
            LoadListRoomType();
            LoadListFullRoom();
        }
        public void Pay(int idBill, int discount)
        {
            BillDAO.Instance.UpdateRoomPrice(idBill);
            BillDAO.Instance.UpdateServicePrice(idBill);
            BillDAO.Instance.UpdateOther(idBill, discount);

        }
        public void LoadListRoomType()
        {
            List<RoomType> roomTypes = RoomTypeDAO.Instance.LoadListRoomType();    
        }
        public void LoadListServiceType()
        {
            cbServiceType.DataSource = ServiceTypeDAO.Instance.GetServiceTypes();
            cbServiceType.DisplayMember = "Name";
        }
        public void LoadListService(int idServiceType)
        {
            cbService.DataSource = ServiceDao.Instance.GetServices(idServiceType);
            cbService.DisplayMember = "Name";
        }
        public void DrawControl(Room room,Button button)
        {
            int idRoomTypeName = RoomTypeDAO.Instance.GetRoomTypeByIdRoom(room.Id).Id;
            switch (idRoomTypeName)
            {
                case 1:
                    {
                        button.BackColor = System.Drawing.Color.Tomato;
                        break;
                    }
                case 2:
                    {
                        button.BackColor = System.Drawing.Color.Violet;
                        break;
                    }
                case 3:
                    {
                        button.BackColor = System.Drawing.Color.DeepSkyBlue;
                        break;
                    }
                case 4:
                    {
                        button.BackColor = System.Drawing.Color.LimeGreen;
                        break;
                    }
                default:
                    {
                        button.BackColor = System.Drawing.Color.Gray;
                        break;
                    }
            }
        }

        public void LoadListFullRoom()
        {
            flowLayoutRooms.Controls.Clear();
            listViewBillRoom.Items.Clear();
            listViewUseService.Items.Clear();
            List<Room> rooms = RoomDAO.Instance.LoadListFullRoom();
            foreach (Room item in rooms)
            {
                Button button = new Button();
                button.Font = new Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                button.ForeColor = Color.Black;
                button.Size = new Size(95, 85);
                button.Margin = new Padding(1, 1, 1, 1);

                button.Tag = item;
                button.Text = item.Name;
                button.Click += Button_Click;

                DrawControl(item, button);

                flowLayoutRooms.Controls.Add(button);

                //BillDAO.Instance.UpdateRoomPrice(item.Id);
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            listViewBillRoom.Items.Clear();
            totalPrice = 0;
            Button button = sender as Button;
            flowLayoutRooms.Tag = button.Tag;
            button.BackColor = Color.SeaGreen;
            foreach (var item in flowLayoutRooms.Controls)
            {
                if (item != button)
                    DrawControl((item as Button).Tag as Room, item as Button);
            }
            Room room = button.Tag as Room;
            ShowBill(room.Id);
            if (!BillDAO.Instance.IsExistsBill(room.Id))
            {
                int idReceiveRoom = check_inb.Instance.GetIdReceiveRoomFromIdRoom(room.Id);
                InsertBill(idReceiveRoom, staffSetUp);
            }
            BillDAO.Instance.UpdateRoomPrice(BillDAO.Instance.GetIdBillFromIdRoom(room.Id));
            ShowBillRoom(room.Id);

            txbTotalPrice.Text = totalPrice.ToString("c0", new CultureInfo("lo-la"));
        }

        public bool IsExistsBill(int idRoom)
        {
            return BillDAO.Instance.IsExistsBill(idRoom);
        }
        public bool IsExistsBillDetails(int idRoom, int idService)
        {
            return BillDetailb.Instance.IsExistsBillDetails(idRoom, idService);
        }
        public bool InsertBill(int idReceiveRoom, string staffSetUp)
        {
            return BillDAO.Instance.InsertBill(idReceiveRoom, staffSetUp);
        }
        public bool InsertBillDetails(int idBill, int idService, int count)
        {
            return BillDetailb.Instance.InsertBillDetails(idBill, idService, count);
        }
        public bool UpdateBillDetails(int idBill, int idService, int _count)
        {
            return BillDetailb.Instance.UpdateBillDetails(idBill, idService, _count);
        }
        public void AddBill(int idRoom, int idService, int count)
        {
            if (IsExistsBill(idRoom))
            {
                if (!IsExistsBillDetails(idRoom, idService))
                {
                    if (count > 0)
                    {
                        int idBill = BillDAO.Instance.GetIdBillFromIdRoom(idRoom);
                        InsertBillDetails(idBill, idService, count);
                    }
                    else
                       MessageBox.Show(this, "Invalid quantity.\nPlease re-enter.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int idBill = BillDAO.Instance.GetIdBillFromIdRoom(idRoom);
                    UpdateBillDetails(idBill, idService, count);
                }
            }
            else
            {
                if (count > 0)
                {
                    int idReceiveRoom = check_inb.Instance.GetIdReceiveRoomFromIdRoom(idRoom);
                    InsertBill(idReceiveRoom, staffSetUp);
                    int idBill = BillDAO.Instance.GetIdBillMax();
                    InsertBillDetails(idBill, idService, count);
                }
                else
                    MessageBox.Show(this, "Invalid quantity.\nPlease re-enter.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ShowBill(int idRoom)
        {
            listViewUseService.Items.Clear();
            DataTable dataTable = BillDAO.Instance.ShowBill(idRoom);
            CultureInfo cultureInfo = new CultureInfo("lo-la");
            int _totalPrice = 0;
            foreach (DataRow item in dataTable.Rows)
            {
                ListViewItem listViewItem = new ListViewItem(id.ToString());
                id++;

                ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem(listViewItem, item["Service name"].ToString());
                ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Unit price"]).ToString("c0", cultureInfo));
                ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Quantity"]).ToString());
                ListViewItem.ListViewSubItem subItem4 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Total Price"]).ToString("c0", cultureInfo));


                _totalPrice += (int)item["Total Price"];

                listViewItem.SubItems.Add(subItem1);
                listViewItem.SubItems.Add(subItem2);
                listViewItem.SubItems.Add(subItem3);
                listViewItem.SubItems.Add(subItem4);

                listViewUseService.Items.Add(listViewItem);
            }
            totalPrice += _totalPrice;

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

        public void ShowBillRoom(int idRoom)
        {
            CultureInfo cultureInfo = new CultureInfo("lo-LA");
            listViewBillRoom.Items.Clear();
            if (IsExistsBill(idRoom))
            {
                DataRow data = BillDAO.Instance.ShowBillRoom(idRoom);

                ListViewItem listViewItem = new ListViewItem(data["Room name"].ToString());

                ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem(listViewItem, ((int)data["Unit price"]).ToString("c0", cultureInfo));
                ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem(listViewItem, ((DateTime)data["Check-in Date"]).ToString().Split(' ')[0]);
                ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem(listViewItem, ((DateTime)data["Check-out Date"]).ToString().Split(' ')[0]);
                ListViewItem.ListViewSubItem subItem4 = new ListViewItem.ListViewSubItem(listViewItem, ((int)data["Room charge"]).ToString("c0", cultureInfo));
                
                totalPrice = (int)data["Room charge"];

                listViewItem.SubItems.Add(subItem1);
                listViewItem.SubItems.Add(subItem2);
                listViewItem.SubItems.Add(subItem3);
                listViewItem.SubItems.Add(subItem4);


                listViewBillRoom.Items.Add(listViewItem);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadListService((cbServiceType.SelectedItem as ServiceType).Id);
        }

        private void cbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = new CultureInfo("lo-LA");
            if (cbService.SelectedItem != null)
                txbPrice.Text = (cbService.SelectedItem as Service).Price.ToString("c0", cultureInfo);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            totalPrice = 0;
            Room room = flowLayoutRooms.Tag as Room;
            AddBill(room.Id, (cbService.SelectedItem as Service).Id, int.Parse(nrudDiscout.Value.ToString()));
            ShowBill(room.Id);
            nrudQty.Value = 1;

            ShowBillRoom(room.Id);
            txbTotalPrice.Text = totalPrice.ToString("c0", new CultureInfo("lo-LA"));
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            Room room = flowLayoutRooms.Tag as Room;
            if (MessageBox.Show("Are you sure to pay for it? " + room.Name + " Are not?", "Result", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int idBill = BillDAO.Instance.GetIdBillFromIdRoom(room.Id);
                Pay(idBill, int.Parse(nrudDiscout.Value.ToString()));
                ReportDAO.Instance.InsertReport(idBill);
                MessageBox.Show("Payment success!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                fPrintBill fPrintBill = new fPrintBill(room.Id, idBill);
                fPrintBill.ShowDialog();
                this.Show();
                LoadListFullRoom();
                listViewBillRoom.Items.Clear();
                listViewUseService.Items.Clear();
            }
        }
    }
}
