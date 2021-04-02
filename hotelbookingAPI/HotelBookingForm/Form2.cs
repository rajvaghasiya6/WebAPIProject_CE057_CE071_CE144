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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="admin@gmail.com" && textBox2.Text=="admin")
            {
                this.Hide();
                Form4 f4 = new Form4();
                f4.Show();
            }
            else
            {
                string email = textBox1.Text;
                string password = textBox2.Text;
                using (HttpClient hc = new HttpClient())
                {
                    hc.BaseAddress = new Uri("https://localhost:44304/api/");
                    var consume = hc.GetAsync("hoteluser?email="+email+"&password="+password);
                    consume.Wait();
                    var test = consume.Result;
                    if (test.IsSuccessStatusCode)
                    {
                        var display = test.Content.ReadAsStringAsync();
                        bool result = JsonConvert.DeserializeObject<Boolean>(display.Result);
                        if(result)
                        {
                            this.Hide();
                            Form5 f5 = new Form5();
                            f5.Show();
                        }  
                        else
                        {
                            label4.ForeColor = Color.Red;
                            label4.Text = "Invalid User";
                        }
                    }
                    
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
