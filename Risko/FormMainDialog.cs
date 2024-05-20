using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Data.OleDb;
using manolis;


namespace Risko
{
    public partial class FormMainDialog : Form
    {
        SqlConnection cnn = null;
        string strServerName = null;
        string strDatabase = null;
        string strDatabase_Sys = null;

        public FormMainDialog()
        {
            cnn = FormDBConnection.cnn_global;
            strServerName = FormDBConnection.strServerName_global;
            strDatabase = FormDBConnection.strDatabase_global;
            strDatabase_Sys = FormDBConnection.strSysDatabase_global;           

            InitializeComponent();
        }


        private void FormMainDialog_Load(object sender, EventArgs e)
        {

            this.Text = "DB Server: " + strServerName + " / Database Name: " + strDatabase + " / Sec DB: " + strDatabase_Sys;
            this.listViewMain.Dock = DockStyle.Fill;
            //this.treeViewMain.ExpandAll();
            //this.treeViewMain.Nodes[0].Expand(); // Expand only the first level
            //this.pictureBoxMain.Dock = DockStyle.Fill;                                    
            
        }


        private void treeViewMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string strSelectedNodeTag = treeViewMain.SelectedNode.Tag.ToString();

            //if (strSelectedNodeTag.Length == 3)
            //    this.pictureBoxMain.Visible = true;
            //else
            //    this.pictureBoxMain.Visible = false;

            string sql; 
            sql = string.Empty;
            

            listViewMain.Columns.Clear();
            listViewMain.Items.Clear();
            listViewMain.View = View.Details;
            listViewMain.GridLines = true;
            listViewMain.FullRowSelect = true;

