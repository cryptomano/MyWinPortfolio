using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts; //Core of the library
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System.Net.Http;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using BittrexSharp;
using System.Collections;
using HitBtcApi;
using NoobsMuc.Coinmarketcap.Client;
using System.Globalization;
using CryptoCompare;
using Newtonsoft.Json.Linq;
using KrakenApi;
using System.Windows.Media;
using System.Threading;
using System.Timers;

namespace WindowsFormsApp1
{
    public partial class Form1 : MetroForm
    {
        SQLiteConnection m_dbConnection;
        Bittrex bittrex;
        SQLiteDatabase db;
        IniParser inifile;
        private TooltipData _data;
        string Bittrex_apiSecret;
        string Bittrex_apiKey;
        string exchange_kraken_key;
        string exchange_kraken_secret;
        string exchange_hitbtc_key;
        string exchange_hitbtc_secret;
        string eth_wallet_address;
        //Used to calculate 1BTC value into fiat
        double btc_to_fiat;
        string fiat_currency;

        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Timer to check currency alerts   -  WIP
            //System.Timers.Timer timer = new System.Timers.Timer();
            //timer.Interval = 30000;
            //timer.Elapsed += CheckCurrenciesPrice;
            //timer.Start();


            this.Size = new Size(1800, 200);
            metroTile1.Size = new Size(372, 183);
            metroTile2.Size = new Size(372, 183);
            metroTile3.Size = new Size(372, 183);
            metroTile4.Size = new Size(372, 183);
            try
            {
                inifile = new IniParser("config.ini");
                if (inifile.Read("Exchange_Bittrex_Enabled") == "false" && inifile.Read("Exchange_Hitbtc_Enabled") == "false" && inifile.Read("Exchange_Kraken_Enabled") == "false")
                {
                    Options option = new Options();
                    option.ShowDialog();
                }
                else
                {
                    Bittrex_apiKey = inifile.Read("Exchange_Bittrex_APIKey");
                    eth_wallet_address = inifile.Read("Wallet_ETH_Address");
                    fiat_currency = inifile.Read("FIAT_Currency");
                    GetBTC_FIAT_Price();
                    if (inifile.Read("Exchange_Bittrex_APISecret") != "")
                    {
                        Bittrex_apiSecret = StringCipher.Decrypt(inifile.Read("Exchange_Bittrex_APISecret"), "Zv50ty730");
                    }
                    exchange_hitbtc_key = inifile.Read("Exchange_Hitbtc_APIKey");
                    if (inifile.Read("Exchange_Hitbtc_APISecret") != "")
                    {
                        exchange_hitbtc_secret = StringCipher.Decrypt(inifile.Read("Exchange_Hitbtc_APISecret"), "Zv50ty730");
                    }

                    exchange_kraken_key = inifile.Read("Exchange_Kraken_APIKey");
                    if (inifile.Read("Exchange_Kraken_APISecret") != "")
                    {
                        exchange_kraken_secret = StringCipher.Decrypt(inifile.Read("Exchange_Kraken_APISecret"), "Zv50ty730");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            if (inifile.Read("Exchange_Bittrex_Enabled") == "true")
            {
                bittrex = new Bittrex(Bittrex_apiKey, Bittrex_apiSecret);
            }
            m_dbConnection = new SQLiteConnection("Data Source=Crypto2.db;Version=3;");
            m_dbConnection.Open();


        }

        private void CheckCurrenciesPrice(object sender, ElapsedEventArgs e)
        {
            //BTC TO FIAT Conversion
            var uri = String.Format("https://blockchain.info/ticker", 500);
            WebClient webclient = new WebClient();
            webclient.UseDefaultCredentials = true;
            var data = webclient.DownloadString(uri);
            var result = Convert.ToString(data);
            //dynamic price = JObject.Parse(result).SelectTokens(fiat_currency+".*");
            var parsed = JObject.Parse(result);
            var btc_price = new BTCPrice();

            btc_price.last = parsed.SelectToken(fiat_currency + ".last").Value<double>();
            btc_to_fiat = btc_price.last;
            //MessageBox.Show(btc_price.last.ToString());




            /////////// Notification Stuff ////////////////////

            var notification = new System.Windows.Forms.NotifyIcon()
            {
                Visible = true,
                Icon = System.Drawing.SystemIcons.Information,
                // optional - BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info,
                // optional - BalloonTipTitle = "My Title",
                BalloonTipText = "BTC Price :" + btc_price.last.ToString(),
            };

            // Display for 5 seconds.
            notification.ShowBalloonTip(5000);

            // This will let the balloon close after it's 5 second timeout
            // for demonstration purposes. Comment this out to see what happens
            // when dispose is called while a balloon is still visible.
            //Thread.Sleep(10000);

            // The notification should be disposed when you don't need it anymore,
            // but doing so will immediately close the balloon if it's visible.
            notification.Dispose();


        }

        private async Task<string> ProcessGeneralBalancesData()
        {
            lblProcessingState.Text = "Processing General Data...";
            buttonBalance.Text = "Working...";
            buttonBalance.Enabled = false;
            string sql = "select coin_name As Currency, balance_total As Total, balance_available As Available, price_btc As 'BTC Price', price_fiat As '" + fiat_currency + " Price', ROUND(price_btc*balance_total,7) As 'Total BTC', ROUND(price_fiat*balance_total,2) As 'Total " + fiat_currency + "', exchange As Exchange from balances ORDER BY coin_name";
            DataSet ds = new DataSet();
            var da = new SQLiteDataAdapter(sql, m_dbConnection);
            da.Fill(ds);
            GridBalancesGeneral.DataSource = ds.Tables[0].DefaultView;
            string general_balance_total_coins = "0";
            string general_balance_total_btc = "0";
            string general_balance_total_fiat = "0";

            try
            {
                db = new SQLiteDatabase();
                DataTable balances;
                String query = "select count(coin_name) from balances where balance_total <> 0";
                balances = db.GetDataTable(query);
                foreach (DataRow r in balances.Rows)
                {
                    general_balance_total_coins = r[0].ToString();
                }


                // Total BTC
                balances.Reset();

                query = "select ROUND(SUM((price_btc*balance_total)),8) from balances";
                balances = db.GetDataTable(query);
                foreach (DataRow r in balances.Rows)
                {
                    general_balance_total_btc = r[0].ToString();
                }


                // Total FIAT
                balances.Reset();

                query = "select ROUND(SUM((price_fiat*balance_total)),2) from balances";
                balances = db.GetDataTable(query);
                foreach (DataRow r in balances.Rows)
                {
                    general_balance_total_fiat = r[0].ToString();
                }

                txtBalancesGeneralTotalCoins.Text = general_balance_total_coins;
                txtBalancesGeneralBTCValue.Text = general_balance_total_btc + " BTC";
                txtBalancesGeneralFIATValue.Text = general_balance_total_fiat + " " + fiat_currency;

                ///////////////////////////////////////
                ///////// CHARTS STUFF ///////////////
                ////////////////////////////////////

                string coin_name = "";
                double coin_balance = 0;
                db = new SQLiteDatabase();
                DataTable balances_charts;
                String querychart = "select coin_name, ROUND(balance_total*price_btc,2) As total_btc from balances WHERE balance_total > 0 ORDER by total_btc DESC";
                balances_charts = db.GetDataTable(querychart);

                Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
                pieChartGeneral.InnerRadius = 50;
                SeriesCollection serie = new SeriesCollection();
                PieSeries PieSerie = new PieSeries();

                foreach (DataRow r in balances_charts.Rows)
                {

                    coin_name = r[0].ToString();
                    coin_balance = double.Parse(r[1].ToString());
                    PieSerie = new PieSeries
                    {
                        Title = coin_name,
                        Values = new ChartValues<double> { coin_balance },
                        //PushOut = 15,

                        DataLabels = true,
                        //DataLabelsTemplate = "",
                        //LabelPoint = labelPoint
                        LabelPoint = point => r[0].ToString()
                    };

                    serie.Add(PieSerie);

                }


                //pieChart1.LegendLocation = LegendLocation.Right;
                pieChartGeneral.HoverPushOut = 20;
                //pieChart1.DataTooltip = new CustomersTooltip();
                pieChartGeneral.Series = serie;

                buttonBalance.Text = "Refresh Portfolio";
                buttonBalance.Enabled = true;
                lblProcessingState.Text = "Done !";
            }

            catch
            {
                return "Error";
            }
            return "OK";
        }

        private void HistoricValuesChart()
        {



            //while (reader.Read())
            //{
            String querychart = "SELECT date_balance, balance_value_btc, balance_value_fiat from balances_total_history";
            SQLiteCommand command = new SQLiteCommand(querychart, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            SeriesCollection serie = new SeriesCollection();
            LineSeries LineSerie = new LineSeries();
            LineSerie = new LineSeries
            {
                Title = "Series 1",
                Values = new ChartValues<double> { }
            };
            string total_btc = "";
            while (reader.Read())
            {
                total_btc = reader["balance_value_btc"].ToString();
                LineSerie = new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { 5 }
                };
                //ChartValues<double> chartval = new ChartValues<double> { double.Parse(total_btc) };
                //LineSerie.Values = chartval;
            };
            cartesianChart1.Series = serie;

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Date",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" }
            });

