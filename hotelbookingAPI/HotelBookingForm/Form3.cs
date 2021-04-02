using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hotelbookingAPI.Models;
using Newtonsoft.Json;

namespace HotelBookingForm
{
    public partial class Form3 : Form
    {

        
        public Form3()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            hoteluser u = new hoteluser()
            {
                name = textBox1.Text,
                email = textBox4.Text,
                mobileno = textBox2.Text,
                password = textBox3.Text,
            };
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri("https://localhost:44304/api/");
                var serializedProduct = JsonConvert.SerializeObject(u);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var consume = hc.PostAsync("hoteluser", content);

                consume.Wait();
                var test = consume.Result;
                if (test.IsSuccessStatusCode)
                {
                    this.Hide();
                    Form2 f2 = new Form2();
                    f2.Show();
                }
                else
                {
                    label7.ForeColor = Color.Red;
                    label7.Text = "Error while Register";
                }
            }
           

        }
    }
}
