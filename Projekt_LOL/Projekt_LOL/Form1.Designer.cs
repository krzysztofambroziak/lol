namespace Projekt_LOL
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonDodajGracza = new System.Windows.Forms.Button();
            this.textBoxDodajGracza = new System.Windows.Forms.TextBox();
            this.comboBoxDodajGracza = new System.Windows.Forms.ComboBox();
            this.bazaDataSet1 = new Projekt_LOL.bazaDataSet1();
            this.regionyBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.regionyTableAdapter1 = new Projekt_LOL.bazaDataSet1TableAdapters.RegionyTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bazaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionyBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(21, 23);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(299, 215);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // buttonDodajGracza
            // 
            this.buttonDodajGracza.Location = new System.Drawing.Point(33, 285);
            this.buttonDodajGracza.Name = "buttonDodajGracza";
            this.buttonDodajGracza.Size = new System.Drawing.Size(130, 20);
            this.buttonDodajGracza.TabIndex = 2;
            this.buttonDodajGracza.Text = "Dodaj gracza";
            this.buttonDodajGracza.UseVisualStyleBackColor = true;
            this.buttonDodajGracza.Click += new System.EventHandler(this.buttonDodajGracza_Click);
            // 
            // textBoxDodajGracza
            // 
            this.textBoxDodajGracza.Location = new System.Drawing.Point(169, 285);
            this.textBoxDodajGracza.Name = "textBoxDodajGracza";
            this.textBoxDodajGracza.Size = new System.Drawing.Size(100, 20);
            this.textBoxDodajGracza.TabIndex = 3;
            // 
            // comboBoxDodajGracza
            // 
            this.comboBoxDodajGracza.DataSource = this.regionyBindingSource1;
            this.comboBoxDodajGracza.DisplayMember = "name";
            this.comboBoxDodajGracza.FormattingEnabled = true;
            this.comboBoxDodajGracza.Location = new System.Drawing.Point(275, 285);
            this.comboBoxDodajGracza.Name = "comboBoxDodajGracza";
            this.comboBoxDodajGracza.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDodajGracza.TabIndex = 4;
            // 
            // bazaDataSet1
            // 
            this.bazaDataSet1.DataSetName = "bazaDataSet1";
            this.bazaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // regionyBindingSource1
            // 
            this.regionyBindingSource1.DataMember = "Regiony";
            this.regionyBindingSource1.DataSource = this.bazaDataSet1;
            // 
            // regionyTableAdapter1
            // 
            this.regionyTableAdapter1.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 320);
            this.Controls.Add(this.comboBoxDodajGracza);
            this.Controls.Add(this.textBoxDodajGracza);
            this.Controls.Add(this.buttonDodajGracza);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bazaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionyBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonDodajGracza;
        private System.Windows.Forms.TextBox textBoxDodajGracza;
        private System.Windows.Forms.ComboBox comboBoxDodajGracza;
        private bazaDataSet1 bazaDataSet1;
        private System.Windows.Forms.BindingSource regionyBindingSource1;
        private bazaDataSet1TableAdapters.RegionyTableAdapter regionyTableAdapter1;
    }
}

