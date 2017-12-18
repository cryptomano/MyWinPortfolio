namespace WindowsFormsApp1
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtBittrexApiKey = new MetroFramework.Controls.MetroTextBox();
            this.txtBittrexAPISecret = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtKrakenAPISecret = new MetroFramework.Controls.MetroTextBox();
            this.txtKrakenAPIKey = new MetroFramework.Controls.MetroTextBox();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txtHitbtcAPISecret = new MetroFramework.Controls.MetroTextBox();
            this.txtHitbtcAPIKey = new MetroFramework.Controls.MetroTextBox();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.cmbFIATCurrency = new MetroFramework.Controls.MetroComboBox();
            this.metroTile4 = new MetroFramework.Controls.MetroTile();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.checkBittrexEnable = new MetroFramework.Controls.MetroToggle();
            this.checkKrakenEnable = new MetroFramework.Controls.MetroToggle();
            this.checkHitbtcEnable = new MetroFramework.Controls.MetroToggle();
            this.txtETHWallet = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.txtBTCWallet = new MetroFramework.Controls.MetroTextBox();
            this.metroTile1.SuspendLayout();
            this.metroTile2.SuspendLayout();
            this.metroTile3.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(399, 245);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(125, 58);
            this.metroButton1.TabIndex = 0;
            this.metroButton1.Text = "Save";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Controls.Add(this.metroLabel1);
            this.metroTile1.Location = new System.Drawing.Point(13, 63);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(285, 29);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroTile1.TabIndex = 1;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(114, -4);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(72, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Bittrex";
            // 
            // txtBittrexApiKey
            // 
            // 
            // 
            // 
            this.txtBittrexApiKey.CustomButton.Image = null;
            this.txtBittrexApiKey.CustomButton.Location = new System.Drawing.Point(172, 1);
            this.txtBittrexApiKey.CustomButton.Name = "";
            this.txtBittrexApiKey.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBittrexApiKey.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBittrexApiKey.CustomButton.TabIndex = 1;
            this.txtBittrexApiKey.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBittrexApiKey.CustomButton.UseSelectable = true;
            this.txtBittrexApiKey.CustomButton.Visible = false;
            this.txtBittrexApiKey.Enabled = false;
            this.txtBittrexApiKey.Lines = new string[0];
            this.txtBittrexApiKey.Location = new System.Drawing.Point(105, 131);
            this.txtBittrexApiKey.MaxLength = 32767;
            this.txtBittrexApiKey.Name = "txtBittrexApiKey";
            this.txtBittrexApiKey.PasswordChar = '\0';
            this.txtBittrexApiKey.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBittrexApiKey.SelectedText = "";
            this.txtBittrexApiKey.SelectionLength = 0;
            this.txtBittrexApiKey.SelectionStart = 0;
            this.txtBittrexApiKey.ShortcutsEnabled = true;
            this.txtBittrexApiKey.Size = new System.Drawing.Size(194, 23);
            this.txtBittrexApiKey.TabIndex = 1;
            this.txtBittrexApiKey.UseSelectable = true;
            this.txtBittrexApiKey.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBittrexApiKey.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtBittrexAPISecret
            // 
            // 
            // 
            // 
            this.txtBittrexAPISecret.CustomButton.Image = null;
            this.txtBittrexAPISecret.CustomButton.Location = new System.Drawing.Point(172, 1);
            this.txtBittrexAPISecret.CustomButton.Name = "";
            this.txtBittrexAPISecret.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBittrexAPISecret.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBittrexAPISecret.CustomButton.TabIndex = 1;
            this.txtBittrexAPISecret.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBittrexAPISecret.CustomButton.UseSelectable = true;
            this.txtBittrexAPISecret.CustomButton.Visible = false;
            this.txtBittrexAPISecret.Enabled = false;
            this.txtBittrexAPISecret.Lines = new string[0];
            this.txtBittrexAPISecret.Location = new System.Drawing.Point(107, 169);
            this.txtBittrexAPISecret.MaxLength = 32767;
            this.txtBittrexAPISecret.Name = "txtBittrexAPISecret";
            this.txtBittrexAPISecret.PasswordChar = '*';
            this.txtBittrexAPISecret.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBittrexAPISecret.SelectedText = "";
            this.txtBittrexAPISecret.SelectionLength = 0;
            this.txtBittrexAPISecret.SelectionStart = 0;
            this.txtBittrexAPISecret.ShortcutsEnabled = true;
            this.txtBittrexAPISecret.Size = new System.Drawing.Size(194, 23);
            this.txtBittrexAPISecret.TabIndex = 2;
            this.txtBittrexAPISecret.UseSelectable = true;
            this.txtBittrexAPISecret.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBittrexAPISecret.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(14, 134);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(56, 20);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "API Key";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(14, 169);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(72, 20);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "API Secret";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(336, 169);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(72, 20);
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "API Secret";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(336, 134);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(56, 20);
            this.metroLabel5.TabIndex = 8;
            this.metroLabel5.Text = "API Key";
            // 
            // txtKrakenAPISecret
            // 
            // 
            // 
            // 
            this.txtKrakenAPISecret.CustomButton.Image = null;
            this.txtKrakenAPISecret.CustomButton.Location = new System.Drawing.Point(172, 1);
            this.txtKrakenAPISecret.CustomButton.Name = "";
            this.txtKrakenAPISecret.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtKrakenAPISecret.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtKrakenAPISecret.CustomButton.TabIndex = 1;
            this.txtKrakenAPISecret.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtKrakenAPISecret.CustomButton.UseSelectable = true;
            this.txtKrakenAPISecret.CustomButton.Visible = false;
            this.txtKrakenAPISecret.Enabled = false;
            this.txtKrakenAPISecret.Lines = new string[0];
            this.txtKrakenAPISecret.Location = new System.Drawing.Point(427, 169);
            this.txtKrakenAPISecret.MaxLength = 32767;
            this.txtKrakenAPISecret.Name = "txtKrakenAPISecret";
            this.txtKrakenAPISecret.PasswordChar = '*';
            this.txtKrakenAPISecret.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtKrakenAPISecret.SelectedText = "";
            this.txtKrakenAPISecret.SelectionLength = 0;
            this.txtKrakenAPISecret.SelectionStart = 0;
            this.txtKrakenAPISecret.ShortcutsEnabled = true;
            this.txtKrakenAPISecret.Size = new System.Drawing.Size(194, 23);
            this.txtKrakenAPISecret.TabIndex = 7;
            this.txtKrakenAPISecret.UseSelectable = true;
            this.txtKrakenAPISecret.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtKrakenAPISecret.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtKrakenAPIKey
            // 
            // 
            // 
            // 
            this.txtKrakenAPIKey.CustomButton.Image = null;
            this.txtKrakenAPIKey.CustomButton.Location = new System.Drawing.Point(172, 1);
            this.txtKrakenAPIKey.CustomButton.Name = "";
            this.txtKrakenAPIKey.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtKrakenAPIKey.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtKrakenAPIKey.CustomButton.TabIndex = 1;
            this.txtKrakenAPIKey.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtKrakenAPIKey.CustomButton.UseSelectable = true;
            this.txtKrakenAPIKey.CustomButton.Visible = false;
            this.txtKrakenAPIKey.Enabled = false;
            this.txtKrakenAPIKey.Lines = new string[0];
            this.txtKrakenAPIKey.Location = new System.Drawing.Point(427, 131);
            this.txtKrakenAPIKey.MaxLength = 32767;
            this.txtKrakenAPIKey.Name = "txtKrakenAPIKey";
            this.txtKrakenAPIKey.PasswordChar = '\0';
            this.txtKrakenAPIKey.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtKrakenAPIKey.SelectedText = "";
            this.txtKrakenAPIKey.SelectionLength = 0;
            this.txtKrakenAPIKey.SelectionStart = 0;
            this.txtKrakenAPIKey.ShortcutsEnabled = true;
            this.txtKrakenAPIKey.Size = new System.Drawing.Size(194, 23);
            this.txtKrakenAPIKey.TabIndex = 5;
            this.txtKrakenAPIKey.UseSelectable = true;
            this.txtKrakenAPIKey.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtKrakenAPIKey.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Controls.Add(this.metroLabel6);
            this.metroTile2.Location = new System.Drawing.Point(335, 63);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(285, 29);
            this.metroTile2.Style = MetroFramework.MetroColorStyle.Yellow;
            this.metroTile2.TabIndex = 6;
            this.metroTile2.UseSelectable = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel6.Location = new System.Drawing.Point(114, -4);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(75, 25);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Yellow;
            this.metroLabel6.TabIndex = 0;
            this.metroLabel6.Text = "Kraken";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(656, 169);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(72, 20);
            this.metroLabel7.TabIndex = 14;
            this.metroLabel7.Text = "API Secret";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(656, 134);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(56, 20);
            this.metroLabel8.TabIndex = 13;
            this.metroLabel8.Text = "API Key";
            // 
            // txtHitbtcAPISecret
            // 
            // 
            // 
            // 
            this.txtHitbtcAPISecret.CustomButton.Image = null;
            this.txtHitbtcAPISecret.CustomButton.Location = new System.Drawing.Point(172, 1);
            this.txtHitbtcAPISecret.CustomButton.Name = "";
            this.txtHitbtcAPISecret.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtHitbtcAPISecret.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtHitbtcAPISecret.CustomButton.TabIndex = 1;
            this.txtHitbtcAPISecret.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtHitbtcAPISecret.CustomButton.UseSelectable = true;
            this.txtHitbtcAPISecret.CustomButton.Visible = false;
            this.txtHitbtcAPISecret.Enabled = false;
            this.txtHitbtcAPISecret.Lines = new string[0];
            this.txtHitbtcAPISecret.Location = new System.Drawing.Point(747, 169);
            this.txtHitbtcAPISecret.MaxLength = 32767;
            this.txtHitbtcAPISecret.Name = "txtHitbtcAPISecret";
            this.txtHitbtcAPISecret.PasswordChar = '*';
            this.txtHitbtcAPISecret.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtHitbtcAPISecret.SelectedText = "";
            this.txtHitbtcAPISecret.SelectionLength = 0;
            this.txtHitbtcAPISecret.SelectionStart = 0;
            this.txtHitbtcAPISecret.ShortcutsEnabled = true;
            this.txtHitbtcAPISecret.Size = new System.Drawing.Size(194, 23);
            this.txtHitbtcAPISecret.TabIndex = 12;
            this.txtHitbtcAPISecret.UseSelectable = true;
            this.txtHitbtcAPISecret.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtHitbtcAPISecret.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtHitbtcAPIKey
            // 
            // 
            // 
            // 
            this.txtHitbtcAPIKey.CustomButton.Image = null;
            this.txtHitbtcAPIKey.CustomButton.Location = new System.Drawing.Point(172, 1);
            this.txtHitbtcAPIKey.CustomButton.Name = "";
            this.txtHitbtcAPIKey.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtHitbtcAPIKey.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtHitbtcAPIKey.CustomButton.TabIndex = 1;
            this.txtHitbtcAPIKey.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtHitbtcAPIKey.CustomButton.UseSelectable = true;
            this.txtHitbtcAPIKey.CustomButton.Visible = false;
            this.txtHitbtcAPIKey.Enabled = false;
            this.txtHitbtcAPIKey.Lines = new string[0];
            this.txtHitbtcAPIKey.Location = new System.Drawing.Point(747, 131);
            this.txtHitbtcAPIKey.MaxLength = 32767;
            this.txtHitbtcAPIKey.Name = "txtHitbtcAPIKey";
            this.txtHitbtcAPIKey.PasswordChar = '\0';
            this.txtHitbtcAPIKey.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtHitbtcAPIKey.SelectedText = "";
            this.txtHitbtcAPIKey.SelectionLength = 0;
            this.txtHitbtcAPIKey.SelectionStart = 0;
            this.txtHitbtcAPIKey.ShortcutsEnabled = true;
            this.txtHitbtcAPIKey.Size = new System.Drawing.Size(194, 23);
            this.txtHitbtcAPIKey.TabIndex = 10;
            this.txtHitbtcAPIKey.UseSelectable = true;
            this.txtHitbtcAPIKey.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtHitbtcAPIKey.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTile3
            // 
            this.metroTile3.ActiveControl = null;
            this.metroTile3.Controls.Add(this.metroLabel9);
            this.metroTile3.Location = new System.Drawing.Point(655, 63);
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Size = new System.Drawing.Size(285, 29);
            this.metroTile3.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTile3.TabIndex = 11;
            this.metroTile3.UseSelectable = true;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel9.Location = new System.Drawing.Point(114, -4);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(67, 25);
            this.metroLabel9.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel9.TabIndex = 0;
            this.metroLabel9.Text = "Hitbtc";
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel10.Location = new System.Drawing.Point(428, 16);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(82, 25);
            this.metroLabel10.TabIndex = 15;
            this.metroLabel10.Text = "Options";
            // 
            // cmbFIATCurrency
            // 
            this.cmbFIATCurrency.FormattingEnabled = true;
            this.cmbFIATCurrency.ItemHeight = 24;
            this.cmbFIATCurrency.Items.AddRange(new object[] {
            "AUD",
            "BRL",
            "CAD",
            "CHF",
            "CLP",
            "CNY",
            "DKK",
            "EUR",
            "GBP",
            "HKD",
            "INR",
            "ISK",
            "JPY",
            "KRW",
            "NZD",
            "PLN",
            "RUB",
            "SEK",
            "SGD",
            "THB",
            "TWD",
            "USD"});
            this.cmbFIATCurrency.Location = new System.Drawing.Point(184, 239);
            this.cmbFIATCurrency.Name = "cmbFIATCurrency";
            this.cmbFIATCurrency.PromptText = "EUR";
            this.cmbFIATCurrency.Size = new System.Drawing.Size(209, 30);
            this.cmbFIATCurrency.TabIndex = 16;
            this.cmbFIATCurrency.UseSelectable = true;
            // 
            // metroTile4
            // 
            this.metroTile4.ActiveControl = null;
            this.metroTile4.Location = new System.Drawing.Point(13, 223);
            this.metroTile4.Name = "metroTile4";
            this.metroTile4.Size = new System.Drawing.Size(928, 10);
            this.metroTile4.TabIndex = 17;
            this.metroTile4.UseSelectable = true;
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(16, 245);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(95, 20);
            this.metroLabel11.TabIndex = 18;
            this.metroLabel11.Text = "FIAT Currency";
            // 
            // checkBittrexEnable
            // 
            this.checkBittrexEnable.AutoSize = true;
            this.checkBittrexEnable.Location = new System.Drawing.Point(128, 99);
            this.checkBittrexEnable.Name = "checkBittrexEnable";
            this.checkBittrexEnable.Size = new System.Drawing.Size(80, 21);
            this.checkBittrexEnable.Style = MetroFramework.MetroColorStyle.Green;
            this.checkBittrexEnable.TabIndex = 19;
            this.checkBittrexEnable.Text = "Off";
            this.checkBittrexEnable.UseSelectable = true;
            this.checkBittrexEnable.CheckedChanged += new System.EventHandler(this.checkBittrexEnable_CheckedChanged);
            // 
            // checkKrakenEnable
            // 
            this.checkKrakenEnable.AutoSize = true;
            this.checkKrakenEnable.Location = new System.Drawing.Point(450, 99);
            this.checkKrakenEnable.Name = "checkKrakenEnable";
            this.checkKrakenEnable.Size = new System.Drawing.Size(80, 21);
            this.checkKrakenEnable.Style = MetroFramework.MetroColorStyle.Yellow;
            this.checkKrakenEnable.TabIndex = 20;
            this.checkKrakenEnable.Text = "Off";
            this.checkKrakenEnable.UseSelectable = true;
            this.checkKrakenEnable.CheckedChanged += new System.EventHandler(this.checkKrakenEnable_CheckedChanged);
            // 
            // checkHitbtcEnable
            // 
            this.checkHitbtcEnable.AutoSize = true;
            this.checkHitbtcEnable.Location = new System.Drawing.Point(770, 99);
            this.checkHitbtcEnable.Name = "checkHitbtcEnable";
            this.checkHitbtcEnable.Size = new System.Drawing.Size(80, 21);
            this.checkHitbtcEnable.Style = MetroFramework.MetroColorStyle.Red;
            this.checkHitbtcEnable.TabIndex = 21;
            this.checkHitbtcEnable.Text = "Off";
            this.checkHitbtcEnable.UseSelectable = true;
            this.checkHitbtcEnable.CheckedChanged += new System.EventHandler(this.checkHitbtcEnable_CheckedChanged);
            // 
            // txtETHWallet
            // 
            this.txtETHWallet.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            // 
            // 
            // 
            this.txtETHWallet.CustomButton.Image = null;
            this.txtETHWallet.CustomButton.Location = new System.Drawing.Point(187, 1);
            this.txtETHWallet.CustomButton.Name = "";
            this.txtETHWallet.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtETHWallet.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtETHWallet.CustomButton.TabIndex = 1;
            this.txtETHWallet.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtETHWallet.CustomButton.UseSelectable = true;
            this.txtETHWallet.CustomButton.Visible = false;
            this.txtETHWallet.Lines = new string[0];
            this.txtETHWallet.Location = new System.Drawing.Point(184, 277);
            this.txtETHWallet.MaxLength = 32767;
            this.txtETHWallet.Name = "txtETHWallet";
            this.txtETHWallet.PasswordChar = '\0';
            this.txtETHWallet.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtETHWallet.SelectedText = "";
            this.txtETHWallet.SelectionLength = 0;
            this.txtETHWallet.SelectionStart = 0;
            this.txtETHWallet.ShortcutsEnabled = true;
            this.txtETHWallet.Size = new System.Drawing.Size(209, 23);
            this.txtETHWallet.TabIndex = 22;
            this.txtETHWallet.UseSelectable = true;
            this.txtETHWallet.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtETHWallet.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(16, 275);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(130, 20);
            this.metroLabel12.TabIndex = 23;
            this.metroLabel12.Text = "ETH Wallet Address";
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Location = new System.Drawing.Point(16, 304);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(128, 20);
            this.metroLabel13.TabIndex = 25;
            this.metroLabel13.Text = "BTC Wallet Address";
            // 
            // txtBTCWallet
            // 
            this.txtBTCWallet.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            // 
            // 
            // 
            this.txtBTCWallet.CustomButton.Image = null;
            this.txtBTCWallet.CustomButton.Location = new System.Drawing.Point(187, 1);
            this.txtBTCWallet.CustomButton.Name = "";
            this.txtBTCWallet.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBTCWallet.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBTCWallet.CustomButton.TabIndex = 1;
            this.txtBTCWallet.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBTCWallet.CustomButton.UseSelectable = true;
            this.txtBTCWallet.CustomButton.Visible = false;
            this.txtBTCWallet.Lines = new string[0];
            this.txtBTCWallet.Location = new System.Drawing.Point(184, 304);
            this.txtBTCWallet.MaxLength = 32767;
            this.txtBTCWallet.Name = "txtBTCWallet";
            this.txtBTCWallet.PasswordChar = '\0';
            this.txtBTCWallet.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBTCWallet.SelectedText = "";
            this.txtBTCWallet.SelectionLength = 0;
            this.txtBTCWallet.SelectionStart = 0;
            this.txtBTCWallet.ShortcutsEnabled = true;
            this.txtBTCWallet.Size = new System.Drawing.Size(209, 23);
            this.txtBTCWallet.TabIndex = 24;
            this.txtBTCWallet.UseSelectable = true;
            this.txtBTCWallet.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBTCWallet.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Options
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(948, 335);
            this.Controls.Add(this.metroLabel13);
            this.Controls.Add(this.txtBTCWallet);
            this.Controls.Add(this.metroLabel12);
            this.Controls.Add(this.txtETHWallet);
            this.Controls.Add(this.checkHitbtcEnable);
            this.Controls.Add(this.checkKrakenEnable);
            this.Controls.Add(this.checkBittrexEnable);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.metroTile4);
            this.Controls.Add(this.cmbFIATCurrency);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.txtHitbtcAPISecret);
            this.Controls.Add(this.txtHitbtcAPIKey);
            this.Controls.Add(this.metroTile3);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.txtKrakenAPISecret);
            this.Controls.Add(this.txtKrakenAPIKey);
            this.Controls.Add(this.metroTile2);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtBittrexAPISecret);
            this.Controls.Add(this.txtBittrexApiKey);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.metroButton1);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Options";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.metroTile1.ResumeLayout(false);
            this.metroTile1.PerformLayout();
            this.metroTile2.ResumeLayout(false);
            this.metroTile2.PerformLayout();
            this.metroTile3.ResumeLayout(false);
            this.metroTile3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtBittrexApiKey;
        private MetroFramework.Controls.MetroTextBox txtBittrexAPISecret;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox txtKrakenAPISecret;
        private MetroFramework.Controls.MetroTextBox txtKrakenAPIKey;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox txtHitbtcAPISecret;
        private MetroFramework.Controls.MetroTextBox txtHitbtcAPIKey;
        private MetroFramework.Controls.MetroTile metroTile3;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroComboBox cmbFIATCurrency;
        private MetroFramework.Controls.MetroTile metroTile4;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroToggle checkBittrexEnable;
        private MetroFramework.Controls.MetroToggle checkKrakenEnable;
        private MetroFramework.Controls.MetroToggle checkHitbtcEnable;
        private MetroFramework.Controls.MetroTextBox txtETHWallet;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroTextBox txtBTCWallet;
    }
}