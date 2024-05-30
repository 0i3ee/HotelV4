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
            BindingSource source = new BindingSource();
            ChangePrice(table);
            source.DataSource = table;
            dataGridReport.DataSource = source;
            bindingReport.BindingSource = source;
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
            chartReport.DataSource = source;
            chartReport.DataBind();
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
            table.Columns.Add("value_New", typeof(string));
            table.Columns.Add("rate_New", typeof(string));
            int sum = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                int node = ((int)table.Rows[i]["value"]);
                table.Rows[i]["value_New"] = node.ToString("C0", CultureInfo.CreateSpecificCulture("lo-LA"));
                table.Rows[i]["rate_New"] = (((double)table.Rows[i]["rate"]) / 100).ToString("#0.##%");
                sum += node;
            }
            table.Columns.Remove("value");
            DataRow row = table.NewRow();
            table.Columns["value_new"].ColumnName = "value";
            row["value"] = sum.ToString("C0", CultureInfo.CreateSpecificCulture("lo-LA"));
            table.Rows.Add(row);
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
    }
}
