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
namespace HotelV4
{
    public partial class AddService : Form
    {
        public AddService()
        {
            InitializeComponent();
            LoadFullServiceType();
            txtPrice.Text = IntToString("100000");
        }
        

        private void LoadFullServiceType()
        {
            DataTable table = GetFullServiceType();
            cbtypeservice.DataSource = table;
            cbtypeservice.DisplayMember = "name";
            
            if (table.Rows.Count > 0)
                cbtypeservice.SelectedIndex = 0;
        }
        private DataTable GetFullServiceType()
        {
            return ServiceTypeDAO.Instance.LoadFullServiceType();
        }
        private Service GetServiceNow()
        {
            Service service = new Service();
            txtservicename.Text = txtservicename.Text.Trim();
            service.Name = txtservicename.Text;
            service.Price = int.Parse(StringToInt(txtPrice.Text));
            int index = cbtypeservice.SelectedIndex;
            service.IdServiceType = (int)((DataTable)cbtypeservice.DataSource).Rows[index]["id"];
            return service;
        }
        private void ChangePrice(DataTable table)
        {
            table.Columns.Add("price_New", typeof(string));
            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["price_New"] = ((int)table.Rows[i]["price"]).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
            }
        }
        private string StringToInt(string text)
        {
            if (text.Contains(".") || text.Contains(" "))
            {
                string[] vs = text.Split(new char[] { '.', ' ' });
                StringBuilder textNow = new StringBuilder();
                for (int i = 0; i < vs.Length - 1; i++)
                {
                    textNow.Append(vs[i]);
                }
                return textNow.ToString();
            }
            else return text;
        }
        private string IntToString(string text)
        {
            if (text == string.Empty)
                return 0.ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
            if (text.Contains(".") || text.Contains(" "))
                return text;
            else
                return (int.Parse(text).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN")));
        }
        private DataTable RemoveDuplicates(DataTable table, params string[] keyColumns)
        {
            return table.DefaultView.ToTable(true, keyColumns);
        }

        private void InsertService()
        {
            if (!fCustomer.CheckFillInText(new Control[] { txtservicename, cbtypeservice, txtPrice }))
            {
                DialogResult result = MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Service serviceNow = GetServiceNow();
                if (ServiceDao.Instance.InsertService(serviceNow))
                {
                    MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtservicename.Text = string.Empty;
                    txtPrice.Text = IntToString("100000");
                }
                else
                    MessageBox.Show("Dịch vụ đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm mới dịch vụ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                InsertService();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPrice_Enter(object sender, EventArgs e)
        {
            txtPrice.Tag = txtPrice.Text;
            txtPrice.Text = StringToInt(txtPrice.Text);
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            if (txtPrice.Text == string.Empty)
                txtPrice.Text = txtPrice.Tag as string;
            else
                txtPrice.Text = IntToString(txtPrice.Text);
        }
    }
}
