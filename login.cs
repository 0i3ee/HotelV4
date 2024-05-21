using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace HotelV4
{
    public partial class login : Form
    {
        
        public login()
        {
            InitializeComponent();
        }
        ClassconnectDB cdb = new ClassconnectDB();
        SqlDataReader dr;

        private void login_Load(object sender, EventArgs e)
        {
            cdb.connectDatabase();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private string GetMd5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string hashedPassword = GetMd5Hash(password);

            try
            {
                cdb.cmd = new SqlCommand("SELECT * FROM Staff WHERE UserName = @username AND PassWord = @password", cdb.conn);
            {
                // Using parameterized query properly
                cdb.cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar)).Value = username;
                cdb.cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar)).Value = hashedPassword;

                using (SqlDataReader dr = cdb.cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        this.Hide();
                        menu frm = new menu();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("ຊື່ຜູ້ໃຊ້ແລະລະຫັດຜ່ານບໍ່ຖືກຕ້ອງ", "ຜົນການກວດສອບ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUsername.Focus();
                    }
                }
            }


        }
            catch(Exception ex)
            {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ"+ex, "ການກວດສອບ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
}

        private void lbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
