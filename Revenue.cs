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
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;


namespace HotelV4
{
    public partial class Revenue : Form
    {
        

        private int month = 1;
        private int year = 1990;
        
        public Revenue()
        {
            InitializeComponent();
            FormMover.Moveform(this);
            savereport = new SaveFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx|PDF Files|*.pdf|All Files|*.*",
                Title = "Save Report",
                DefaultExt = "xls",
                InitialDirectory = @"M:\NUOL\py3\report3" // Set your desired initial directory here
            };
            
            
        }
        private void LoadFullReport(int month, int year)
        {
            this.month = month;
            this.year = year;
            DataTable table = GetFulReport(month, year);
            ChangePrice(table);

            // Debug: Print DataTable contents


            BindingSource source = new BindingSource
            {
                DataSource = table
            };

            dataGridReport.DataSource = source;
            bindingReport.BindingSource = source;

            // Set the header text for the value_Display column
            dataGridReport.Columns["value_Display"].HeaderText = "Revenue";
            dataGridReport.Columns["value_Display"].Width = 250;

            dataGridReport.Columns["rate"].Visible = false;
            DrawChart(source);
            GC.Collect();
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadFullReport(int.Parse(comboBoxMonth.Text), (int)(numericYear.Value));
        }
        private DataTable GetFulReport(int month, int year)
        {
            return ReportDAO.Instance.LoadFullReport(month, year);
        }
        private void DrawChart(BindingSource source)
        {
            chartReport.Series.Clear(); // Clear any existing series

            Series series = new Series
            {
                XValueMember = "name", // Set X value member to 'name'
                YValueMembers = "value", // Set Y value member to numeric 'value'
                ChartType = SeriesChartType.Column // Choose the type of chart you want
                
            };

            chartReport.Series.Add(series);
            chartReport.DataSource = source;
            chartReport.DataBind();

 

            // Debugging: Log the series points
            foreach (DataPoint item in chartReport.Series[0].Points)
            {
                if (item.YValues[0] == 0)
                {
                    item.Label = " ";
                }
            }
        }
        

        private void ChangePrice(DataTable table)
        {
            table.Columns.Add("value_Display", typeof(string));
            
            int sum = 0;

            foreach (DataRow row in table.Rows)
            {
                int value = Convert.ToInt32(row["value"]);
                row["value_Display"] = value.ToString("C0", CultureInfo.CreateSpecificCulture("lo-LA"));
                
                sum += value;
            }

            DataRow totalRow = table.NewRow();
            totalRow["name"] = "Total";
            totalRow["value"] = sum; // Keep as numeric
            totalRow["value_Display"] = sum.ToString("C0", CultureInfo.CreateSpecificCulture("lo-LA"));
            table.Rows.Add(totalRow);
        }





        private void Revenue_Load(object sender, EventArgs e)
        {
            LoadFullReport(DateTime.Now.Month, DateTime.Now.Year);
            comboBoxMonth.Text = DateTime.Now.Month.ToString();
            numericYear.Value = DateTime.Now.Year;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            savereport.InitialDirectory = @"M:\NUOL\py3\report3";
            savereport.FileName = "Monthly revenue " + month + '-' + year;
            if (savereport.ShowDialog() == DialogResult.Cancel)
                return;
            else
            {
                bool check;
                try
                {
                    switch (savereport.FilterIndex)
                    {
                        case 2:
                            check = ExportToExcel.Instance.Export(dataGridReport, savereport.FileName, ModeExportToExcel.XLSX);
                            break;
                        case 3:
                            check = ExportToExcel.Instance.Export(dataGridReport, savereport.FileName, ModeExportToExcel.PDF);
                            break;
                        default:
                            check = ExportToExcel.Instance.Export(dataGridReport, savereport.FileName, ModeExportToExcel.XLS);
                            break;
                    }
                    if (check)
                        MessageBox.Show("Export successful", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Export failed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Error (Need to install Office)", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chartReport_Click(object sender, EventArgs e)
        {

        }
    }
}
