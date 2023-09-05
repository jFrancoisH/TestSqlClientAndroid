using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MauiAppTestReqSql
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            try
            {
                Platforms.Android.DangerousTrustProvider.Register();

				string connString = "Server=testServer.domain.local; Database=TestDb; User Id=sa; password=147852$Test";
				using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string reqSql0 = new string(' ', 1001) + "select 1";

                    using (SqlCommand cmd = new SqlCommand(reqSql0, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }


            


        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}