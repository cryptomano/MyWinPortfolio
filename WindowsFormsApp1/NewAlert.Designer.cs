namespace WindowsFormsApp1
{
    partial class NewAlert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewAlert));
            this.lblAlertTitle = new MetroFramework.Controls.MetroLabel();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtCurrentPrice = new MetroFramework.Controls.MetroTextBox();
            this.txtTargetPrice = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.txtTargetType = new MetroFramework.Controls.MetroComboBox();
            this.txtCurrency = new MetroFramework.Controls.MetroTextBox();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAlertTitle
            // 
            this.lblAlertTitle.AutoSize = true;
            this.lblAlertTitle.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblAlertTitle.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblAlertTitle.Location = new System.Drawing.Point(88, 20);
            this.lblAlertTitle.Name = "lblAlertTitle";
            this.lblAlertTitle.Size = new System.Drawing.Size(152, 25);
            this.lblAlertTitle.TabIndex = 0;
            this.lblAlertTitle.Text = "Add a new alert";
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Location = new System.Drawing.Point(8, 58);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(367, 269);
            this.metroTabControl1.TabIndex = 1;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.txtCurrency);
            this.metroTabPage1.Controls.Add(this.txtTargetType);
            this.metroTabPage1.Controls.Add(this.metroButton1);
            this.metroTabPage1.Controls.Add(this.metroLabel3);
            this.metroTabPage1.Controls.Add(this.metroLabel2);
            this.metroTabPage1.Controls.Add(this.txtTargetPrice);
            this.metroTabPage1.Controls.Add(this.txtCurrentPrice);
            this.metroTabPage1.Controls.Add(this.metroLabel1);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(359, 227);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "New Alert";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(309, 206);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "All Alerts";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(11, 18);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(66, 20);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Currency";
            // 
            // txtCurrentPrice
            // 
            // 
            // 
            // 
            this.txtCurrentPrice.CustomButton.Image = null;
            this.txtCurrentPrice.CustomButton.Location = new System.Drawing.Point(163, 1);
            this.txtCurrentPrice.CustomButton.Name = "";
            this.txtCurrentPrice.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtCurrentPrice.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCurrentPrice.CustomButton.TabIndex = 1;
            this.txtCurrentPrice.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCurrentPrice.CustomButton.UseSelectable = true;
            this.txtCurrentPrice.CustomButton.Visible = false;
            this.txtCurrentPrice.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtCurrentPrice.Lines = new string[] {
        "0.000"};
            this.txtCurrentPrice.Location = new System.Drawing.Point(137, 60);
            this.txtCurrentPrice.MaxLength = 32767;
            this.txtCurrentPrice.Name = "txtCurrentPrice";
            this.txtCurrentPrice.PasswordChar = '\0';
            this.txtCurrentPrice.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCurrentPrice.SelectedText = "";
            this.txtCurrentPrice.SelectionLength = 0;
            this.txtCurrentPrice.SelectionStart = 0;
            this.txtCurrentPrice.ShortcutsEnabled = true;
            this.txtCurrentPrice.Size = new System.Drawing.Size(191, 29);
            this.txtCurrentPrice.TabIndex = 4;
            this.txtCurrentPrice.Text = "0.000";
            this.txtCurrentPrice.UseSelectable = true;
            this.txtCurrentPrice.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCurrentPrice.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtTargetPrice
            // 
            // 
            // 
            // 
            this.txtTargetPrice.CustomButton.Image = null;
            this.txtTargetPrice.CustomButton.Location = new System.Drawing.Point(96, 1);
            this.txtTargetPrice.CustomButton.Name = "";
            this.txtTargetPrice.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtTargetPrice.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTargetPrice.CustomButton.TabIndex = 1;
            this.txtTargetPrice.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTargetPrice.CustomButton.UseSelectable = true;
            this.txtTargetPrice.CustomButton.Visible = false;
            this.txtTargetPrice.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtTargetPrice.Lines = new string[] {
        "0.000"};
            this.txtTargetPrice.Location = new System.Drawing.Point(204, 104);
            this.txtTargetPrice.MaxLength = 32767;
            this.txtTargetPrice.Name = "txtTargetPrice";
            this.txtTargetPrice.PasswordChar = '\0';
            this.txtTargetPrice.ReadOnly = true;
            this.txtTargetPrice.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTargetPrice.SelectedText = "";
            this.txtTargetPrice.SelectionLength = 0;
            this.txtTargetPrice.SelectionStart = 0;
            this.txtTargetPrice.ShortcutsEnabled = true;
            this.txtTargetPrice.Size = new System.Drawing.Size(124, 29);
            this.txtTargetPrice.TabIndex = 5;
            this.txtTargetPrice.Text = "0.000";
            this.txtTargetPrice.UseSelectable = true;
            this.txtTargetPrice.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTargetPrice.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(11, 66);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(91, 20);
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "Current Price";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(11, 107);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(82, 20);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Target Price";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(117, 152);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(101, 40);
            this.metroButton1.TabIndex = 8;
            this.metroButton1.Text = "Add Alert";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // txtTargetType
            // 
            this.txtTargetType.FormattingEnabled = true;
            this.txtTargetType.ItemHeight = 24;
            this.txtTargetType.Items.AddRange(new object[] {
            ">",
            "<",
            "="});
            this.txtTargetType.Location = new System.Drawing.Point(137, 103);
            this.txtTargetType.Name = "txtTargetType";
            this.txtTargetType.PromptText = ">";
            this.txtTargetType.Size = new System.Drawing.Size(57, 30);
            this.txtTargetType.TabIndex = 9;
            this.txtTargetType.UseSelectable = true;
            // 
            // txtCurrency
            // 
            // 
            // 
            // 
            this.txtCurrency.CustomButton.Image = null;
            this.txtCurrency.CustomButton.Location = new System.Drawing.Point(163, 1);
            this.txtCurrency.CustomButton.Name = "";
            this.txtCurrency.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtCurrency.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCurrency.CustomButton.TabIndex = 1;
            this.txtCurrency.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCurrency.CustomButton.UseSelectable = true;
            this.txtCurrency.CustomButton.Visible = false;
            this.txtCurrency.Enabled = false;
            this.txtCurrency.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtCurrency.Lines = new string[0];
            this.txtCurrency.Location = new System.Drawing.Point(137, 9);
            this.txtCurrency.MaxLength = 32767;
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.PasswordChar = '\0';
            this.txtCurrency.ReadOnly = true;
            this.txtCurrency.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCurrency.SelectedText = "";
            this.txtCurrency.SelectionLength = 0;
            this.txtCurrency.SelectionStart = 0;
            this.txtCurrency.ShortcutsEnabled = true;
            this.txtCurrency.Size = new System.Drawing.Size(191, 29);
            this.txtCurrency.TabIndex = 10;
            this.txtCurrency.UseSelectable = true;
            this.txtCurrency.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCurrency.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // NewAlert
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(383, 350);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.lblAlertTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewAlert";
            this.Load += new System.EventHandler(this.NewAlert_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblAlertTitle;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTextBox txtCurrentPrice;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroComboBox txtTargetType;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtTargetPrice;
        private MetroFramework.Controls.MetroTextBox txtCurrency;
    }
}