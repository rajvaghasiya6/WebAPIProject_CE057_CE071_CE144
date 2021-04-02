using hotelbookingAPI.Models;
using Newtonsoft.Json;
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

namespace HotelBookingForm
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hotel h = new hotel()
            {
                hotelname = textBox1.Text,
                address = textBox2.Text,
                city = textBox3.Text,
                rating = textBox4.Text,
                rent = textBox5.Text,
            };
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri("https://localhost:44304/api/");
                var serializedProduct = JsonConvert.SerializeObject(h);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var consume = hc.PostAsync("hotel", content);

                consume.Wait();
                var test = consume.Result;
                if (test.IsSuccessStatusCode)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    label7.ForeColor = Color.Green;
                    label7.Text = "New Hotel Added Sucessfully";
                }
                else
                {
                    label7.ForeColor = Color.Red;
                    label7.Text = "Error while register new hotel";
                }
            }
        }
    }
}
