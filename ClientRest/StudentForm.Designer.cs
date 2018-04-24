namespace ClientRest
{
    partial class StudentForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelId = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelSurname = new System.Windows.Forms.Label();
            this.labelDni = new System.Windows.Forms.Label();
            this.labelBirth = new System.Windows.Forms.Label();
            this.BtnAction = new System.Windows.Forms.Button();
            this.listAction = new System.Windows.Forms.ComboBox();
            this.textId = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.textSurname = new System.Windows.Forms.TextBox();
            this.textDni = new System.Windows.Forms.TextBox();
            this.BirthDate = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.HelloBtn = new System.Windows.Forms.Button();
            this.textShow = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(72, 73);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(23, 20);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "Id";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(72, 126);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(51, 20);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name";
            // 
            // labelSurname
            // 
            this.labelSurname.AutoSize = true;
            this.labelSurname.Location = new System.Drawing.Point(70, 172);
            this.labelSurname.Name = "labelSurname";
            this.labelSurname.Size = new System.Drawing.Size(74, 20);
            this.labelSurname.TabIndex = 2;
            this.labelSurname.Text = "Surname";
            // 
            // labelDni
            // 
            this.labelDni.AutoSize = true;
            this.labelDni.Location = new System.Drawing.Point(72, 218);
            this.labelDni.Name = "labelDni";
            this.labelDni.Size = new System.Drawing.Size(33, 20);
            this.labelDni.TabIndex = 3;
            this.labelDni.Text = "Dni";
            // 
            // labelBirth
            // 
            this.labelBirth.AutoSize = true;
            this.labelBirth.Enabled = false;
            this.labelBirth.Location = new System.Drawing.Point(70, 265);
            this.labelBirth.Name = "labelBirth";
            this.labelBirth.Size = new System.Drawing.Size(81, 20);
            this.labelBirth.TabIndex = 4;
            this.labelBirth.Text = "Birth Date";
            this.labelBirth.UseMnemonic = false;
            // 
            // BtnAction
            // 
            this.BtnAction.Location = new System.Drawing.Point(563, 114);
            this.BtnAction.Name = "BtnAction";
            this.BtnAction.Size = new System.Drawing.Size(219, 78);
            this.BtnAction.TabIndex = 5;
            this.BtnAction.Text = "Actions";
            this.BtnAction.UseVisualStyleBackColor = true;
            this.BtnAction.Click += new System.EventHandler(this.BtnAction_Click);
            // 
            // listAction
            // 
            this.listAction.FormattingEnabled = true;
            this.listAction.Items.AddRange(new object[] {
            "Create",
            "Update",
            "Read",
            "Delete",
            "GetAll"});
            this.listAction.Location = new System.Drawing.Point(563, 65);
            this.listAction.Name = "listAction";
            this.listAction.Size = new System.Drawing.Size(219, 28);
            this.listAction.TabIndex = 6;
            this.listAction.Text = "List Actions";
            this.listAction.SelectedIndexChanged += new System.EventHandler(this.listAction_SelectedIndexChanged);
            // 
            // textId
            // 
            this.textId.Location = new System.Drawing.Point(168, 73);
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(47, 26);
            this.textId.TabIndex = 7;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(168, 120);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(322, 26);
            this.textName.TabIndex = 8;
            // 
            // textSurname
            // 
            this.textSurname.Location = new System.Drawing.Point(168, 166);
            this.textSurname.Name = "textSurname";
            this.textSurname.Size = new System.Drawing.Size(319, 26);
            this.textSurname.TabIndex = 9;
            // 
            // textDni
            // 
            this.textDni.Location = new System.Drawing.Point(168, 212);
            this.textDni.Name = "textDni";
            this.textDni.Size = new System.Drawing.Size(319, 26);
            this.textDni.TabIndex = 10;
            // 
            // BirthDate
            // 
            this.BirthDate.Location = new System.Drawing.Point(168, 260);
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.Size = new System.Drawing.Size(319, 26);
            this.BirthDate.TabIndex = 12;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(74, 324);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(988, 193);
            this.dataGridView1.TabIndex = 13;
            // 
            // HelloBtn
            // 
            this.HelloBtn.Location = new System.Drawing.Point(563, 234);
            this.HelloBtn.Name = "HelloBtn";
            this.HelloBtn.Size = new System.Drawing.Size(219, 51);
            this.HelloBtn.TabIndex = 14;
            this.HelloBtn.Text = "Hello button";
            this.HelloBtn.UseVisualStyleBackColor = true;
            this.HelloBtn.Click += new System.EventHandler(this.HelloBtn_Click);
            // 
            // textShow
            // 
            this.textShow.Location = new System.Drawing.Point(823, 259);
            this.textShow.Name = "textShow";
            this.textShow.Size = new System.Drawing.Size(239, 26);
            this.textShow.TabIndex = 15;
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 619);
            this.Controls.Add(this.textShow);
            this.Controls.Add(this.HelloBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BirthDate);
            this.Controls.Add(this.textDni);
            this.Controls.Add(this.textSurname);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.listAction);
            this.Controls.Add(this.BtnAction);
            this.Controls.Add(this.labelBirth);
            this.Controls.Add(this.labelDni);
            this.Controls.Add(this.labelSurname);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelId);
            this.Name = "StudentForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.Label labelDni;
        private System.Windows.Forms.Label labelBirth;
        private System.Windows.Forms.Button BtnAction;
        private System.Windows.Forms.ComboBox listAction;
        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.TextBox textSurname;
        private System.Windows.Forms.TextBox textDni;
        private System.Windows.Forms.DateTimePicker BirthDate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button HelloBtn;
        private System.Windows.Forms.TextBox textShow;
    }
}

