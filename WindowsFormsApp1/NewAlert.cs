using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class NewAlert : MetroForm
    {
        string currency;
        string exchange;
        string price_btc;
        SQLiteConnection m_dbConnection;

        public NewAlert(string _currency, string _exchange, string _price_btc)
        {
            InitializeComponent();
            currency = _currency;
            exchange = _exchange;
            price_btc = _price_btc;
        }

        private void NewAlert_Load(object sender, EventArgs e)
        {
            m_dbConnection = new SQLiteConnection("Data Source=Crypto2.db;Version=3;");
            m_dbConnection.Open();
            txtCurrency.Text = currency;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            SQLiteCommand sql = new SQLiteCommand("INSERT INTO alerts(price_alert, currency_pair, exchange, alert_type) " +
                    "VALUES ('" + txtTargetPrice.Text.Replace(",",".") + "','" + currency + "','ALL,'" + txtTargetType.Text +"')", m_dbConnection);
                MessageBox.Show("Added !", "New Alert Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
