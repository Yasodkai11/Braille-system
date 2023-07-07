using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace myform1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            //insert items
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string h = Height.Text;
            string w = Width.Text;
            string r = Radius.Text;
            string b = Base.Text;
            string url;



            if (comboBox1.SelectedIndex == 0)
            {
                url = $"https://localhost:7131/DotPattern/api/circle/{r}";
                GetApi(url);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                url = $"https://localhost:7131/DotPattern/api/triangle/{h}";
                GetApi(url);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                url = $"https://localhost:7131/DotPattern/api/rectangle/{w}/{h}";
                GetApi(url);
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                url = $"https://localhost:7131/DotPattern/api/square/{h}";
                GetApi(url);
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                url = $"https://localhost:7131/DotPattern/api/pyramid/{h}";
                GetApi(url);
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                url = $"https://localhost:7131/DotPattern/api/diamond/{h}";
                GetApi(url);
            }



        }



        private async void GetApi(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                string dotPattern = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    string shapeName = comboBox1.SelectedItem.ToString(); // get the selected shape name
                    dotPattern = $"{shapeName}:\n{dotPattern}"; // add the shape name to the dot pattern string
                    richTextBox1.Text = dotPattern;
                    // center the text and increase the font size
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                    richTextBox1.SelectionFont = new Font("Arial", 16, FontStyle.Bold);
                    string shape = richTextBox1.Text;
                    int dotCount = 0;

                    foreach (char c in shape)
                    {
                        if (c == '.')
                        {
                            dotCount++;
                        }
                    }

                    textBox1.Text = dotCount.ToString(); // set the Text property of textbox1 to the dot count
                }
                else
                {
                    richTextBox1.Text = "Server Error";
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Text = ex.Message;
            }

        }

        private void NewMethod(int dotCount)
        {

        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string text = richTextBox1.Text;
            //dot count
            e.Graphics.DrawString(text, new Font("Poppins", 20, FontStyle.Bold), Brushes.Black, new Point(80));

        }


        public string Url { get; private set; }

        private void Print_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);

            PrintPreviewDialog printDialog = new PrintPreviewDialog();
            printDialog.Document = pd;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }

        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.SelectionFont = new Font("Arial", 16, FontStyle.Bold);
        }

        private void Width_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void Height_TextChanged(object sender, EventArgs e)
        {

        }

        private void Radius_TextChanged(object sender, EventArgs e)
        {

        }

        private void Base_TextChanged(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Height.Clear();
            Width.Clear();
            Radius.Clear();
            Base.Clear();
            comboBox1.SelectedIndex = -1;
            textBox1.Clear();
        }
    }
}
