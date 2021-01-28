using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Day03TempConv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbInput_TextChanged(object sender, EventArgs e)
        {
            
            string inTempStr = tbInput.Text;
            double inTemp;
            if (!double.TryParse(inTempStr, out inTemp))
            {
                MessageBox.Show("Input temperature must be a number", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rbInputCelcius.Checked)
            {
                if(rbOutputCelcius.Checked)
                {
                    tbOutput.Text = inTemp+"";
                }
                else if(rbOutputFarenh.Checked)
                {
                    tbOutput.Text = ((inTemp * 9 / 5) + 32) +"";
                }
                else if (rbOutputKelvin.Checked)
                {
                    tbOutput.Text = (inTemp + 273.15) + "";
                }
                else
                {
                    tbOutput.Text = "";
                }
            }


            if (rbInputFarenh.Checked)
            {
                if (rbOutputCelcius.Checked)
                {
                    
                    tbOutput.Text = ((inTemp -32)*5/9) + "";
                }
                else if (rbOutputFarenh.Checked)
                {
                    tbOutput.Text = inTemp + "";
                }
                else if (rbOutputKelvin.Checked)
                {
                    
                    tbOutput.Text = ((inTemp -32)*5/9 + 273.15) + "";
                }
                else
                {
                    tbOutput.Text = "";
                }
            }

            if (rbInputKelvin.Checked)
            {
                if (rbOutputCelcius.Checked)
                {

                    tbOutput.Text = (inTemp - 273.15) + "";
                }
                else if (rbOutputFarenh.Checked)
                {
                    //− 273.15) × 9/5 + 32
                    tbOutput.Text = ((inTemp - 273.15)*9/5 +32) + "";
                }
                else if (rbOutputKelvin.Checked)
                {

                    tbOutput.Text = inTemp  + "";
                }
                else
                {
                    tbOutput.Text = "";
                }
            }
        }
    }
}
