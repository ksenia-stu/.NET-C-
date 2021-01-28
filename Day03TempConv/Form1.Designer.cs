
namespace Day03TempConv
{
    partial class Form1
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
            this.lblInput = new System.Windows.Forms.Label();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.lblInputScale = new System.Windows.Forms.Label();
            this.lblOutputScale = new System.Windows.Forms.Label();
            this.rbInputCelcius = new System.Windows.Forms.RadioButton();
            this.rbInputFarenh = new System.Windows.Forms.RadioButton();
            this.rbInputKelvin = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbOutputCelcius = new System.Windows.Forms.RadioButton();
            this.rbOutputKelvin = new System.Windows.Forms.RadioButton();
            this.rbOutputFarenh = new System.Windows.Forms.RadioButton();
            this.lblOutput = new System.Windows.Forms.Label();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(82, 24);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(31, 13);
            this.lblInput.TabIndex = 0;
            this.lblInput.Text = "Input";
            this.lblInput.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(119, 21);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(100, 20);
            this.tbInput.TabIndex = 1;
            this.tbInput.Text = "100";
            this.tbInput.TextChanged += new System.EventHandler(this.tbInput_TextChanged);
            // 
            // lblInputScale
            // 
            this.lblInputScale.AutoSize = true;
            this.lblInputScale.Location = new System.Drawing.Point(43, 71);
            this.lblInputScale.Name = "lblInputScale";
            this.lblInputScale.Size = new System.Drawing.Size(61, 13);
            this.lblInputScale.TabIndex = 2;
            this.lblInputScale.Text = "Input Scale";
            // 
            // lblOutputScale
            // 
            this.lblOutputScale.AutoSize = true;
            this.lblOutputScale.Location = new System.Drawing.Point(207, 71);
            this.lblOutputScale.Name = "lblOutputScale";
            this.lblOutputScale.Size = new System.Drawing.Size(69, 13);
            this.lblOutputScale.TabIndex = 3;
            this.lblOutputScale.Text = "Output Scale";
            // 
            // rbInputCelcius
            // 
            this.rbInputCelcius.AutoSize = true;
            this.rbInputCelcius.Checked = true;
            this.rbInputCelcius.Location = new System.Drawing.Point(20, 19);
            this.rbInputCelcius.Name = "rbInputCelcius";
            this.rbInputCelcius.Size = new System.Drawing.Size(59, 17);
            this.rbInputCelcius.TabIndex = 4;
            this.rbInputCelcius.TabStop = true;
            this.rbInputCelcius.Text = "Celcius";
            this.rbInputCelcius.UseVisualStyleBackColor = true;
            // 
            // rbInputFarenh
            // 
            this.rbInputFarenh.AutoSize = true;
            this.rbInputFarenh.Location = new System.Drawing.Point(20, 42);
            this.rbInputFarenh.Name = "rbInputFarenh";
            this.rbInputFarenh.Size = new System.Drawing.Size(69, 17);
            this.rbInputFarenh.TabIndex = 5;
            this.rbInputFarenh.TabStop = true;
            this.rbInputFarenh.Text = "Farenheit";
            this.rbInputFarenh.UseVisualStyleBackColor = true;
            // 
            // rbInputKelvin
            // 
            this.rbInputKelvin.AutoSize = true;
            this.rbInputKelvin.Location = new System.Drawing.Point(20, 65);
            this.rbInputKelvin.Name = "rbInputKelvin";
            this.rbInputKelvin.Size = new System.Drawing.Size(54, 17);
            this.rbInputKelvin.TabIndex = 6;
            this.rbInputKelvin.TabStop = true;
            this.rbInputKelvin.Text = "Kelvin";
            this.rbInputKelvin.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbInputCelcius);
            this.groupBox1.Controls.Add(this.rbInputKelvin);
            this.groupBox1.Controls.Add(this.rbInputFarenh);
            this.groupBox1.Location = new System.Drawing.Point(26, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbOutputCelcius);
            this.groupBox2.Controls.Add(this.rbOutputKelvin);
            this.groupBox2.Controls.Add(this.rbOutputFarenh);
            this.groupBox2.Location = new System.Drawing.Point(187, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(122, 100);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // rbOutputCelcius
            // 
            this.rbOutputCelcius.AutoSize = true;
            this.rbOutputCelcius.Location = new System.Drawing.Point(20, 19);
            this.rbOutputCelcius.Name = "rbOutputCelcius";
            this.rbOutputCelcius.Size = new System.Drawing.Size(59, 17);
            this.rbOutputCelcius.TabIndex = 4;
            this.rbOutputCelcius.TabStop = true;
            this.rbOutputCelcius.Text = "Celcius";
            this.rbOutputCelcius.UseVisualStyleBackColor = true;
            // 
            // rbOutputKelvin
            // 
            this.rbOutputKelvin.AutoSize = true;
            this.rbOutputKelvin.Location = new System.Drawing.Point(20, 65);
            this.rbOutputKelvin.Name = "rbOutputKelvin";
            this.rbOutputKelvin.Size = new System.Drawing.Size(54, 17);
            this.rbOutputKelvin.TabIndex = 6;
            this.rbOutputKelvin.TabStop = true;
            this.rbOutputKelvin.Text = "Kelvin";
            this.rbOutputKelvin.UseVisualStyleBackColor = true;
            // 
            // rbOutputFarenh
            // 
            this.rbOutputFarenh.AutoSize = true;
            this.rbOutputFarenh.Checked = true;
            this.rbOutputFarenh.Location = new System.Drawing.Point(20, 42);
            this.rbOutputFarenh.Name = "rbOutputFarenh";
            this.rbOutputFarenh.Size = new System.Drawing.Size(69, 17);
            this.rbOutputFarenh.TabIndex = 5;
            this.rbOutputFarenh.TabStop = true;
            this.rbOutputFarenh.Text = "Farenheit";
            this.rbOutputFarenh.UseVisualStyleBackColor = true;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(82, 204);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(39, 13);
            this.lblOutput.TabIndex = 9;
            this.lblOutput.Text = "Output";
            // 
            // tbOutput
            // 
            this.tbOutput.Enabled = false;
            this.tbOutput.Location = new System.Drawing.Point(127, 201);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(100, 20);
            this.tbOutput.TabIndex = 10;
            this.tbOutput.Text = "212.00° F";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 245);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblOutputScale);
            this.Controls.Add(this.lblInputScale);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.lblInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Temperature converter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Label lblInputScale;
        private System.Windows.Forms.Label lblOutputScale;
        private System.Windows.Forms.RadioButton rbInputCelcius;
        private System.Windows.Forms.RadioButton rbInputFarenh;
        private System.Windows.Forms.RadioButton rbInputKelvin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbOutputCelcius;
        private System.Windows.Forms.RadioButton rbOutputKelvin;
        private System.Windows.Forms.RadioButton rbOutputFarenh;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox tbOutput;
    }
}

