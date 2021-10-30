namespace ProyectoTrackMyRecord
{
    partial class frmCancion
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grpAgregarCancion = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lbFechaLanzaCancion = new System.Windows.Forms.Label();
            this.cmbGeneroMusical = new System.Windows.Forms.ComboBox();
            this.monthCalendar4 = new System.Windows.Forms.MonthCalendar();
            this.txtLetraCancion = new System.Windows.Forms.TextBox();
            this.txtNoPiezaDisco = new System.Windows.Forms.TextBox();
            this.txtTituloCancion = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpAgregarCancion.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 37);
            this.button1.TabIndex = 10;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(499, 354);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(161, 23);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Guardar Cambios";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(538, 312);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(82, 23);
            this.btnEditar.TabIndex = 12;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(475, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(465, 246);
            this.dataGridView1.TabIndex = 11;
            // 
            // grpAgregarCancion
            // 
            this.grpAgregarCancion.Controls.Add(this.label23);
            this.grpAgregarCancion.Controls.Add(this.label54);
            this.grpAgregarCancion.Controls.Add(this.label22);
            this.grpAgregarCancion.Controls.Add(this.label53);
            this.grpAgregarCancion.Controls.Add(this.label21);
            this.grpAgregarCancion.Controls.Add(this.label52);
            this.grpAgregarCancion.Controls.Add(this.label20);
            this.grpAgregarCancion.Controls.Add(this.label51);
            this.grpAgregarCancion.Controls.Add(this.label50);
            this.grpAgregarCancion.Controls.Add(this.label19);
            this.grpAgregarCancion.Controls.Add(this.lbFechaLanzaCancion);
            this.grpAgregarCancion.Controls.Add(this.cmbGeneroMusical);
            this.grpAgregarCancion.Controls.Add(this.monthCalendar4);
            this.grpAgregarCancion.Controls.Add(this.txtLetraCancion);
            this.grpAgregarCancion.Controls.Add(this.txtNoPiezaDisco);
            this.grpAgregarCancion.Controls.Add(this.txtTituloCancion);
            this.grpAgregarCancion.Location = new System.Drawing.Point(12, 56);
            this.grpAgregarCancion.Name = "grpAgregarCancion";
            this.grpAgregarCancion.Size = new System.Drawing.Size(425, 539);
            this.grpAgregarCancion.TabIndex = 14;
            this.grpAgregarCancion.TabStop = false;
            this.grpAgregarCancion.Text = "Agregar Canción";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(15, 480);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(81, 13);
            this.label23.TabIndex = 10;
            this.label23.Text = "Genero Musical";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(15, 280);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(142, 13);
            this.label22.TabIndex = 9;
            this.label22.Text = "Fecha Lanzamiento Canción";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(15, 128);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(73, 13);
            this.label21.TabIndex = 8;
            this.label21.Text = "Letra Canción";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(15, 78);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(103, 13);
            this.label20.TabIndex = 7;
            this.label20.Text = "Número Pieza Disco";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(15, 36);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 13);
            this.label19.TabIndex = 6;
            this.label19.Text = "Titulo Canción";
            // 
            // lbFechaLanzaCancion
            // 
            this.lbFechaLanzaCancion.AutoSize = true;
            this.lbFechaLanzaCancion.Location = new System.Drawing.Point(260, 447);
            this.lbFechaLanzaCancion.Name = "lbFechaLanzaCancion";
            this.lbFechaLanzaCancion.Size = new System.Drawing.Size(0, 13);
            this.lbFechaLanzaCancion.TabIndex = 5;
            // 
            // cmbGeneroMusical
            // 
            this.cmbGeneroMusical.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGeneroMusical.FormattingEnabled = true;
            this.cmbGeneroMusical.Location = new System.Drawing.Point(159, 475);
            this.cmbGeneroMusical.Name = "cmbGeneroMusical";
            this.cmbGeneroMusical.Size = new System.Drawing.Size(248, 21);
            this.cmbGeneroMusical.TabIndex = 4;
            // 
            // monthCalendar4
            // 
            this.monthCalendar4.Location = new System.Drawing.Point(159, 276);
            this.monthCalendar4.Name = "monthCalendar4";
            this.monthCalendar4.TabIndex = 3;
            this.monthCalendar4.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar4_DateChanged);
            // 
            // txtLetraCancion
            // 
            this.txtLetraCancion.Location = new System.Drawing.Point(159, 128);
            this.txtLetraCancion.Multiline = true;
            this.txtLetraCancion.Name = "txtLetraCancion";
            this.txtLetraCancion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLetraCancion.Size = new System.Drawing.Size(248, 136);
            this.txtLetraCancion.TabIndex = 2;
            // 
            // txtNoPiezaDisco
            // 
            this.txtNoPiezaDisco.Location = new System.Drawing.Point(159, 75);
            this.txtNoPiezaDisco.Name = "txtNoPiezaDisco";
            this.txtNoPiezaDisco.Size = new System.Drawing.Size(248, 20);
            this.txtNoPiezaDisco.TabIndex = 1;
            // 
            // txtTituloCancion
            // 
            this.txtTituloCancion.Location = new System.Drawing.Point(159, 33);
            this.txtTituloCancion.Name = "txtTituloCancion";
            this.txtTituloCancion.Size = new System.Drawing.Size(248, 20);
            this.txtTituloCancion.TabIndex = 0;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.ForeColor = System.Drawing.Color.Red;
            this.label54.Location = new System.Drawing.Point(97, 475);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(18, 24);
            this.label54.TabIndex = 47;
            this.label54.Text = "*";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.Color.Red;
            this.label53.Location = new System.Drawing.Point(155, 276);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(18, 24);
            this.label53.TabIndex = 46;
            this.label53.Text = "*";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.Color.Red;
            this.label52.Location = new System.Drawing.Point(114, 75);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(18, 24);
            this.label52.TabIndex = 45;
            this.label52.Text = "*";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.Red;
            this.label51.Location = new System.Drawing.Point(87, 33);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(18, 24);
            this.label51.TabIndex = 44;
            this.label51.Text = "*";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.Color.Red;
            this.label50.Location = new System.Drawing.Point(87, 127);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(18, 24);
            this.label50.TabIndex = 43;
            this.label50.Text = "*";
            // 
            // frmCancion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1242, 604);
            this.Controls.Add(this.grpAgregarCancion);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "frmCancion";
            this.Text = "frmCancion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCancion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpAgregarCancion.ResumeLayout(false);
            this.grpAgregarCancion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox grpAgregarCancion;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lbFechaLanzaCancion;
        private System.Windows.Forms.ComboBox cmbGeneroMusical;
        private System.Windows.Forms.MonthCalendar monthCalendar4;
        private System.Windows.Forms.TextBox txtLetraCancion;
        private System.Windows.Forms.TextBox txtNoPiezaDisco;
        private System.Windows.Forms.TextBox txtTituloCancion;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
    }
}