            switch (strSelectedNodeTag)
            {
                case "000007001":
                    {
                        sql = String.Format
                        (
                            @"                                                                                           
                                select 
	                                cast(trc_run_id as varchar(10)) as trc_run_id,
	                                cast(trc_step_id as varchar(10)) as trc_step_id,
	                                trc_step_desc,
	                                trc_info,
	                                isnull(convert(varchar(30), trc_input_date, 103) + ' ' + convert(varchar(30), trc_input_date, 108), '') as trc_input_date,
	                                trc_user
                                from
	                                [dbo].[traces]
                                order by
	                                cast(trc_run_id as int) desc,
	                                trc_step_id asc
                            "
                        );

                        Clipboard.SetText(sql);
                        this.richTextBoxSQL.Text = sql;

                        FillList(strSelectedNodeTag, sql);
                        break;
                    }

                case "000007002":
                    {
                        sql = String.Format
                        (
                            @"                                                                                           
                                SELECT
	                                DATE,
                                    FROM_CURRENCY,
                                    TO_CURRENCY,
                                    EXCHANGE_RATE,
                                    INPUT_DATE
                                FROM
	                                [dbo].[VW_EXCHANGE_RATES_USD_MISSING_DATES]
                                ORDER BY
                                    DATE DESC
                            "
                        );

                        Clipboard.SetText(sql);
                        this.richTextBoxSQL.Text = sql;

                        FillList(strSelectedNodeTag, sql);
                        break;
                    }

                case "000007003":
                    {
                        sql = String.Format
                        (
                            @"
                                SELECT
	                                LEFT(CAST(MONTH AS VARCHAR(10)), 4) + '-' + RIGHT(CAST(MONTH AS VARCHAR(10)), 2) AS [MONTH],
	                                CAST(MIN_EXCHANGE_RATE AS VARCHAR(20)) AS MIN_EXCHANGE_RATE, 
	                                CAST(MAX_EXCHANGE_RATE AS VARCHAR(20)) AS MAX_EXCHANGE_RATE,
	                                CAST(AVG_EXCHANGE_RATE AS VARCHAR(20)) AS AVG_EXCHANGE_RATE
                                FROM
	                                [dbo].[VW_EXCHANGE_RATES_USD_STATISTICS]
                                ORDER BY
	                                [MONTH] DESC
                            "
                        );

                        Clipboard.SetText(sql);
                        this.richTextBoxSQL.Text = sql;

                        FillList(strSelectedNodeTag, sql);
                        break;
                    }

                case "002001":
                    {
                        sql =
                            @"
                               ;
                                with cte as
                                (
                                select
	                                cast(col.object_id as nvarchar(20)) as obj_id,
	                                sch.name + '.' + obj.name as table_name,
	                                cast(col.column_id as nvarchar(5)) as column_id,
	                                col.name as column_name,
	                                isnull(tps.name + 
		                                case 
			                                when tps.name = 'decimal' then ' (' + cast(col.precision as nvarchar(20)) + ', ' + cast(col.scale as nvarchar(20)) + ')' 
			                                when tps.name = 'nvarchar' then ' (' + cast(col.max_length/2 as nvarchar(20)) + ')' 
		                                else ''
	                                end, 'Unknown') as column_type,
	                                cast(col.precision as nvarchar(5)) as [precision],
	                                cast(col.scale as nvarchar(5)) as scale,
	                                iif(col.is_nullable = 0 , 'NO', 'YES') as allow_nulls,
	                                iif(col.is_identity = 1, 'YES', 'NO') as is_identity,
	                                iif(col.is_computed = 1, 'YES', 'NO') as is_computed,
									cast(col.max_length as nvarchar(10)) as max_byte_length,
									isnull(col.collation_name, '') as collation_name
                                from sys.columns col
                                inner join sys.objects obj
									on col.object_id = obj.object_id								
								INNER JOIN SYS.schemas sch
									on obj.schema_id = sch.schema_id
                                left join sys.types tps
                                on col.system_type_id = tps.user_type_id
                                where obj.type = 'U'
                                and obj.name <> 'sysdiagrams'
                                )
                                select * from cte
                                order by cte.table_name, cast(cte.column_id as int)
                            ";

                       
                        Clipboard.SetText(sql);
                        this.richTextBoxSQL.Text = sql;
                        FillList(strSelectedNodeTag, sql);

                        break;
                    }

                case "002002":
                    {
                        sql =
                            @"
                           select 
	                            cast(obj.object_id as nvarchar(20)) as object_id, 
	                            sch.name + '.' + obj.name as table_name, 
	                            isnull(inx.name, '') as index_name,
	                            iif(inx.is_unique = 0, 'NO', 'YES') as is_index_unique,
                                iif(inx.has_filter = 1, 'YES', 'NO') as has_filter,
	                            iif(inx.auto_created = 0, 'NO', 'YES') as index_auto_created,                                
	                            inx.type_desc as index_type_desc,
	                            iif(inx.is_primary_key = 1, 'YES', 'NO') as is_primary_key,
	                            iif(inx.is_unique_constraint = 1, 'YES', 'NO') as is_unique_key	                            
                            from sys.objects obj
								inner join sys.schemas sch
									on obj.schema_id = sch.schema_id
	                            inner join sys.indexes inx
	                            on obj.object_id = inx.object_id
                            where 
	                            1 = 1
	                            AND obj.type = 'U'
	                            and obj.name <> 'sysdiagrams'
                            order by 
	                            obj.name, inx.name                               

                            ";


                        Clipboard.SetText(sql);
                        this.richTextBoxSQL.Text = sql;
                        FillList(strSelectedNodeTag, sql);

                        break;
                    }

                case "002003":
                    {
                        sql =
                            @"
                               -- FOREIGN KEYS
                                with cte as
                                (
                                SELECT
	                                cast(frg.object_id as nvarchar(20)) as object_id,
	                                frg.name,
	                                frg.referenced_object_id,
	                                sch.name + '.' + obj.name as obj_name_ref,
                                    iif(frg.is_disabled = 1, 'YES', 'NO') as is_disabled
                                FROM SYS.foreign_keys frg
                                INNER JOIN SYS.objects obj
                                    on obj.object_id = frg.parent_object_id
                                inner join sys.schemas sch
									on sch.schema_id = obj.schema_id								
								 
                                )
                                select 
	                                cte.object_id as object_id,
	                                cte.name as table_name,
	                                cte.obj_name_ref as table_name,
	                                sch2.name + '.' + obj.name as ref_table_name,
                                    cte.is_disabled
                                from cte
                                inner join sys.objects obj
	                                on cte.referenced_object_id = obj.object_id
								inner join sys.schemas sch2
									on sch2.schema_id = obj.schema_id
                                order by 
	                                cte.name
                            ";


                        Clipboard.SetText(sql);
                        this.richTextBoxSQL.Text = sql;
                        FillList(strSelectedNodeTag, sql);

                        break;
                    }

                case "002004":
                    {
                        sql =
                            @"
                            -- DEFAULT CONSTRAINTS
                            select 
                            cast(obj.object_id as nvarchar(20)) as object_id,
                            dfl.type_desc,
                            dfl.name as constraint_name,
                            sch.name + '.' + obj.name as table_name,
                            dfl.definition
                            from 
                            sys.objects obj
                            inner join
                            sys.default_constraints dfl
	                            on obj.object_id = dfl.parent_object_id
							inner join sys.schemas sch
								on obj.schema_id = sch.schema_id

                            union

                            -- CHECK CONSTRAINTS
                            select 
	                            cast(obj.object_id as nvarchar(20)) as object_id,
	                            chk.type_desc,
	                            chk.name as constraint_name,
	                            sch.name + '.' + obj.name as table_name,
	                            chk.definition
                            from 
                            sys.objects obj
                            inner join
                            sys.check_constraints chk
                            on obj.object_id = chk.parent_object_id
							inner join sys.schemas sch
								on obj.schema_id = sch.schema_id
                            
							order by
	                            type_desc, table_name, dfl.name
                            ";


                        Clipboard.SetText(sql);
                        this.richTextBoxSQL.Text = sql;
                        FillList(strSelectedNodeTag, sql);

                        break;
                    }

                case "002005":
                    {
                        sql =
                            @"
                            SELECT
	                            cast(Tables.object_id as nvarchar(20)) as object_id,
	                            SCHEMA_NAME(schema_id) + '.' + Tables.[name] as table_name,
	                            cast(cast([create_date] as date) as nvarchar(10)) as cr_date,
	                            cast(cast([modify_date] as date) as nvarchar(10)) as mod_date,
	                            cast(SUM([Partitions].[rows]) as varchar(20)) AS [TotalRowCount]
                            FROM
	                            sys.tables AS [Tables]
	                            JOIN sys.partitions AS [Partitions]
	                            ON [Tables].[object_id] = [Partitions].[object_id]
	                            AND [Partitions].index_id IN ( 0, 1 )
                            WHERE
	                            [name] <> N'sysdiagrams'
                            GROUP BY 
	                            Tables.object_id,
	                            SCHEMA_NAME(schema_id) + '.' + Tables.[name],
	                            --SCHEMA_NAME(schema_id), [Tables].name, 	create_date,
	                            modify_date,
	                            create_date
                            ORDER BY
	                            SUM([Partitions].[rows]) DESC
                            ";


                        Clipboard.SetText(sql);
                        this.richTextBoxSQL.Text = sql;
                        FillList(strSelectedNodeTag, sql);

                        break;
                    }

                case "002006":
                    {
                        sql =
                            @"
                            select 
	                            ROUTINE_SCHEMA + '.' + ROUTINE_NAME, 
	                            ROUTINE_SCHEMA, 
	                            ROUTINE_TYPE,
	                            convert(nvarchar(100), CREATED, 103) as CREATED, 
	                            convert(nvarchar(100), LAST_ALTERED, 103) as LAST_ALTERED
                            from
	                            INFORMATION_SCHEMA.ROUTINES
                            where
	                            1 = 1
	                            --ROUTINE_TYPE = 'PROCEDURE'
	                            --and ROUTINE_NAME not like 'sp_%'
	                            --and ROUTINE_NAME not like 'fn_%'
                            order by
	                            ROUTINE_TYPE, ROUTINE_NAME asc
                            ";


                        Clipboard.SetText(sql);
                        this.richTextBoxSQL.Text = sql;
                        FillList(strSelectedNodeTag, sql);

                        break;
                    }

                case "002007":
                    {
                        sql =
                            @"
                                SELECT
	                                OBJECT_NAME(P.object_id) AS TableName,
	                                Resource_type,
	                                cast(request_session_id as nvarchar(10)) as request_session_id,
	                                request_owner_type
                                FROM
	                                sys.dm_tran_locks L
                                INNER join sys.partitions P
	                                ON L.resource_associated_entity_id = p.hobt_id
                            ";


                        Clipboard.SetText(sql);
                        this.richTextBoxSQL.Text = sql;
                        FillList(strSelectedNodeTag, sql);

                        break;
                    }
            }