            //cartesianChart1.AxisY.Add(new Axis
            //{
            //    Title = "Sales",
            //    LabelFormatter = value => value.ToString("C")
            //});

        }

        private void GetBTC_FIAT_Price()
        {
            //BTC TO FIAT Conversion
            var uri = String.Format("https://blockchain.info/ticker", 500);
            WebClient webclient = new WebClient();
            webclient.UseDefaultCredentials = true;
            var data = webclient.DownloadString(uri);
            var result = Convert.ToString(data);
            //dynamic price = JObject.Parse(result).SelectTokens(fiat_currency+".*");
            var parsed = JObject.Parse(result);
            var btc_price = new BTCPrice();

            btc_price.last = parsed.SelectToken(fiat_currency + ".last").Value<double>();
            btc_to_fiat = btc_price.last;
            //MessageBox.Show(btc_price.last.ToString());
        }

        private async Task<string> Exchange_Bittrex_GetOpenOrders()
        {
            buttonOrders.Text = "Loading Bittrex open orders...";
            ResponseWrapper<IEnumerable<BittrexSharp.Domain.OpenOrder>> x = await bittrex.GetOpenOrders();
            foreach (BittrexSharp.Domain.OpenOrder openOrder in x.Result)
            {
                
                metroTextBox1.Text = metroTextBox1.Text +
                "\r\n Exchange :" + openOrder.Exchange +
                "\r\nLimit :" + openOrder.Limit +
                "\r\nOrderType :" + openOrder.OrderType +
                "\r\nPrice :" + openOrder.Price +
                "\r\nPrice/Unit " + openOrder.PricePerUnit +
                "\r\nQuantity" + openOrder.Quantity +
                "\r\nQuantityRemaining" + openOrder.QuantityRemaining;
                SQLiteCommand sql = new SQLiteCommand("INSERT INTO open_orders(order_currency,order_limit,order_type," +
                    "order_price, order_quantity, order_quantityremain, exchange) VALUES ('" +
                  openOrder.Exchange + "','" + openOrder.Limit.ToString().Replace(",", ".") + "','" + openOrder.OrderType + "','"
                  + openOrder.Price.ToString().Replace(",", ".") + "','" + openOrder.Quantity.ToString().Replace(",", ".") + "','" + openOrder.QuantityRemaining.ToString().Replace(",", ".") + "','Bittrex')", m_dbConnection);

                try
                {
                    sql.ExecuteNonQuery();


                    DataSet ds = new DataSet();
                    string sql2 = "select order_currency As Pair, order_type As 'Type', order_limit As 'Limit Order', order_quantity As 'Quantity', order_quantityremain As 'Quantity Remaining' FROM open_orders WHERE Exchange='Bittrex'";
                    var da = new SQLiteDataAdapter(sql2, m_dbConnection);
                    da.Fill(ds);
                    GridOpenedOrdersBittrex.DataSource = ds.Tables[0].DefaultView;

                }
                catch (Exception)
                {

                    throw;
                    return "Error";
                }
            }
            return "OK";
        }

