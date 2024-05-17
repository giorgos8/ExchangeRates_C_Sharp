using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Risko
{
    public partial class FormLinks : Form
    {
        public FormLinks()
        {
            InitializeComponent();
        }

        private void FormLinks_Load(object sender, EventArgs e)
        {
            //if (Environment.MachineName != "GS01072")
            //{
            //    this.groupBox_Attica.Visible = false;
            //    this.groupBox_Diafora.Visible = false;
            //}
        }

        private void buttonFortiClient_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Program Files\Fortinet\FortiClient\FortiClient VPN\FortiClient.exe");
        }

        private void buttonRMDAttica_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\GKOKKINOS\AppData\Roaming\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\Remote Desktop Connection.lnk");
        }

        private void linkLabel_Attica_UI_URL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button_RMD_Attica_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\GKOKKINOS\AppData\Roaming\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\Remote Desktop Connection.lnk");
        }

        private void linkLabel_UAT_URL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            System.Diagnostics.Process.Start(@"\\profiledomain\RiskShared\02 Projects\Attica Bank");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void linkLabel_Attica_UI_URL_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void buttonFortiiClient_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\FortiClient VPN\FortiClient.exe");
        }

        private void buttonRMD_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(@"Remote Desktop Connection.lnk");
        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
            
        private void linkLabel3_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel3.LinkVisited = true;
            System.Diagnostics.Process.Start("http://confluencesrv:3028/secure/Dashboard.jspa");
        }

        private void linkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel4.LinkVisited = true;
            System.Diagnostics.Process.Start("https://bitbucket.org/account/workspaces/");
        }

        private void linkReportServer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkReportServer.LinkVisited = true;
            System.Diagnostics.Process.Start("http://dboltp/Reports/browse/");
        }

        private void linkLabel_elearning_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel_elearning.LinkVisited = true;
            System.Diagnostics.Process.Start("https://ambience.e-academe.gr/index");
        }

        private void linkLabel5_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel5.LinkVisited = true;
            System.Diagnostics.Process.Start(@"\\lawoffice\Applications\Other\MIS APPLICATIONS\IMS");
        }

        private void linkLabel6_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel6.LinkVisited = true;
            System.Diagnostics.Process.Start(@"https://github.com/login");
        }

        private void linkLabel7_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel3.LinkVisited = true;
            System.Diagnostics.Process.Start("http://helpdesksrv2:3032/HomePage.do?view_type=my_view");
        }

        private void linkLabel8_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel8.LinkVisited = true;
            System.Diagnostics.Process.Start(@"\\lawoffice\applications\MIS_Access");
        }             
       

        private void linkLabel12_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel12.LinkVisited = true;
            System.Diagnostics.Process.Start("https://ambience.atlassian.net/jira/your-work");
        }

        private void linkLabel13_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel13.LinkVisited = true;
            System.Diagnostics.Process.Start(@"\\lawoffice\GSLODocuments\InformationTechnology_Division\13.IT_Applications\13.1.Common\");
        }

       

      
        private void linkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel17.LinkVisited = true;
            System.Diagnostics.Process.Start("https://bteam.benefit.gr/");
        }

        private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel18.LinkVisited = true;
            System.Diagnostics.Process.Start("https://join.skype.com/C81tZ7U8CC3X");
        }

        private void linkLabel5_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel5.LinkVisited = true;
            System.Diagnostics.Process.Start("https://dev.azure.com/");
        }

        private void linkLabel9_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel9.LinkVisited = true;
            System.Diagnostics.Process.Start(@"\\192.168.0.212\Development Recordings\DB Dev\Auto Replication Training");
        }

        private void linkLabel11_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel11.LinkVisited = true;
            System.Diagnostics.Process.Start(@"https://dev.azure.com/BenefitSoftwareDatabases/ERP%20Replication/_wiki/wikis/ERP-Replication.wiki/455/Internal-Processes");
        }

        private void linkLabel14_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel14.LinkVisited = true;
            System.Diagnostics.Process.Start(@"W:\DB Dev");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start(@"\\192.168.0.212\Development Recordings\Business Modules");
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel2.LinkVisited = true;
            System.Diagnostics.Process.Start(@"https://custs.benefit.gr//hardware");
        }
    }
}
