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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            f6.Show();
        }
        
        private void Form5_Load(object sender, EventArgs e)
        {
            
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.AutoScroll = true;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 6;
            //tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.633803F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Location = new Point(1, 30);
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 0;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(500, 0);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.84746F));
            tableLayoutPanel1.Controls.Add(new Label() { Text = "HotelName" }, 0, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Address" }, 1, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "City" }, 2, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Rating" }, 3, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Rent" }, 4, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Select" }, 5, 0);
            for (int i = 0; i < 6; i++)
            {
                tableLayoutPanel1.GetControlFromPosition(i, 0).BackColor = SystemColors.ControlDark;
            }

            List<hotel> h = new List<hotel>();
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri("https://localhost:44304/api/");
                var consume = hc.GetAsync("hotel");
                consume.Wait();
                var test = consume.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsStringAsync();
                    h = JsonConvert.DeserializeObject<List<hotel>>(display.Result).ToList();

                }
            }
            // For Add New Row (Loop this code for add multiple rows)
            foreach (hotel temp in h)
            {
                tableLayoutPanel1.RowCount += 1;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30.84746F));
                tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.hotelname, ReadOnly = true, BorderStyle = BorderStyle.None }, 0, tableLayoutPanel1.RowCount);
                tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.address, ReadOnly = true, BorderStyle = BorderStyle.None }, 1, tableLayoutPanel1.RowCount);
                tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.city, ReadOnly = true, BorderStyle = BorderStyle.None }, 2, tableLayoutPanel1.RowCount);
                tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.rating, ReadOnly = true, BorderStyle = BorderStyle.None }, 3, tableLayoutPanel1.RowCount);
                tableLayoutPanel1.Controls.Add(new TextBox() { Text = temp.rent, ReadOnly = true, BorderStyle = BorderStyle.None }, 4, tableLayoutPanel1.RowCount);
                tableLayoutPanel1.Controls.Add(new RadioButton() { }, 5, tableLayoutPanel1.RowCount);
            }

        }
    }
}
