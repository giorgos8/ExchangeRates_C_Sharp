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
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;

namespace Risko
{
    public partial class FormDbDoc : Form
    {
        SqlConnection cnn = null;
        string strServerName = null;
        string strDatabase = null;

        //string strKeyId = null;
        //int iKeyId = 0;

        string g_strExcelFileName = string.Empty;
        string g_strOutputFolderPath = string.Empty;

        public FormDbDoc()
        {
            cnn = FormDBConnection.cnn_global;
            strServerName = FormDBConnection.strServerName_global;
            strDatabase = FormDBConnection.strDatabase_global;

            InitializeComponent();
        }


        public FormDbDoc(string _strKeyId)
        {
            cnn = FormDBConnection.cnn_global;
            strServerName = FormDBConnection.strServerName_global;
            strDatabase = FormDBConnection.strDatabase_global;

            //strKeyId = _strKeyId;
            //iKeyId = Convert.ToInt32(strKeyId);

            InitializeComponent();
        }


        private void buttonExchangeRatesAPI_Click(object sender, EventArgs e)
        {
            // Run Python Program FormatExcel.py
            // https://www.youtube.com/watch?v=g1VWGdHRkHs

            string python_exe_path = Environment.GetEnvironmentVariable("exchange_rates_python_exe_path");
            string python_script_path = Environment.GetEnvironmentVariable("exchange_rates_python_script_path");

            // 1) Create Process Info
            var psi = new ProcessStartInfo();
            psi.FileName = python_exe_path; //@"C:\GIORGOS\Pythons\Python311\Python.exe";
            //psi.FileName = @"C:\GIORGOS\Pythons\Python311\Python.exe";

            // 2) Provide Script and Arguments
            var script = python_script_path; //@"C:\GIORGOS\ExchangeRates\ExchangeRates_Python\main.py";
            //var script = @"C:\GIORGOS\ExchangeRates\ExchangeRates_Python\main.py";

            //MessageBox.Show(python_exe_path);
            //MessageBox.Show(python_script_path);


            //============ Date From =============
            DateTime date_from = dt_from_date.Value.Date;
            string str_year_from = date_from.Year.ToString();
            string str_month_from = date_from.Month.ToString();
            if (str_month_from.Length == 1)
                str_month_from = "0" + str_month_from;

            string str_day_from = date_from.Day.ToString();
            if (str_day_from.Length == 1)
                str_day_from = "0" + str_day_from;

            string strDateFrom = str_year_from + "-" + str_month_from + "-" + str_day_from;

            //============ Date To =============
            DateTime date_to = dt_to_date.Value.Date;
            string str_year_to = date_to.Year.ToString();
            string str_month_to = date_to.Month.ToString();
            if (str_month_to.Length == 1)
                str_month_to = "0" + str_month_to;

            string str_day_to = date_to.Day.ToString();
            if (str_day_to.Length == 1)
                str_day_to = "0" + str_day_to;

            string strDateTo = str_year_to + "-" + str_month_to + "-" + str_day_to;

            //MessageBox.Show(strDateFrom);
            //MessageBox.Show(strDateTo);

            if (MessageBox.Show("Run API \nFrom: " + strDateFrom + "\nTo: " + strDateTo, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                //return;
                psi.Arguments = $"\"{script}\" \"{strDateFrom}\" \"{strDateTo}\"";

                // 3) Process Configuration
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;

                // Execute Process and Get Output
                var errors = "";
                var results = "";

                using (var process = Process.Start(psi))
                {
                    errors = process.StandardError.ReadToEnd();
                    results = process.StandardOutput.ReadToEnd();
                }

                MessageBox.Show("End, Please Check the results!");
            }


        }              
        
    }
}