        private async Task<string> ExchangeBittex_GetBalances(bool hide_zero_balances)
        {
            buttonBalance.Text = "Processing Bittrex...";
            buttonBalance.Enabled = false;
            lblProcessingState.Text = "Processing Bittrex.";
            string sql2;
            if (hide_zero_balances == true)
            {
                sql2 = "select coin_name As Currency, balance_total As Total, balance_available As Available, price_btc As 'BTC Price', price_fiat As '" + fiat_currency + " Price', ROUND(price_btc*balance_total,7) As 'Total BTC', ROUND(price_fiat*balance_total,2) As 'Total " + fiat_currency + "' from balances WHERE balance_total <> 0 AND exchange='Bittrex'";
            }
            else
            {
                sql2 = "select coin_name As Currency, balance_total As Total, balance_available As Available, price_btc As 'BTC Price', price_fiat As '" + fiat_currency + " Price', price_btc*balance_total As ROUND('Total BTC',7), ROUND(price_fiat*balance_total,2) As 'Total " + fiat_currency + "' from balances WHERE exchange='Bittrex'";
            }
            // We get new data
            //Task<ResponseWrapper<IEnumerable<BittrexSharp.Domain.CurrencyBalance>>> x =  bittrex.GetBalances();
            //x.Wait();
            //var task_result = x.Result;


            ResponseWrapper<IEnumerable<BittrexSharp.Domain.CurrencyBalance>> x = await bittrex.GetBalances();
            if (x.Success == true)
            {
                long datetime_balance = DateTimeOffset.Now.ToUnixTimeSeconds();
                lblProcessingState.Text = "Processing Bittrex..";
                //CoinMarketCap stuff for price conversion
                ICoinmarketcapClient client = new CoinmarketcapClient();

                // Currency btc_to_fiat = client.GetCurrencyById("ethereum");
                // MessageBox.Show(currency.PriceBtc.ToString());

                //IEnumerable<Currency> x2 = client.GetCurrencies(50000, "EUR");


                string price_btc = "";
                string price_fiat = "";
                string coinmarketcap_currency_id = "";

                var client2 = new CryptoCompareClient();


                //var eth = await client2.Coins.SnapshotAsync(balance.Currency, "BTC");

                //Console.WriteLine(eth.Data.AggregatedData.Price.ToString());

                foreach (BittrexSharp.Domain.CurrencyBalance balance in x.Result)
                {
                    //if (balance.Currency == "BCC")
                    //{
                    //    balance.Currency = "BCH";
                    //}

                    //try
                    //{
                    //    var price_value_btc = await client2.Coins.SnapshotAsync(balance.Currency, "BTC");
                    //    Console.WriteLine(price_value_btc.Data.AggregatedData.Price.ToString());

                    //}
                    //catch (Exception)
                    //{

                    //    throw;
                    //}
                    //var price_value_fiat = await client2.Coins.SnapshotAsync(balance.Currency, "EUR");

                    //Console.WriteLine(price_value_fiat.Data.AggregatedData.Price.ToString());


                    //price_fiat = price_value_btc.Data.AggregatedData.Price.ToString();
                    // price_btc = price_value_fiat.Data.AggregatedData.Price.ToString();

                    if (balance.Currency == "BTC")
                    {
                        price_btc = "1";
                        price_fiat = btc_to_fiat.ToString();
                    }
                    else
                    {
                        ResponseWrapper<BittrexSharp.Domain.Ticker> ticker = await bittrex.GetTicker("BTC-" + balance.Currency);
                        price_btc = ticker.Result.Last.ToString().Replace(",", ".");
                        //var btc_to_fiat = await client2.Coins.SnapshotAsync("BTC", "EUR");
                        price_fiat = ((double.Parse(price_btc.Replace(".", ","))) * btc_to_fiat).ToString();
                        //price_fiat = "";
                    }



                    ////////// OLD CoinMaketCap stuff ////////////////
                    coinmarketcap_currency_id = balance.Currency;

                    // We use CoinMarketPrice to get current price of asset
                    //foreach (Currency coin in x2)
                    //{
                    //Fixing some shit ticker from Bittrex
                    //if (balance.Currency == "BCC")
                    //    {
                    //        balance.Currency = "BCH";
                    //    }

                    //    if (balance.Currency == coin.Symbol)
                    //    {
                    //        price_btc = coin.PriceBtc;
                    //        price_fiat = coin.PriceConvert;
                    //    }



                    //}

                    textBox1.Text = textBox1.Text + "\r\n Currency :" + balance.Currency + "\r\n Available : " + balance.Available.ToString().ToString(CultureInfo.CreateSpecificCulture("sv-SE")) + "\r\n Balance :" + balance.Balance + "\r\n Pending: " + balance.Pending;
                    SQLiteCommand sql = new SQLiteCommand("INSERT INTO balances (date_balance, exchange, balance_available, balance_reserved, balance_total, coin_name, balance_address, price_btc, price_fiat) VALUES ('" + datetime_balance.ToString() + "','Bittrex', '" + balance.Available + "','" + balance.Requested + "','" + balance.Balance + "','" + balance.Currency + "','" + balance.CryptoAddress + "','" + price_btc + "','" + price_fiat + "');", m_dbConnection);
                    sql.ExecuteNonQuery();
                }

                lblProcessingState.Text = "Processing Bittrex......";

                // We need to change comma for dots, just spent to much time trying to deal with decimal and then datagrid and so on..
                SQLiteCommand sql3 = new SQLiteCommand("UPDATE balances SET balance_available = replace(balance_available, ',', '.') WHERE balance_available LIKE '%,%';", m_dbConnection);
                sql3.ExecuteNonQuery();
                sql3 = new SQLiteCommand("UPDATE balances SET balance_total = replace(balance_total, ',', '.') WHERE balance_total LIKE '%,%';", m_dbConnection);
                sql3.ExecuteNonQuery();
                sql3 = new SQLiteCommand("UPDATE balances SET price_fiat = replace(price_fiat, ',', '.') WHERE price_fiat LIKE '%,%';", m_dbConnection);
                sql3.ExecuteNonQuery();
                sql3 = new SQLiteCommand("UPDATE balances SET balance_reserved = balance_total - balance_available", m_dbConnection);
                sql3.ExecuteNonQuery();
                lblProcessingState.Text = "Processing Bittrex............";
                DataSet ds = new DataSet();
                var da = new SQLiteDataAdapter(sql2, m_dbConnection);
                da.Fill(ds);
                GridBalanceBittrex.DataSource = ds.Tables[0].DefaultView;



                //string stm = "select count(coin_name) from balances"; // Add others queries here if necessary SELECT 44; SELECT 33";
                string bittrex_total_coins = "";
                string bittrex_total_btc = "";
                string bittrex_total_fiat = "";
                lblProcessingState.Text = "Processing Bittrex.................";
                try
                {
                    db = new SQLiteDatabase();
                    DataTable balances;
                    String query = "select count(coin_name) from balances where balance_total <> 0 AND exchange='Bittrex'";
                    balances = db.GetDataTable(query);
                    foreach (DataRow r in balances.Rows)
                    {
                        bittrex_total_coins = r[0].ToString();
                    }


                    // Total BTC
                    balances.Reset();

                    query = "select ROUND(SUM((price_btc*balance_total)),8) from balances WHERE exchange='Bittrex' ";
                    balances = db.GetDataTable(query);
                    foreach (DataRow r in balances.Rows)
                    {
                        bittrex_total_btc = r[0].ToString();
                    }


                    // Total FIAT
                    balances.Reset();

                    query = "select ROUND(SUM((price_fiat*balance_total)),2) from balances WHERE exchange='Bittrex'";
                    balances = db.GetDataTable(query);
                    foreach (DataRow r in balances.Rows)
                    {
                        bittrex_total_fiat = r[0].ToString();
                    }

                    //using (SQLiteCommand cmd = new SQLiteCommand(stm, m_dbConnection))
                    //{
                    //    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    //    {
                    //        do
                    //        {
                    //            reader.Read();
                    //            bittrex_total_coins = reader.GetTextReader(0).ToString();

                    //        } while (reader.NextResult());

                    //    }



                    //}
                    lblLoading.Visible = false;
                    buttonBalance.Enabled = true;


                    lblProcessingState.Text = "Done !";
                }
                catch (Exception fail)
                {
                    String error = "The following error has occurred:\n\n";
                    error += fail.Message.ToString() + "\n\n";
                    MessageBox.Show(error);
                    this.Close();
                }

                txtBittrexTotalCoins.Text = bittrex_total_coins;
                txtBittrexTotalBTC_Value.Text = bittrex_total_btc + " BTC";
                txtBittrexTotalFIAT_Value.Text = bittrex_total_fiat + " EUR";




                ///////////////////////////////////////
                ///////// CHARTS STUFF ///////////////
                ////////////////////////////////////

                string coin_name = "";
                double coin_balance = 0;
                db = new SQLiteDatabase();
                DataTable balances_charts;
                String querychart = "select coin_name, ROUND(balance_total*price_btc,2) from balances where exchange='Bittrex' AND balance_total > 0";
                balances_charts = db.GetDataTable(querychart);

                Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
                PieChartBittrex.InnerRadius = 50;
                SeriesCollection serie = new SeriesCollection();
                PieSeries PieSerie = new PieSeries();

                foreach (DataRow r in balances_charts.Rows)
                {

                    coin_name = r[0].ToString();
                    coin_balance = double.Parse(r[1].ToString());
                    PieSerie = new PieSeries
                    {
                        Title = coin_name,
                        Values = new ChartValues<double> { coin_balance },
                        //PushOut = 15,

                        DataLabels = true,
                        //DataLabelsTemplate = "",
                        //LabelPoint = labelPoint
                        LabelPoint = point => r[0].ToString()
                    };

                    serie.Add(PieSerie);

                }


                //pieChart1.LegendLocation = LegendLocation.Right;
                PieChartBittrex.HoverPushOut = 20;
                //pieChart1.DataTooltip = new CustomersTooltip();
                PieChartBittrex.Series = serie;



                //pieChart1.Series = new SeriesCollection(PieSerie);
                //{
                //    new PieSeries
                //    {
                //    Title = coin_name,
                //    Values = new ChartValues<double> { coin_balance },
                //    //PushOut = 15,
                //    DataLabels = true,
                //    LabelPoint = labelPoint
                //    }
                //};








                buttonBalance.Text = "Refresh Portfolio";
                buttonBalance.Enabled = true;
            }
            return "OK";

        }


