namespace Risko
{
    partial class FormDbDoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dt_to_date = new System.Windows.Forms.DateTimePicker();
            this.buttonExchangeRatesAPI = new System.Windows.Forms.Button();
            this.dt_from_date = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dt_to_date
            // 
            this.dt_to_date.Location = new System.Drawing.Point(346, 59);
            this.dt_to_date.Name = "dt_to_date";
            this.dt_to_date.Size = new System.Drawing.Size(275, 26);
            this.dt_to_date.TabIndex = 38;
            // 
            // buttonExchangeRatesAPI
            // 
            this.buttonExchangeRatesAPI.ForeColor = System.Drawing.Color.Blue;
            this.buttonExchangeRatesAPI.Location = new System.Drawing.Point(65, 106);
            this.buttonExchangeRatesAPI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonExchangeRatesAPI.Name = "buttonExchangeRatesAPI";
            this.buttonExchangeRatesAPI.Size = new System.Drawing.Size(556, 35);
            this.buttonExchangeRatesAPI.TabIndex = 36;
            this.buttonExchangeRatesAPI.Text = "Run API for Exchange Rates";
            this.buttonExchangeRatesAPI.UseVisualStyleBackColor = true;
            this.buttonExchangeRatesAPI.Click += new System.EventHandler(this.buttonExchangeRatesAPI_Click);
            // 
            // dt_from_date
            // 
            this.dt_from_date.Location = new System.Drawing.Point(65, 59);
            this.dt_from_date.Name = "dt_from_date";
            this.dt_from_date.Size = new System.Drawing.Size(275, 26);
            this.dt_from_date.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(342, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 39;
            this.label1.Text = "End Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "Start Date:";
            // 
            // FormDbDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 163);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dt_to_date);
            this.Controls.Add(this.buttonExchangeRatesAPI);
            this.Controls.Add(this.dt_from_date);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDbDoc";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Run API for Previous Range Dates";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonExchangeRatesAPI;
        private System.Windows.Forms.DateTimePicker dt_from_date;
        private System.Windows.Forms.DateTimePicker dt_to_date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}