            //this.richTextBoxSQL.Text = sql;
        }

        void FillList(string strSelectedNodeTag, string sql)
        {
            //ContextMenuStrip PopupMenu = null;

            this.listViewMain.CheckBoxes = false;
            
            SqlCommand command;
            SqlDataReader dr;

            int iRowCount = 0;            

            switch (strSelectedNodeTag)
            {                 
                
                case "000002":
                    {
                        listViewMain.ForeColor = System.Drawing.Color.Black;
                        listViewMain.Columns.Add("Report ID", 80, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Report Profile Name", 170, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Regulation", 150, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Currency", 100, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Country", 100, HorizontalAlignment.Left);
                        //listViewMain.Columns.Add("Approach", 220, HorizontalAlignment.Left);
                        //listViewMain.Columns.Add("Approach Group", 220, HorizontalAlignment.Left);
                        //listViewMain.Columns.Add("Beta Factor for Operational Risk", 220, HorizontalAlignment.Left);

                        command = new SqlCommand(sql, cnn);
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            string strReportProfileID = dr.GetString(0);
                            string strReportProfileName = dr.GetString(1);
                            string strReportRegulation = dr.GetString(2);
                            string strReportCurrency = dr.GetString(3);
                            string strReportCountry = dr.GetString(4);
                            //string strApproach = dr.GetString(5);
                            //string strApproachGroup = dr.GetString(6);
                            //string strBetaFactorSource = dr.GetString(7);

                            ListViewItem item = this.listViewMain.Items.Add(strReportProfileID, strReportProfileID);

                            item.ForeColor = Color.MediumBlue;
                            item.SubItems.Add(strReportProfileName);
                            item.SubItems.Add(strReportRegulation);
                            item.SubItems.Add(strReportCurrency);
                            item.SubItems.Add(strReportCountry);
                            //item.SubItems.Add(strApproach);
                            //item.SubItems.Add(strApproachGroup);
                            //item.SubItems.Add(strBetaFactorSource);

                            // this is very Important
                            // listViewMain.Items[0].UseItemStyleForSubItems = false;
                            // Now you can Change the Particular Cell Property of Style
                            // listViewMain.Items[0].SubItems[7].BackColor = Color.Green;

                            iRowCount++;
                        }

                        dr.Close();
                        command.Dispose();

                        break;
                    }

                case "000003":
                    {
                        listViewMain.ForeColor = System.Drawing.Color.Black;
                        listViewMain.Columns.Add("Entity ID", 80, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Entity Name", 600, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Level", 70, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("Group Entity Type", 150, HorizontalAlignment.Center);

                        command = new SqlCommand(sql, cnn);
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            string strEntityID = dr.GetString(0);
                            string strEntityName = dr.GetString(1);
                            string strEntityLevel = dr.GetString(2);
                            string strGroupEntityType = dr.GetString(3);

                            ListViewItem item = this.listViewMain.Items.Add(strEntityID, strEntityID);
                            item.ForeColor = Color.MediumBlue;
                            item.SubItems.Add(strEntityName);
                            item.SubItems.Add(strEntityLevel);
                            item.SubItems.Add(strGroupEntityType);

                            iRowCount++;
                        }

                        dr.Close();
                        command.Dispose();

                        break;
                    }                                


                case "000007001":
                    {
                        listViewMain.ForeColor = System.Drawing.Color.Black;
                        listViewMain.Columns.Add("run_id", 60, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("step_id", 60, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("step_desc", 200, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("info", 80, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("datetime", 130, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("user", 120, HorizontalAlignment.Left);


                        command = new SqlCommand(sql, cnn);
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            string str_run_id = dr.GetString(0);
                            string str_step_id = dr.GetString(1);
                            string str_step_desc = dr.GetString(2);
                            string str_info = dr.GetString(3);    
                            string str_input_date = dr.GetString(4);
                            string str_user = dr.GetString(5);


                            ListViewItem item = this.listViewMain.Items.Add(str_run_id, str_run_id);
                            item.ForeColor = Color.Blue;
                            item.SubItems.Add(str_step_id);
                            item.SubItems.Add(str_step_desc);
                            item.SubItems.Add(str_info);
                            item.SubItems.Add(str_input_date);
                            item.SubItems.Add(str_user);

                            if (str_info == "ERROR")
                                item.ForeColor = Color.Red;                         

                            iRowCount++;
                        }

                        dr.Close();
                        command.Dispose();

                        break;
                    }

                case "000007002":
                    {
                        listViewMain.ForeColor = System.Drawing.Color.Black;
                        listViewMain.Columns.Add("DATE", 80, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("FROM_CUR", 80, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("TO_CUR", 80, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("EXCHANGE_RATE", 120, HorizontalAlignment.Right);
                        listViewMain.Columns.Add("INPUT_DATE", 150, HorizontalAlignment.Center);


                        command = new SqlCommand(sql, cnn);
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            string str_date = dr.GetString(0);
                            string str_from_currency = dr.GetString(1);
                            string str_to_currency = dr.GetString(2);
                            string str_exchange_rate = dr.GetString(3);
                            string str_input_date = dr.GetString(4);

                            ListViewItem item = this.listViewMain.Items.Add(str_date, str_date);
                            item.ForeColor = Color.Blue;
                            item.SubItems.Add(str_from_currency);
                            item.SubItems.Add(str_to_currency);
                            item.SubItems.Add(str_exchange_rate);
                            item.SubItems.Add(str_input_date);

                            if (str_exchange_rate == "-")
                                item.ForeColor = Color.Red;

                            iRowCount++;
                        }

                        dr.Close();
                        command.Dispose();

                        break;
                    }

                case "000007003":
                    {
                        listViewMain.ForeColor = System.Drawing.Color.Black;
                        listViewMain.Columns.Add("MONTH", 80, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("MIN_RATE", 80, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("MAX_RATE", 80, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("AVG_RATE", 80, HorizontalAlignment.Center);

                        command = new SqlCommand(sql, cnn);
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            string str_month = dr.GetString(0);
                            string str_min_rate = dr.GetString(1);
                            string str_max_rate = dr.GetString(2);
                            string str_avg_rate = dr.GetString(3);

                            ListViewItem item = this.listViewMain.Items.Add(str_month, str_month);
                            item.ForeColor = Color.Blue;
                            item.SubItems.Add(str_min_rate);
                            item.SubItems.Add(str_max_rate);
                            item.SubItems.Add(str_avg_rate);

                            iRowCount++;
                        }

                        dr.Close();
                        command.Dispose();

                        break;
                    }


                case "002001":
                    {
                        listViewMain.ForeColor = System.Drawing.Color.Black;
                        listViewMain.Columns.Add("OBJ ID", 80, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Table Name", 300, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Column ID", 80, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Column Name", 200, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Column Type", 120, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Precision", 0, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("Scale", 0, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("Allow NULLs?", 80, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("Is Identity?", 80, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("Is Computed?", 80, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("Max Lenght Byte", 0, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("Collation Name", 100, HorizontalAlignment.Left);


                        command = new SqlCommand(sql, cnn);
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            string strID = dr.GetString(0);
                            string strTableName = dr.GetString(1);

                            string strColumnID = dr.GetString(2);
                            string strColumnName = dr.GetString(3);
                            string strColumnType = dr.GetString(4);
                            string strPrecision = dr.GetString(5);
                            string strScale = dr.GetString(6);
                            string strAllowNulls = dr.GetString(7);
                            string strIsIdentity = dr.GetString(8);
                            string strIsComputed = dr.GetString(9);
                            string strMaxLenght = dr.GetString(10);
                            string strCollation = dr.GetString(11);

                            ListViewItem item = this.listViewMain.Items.Add(strID, strID);
                            item.ForeColor = Color.MediumBlue;
                            item.SubItems.Add(strTableName);
                            item.SubItems.Add(strColumnID);
                            item.SubItems.Add(strColumnName);
                            item.SubItems.Add(strColumnType);
                            item.SubItems.Add(strPrecision);
                            item.SubItems.Add(strScale);
                            item.SubItems.Add(strAllowNulls);
                            item.SubItems.Add(strIsIdentity);
                            item.SubItems.Add(strIsComputed);
                            item.SubItems.Add(strMaxLenght);
                            item.SubItems.Add(strCollation);

                            iRowCount++;
                        }

                        dr.Close();
                        command.Dispose();

                        break;
                    }

                case "002002":
                    {
                        listViewMain.ForeColor = System.Drawing.Color.Black;
                        listViewMain.Columns.Add("Obect ID", 80, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Table Name", 300, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Index Name", 300, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Is Index Unique?", 100, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("Has Index Filter?", 100, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("Is Auto Created?", 100, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("Index Type Desc", 100, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Is Primary Key?", 100, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("Is Unique Key?", 100, HorizontalAlignment.Center);


                        command = new SqlCommand(sql, cnn);
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            string strID = dr.GetString(0);
                            string strTableName = dr.GetString(1);
                            string strIndexName = dr.GetString(2);
                            string strIsIndexUnique = dr.GetString(3);
                            string strHasIndexFilter = dr.GetString(4);
                            string strIsAutoCreated = dr.GetString(5);
                            string strIndexType = dr.GetString(6);
                            string strIsPrimaryKey = dr.GetString(7);
                            string strIsUniqueKey = dr.GetString(8);
                           
                            ListViewItem item = this.listViewMain.Items.Add(strID, strID);
                            item.ForeColor = Color.MediumBlue;
                            item.SubItems.Add(strTableName);
                            item.SubItems.Add(strIndexName);
                            item.SubItems.Add(strIsIndexUnique);
                            item.SubItems.Add(strHasIndexFilter);
                            item.SubItems.Add(strIsAutoCreated);
                            item.SubItems.Add(strIndexType);
                            item.SubItems.Add(strIsPrimaryKey);
                            item.SubItems.Add(strIsUniqueKey);

                            if (strIsAutoCreated == "YES" || strIndexType == "HEAP")
                                item.ForeColor = Color.Orange;

                            iRowCount++;
                        }

                        dr.Close();
                        command.Dispose();

                        break;
                    }

                case "002003":
                    {
                        ContextMenuStrip PopupMenu = null;
                        PopupMenu = new ContextMenuStrip();

                        //PopupMenu.BackColor = Color.OrangeRed;
                        //PopupMenu.ForeColor = Color.Black;
                        //PopupMenu.Text = "File Menu";
                        //PopupMenu.Font = new Font("Georgia", 12);
                        PopupMenu.Show();
                        //PopupMenu.Name = "PopupMenu";
                        // Create a Menu Item

                        ToolStripMenuItem FileMenuDisable = new ToolStripMenuItem();
                        FileMenuDisable.BackColor = Color.Red;
                        FileMenuDisable.ForeColor = Color.Black;
                        FileMenuDisable.Text = "Disable FK";
                        //FileMenu.Font = new Font("Georgia", 16);
                        //FileMenu.TextAlign = ContentAlignment.BottomRight;
                        FileMenuDisable.ToolTipText = "Disable FK ... (Not Drop FK!!!)";
                        //FileMenuDisable.Tag = false;
                        FileMenuDisable.Click += new System.EventHandler(this.FK_Disable_Click);
                        PopupMenu.Items.Add(FileMenuDisable);

                        ToolStripMenuItem FileMenuEnable = new ToolStripMenuItem();
                        FileMenuEnable.BackColor = Color.Green;
                        FileMenuEnable.ForeColor = Color.Black;
                        FileMenuEnable.Text = "Enable FK";
                        //FileMenuEnable.Font = new Font("Georgia", 16);
                        //FileMenuEnable.TextAlign = ContentAlignment.BottomRight;
                        FileMenuEnable.ToolTipText = "Enable FK... (Not Create FK)";
                        FileMenuEnable.Tag = true;
                        FileMenuEnable.Click += new System.EventHandler(this.FK_Enable_Click);                        
                        PopupMenu.Items.Add(FileMenuEnable);
                        
                        //================================
                        listViewMain.ContextMenuStrip = PopupMenu; 
                        
                        //this.listViewMain.CheckBoxes = true;  
                        listViewMain.ForeColor = System.Drawing.Color.Black;
                        listViewMain.Columns.Add("Obect ID", 100, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("FK Constraint Name", 500, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Table Name", 300, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Ref Table Name", 300, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Is Disable", 80, HorizontalAlignment.Center);

                        command = new SqlCommand(sql, cnn);
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            string strID = dr.GetString(0);
                            string strConstraintName = dr.GetString(1);
                            string strTableName = dr.GetString(2);
                            string strRefTableName = dr.GetString(3);
                            string strIs_FK_Disabled = dr.GetString(4);

                            ListViewItem item = this.listViewMain.Items.Add(strID, strID);
                            item.ForeColor = Color.MediumBlue;
                            item.SubItems.Add(strConstraintName);
                            item.SubItems.Add(strTableName);
                            item.SubItems.Add(strRefTableName);
                            item.SubItems.Add(strIs_FK_Disabled);

                            if(strIs_FK_Disabled == "YES")
                                item.ForeColor = Color.Red;

                            iRowCount++;
                        }

                        dr.Close();
                        command.Dispose();

                        //for (int i = 0; i < this.listViewMain.Items.Count; i++)
                        //{
                        //    this.listViewMain.Items[i].Checked = true;

                        //    if (this.listViewMain.Items[i].SubItems[4].Text == "YES")
                        //    {
                        //        this.listViewMain.Items[i].Checked = false;
                        //    }
                        //}

                        break;
                    }

                case "002004":
                    {
                        listViewMain.ForeColor = System.Drawing.Color.Black;
                        listViewMain.Columns.Add("Obect ID", 100, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Constraint Type", 150, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Constraint Name", 300, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Table Name", 300, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Definition", 700, HorizontalAlignment.Left);

                        command = new SqlCommand(sql, cnn);
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            string strID = dr.GetString(0);
                            string strConstraintType = dr.GetString(1);
                            string strConstraintName = dr.GetString(2);
                            string strTableName = dr.GetString(3);
                            string strDefinition = dr.GetString(4);

                            ListViewItem item = this.listViewMain.Items.Add(strID, strID);
                            item.ForeColor = Color.MediumBlue;
                            item.SubItems.Add(strConstraintType);
                            item.SubItems.Add(strConstraintName);
                            item.SubItems.Add(strTableName);
                            item.SubItems.Add(strDefinition);

                            if (strConstraintType == "CHECK_CONSTRAINT")
                                item.ForeColor = Color.BlueViolet;

                            iRowCount++;
                        }

                        dr.Close();
                        command.Dispose();

                        break;
                    }

                case "002005":
                    {
                        listViewMain.ForeColor = System.Drawing.Color.Black;
                        listViewMain.Columns.Add("Obect ID", 100, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Table Name", 250, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Create Date", 100, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("Modify Date", 100, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("Row Count", 100, HorizontalAlignment.Right);

                        command = new SqlCommand(sql, cnn);
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            string strID = dr.GetString(0);
                            string strTableName = dr.GetString(1);
                            string strCreateDate = dr.GetString(2);
                            string strModifyDate = dr.GetString(3);
                            string strRowCount = dr.GetString(4);

                            ListViewItem item = this.listViewMain.Items.Add(strID, strID);
                            item.ForeColor = Color.MediumBlue;
                            item.SubItems.Add(strTableName);
                            item.SubItems.Add(strCreateDate);
                            item.SubItems.Add(strModifyDate);
                            item.SubItems.Add(strRowCount);

                            

                            iRowCount++;
                        }

                        dr.Close();
                        command.Dispose();

                        break;
                    }

                case "002006":
                    {
                        listViewMain.ForeColor = System.Drawing.Color.Black;
                        listViewMain.Columns.Add("Routine", 400, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Schema", 100, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("Type", 100, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("Create Date", 150, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("Modify Date", 150, HorizontalAlignment.Center);                        

                        command = new SqlCommand(sql, cnn);
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            string strRoutine = dr.GetString(0);
                            string strSchema = dr.GetString(1);
                            string strType = dr.GetString(2);
                            string strCreateDate = dr.GetString(3);
                            string strModifyDate = dr.GetString(4);
                            
                            ListViewItem item = this.listViewMain.Items.Add(strRoutine, strRoutine);
                            item.ForeColor = Color.MediumBlue;
                            item.SubItems.Add(strSchema);
                            item.SubItems.Add(strType);
                            item.SubItems.Add(strCreateDate);
                            item.SubItems.Add(strModifyDate);                            

                            iRowCount++;
                        }

                        dr.Close();
                        command.Dispose();

                        break;
                    }

                case "002007":
                    {
                        listViewMain.ForeColor = System.Drawing.Color.Black;
                        listViewMain.Columns.Add("Table", 100, HorizontalAlignment.Left);
                        listViewMain.Columns.Add("Resource Type", 100, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("Req Session Id", 100, HorizontalAlignment.Center);
                        listViewMain.Columns.Add("Req Owner Type", 100, HorizontalAlignment.Center);

                        command = new SqlCommand(sql, cnn);
                        dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            string strRoutine = dr.GetString(0);
                            string strSchema = dr.GetString(1);
                            string strType = dr.GetString(2);
                            string strCreateDate = dr.GetString(3);

                            ListViewItem item = this.listViewMain.Items.Add(strRoutine, strRoutine);
                            item.ForeColor = Color.MediumBlue;
                            item.SubItems.Add(strSchema);
                            item.SubItems.Add(strType);
                            item.SubItems.Add(strCreateDate);

                            iRowCount++;
                        }

                        dr.Close();
                        command.Dispose();

                        break;
                    }
            }

            this.treeViewMain.SelectedNode.Text = this.treeViewMain.SelectedNode.Name + " (" + iRowCount.ToString() + ")";
        }

        private void listViewMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {            
            string strKeyID = listViewMain.SelectedItems[0].SubItems[0].Text;
            string strSecondColumn = listViewMain.SelectedItems[0].SubItems[1].Text;
            string strSelectedNodeTag = treeViewMain.SelectedNode.Tag.ToString();
        }        

        private void listViewMain_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            string strSelectedNodeTag = treeViewMain.SelectedNode.Tag.ToString();

            switch(strSelectedNodeTag)
            {
                case "002001":
                {
                    MessageBox.Show(e.Column.ToString());
                    break;
                }
            }
        }

        private void buttonRiskAvertDBDocumentation_Click(object sender, EventArgs e)
        {
            
        }

        private void Disable_FK(string strAction)
        {
            string sql = string.Empty;

            for (int i = 0; i < this.listViewMain.SelectedItems.Count; i++)
            {
                string strTable, strFK_Name = string.Empty;

                strTable = this.listViewMain.SelectedItems[i].SubItems[2].Text;
                strFK_Name = this.listViewMain.SelectedItems[i].SubItems[1].Text;

                MessageBox.Show(strTable);
                MessageBox.Show(strFK_Name);

                sql = String.Format(
                    @"ALTER TABLE {0} {1} CONSTRAINT [{2}]",
                    strTable,
                    strAction,
                    strFK_Name
                );


                MessageBox.Show(cnn.ConnectionString);
                MessageBox.Show(sql);

                //Clipboard.SetText(sqlProcesses);

                SqlCommand command = new SqlCommand(sql, cnn);
                command.ExecuteNonQuery();                
            }            
        }

        private void FK_Disable_Click(object sender, EventArgs e)
        {            
            string strSelectedNodeTag = treeViewMain.SelectedNode.Tag.ToString();

            switch (strSelectedNodeTag)
            {
                case "002003":
                    {
                        Disable_FK("NOCHECK");
                        break;
                    }
            }
        }

        private void FK_Enable_Click(object sender, EventArgs e)
        {
            string strSelectedNodeTag = treeViewMain.SelectedNode.Tag.ToString();

            switch (strSelectedNodeTag)
            {
                case "002003":
                    {
                        Disable_FK("CHECK");
                        break;
                    }
            }
        }              

               
      

        private void treeViewMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string strSelectedNodeTag = treeViewMain.SelectedNode.Tag.ToString();
            
            
        }

        private void listViewMain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        
        private void buttonDbDocumentation_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(strKeyID);
            FormDbDoc DbDocDlg = new FormDbDoc();
            DialogResult dbDocResult = DbDocDlg.ShowDialog();

            //this.pictureBoxMain.Visible = false;
            //listViewMain.Columns.Clear();
            //listViewMain.Items.Clear();
            //listViewMain.View = View.Details;
            //listViewMain.GridLines = true;
            //listViewMain.FullRowSelect = true;
            //FillList(strSelectedNodeTag, sqlNsfrRsf);

            //ExportDbDocToExcel();
        }

        private void listViewMain_KeyDown(object sender, KeyEventArgs e)
        {
            string strSelectedNodeTag = treeViewMain.SelectedNode.Tag.ToString();


            switch (strSelectedNodeTag)
            {               

                case "002007":
                    {                        
                        if (Keys.K == e.KeyCode)
                        {
                            DialogResult result = MessageBox.Show("Do you want to Kill this Process?", "Kill", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            if (result.Equals(DialogResult.OK))
                            {
                                foreach (ListViewItem listViewItem in ((ListView)sender).SelectedItems)
                                {
                                    //MessageBox.Show(listViewItem.SubItems[2].Text);
                                    
                                    string sql = string.Empty;
                                    SqlCommand command = null;

                                    // Delete from menus
                                    sql = String.Format
                                    (
                                        @"
                                            Kill {0}
                                        ",
                                        listViewItem.SubItems[2].Text
                                    );

                                    command = new SqlCommand(sql, cnn);
                                    command.ExecuteNonQuery();                                    
                                    
                                }


                                MessageBox.Show("Refresh the Lock List!");
                                //Clipboard.SetText(sqlLocks);
                                //FillList(strSelectedNodeTag, sqlLocks);
                            }
                        }
                        break;
                    }
            }
        }

        private void transferScemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        
    }
}
