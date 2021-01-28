
namespace AllInputs
{
    partial class AllInputs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.rbAgeBelow18 = new System.Windows.Forms.RadioButton();
            this.rbAge1835 = new System.Windows.Forms.RadioButton();
            this.rbAge36Up = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPets = new System.Windows.Forms.Label();
            this.cbPetsCat = new System.Windows.Forms.CheckBox();
            this.cbPetsOther = new System.Windows.Forms.CheckBox();
            this.cbPetsDog = new System.Windows.Forms.CheckBox();
            this.lblContinent = new System.Windows.Forms.Label();
            this.comboCountry = new System.Windows.Forms.ComboBox();
            this.lblTemp = new System.Windows.Forms.Label();
            this.sliderTemp = new System.Windows.Forms.TrackBar();
            this.btRegister = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTemp)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(69, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            this.lblName.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(126, 24);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(237, 20);
            this.tbName.TabIndex = 1;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(69, 66);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(29, 13);
            this.lblAge.TabIndex = 2;
            this.lblAge.Text = "Age:";
            // 
            // rbAgeBelow18
            // 
            this.rbAgeBelow18.AutoSize = true;
            this.rbAgeBelow18.Checked = true;
            this.rbAgeBelow18.Location = new System.Drawing.Point(13, 18);
            this.rbAgeBelow18.Name = "rbAgeBelow18";
            this.rbAgeBelow18.Size = new System.Drawing.Size(69, 17);
            this.rbAgeBelow18.TabIndex = 3;
            this.rbAgeBelow18.TabStop = true;
            this.rbAgeBelow18.Text = "Below 18";
            this.rbAgeBelow18.UseVisualStyleBackColor = true;
            // 
            // rbAge1835
            // 
            this.rbAge1835.AutoSize = true;
            this.rbAge1835.Location = new System.Drawing.Point(90, 18);
            this.rbAge1835.Name = "rbAge1835";
            this.rbAge1835.Size = new System.Drawing.Size(58, 17);
            this.rbAge1835.TabIndex = 4;
            this.rbAge1835.Text = "18 - 35";
            this.rbAge1835.UseVisualStyleBackColor = true;
            // 
            // rbAge36Up
            // 
            this.rbAge36Up.AutoSize = true;
            this.rbAge36Up.Location = new System.Drawing.Point(154, 18);
            this.rbAge36Up.Name = "rbAge36Up";
            this.rbAge36Up.Size = new System.Drawing.Size(73, 17);
            this.rbAge36Up.TabIndex = 5;
            this.rbAge36Up.Text = "36 and up";
            this.rbAge36Up.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAgeBelow18);
            this.groupBox1.Controls.Add(this.rbAge36Up);
            this.groupBox1.Controls.Add(this.rbAge1835);
            this.groupBox1.Location = new System.Drawing.Point(113, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 43);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // lblPets
            // 
            this.lblPets.AutoSize = true;
            this.lblPets.Location = new System.Drawing.Point(69, 105);
            this.lblPets.Name = "lblPets";
            this.lblPets.Size = new System.Drawing.Size(31, 13);
            this.lblPets.TabIndex = 7;
            this.lblPets.Text = "Pets:";
            // 
            // cbPetsCat
            // 
            this.cbPetsCat.AutoSize = true;
            this.cbPetsCat.Location = new System.Drawing.Point(126, 105);
            this.cbPetsCat.Name = "cbPetsCat";
            this.cbPetsCat.Size = new System.Drawing.Size(41, 17);
            this.cbPetsCat.TabIndex = 8;
            this.cbPetsCat.Text = "cat";
            this.cbPetsCat.UseVisualStyleBackColor = true;
            // 
            // cbPetsOther
            // 
            this.cbPetsOther.AutoSize = true;
            this.cbPetsOther.Location = new System.Drawing.Point(257, 105);
            this.cbPetsOther.Name = "cbPetsOther";
            this.cbPetsOther.Size = new System.Drawing.Size(50, 17);
            this.cbPetsOther.TabIndex = 9;
            this.cbPetsOther.Text = "other";
            this.cbPetsOther.UseVisualStyleBackColor = true;
            // 
            // cbPetsDog
            // 
            this.cbPetsDog.AutoSize = true;
            this.cbPetsDog.Location = new System.Drawing.Point(193, 105);
            this.cbPetsDog.Name = "cbPetsDog";
            this.cbPetsDog.Size = new System.Drawing.Size(44, 17);
            this.cbPetsDog.TabIndex = 10;
            this.cbPetsDog.Text = "dog";
            this.cbPetsDog.UseVisualStyleBackColor = true;
            // 
            // lblContinent
            // 
            this.lblContinent.AutoSize = true;
            this.lblContinent.Location = new System.Drawing.Point(69, 145);
            this.lblContinent.Name = "lblContinent";
            this.lblContinent.Size = new System.Drawing.Size(116, 13);
            this.lblContinent.TabIndex = 11;
            this.lblContinent.Text = "Continent of residence:";
            // 
            // comboCountry
            // 
            this.comboCountry.AccessibleName = "";
            this.comboCountry.FormattingEnabled = true;
            this.comboCountry.Items.AddRange(new object[] {
            "Africa",
            "America",
            "Asia",
            "Europe",
            "Australia"});
            this.comboCountry.Location = new System.Drawing.Point(193, 142);
            this.comboCountry.Name = "comboCountry";
            this.comboCountry.Size = new System.Drawing.Size(170, 21);
            this.comboCountry.TabIndex = 12;
            this.comboCountry.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Location = new System.Drawing.Point(69, 186);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(122, 13);
            this.lblTemp.TabIndex = 13;
            this.lblTemp.Text = "Preferred temperature C:";
            this.lblTemp.Click += new System.EventHandler(this.label5_Click);
            // 
            // sliderTemp
            // 
            this.sliderTemp.LargeChange = 15;
            this.sliderTemp.Location = new System.Drawing.Point(197, 186);
            this.sliderTemp.Maximum = 35;
            this.sliderTemp.Minimum = 15;
            this.sliderTemp.Name = "sliderTemp";
            this.sliderTemp.Size = new System.Drawing.Size(166, 45);
            this.sliderTemp.SmallChange = 5;
            this.sliderTemp.TabIndex = 14;
            this.sliderTemp.TickFrequency = 5;
            this.sliderTemp.Value = 20;
            this.sliderTemp.Scroll += new System.EventHandler(this.sliderTemp_Scroll);
            // 
            // btRegister
            // 
            this.btRegister.Location = new System.Drawing.Point(174, 251);
            this.btRegister.Name = "btRegister";
            this.btRegister.Size = new System.Drawing.Size(75, 23);
            this.btRegister.TabIndex = 15;
            this.btRegister.Text = "Register me";
            this.btRegister.UseVisualStyleBackColor = true;
            this.btRegister.Click += new System.EventHandler(this.btRegister_Click);
            // 
            // AllInputs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 321);
            this.Controls.Add(this.btRegister);
            this.Controls.Add(this.sliderTemp);
            this.Controls.Add(this.lblTemp);
            this.Controls.Add(this.comboCountry);
            this.Controls.Add(this.lblContinent);
            this.Controls.Add(this.cbPetsDog);
            this.Controls.Add(this.cbPetsOther);
            this.Controls.Add(this.cbPetsCat);
            this.Controls.Add(this.lblPets);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AllInputs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Inputs";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTemp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.RadioButton rbAgeBelow18;
        private System.Windows.Forms.RadioButton rbAge1835;
        private System.Windows.Forms.RadioButton rbAge36Up;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPets;
        private System.Windows.Forms.CheckBox cbPetsCat;
        private System.Windows.Forms.CheckBox cbPetsOther;
        private System.Windows.Forms.CheckBox cbPetsDog;
        private System.Windows.Forms.Label lblContinent;
        private System.Windows.Forms.ComboBox comboCountry;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.TrackBar sliderTemp;
        private System.Windows.Forms.Button btRegister;
    }
}

