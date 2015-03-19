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
            this.buttonDodajGracza = new System.Windows.Forms.Button();
            this.textBoxDodajGracza = new System.Windows.Forms.TextBox();
            this.comboBoxDodajGracza = new System.Windows.Forms.ComboBox();
            this.regionyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bazaDataSet = new Projekt_LOL.bazaDataSet();
            this.regionyTableAdapter = new Projekt_LOL.bazaDataSetTableAdapters.RegionyTableAdapter();
            this.buttonAktualizujGry = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.regionyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bazaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 167);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonDodajGracza
            // 
            this.buttonDodajGracza.Location = new System.Drawing.Point(299, 91);
            this.buttonDodajGracza.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDodajGracza.Name = "buttonDodajGracza";
            this.buttonDodajGracza.Size = new System.Drawing.Size(184, 25);
            this.buttonDodajGracza.TabIndex = 2;
            this.buttonDodajGracza.Text = "Dodaj Gracza";
            this.buttonDodajGracza.UseVisualStyleBackColor = true;
            this.buttonDodajGracza.Click += new System.EventHandler(this.buttonDodajGracza_Click);
            // 
            // textBoxDodajGracza
            // 
            this.textBoxDodajGracza.Location = new System.Drawing.Point(276, 124);
            this.textBoxDodajGracza.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDodajGracza.Name = "textBoxDodajGracza";
            this.textBoxDodajGracza.Size = new System.Drawing.Size(185, 22);
            this.textBoxDodajGracza.TabIndex = 3;
            // 
            // comboBoxDodajGracza
            // 
            this.comboBoxDodajGracza.DataSource = this.regionyBindingSource;
            this.comboBoxDodajGracza.DisplayMember = "name";
            this.comboBoxDodajGracza.FormattingEnabled = true;
            this.comboBoxDodajGracza.Location = new System.Drawing.Point(478, 122);
            this.comboBoxDodajGracza.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxDodajGracza.Name = "comboBoxDodajGracza";
            this.comboBoxDodajGracza.Size = new System.Drawing.Size(80, 24);
            this.comboBoxDodajGracza.TabIndex = 4;
            this.comboBoxDodajGracza.ValueMember = "Id";
            // 
            // regionyBindingSource
            // 
            this.regionyBindingSource.DataMember = "Regiony";
            this.regionyBindingSource.DataSource = this.bazaDataSet;
            // 
            // bazaDataSet
            // 
            this.bazaDataSet.DataSetName = "bazaDataSet";
            this.bazaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // regionyTableAdapter
            // 
            this.regionyTableAdapter.ClearBeforeFill = true;
            // 
            // buttonAktualizujGry
            // 
            this.buttonAktualizujGry.Location = new System.Drawing.Point(299, 58);
            this.buttonAktualizujGry.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAktualizujGry.Name = "buttonAktualizujGry";
            this.buttonAktualizujGry.Size = new System.Drawing.Size(184, 25);
            this.buttonAktualizujGry.TabIndex = 5;
            this.buttonAktualizujGry.Text = "Aktualizuj gry";
            this.buttonAktualizujGry.UseVisualStyleBackColor = true;
            this.buttonAktualizujGry.Click += new System.EventHandler(this.buttonAktualizujGry_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(285, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(222, 39);
            this.button2.TabIndex = 6;
            this.button2.Text = "Wyswietl statystyki";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(257, 148);
            this.listBox1.TabIndex = 7;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 200);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonAktualizujGry);
            this.Controls.Add(this.comboBoxDodajGracza);
            this.Controls.Add(this.textBoxDodajGracza);
            this.Controls.Add(this.buttonDodajGracza);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.regionyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bazaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonDodajGracza;
        private System.Windows.Forms.TextBox textBoxDodajGracza;
        private System.Windows.Forms.ComboBox comboBoxDodajGracza;
        private bazaDataSet bazaDataSet;
        private System.Windows.Forms.BindingSource regionyBindingSource;
        private bazaDataSetTableAdapters.RegionyTableAdapter regionyTableAdapter;
        private System.Windows.Forms.Button buttonAktualizujGry;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.ListBox listBox1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}

