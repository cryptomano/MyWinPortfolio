using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Options : MetroForm
    {
        IniParser inifile;

        public Options()
        {
            InitializeComponent();
            inifile = new IniParser("config.ini");
        }

        private void Options_Load(object sender, EventArgs e)
        {
            this.Size = new Size(948, 335);
            txtBittrexAPISecret.PasswordChar = '\u25CF';
            txtKrakenAPISecret.PasswordChar = '\u25CF';
            txtHitbtcAPISecret.PasswordChar = '\u25CF';
            txtETHWallet.Text = inifile.Read("Wallet_ETH_Address");
            txtBTCWallet.Text = inifile.Read("Wallet_BTC_Address");
            txtBittrexApiKey.Text = inifile.Read("Exchange_Bittrex_APIKey");
            if (inifile.Read("Exchange_Bittrex_APISecret") != "")
            {
                txtBittrexAPISecret.Text = StringCipher.Decrypt(inifile.Read("Exchange_Bittrex_APISecret"), "Zv50ty730");
            }

            txtKrakenAPIKey.Text = inifile.Read("Exchange_Kraken_APIKey");
            if (inifile.Read("Exchange_Kraken_APISecret") != "")
            {
                txtKrakenAPISecret.Text = StringCipher.Decrypt(inifile.Read("Exchange_Kraken_APISecret"), "Zv50ty730");
            }
            txtHitbtcAPIKey.Text = inifile.Read("Exchange_Hitbtc_APIKey");
            if (inifile.Read("Exchange_Hitbtc_APISecret") != "")
            {
                txtHitbtcAPISecret.Text = StringCipher.Decrypt(inifile.Read("Exchange_Hitbtc_APISecret"), "Zv50ty730");
            }
            cmbFIATCurrency.Text = inifile.Read("FIAT_Currency");

            if (inifile.Read("Exchange_Hitbtc_Enabled") == "true")
            {
                checkHitbtcEnable.Checked = true;
                txtHitbtcAPIKey.Enabled = true;
                txtHitbtcAPISecret.Enabled = true;
            }
            else checkHitbtcEnable.Checked = false;

            if (inifile.Read("Exchange_Kraken_Enabled") == "true")
            {
                checkKrakenEnable.Checked = true;
                txtKrakenAPIKey.Enabled = true;
                txtKrakenAPISecret.Enabled = true;
            }
            else checkKrakenEnable.Checked = false;

            if (inifile.Read("Exchange_Bittrex_Enabled") == "true")
            {
                checkBittrexEnable.Checked = true;
                txtBittrexApiKey.Enabled = true;
                txtBittrexApiKey.Enabled = true;
            }
            else checkBittrexEnable.Checked = false;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            inifile.Write("Exchange_Bittrex_APIKey", txtBittrexApiKey.Text);
            inifile.Write("Exchange_Bittrex_APISecret", StringCipher.Encrypt(txtBittrexAPISecret.Text, "Zv50ty730"));
            inifile.Write("Exchange_Kraken_APIKey", txtKrakenAPIKey.Text);
            inifile.Write("Exchange_Kraken_APISecret", StringCipher.Encrypt(txtKrakenAPISecret.Text, "Zv50ty730"));
            inifile.Write("Exchange_Hitbtc_APIKey", txtHitbtcAPIKey.Text);
            inifile.Write("Exchange_Hitbtc_APISecret", StringCipher.Encrypt(txtHitbtcAPISecret.Text, "Zv50ty730"));
            inifile.Write("FIAT_Currency", cmbFIATCurrency.Text);
            inifile.Write("Wallet_ETH_Address", txtETHWallet.Text);
            inifile.Write("Wallet_BTC_Address", txtBTCWallet.Text);


            if (checkBittrexEnable.Checked == true)
            {
                inifile.Write("Exchange_Bittrex_Enabled", "true");
            }
            else inifile.Write("Exchange_Bittrex_Enabled", "false");

            if (checkKrakenEnable.Checked == true)
            {
                inifile.Write("Exchange_Kraken_Enabled", "true");
            }
            else inifile.Write("Exchange_Kraken_Enabled", "false");

            if (checkHitbtcEnable.Checked == true)
            {
                inifile.Write("Exchange_Hitbtc_Enabled", "true");
            }
            else inifile.Write("Exchange_Hitbtc_Enabled", "false");

            MessageBox.Show("Saved !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void checkBittrexEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBittrexEnable.Checked == true)
            {
                txtBittrexApiKey.Enabled = true;
                txtBittrexAPISecret.Enabled = true;
            }
            else
            {
                txtBittrexApiKey.Enabled = false;
                txtBittrexAPISecret.Enabled = false;
            }
        }

        private void checkKrakenEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkKrakenEnable.Checked == true)
            {
                txtKrakenAPIKey.Enabled = true;
                txtKrakenAPISecret.Enabled = true;
            }
            else
            {
                txtKrakenAPIKey.Enabled = false;
                txtKrakenAPISecret.Enabled = false;
            }
        }

        private void checkHitbtcEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHitbtcEnable.Checked == true)
            {
                txtHitbtcAPIKey.Enabled = true;
                txtHitbtcAPISecret.Enabled = true;
            }
            else
            {
                txtHitbtcAPIKey.Enabled = false;
                txtHitbtcAPISecret.Enabled = false;
            }
        }
    }
}