        private async void metroButton1_ClickAsync(object sender, EventArgs e)
        {
            //lblProcessingState.Visible = true;
            //lblProcessingState.Text = "Working...";
            buttonBalance.Text = "Working...";
            buttonBalance.Enabled = false;
            lblLoading.Visible = true;

            //We drop all data so we only get real-time data for this table
            SQLiteCommand drop = new SQLiteCommand("DELETE FROM balances", m_dbConnection);
            drop.ExecuteNonQuery();
            if (checkbox_hide_zero.Checked == true)
            {
                if (inifile.Read("Exchange_Bittrex_Enabled") == "true")
                {
                    ExchangeBittex_GetBalances(true);
                }
                if (inifile.Read("Exchange_Kraken_Enabled") == "true")
                {
                    Exchange_Kraken_Get_Balances();
                }

                if (inifile.Read("Exchange_Hitbtc_Enabled") == "true")
                {
                    ExchangeHitBTC_GetBalances();
                }

                if (inifile.Read("Wallet_ETH_Address") != "")
                {
                    Get_ETH_Wallet_BalanceAsync();
                }

                ProcessGeneralBalancesData();

                //ProcessGeneralBalancesData();
            }
            else
            {
                if (inifile.Read("Exchange_Bittrex_Enabled") == "true")
                {
                    string x = await ExchangeBittex_GetBalances(true);


                }
                if (inifile.Read("Exchange_Kraken_Enabled") == "true")
                {
                    string x2 = await Exchange_Kraken_Get_Balances();

                }

                if (inifile.Read("Exchange_Hitbtc_Enabled") == "true")
                {
                    string x3 = await ExchangeHitBTC_GetBalances();

                }
                string x4 = await Get_ETH_Wallet_BalanceAsync();

                string x5 = await ProcessGeneralBalancesData();
                buttonBalance.Enabled = true;
                //ProcessGeneralBalancesData();
                //db = new SQLiteDatabase();
                //DataTable balances;
                //string total_btc = "";
                //string total_fiat = "";
                //String query = "SELECT SUM(price_btc*balance_total), SUM(price_fiat*balance_total) FROM balances";
                //balances = db.GetDataTable(query);
                //foreach (DataRow r in balances.Rows)
                //{
                //    total_btc= r[0].ToString();
                //    total_fiat = r[1].ToString();
                //}
                //long datetime_balance = DateTimeOffset.Now.ToUnixTimeSeconds();
                //string sql_query = "INSERT INTO balances_total_history (date_balance, balance_value_btc, balance_value_fiat) VALUES ('" + datetime_balance.ToString() + "','" + total_btc + "','" + total_fiat+ "')";
                //SQLiteCommand sql = new SQLiteCommand(sql_query, m_dbConnection);
                //sql.ExecuteNonQuery();

            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            ExchangeHitBTC_GetBalances();

        }

        private async Task<string> ExchangeHitBTC_GetBalances()
        {
            buttonBalance.Text = "Processing Hitbtc...";
            buttonBalance.Enabled = false;
            lblProcessingState.Text = "Processing Hitbtc.";
            GetBTC_FIAT_Price();
            //Exchange_Hitbtc_GetBalancesAsync();

            //Hitbtc Markets
            //var uri = String.Format("https://api.hitbtc.com/api/2/trading/balance", 500);
            //WebClient webclient = new WebClient();

            //Hitbtc Balance
            var uri = String.Format("https://api.hitbtc.com/api/2/trading/balance", 500);
            WebClient webclient = new WebClient();
            string credentials = Convert.ToBase64String(
            Encoding.ASCII.GetBytes(exchange_hitbtc_key + ":" + exchange_hitbtc_secret));
            webclient.Headers[HttpRequestHeader.Authorization] = string.Format(
                "Basic {0}", credentials);
            webclient.UseDefaultCredentials = true;
            var data = webclient.DownloadString(uri);
            var result = Convert.ToString(data);
            JArray balances = JArray.Parse(result);
            dynamic dynJson = JsonConvert.DeserializeObject(result.ToString());
            string currency;
            string balance_available;
            string balance_reserved;

            string price_fiat = "";
            string price_btc = "";
            long datetime_balance = DateTimeOffset.Now.ToUnixTimeSeconds();

            lblProcessingState.Text = "Processing Hitbtc....";

            foreach (var item in dynJson)
            {
                if (item.available == "0" && item.reserved == "0")
                {
                    // Dummy, we don't need to log coins we don't have
                }
                else
                {

                    currency = item.currency;
                    balance_available = item.available;
                    balance_reserved = item.reserved;
                    if (currency != "BTC")
                    {
                        // Hitbtc Markets
                        uri = String.Format("https://api.hitbtc.com/api/2/public/ticker/" + item.currency + "BTC", 500);
                        webclient = new WebClient();
                        webclient.UseDefaultCredentials = true;
                        data = webclient.DownloadString(uri);
                        result = Convert.ToString(data);
                        dynamic market = JsonConvert.DeserializeObject(result.ToString());
                        price_btc = market.last;
                        price_fiat = ((double.Parse(price_btc.Replace(".", ","))) * btc_to_fiat).ToString();
                    }
                    else
                    {
                        price_btc = "1";
                        price_fiat = btc_to_fiat.ToString();
                    }

                    string sql_query = "INSERT INTO balances (date_balance, exchange, balance_available, balance_reserved, balance_total, coin_name, balance_address, price_btc, price_fiat) VALUES ('" + datetime_balance.ToString() + "','HitBTC', '" + balance_available + "','','" + (double.Parse(balance_available.Replace(".", ",")) + double.Parse(balance_reserved.Replace(".", ","))) + "','" + currency + "','','" + price_btc + "','" + price_fiat + "');";
                    SQLiteCommand sql = new SQLiteCommand(sql_query, m_dbConnection);
                    sql.ExecuteNonQuery();

                    lblProcessingState.Text = "Processing Hitbtc........";


                    //////////////////////////////
                    // Hitbtc Tab Form stuff //
                    ////////////////////////////

                    // We need to change comma for dots, just spent to much time trying to deal with decimal and then datagrid and so on..
                    SQLiteCommand sql3 = new SQLiteCommand("UPDATE balances SET balance_available = replace(balance_available, ',', '.') WHERE balance_available LIKE '%,%';", m_dbConnection);
                    sql3.ExecuteNonQuery();
                    sql3 = new SQLiteCommand("UPDATE balances SET balance_total = replace(balance_total, ',', '.') WHERE balance_total LIKE '%,%';", m_dbConnection);
                    sql3.ExecuteNonQuery();
                    sql3 = new SQLiteCommand("UPDATE balances SET price_fiat = replace(price_fiat, ',', '.') WHERE price_fiat LIKE '%,%';", m_dbConnection);
                    sql3.ExecuteNonQuery();
                    sql3 = new SQLiteCommand("UPDATE balances SET balance_reserved = balance_total - balance_available", m_dbConnection);
                    sql3.ExecuteNonQuery();

                    DataSet ds = new DataSet();
                    string sql2 = "select coin_name As Currency, balance_total As Total, balance_available As Available, price_btc As 'BTC Price', price_fiat As '" + fiat_currency + " Price', ROUND(price_btc*balance_total,7) As 'Total BTC', ROUND(price_fiat*balance_total,2) As 'Total " + fiat_currency + "' from balances WHERE balance_total <> 0 AND exchange='HitBTC'";
                    var da = new SQLiteDataAdapter(sql2, m_dbConnection);
                    da.Fill(ds);
                    GridBalancesHitBTC.DataSource = ds.Tables[0].DefaultView;



                    //string stm = "select count(coin_name) from balances where exchange='HitBTC'"; // Add others queries here if necessary SELECT 44; SELECT 33";
                    string hitbtc_total_coins = "";
                    string hitbtc_total_btc = "";
                    string hitbtc_total_fiat = "";

                    try
                    {
                        db = new SQLiteDatabase();
                        DataTable balances_hitbtc;
                        String query = "select count(coin_name) from balances where balance_total <> 0 AND exchange='HitBTC'";
                        balances_hitbtc = db.GetDataTable(query);
                        foreach (DataRow r in balances_hitbtc.Rows)
                        {
                            hitbtc_total_coins = r[0].ToString();
                        }


                        // Total BTC
                        balances_hitbtc.Reset();

                        query = "select ROUND(SUM((price_btc*balance_total)),8) from balances WHERE exchange='HitBTC'";
                        balances_hitbtc = db.GetDataTable(query);
                        foreach (DataRow r in balances_hitbtc.Rows)
                        {
                            hitbtc_total_btc = r[0].ToString();
                        }


                        // Total FIAT
                        balances_hitbtc.Reset();

                        query = "select ROUND(SUM((price_fiat*balance_total)),2) from balances WHERE exchange='HitBTC'";
                        balances_hitbtc = db.GetDataTable(query);
                        foreach (DataRow r in balances_hitbtc.Rows)
                        {
                            hitbtc_total_fiat = r[0].ToString();
                        }


                        txtHitbtcTotalCoins.Text = hitbtc_total_coins;
                        txtHitbtcBTCValue.Text = hitbtc_total_btc + " BTC";
                        txtHitbtcFIATValue.Text = hitbtc_total_fiat + " EUR";


                        ///////////////////////////////////////
                        ///////// CHARTS STUFF ///////////////
                        ////////////////////////////////////

                        string coin_name = "";
                        double coin_balance = 0;
                        db = new SQLiteDatabase();
                        DataTable balances_charts;
                        String querychart = "select coin_name, ROUND(balance_total*price_btc,2) from balances where exchange='HitBTC' AND balance_total > 0";
                        balances_charts = db.GetDataTable(querychart);

                        Func<ChartPoint, string> labelPoint = chartPoint =>
                        string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
                        pieChartHitbtc.InnerRadius = 50;
                        SeriesCollection serie = new SeriesCollection();
                        PieSeries PieSerie = new PieSeries();

                        foreach (DataRow r in balances_charts.Rows)
                        {

                            coin_name = r[0].ToString();
                            coin_balance = double.Parse(r[1].ToString());
                            PieSerie = new PieSeries
                            {
                                Title = coin_name,
                                Values = new ChartValues<double> { coin_balance },
                                //PushOut = 15,

                                DataLabels = true,
                                //DataLabelsTemplate = "",
                                //LabelPoint = labelPoint
                                LabelPoint = point => r[0].ToString()
                            };

                            serie.Add(PieSerie);

                        }


                        //pieChart1.LegendLocation = LegendLocation.Right;
                        pieChartHitbtc.HoverPushOut = 20;
                        //pieChart1.DataTooltip = new CustomersTooltip();
                        pieChartHitbtc.Series = serie;

                        buttonBalance.Text = "Refresh Portfolio";
                        buttonBalance.Enabled = true;
                        lblProcessingState.Text = "Done !";


                    }
                    catch
                    {
                        return "Error";
                    }
                    //Console.WriteLine("{0} {1} {2} \n", item.currency, item.available,
                    //    item.reserved);
                }
            }
            return "OK";
        }


        private async Task<string> Exchange_Kraken_Get_Balances()
        {
            try
            {
                buttonBalance.Text = "(trying) Processing Kraken...";
                buttonBalance.Enabled = false;

                lblProcessingState.Text = "Processing Kraken........";
                GetBTC_FIAT_Price();
                string currency = "";
                string balance = "";
                string ticker = "";
                string price_fiat = "";
                string price_btc = "";
                long datetime_balance = DateTimeOffset.Now.ToUnixTimeSeconds();

                Kraken kraken = new Kraken(exchange_kraken_key, exchange_kraken_secret);
                var accountBalance = kraken.GetAccountBalance();

                foreach (KeyValuePair<string, decimal> pair in accountBalance)
                {
                    currency = pair.Key;
                    balance = pair.Value.ToString();
                    if (currency == "ZEUR")
                    {
                        price_fiat = "1";
                    }
                    else if (currency == "XXBT")
                    {
                        price_btc = "1";
                    }
                    else
                    {
                        switch (currency)
                        {
                            case "BCH":
                                currency = currency;
                                break;

                            default:
                                currency = currency.Substring(1);
                                break;
                        }
                        //currency = currency.Substring(1);
                        var KrakenBTCPrice = kraken.GetTicker(currency + "XBT");
                        foreach (KeyValuePair<string, Ticker> balancepair in KrakenBTCPrice)
                        {
                            price_btc = balancepair.Value.Closed[0].ToString();
                            price_fiat = ((double.Parse(price_btc.Replace(".", ","))) * btc_to_fiat).ToString();
                            //MessageBox.Show(balancepair.Value.Closed[0].ToString());
                            Console.WriteLine("{0}, {1}", balancepair.Key, balancepair.Value);
                            string sql_query = "INSERT INTO balances (date_balance, exchange, balance_available, balance_reserved, balance_total, coin_name, balance_address, price_btc, price_fiat) VALUES ('" + datetime_balance.ToString() + "','Kraken', '" + balance + "','','" + balance + "','" + currency + "','','" + price_btc.Replace(",", ".") + "','" + price_fiat + "');";
                            SQLiteCommand sql = new SQLiteCommand(sql_query, m_dbConnection);
                            sql.ExecuteNonQuery();

                        }

                    }
                    return "OK";

                }


            }
            catch (Exception e)
            {

                MessageBox.Show("Kraken : " + e.Message.ToString(), "Kraken Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error";
            }




            //////////////////////////////
            // Kraken Tab Form stuff //
            ////////////////////////////

            // We need to change comma for dots, just spent to much time trying to deal with decimal and then datagrid and so on..
            SQLiteCommand sql3 = new SQLiteCommand("UPDATE balances SET balance_available = replace(balance_available, ',', '.') WHERE balance_available LIKE '%,%';", m_dbConnection);
            sql3.ExecuteNonQuery();
            sql3 = new SQLiteCommand("UPDATE balances SET balance_total = replace(balance_total, ',', '.') WHERE balance_total LIKE '%,%';", m_dbConnection);
            sql3.ExecuteNonQuery();
            sql3 = new SQLiteCommand("UPDATE balances SET price_fiat = replace(price_fiat, ',', '.') WHERE price_fiat LIKE '%,%';", m_dbConnection);
            sql3.ExecuteNonQuery();
            sql3 = new SQLiteCommand("UPDATE balances SET balance_reserved = balance_total - balance_available", m_dbConnection);
            sql3.ExecuteNonQuery();

            DataSet ds = new DataSet();
            string sql2 = "select coin_name As Currency, balance_total As Total, balance_available As Available, price_btc As 'BTC Price', price_fiat As '" + fiat_currency + " Price', ROUND(price_btc*balance_total,7) As 'Total BTC', ROUND(price_fiat*balance_total,2) As 'Total " + fiat_currency + "'  from balances WHERE balance_total <> 0 AND exchange='Kraken'";
            var da = new SQLiteDataAdapter(sql2, m_dbConnection);
            da.Fill(ds);
            GridBalancesKraken.DataSource = ds.Tables[0].DefaultView;



            //string stm = "select count(coin_name) from balances where exchange='Kraken'"; // Add others queries here if necessary SELECT 44; SELECT 33";
            string Kraken_total_coins = "";
            string Kraken_total_btc = "";
            string Kraken_total_fiat = "";

            try
            {
                db = new SQLiteDatabase();
                DataTable balances_Kraken;
                String query = "select count(coin_name) from balances where balance_total <> 0 AND exchange='Kraken'";
                balances_Kraken = db.GetDataTable(query);
                foreach (DataRow r in balances_Kraken.Rows)
                {
                    Kraken_total_coins = r[0].ToString();
                }


                // Total BTC
                balances_Kraken.Reset();

                query = "select ROUND(SUM((price_btc*balance_total)),8) from balances WHERE exchange='Kraken'";
                balances_Kraken = db.GetDataTable(query);
                foreach (DataRow r in balances_Kraken.Rows)
                {
                    Kraken_total_btc = r[0].ToString();
                }


                // Total FIAT
                balances_Kraken.Reset();

                query = "select ROUND(SUM((price_fiat*balance_total)),2) from balances WHERE exchange='Kraken'";
                balances_Kraken = db.GetDataTable(query);
                foreach (DataRow r in balances_Kraken.Rows)
                {
                    Kraken_total_fiat = r[0].ToString();
                }


                txtKrakenTotalCoins.Text = Kraken_total_coins;
                txtKrakenBTCValue.Text = Kraken_total_btc + " BTC";
                txtKrakenFIATValue.Text = Kraken_total_fiat + " EUR";


                ///////////////////////////////////////
                ///////// CHARTS STUFF ///////////////
                ////////////////////////////////////

                string coin_name = "";
                double coin_balance = 0;
                db = new SQLiteDatabase();
                DataTable balances_charts;
                String querychart = "select coin_name, ROUND(balance_total*price_btc,2) from balances where exchange='Kraken' AND balance_total > 0";
                balances_charts = db.GetDataTable(querychart);

                Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
                pieChartKraken.InnerRadius = 50;
                SeriesCollection serie = new SeriesCollection();
                PieSeries PieSerie = new PieSeries();

                foreach (DataRow r in balances_charts.Rows)
                {

                    coin_name = r[0].ToString();
                    coin_balance = double.Parse(r[1].ToString());
                    PieSerie = new PieSeries
                    {
                        Title = coin_name,
                        Values = new ChartValues<double> { coin_balance },
                        //PushOut = 15,

                        DataLabels = true,
                        //DataLabelsTemplate = "",
                        //LabelPoint = labelPoint
                        LabelPoint = point => r[0].ToString()
                    };

                    serie.Add(PieSerie);

                }


                //pieChart1.LegendLocation = LegendLocation.Right;
                pieChartKraken.HoverPushOut = 20;
                //pieChart1.DataTooltip = new CustomersTooltip();
                pieChartKraken.Series = serie;


                lblProcessingState.Text = "Done !";
                buttonBalance.Text = "Refresh Portfolio";
                return "OK";

            }

            catch
            {
                return "Error";
            }


            return "OK";






            //Console.WriteLine("{0}, {1}", pair.Key, pair.Value);


        }

        private async Task<string> Exchange_Hitbtc_GetOpenOrders()
        {
            //Hitbtc OpenOrders
            var uri = String.Format("https://api.hitbtc.com/api/2/order", 500);
            WebClient webclient = new WebClient();
            string credentials = Convert.ToBase64String(
            Encoding.ASCII.GetBytes(exchange_hitbtc_key + ":" + exchange_hitbtc_secret));
            webclient.Headers[HttpRequestHeader.Authorization] = string.Format(
                "Basic {0}", credentials);
            webclient.UseDefaultCredentials = true;
            var data = webclient.DownloadString(uri);
            var result = Convert.ToString(data);
            JArray balances = JArray.Parse(result);
            dynamic dynJson = JsonConvert.DeserializeObject(result.ToString());
            string symbol;
            string order_type;
            string status;
            string type;
            string quantity;
            string price;
            string cumQuantity;
            string balance_reserved;

            long datetime_balance = DateTimeOffset.Now.ToUnixTimeSeconds();

            foreach (var item in dynJson)
            {
                symbol = item.symbol;
                order_type = item.side;
                status = item.status;
                type = item.type;
                quantity = item.quantity;
                price = item.price;
                cumQuantity = item.cumQuantity;

                SQLiteCommand sql = new SQLiteCommand("INSERT INTO open_orders(order_currency,order_limit,order_type," +
                  "order_price, order_quantity, order_quantityremain, exchange) VALUES ('" +
                symbol + "','" + price.Replace(",", ".") + "','" + order_type + " - " + type + "','"
                + price.Replace(",", ".") + "','" + cumQuantity.Replace(",", ".") + "','" + quantity.Replace(",", ".") + "','Hitbtc')", m_dbConnection);

                try
                {
                    sql.ExecuteNonQuery();


                    DataSet ds = new DataSet();
                    string sql2 = "select order_currency As Pair, order_type As 'Type', order_limit As 'Order Price', order_quantity As 'Quantity', order_quantityremain As 'Quantity Remaining' FROM open_orders WHERE Exchange='Hitbtc'";
                    var da = new SQLiteDataAdapter(sql2, m_dbConnection);
                    da.Fill(ds);
                    GridHitbtcOpenOrders.DataSource = ds.Tables[0].DefaultView;

                }
                catch (Exception)
                {

                    throw;
                }
            }
            return "OK";
        }

        private async Task Exchange_Hitbtc_GetBalancesAsync()
        {
            HitBtcApi.HitBtcApi hitbtc = new HitBtcApi.HitBtcApi();
            try
            {
                hitbtc.Authorize(exchange_hitbtc_key, exchange_hitbtc_secret);

                HitBtcApi.Model.TradingBalanceList x = await hitbtc.Trading.GeTradingBalance();
                long datetime_balance = DateTimeOffset.Now.ToUnixTimeSeconds();
                foreach (HitBtcApi.Model.TradingBalance balance in x.balance)
                {
                    //textBox2.Text = balance.currency_code + ": " + balance.cash;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        private async Task<string> Get_ETH_Wallet_BalanceAsync()

        {
            buttonBalance.Text = "Processing ETH Wallet...";
            buttonBalance.Enabled = false;
            //ETH Wallet Balance
            var uri = String.Format("https://api.ethplorer.io/getAddressInfo/" + eth_wallet_address + "?apiKey=freekey", 500);
            WebClient webclient = new WebClient();
            webclient.UseDefaultCredentials = true;
            var data = webclient.DownloadString(uri);
            var result = Convert.ToString(data);

            dynamic dynJson = JsonConvert.DeserializeObject(result.ToString());
            string address;
            string balance;
            string totalIn;
            string totalOut;
            string countTxs;
            string token_symbol;
            string token_balance;

            string price_fiat = "";
            string price_btc = "";
            string currency = "";
            long datetime_balance = DateTimeOffset.Now.ToUnixTimeSeconds();

            lblProcessingState.Text = "Processing ETH Wallet....";
            var uri2 = String.Format("https://min-api.cryptocompare.com/data/price?fsym=ETH&tsyms=BTC");

            WebClient webclient2 = new WebClient();
            webclient2.UseDefaultCredentials = true;
            var data2 = webclient2.DownloadString(uri2);
            var result2 = Convert.ToString(data2);

            dynamic dynJson2 = JsonConvert.DeserializeObject(result2.ToString());
            price_btc = "0";
            foreach (string item2 in dynJson2.SelectTokens("BTC"))
            {
                price_btc = result2.ToString().Substring(7);
                price_btc = price_btc.Remove(price_btc.Length - 1);
            }
            price_fiat = ((double.Parse(price_btc.Replace(".", ","))) * btc_to_fiat).ToString();
            foreach (var item in dynJson.SelectTokens("ETH"))
            {
                //address = item.address;
                balance = item.balance.ToString().Replace(",", ".");
                totalIn = item.totalIn.ToString();
                totalOut = item.totalIn.ToString();
                countTxs = item.totalIn.ToString();
                currency = "ETH";
                string sql_query = "INSERT INTO balances (date_balance, exchange, balance_available, balance_reserved, balance_total, coin_name, balance_address, price_btc, price_fiat) VALUES ('" + datetime_balance.ToString() + "','Wallet', '" + balance + "','','" + balance + "','" + currency + "','','" + price_btc.Replace(",", ".") + "','" + price_fiat + "');";
                SQLiteCommand sql = new SQLiteCommand(sql_query, m_dbConnection);
                sql.ExecuteNonQuery();
            }

            // Extra Tokens in ETH Wallet
            foreach (var item in dynJson.SelectTokens("tokens[*]"))
            {

                currency = item.tokenInfo.symbol.ToString();
                balance = item.balance;
                if (balance.Length > 8)
                {
                    balance = item.balance.ToString().Substring(0, 8);
                }
                var uri3 = String.Format("https://min-api.cryptocompare.com/data/price?fsym=" + currency + "&tsyms=BTC");

                WebClient webclient3 = new WebClient();
                webclient3.UseDefaultCredentials = true;
                var data3 = webclient3.DownloadString(uri3);
                var result3 = Convert.ToString(data3);

                dynamic dynJson3 = JsonConvert.DeserializeObject(result3.ToString());
                price_btc = "0";
                foreach (string item2 in dynJson3.SelectTokens("BTC"))
                {
                    price_btc = result3.ToString().Substring(7);
                    price_btc = price_btc.Remove(price_btc.Length - 1);
                }
                price_fiat = ((double.Parse(price_btc.Replace(".", ","))) * btc_to_fiat).ToString();
                string sql_query = "INSERT INTO balances (date_balance, exchange, balance_available, balance_reserved, balance_total, coin_name, balance_address, price_btc, price_fiat) VALUES ('" + datetime_balance.ToString() + "','Wallet', '" + balance + "','','" + balance + "','" + currency + "','','" + price_btc.Replace(",", ".") + "','" + price_fiat + "');";
                SQLiteCommand sql = new SQLiteCommand(sql_query, m_dbConnection);
                sql.ExecuteNonQuery();

            }

            lblProcessingState.Text = "Done !";
            return "OK";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.ShowDialog();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Exchange_Kraken_Get_Balances();
        }


        private void metroButton5_Click(object sender, EventArgs e)
        {
            Get_ETH_Wallet_BalanceAsync();
        }

        private void metroButton4_Click_1(object sender, EventArgs e)
        {
            HistoricValuesChart();
            //cartesianChart1.Series.Add(new LineSeries
            //{
            //    Values = new ChartValues<double> { 5, 3, 2, 4, 5 },
            //    LineSmoothness = 0, //straight lines, 1 really smooth lines
            //    PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
            //    PointGeometrySize = 50,
            //    PointForeground = System.Windows.Media.Brushes.Gray
            //});

        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            buttonOrders.Enabled = false;
            buttonOrders.Text = "Loading orders...";
            SQLiteCommand drop = new SQLiteCommand("DELETE FROM open_orders", m_dbConnection);
            drop.ExecuteNonQuery();

            drop = new SQLiteCommand("DELETE FROM trades_history", m_dbConnection);
            drop.ExecuteNonQuery();
            string x = await GetOpenOrders();
            string x2 = "";
            string x3 = "";
            string x4 = "";
            if (inifile.Read("Exchange_Hitbtc_Enabled") == "true")
            {
                 x2 = await Exchange_Hitbtc_GetHistoryTrades();
            }
            if (inifile.Read("Exchange_Bittrex_Enabled") == "true")
            {
                 x3 = await Exchange_Bittrex_GetOrdersHistory();
            }
            if (inifile.Read("Exchange_Kraken_Enabled") == "true")
            {
                 //x2 = await Exchange_Hitbtc_GetHistoryTrades();
            }
             x4 = await GetAllHistoryOrders();

            if (x2 == "OK")
            {
                foreach (DataGridViewRow datarow in GridHitBTCHistoryOrders.Rows)
                {
                    bool colored = false;
                    bool not_vip = true;
                    if (datarow.Cells["Type"].Value.ToString() == "buy")
                    {
                        datarow.DefaultCellStyle.ForeColor = System.Drawing.Color.SeaGreen;
                        colored = true;
                    }
                    if (datarow.Cells["Type"].Value.ToString() == "sell")
                    {
                        datarow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                        colored = true;
                    }
                }
                GridHitBTCHistoryOrders.Refresh();
            }
            

            buttonOrders.Enabled = true;
            buttonOrders.Text = "Refresh Orders";
        }

        private async Task<string> GetOpenOrders()
        {
            string x2 = "";
            string x3 = "";
            string x4 = "";

            x2 = await Exchange_Bittrex_GetOpenOrders();
            if (x2 == "OK")
            {
                x3 = await Exchange_Hitbtc_GetOpenOrders();

            }
            if (x3 == "OK")
            {
                x4 = await GetAllOpenOrders();
            }
            return "OK";
        }

        private async Task<string> GetAllOpenOrders()
        {
            buttonOrders.Text = "Loading All open orders...";
            string sql = "select exchange As Exchange, order_currency As Pair, order_type As 'Type', order_limit As 'Order Price', order_quantity As 'Quantity', order_quantityremain As 'Quantity Remaining' FROM open_orders";
            DataSet ds = new DataSet();
            var da = new SQLiteDataAdapter(sql, m_dbConnection);
            da.Fill(ds);
            GridGeneralOpenOrders.DataSource = ds.Tables[0].DefaultView;
            return "OK";
        }

        private async Task<string> GetAllHistoryOrders()
        {
            buttonOrders.Text = "Loading all historic orders...";
            string sql = "select exchange As Exchange, trade_date As Date, trade_symbol As Pair, trade_type As Type, trade_quantity As Quantity, trade_price As Price, trade_fee As Fee FROM trades_history";
            DataSet ds = new DataSet();
            var da = new SQLiteDataAdapter(sql, m_dbConnection);
            da.Fill(ds);
            GridGeneralHistoryTrades.DataSource = ds.Tables[0].DefaultView;
            return "OK";
        }

        private async Task<string> Exchange_Hitbtc_GetHistoryTrades()
        {
            buttonOrders.Text = "Loading Hitbtc open orders...";
            //Hitbtc OpenOrders
            var uri = String.Format("https://api.hitbtc.com/api/2/history/trades", 500);
            WebClient webclient = new WebClient();
            string credentials = Convert.ToBase64String(
            Encoding.ASCII.GetBytes(exchange_hitbtc_key + ":" + exchange_hitbtc_secret));
            webclient.Headers[HttpRequestHeader.Authorization] = string.Format(
                "Basic {0}", credentials);
            webclient.UseDefaultCredentials = true;
            var data = webclient.DownloadString(uri);
            var result = Convert.ToString(data);
            JArray balances = JArray.Parse(result);
            dynamic dynJson = JsonConvert.DeserializeObject(result.ToString());
            string symbol;
            string order_type;
            string fee;
            string type;
            string quantity;
            string price;
            string trade_date;

            long datetime_balance = DateTimeOffset.Now.ToUnixTimeSeconds();

            foreach (var item in dynJson)
            {
                symbol = item.symbol;
                order_type = item.side;
                quantity = item.quantity;
                price = item.price;
                trade_date = item.timestamp;
                fee = item.fee;


                SQLiteCommand sql = new SQLiteCommand("INSERT INTO trades_history(trade_date, trade_symbol, trade_type, trade_quantity, trade_price, trade_fee, exchange) " +
                    "VALUES ('" +
                trade_date + "','" + symbol + "','" + order_type + "','" + quantity + "','"
                + price.Replace(",", ".") + "','" + fee.Replace(",", ".") + "','Hitbtc')", m_dbConnection);

                try
                {
                    sql.ExecuteNonQuery();


                    DataSet ds = new DataSet();
                    string sql2 = "select trade_date As Date, trade_symbol As Pair, trade_type As Type, trade_quantity As Quantity, trade_price As Price, trade_fee As Fee FROM trades_history WHERE Exchange='Hitbtc'";
                    var da = new SQLiteDataAdapter(sql2, m_dbConnection);
                    da.Fill(ds);
                    GridHitBTCHistoryOrders.DataSource = ds.Tables[0].DefaultView;
    
                }
                catch (Exception)
                {

                    throw;
                    return "Error";
                }
            }

            return "OK";
        }


        private async Task<string> Exchange_Bittrex_GetOrdersHistory()
        {
            buttonOrders.Text = "Loading Bittrex orders history...";
            ResponseWrapper<IEnumerable<BittrexSharp.Domain.HistoricOrder>> x = await bittrex.GetOrderHistory();
            foreach (BittrexSharp.Domain.HistoricOrder trade in x.Result)
            {
               
                SQLiteCommand sql = new SQLiteCommand("INSERT INTO trades_history(trade_date,trade_symbol,trade_type,trade_quantity,trade_price,trade_fee,exchange) " +
                    "VALUES ('" +
                  trade.Timestamp + "','" + trade.Exchange.ToString().Replace(",", ".") + "','" + trade.OrderType + "','"
                  + trade.Quantity.ToString().Replace(",", ".") + "','" + trade.Price.ToString().Replace(",", ".") + "','" + trade.Commission.ToString().Replace(",", ".") + "','Bittrex')", m_dbConnection);

                try
                {
                    sql.ExecuteNonQuery();


                    DataSet ds = new DataSet();
                    string sql2 = "select trade_date As Date, trade_symbol As Pair, trade_type As Type, trade_quantity As Quantity, trade_price As Price, trade_fee As Fee FROM trades_history WHERE Exchange='Bittrex'";
                    var da = new SQLiteDataAdapter(sql2, m_dbConnection);
                    da.Fill(ds);
                    GridTradesHistoryBittrex.DataSource = ds.Tables[0].DefaultView;

                    foreach (DataGridViewRow datarow in GridTradesHistoryBittrex.Rows)
                    {
                        bool colored = false;
                        bool not_vip = true;
                        if (datarow.Cells["Type"].Value.ToString() == "LIMIT_BUY")
                        {
                            datarow.DefaultCellStyle.ForeColor = System.Drawing.Color.SeaGreen;
                            colored = true;
                        }
                        if (datarow.Cells["Type"].Value.ToString() == "LIMIT_SELL")
                        {
                            datarow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                            colored = true;
                        }
                    }
                    string bittrex_total_trades = "0";
                    string bittrex_total_buy = "0";
                    string bittrex_total_sell = "0";
                    string bittrex_fees_btc = "0";
                    db = new SQLiteDatabase();
                    DataTable bittrex_history;
                    String query = "SELECT SUM(trade_fee) FROM trades_history WHERE exchange = 'Bittrex' AND trade_symbol LIKE '%BTC%'";
                    bittrex_history = db.GetDataTable(query);
                    foreach (DataRow r in bittrex_history.Rows)
                    {
                        if (r[0].ToString() == "")
                        {
                            bittrex_fees_btc = "0";
                        }
                        else bittrex_fees_btc = r[0].ToString();
                    }

                    // ETH Fees
                    string bittrex_fees_eth = "0";
                    query = "SELECT SUM(trade_fee) FROM trades_history WHERE exchange = 'Bittrex' AND trade_symbol LIKE '%ETH%'";
                    bittrex_history = db.GetDataTable(query);
                    foreach (DataRow r in bittrex_history.Rows)
                    {
                        if (r[0].ToString() == "")
                        {
                            bittrex_fees_eth = "0";
                        }
                        else bittrex_fees_eth = r[0].ToString();
                    }


                    query = "select COUNT(id_trade) FROM trades_history WHERE exchange='Bittrex' ";
                    bittrex_history = db.GetDataTable(query);
                    foreach (DataRow r in bittrex_history.Rows)
                    {
                        bittrex_total_trades = r[0].ToString();
                    }

                    query = "select COUNT(id_trade) FROM trades_history WHERE exchange='Bittrex' AND trade_type = 'LIMIT_BUY' ";
                    bittrex_history = db.GetDataTable(query);
                    foreach (DataRow r in bittrex_history.Rows)
                    {
                        bittrex_total_buy = r[0].ToString();
                    }

                    query = "select COUNT(id_trade) FROM trades_history WHERE exchange='Bittrex' AND trade_type = 'LIMIT_SELL' ";
                    bittrex_history = db.GetDataTable(query);
                    foreach (DataRow r in bittrex_history.Rows)
                    {
                        bittrex_total_sell = r[0].ToString();
                    }



                    lblBittrexTradesFeesBTC.Text = bittrex_fees_btc + " BTC";
                    lblBittrexTradesFeesETH.Text = bittrex_fees_eth + "ETH";
                    lblBittrexTradesTotal.Text = bittrex_total_trades;
                    lblBittrexTradesSell.Text = bittrex_total_sell;
                    lblBittrexTradesBuy.Text = bittrex_total_buy;


                }
                catch (Exception)
                {

                    throw;
                    return "Error";
                }
            }
            return "OK";
        }

        private void GridBalancesGeneral_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Ignore if a column or row header is clicked
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewCell clickedCell = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];

                    // Here you can do whatever you want with the cell
                    this.GridBalancesGeneral.CurrentCell = clickedCell;  // Select the clicked cell, for instance

                    // Get mouse position relative to the vehicles grid
                    var relativeMousePosition = GridBalancesGeneral.PointToClient(Cursor.Position);

                    // Show the context menu
                    this.metroContextMenu1.Show(GridBalancesGeneral, relativeMousePosition);
                }
            }
        }

        private void metroContextMenu1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            string currency = GridBalancesGeneral.SelectedRows[0].Cells["Currency"].Value.ToString();
            string exchange = GridBalancesGeneral.SelectedRows[0].Cells["Exchange"].Value.ToString();
            string price_btc = GridBalancesGeneral.SelectedRows[0].Cells["BTC Price"].Value.ToString();

            NewAlert alert = new NewAlert(currency, exchange, price_btc);
            alert.ShowDialog();
        }
    }




}
    

