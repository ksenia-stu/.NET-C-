using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllInputs
{
    public partial class AllInputs : Form
    {
        public AllInputs()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sliderTemp_Scroll(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            //name
            string name = tbName.Text;
            if(name.Length == 0)
            {
                MessageBox.Show("Name must not be empty", "Input error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //age
            string age;

            if(rbAgeBelow18.Checked)
            {
                age = "below 18";
            }
            else if (rbAge1835.Checked)
            {
                age = "18-35";
            }
            else if (rbAge36Up.Checked)
            {
                age = "36 and up";
            }
            else
            {
                MessageBox.Show("Select age", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //pets
            List<string> PetsList = new List<string>();

            if(cbPetsCat.Checked)
            {
                PetsList.Add("cat");
            }
            if (cbPetsDog.Checked)
            {
                PetsList.Add("dog");
            }
            if (cbPetsOther.Checked)
            {
                PetsList.Add("other");
            }

            
            string pets = string.Join(",", PetsList);

            //continent
            string continent = comboCountry.SelectedItem+"";

            //temperature
             int temperature = sliderTemp.Value;
            if(temperature < 15 || temperature > 35)
            {
                MessageBox.Show("Temperature must be between 15 and 35", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //save to file (append)
            try
            {
                using (StreamWriter fileOutput = File.AppendText("inputs.txt"))
                {

                    string line = string.Format("{0};{1};{2};{3};{4}", name, age, pets, continent,temperature);
                        fileOutput.WriteLine(line);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error writing to file:"+ex.Message, "Output error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
    }
}
