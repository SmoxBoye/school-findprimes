using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace find_primes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            List<int> listPrimes = new List<int>();

            int intMaxP = 0;
            try
            {
                intMaxP = int.Parse(textBox1.Text);
            }
            catch
            {
                intMaxP = 0;
            }


            if (intMaxP > 0)
            {
                intMaxP = intMaxP + 1;
                string addText = "";
                textBox2.Text = "2 ";
                int aproxPrime = (int)(intMaxP / Math.Log(intMaxP));
                progressBar1.Maximum = aproxPrime + 1;


                for (int i = 3; i < intMaxP; i = i + 2)
                {
                    bool isPrime = true;
                    int sqPrime = (int)(Math.Sqrt(i));
                    int x = 0;
                    while (x < listPrimes.Count && listPrimes[x] <= sqPrime)
                    {

                        if (i % listPrimes[x] == 0)
                        {
                            isPrime = false;
                            break;
                        }

                        x++;
                    }
                    if (isPrime)
                    {
                        listPrimes.Add(i);
                        addText = i.ToString();
                        textBox2.AppendText(addText + " ");
                        if (progressBar1.Maximum >= listPrimes.Count)
                        {
                            progressBar1.Value = listPrimes.Count;
                        }
                    }

                }
                
                progressBar1.Value = progressBar1.Maximum;
                MessageBox.Show("Klar");
            }
            else
            {
                MessageBox.Show(textBox1.Text + " är inte ett tillåtet värde. Använd ett positivt heltal större än 1");
            }


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                button1.PerformClick();
            }
        }
    }
}
