namespace PicsApp
{
    partial class Form1
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
            this.btnclose = new System.Windows.Forms.Button();
            this.btntobar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnruta1 = new System.Windows.Forms.Button();
            this.btnruta2 = new System.Windows.Forms.Button();
            this.lblRes1 = new System.Windows.Forms.Label();
            this.lblPeso1 = new System.Windows.Forms.Label();
            this.lblFecha1 = new System.Windows.Forms.Label();
            this.lblFecha2 = new System.Windows.Forms.Label();
            this.lblPeso2 = new System.Windows.Forms.Label();
            this.lblRes2 = new System.Windows.Forms.Label();
            this.lblNombre1 = new System.Windows.Forms.Label();
            this.lblNombre2 = new System.Windows.Forms.Label();
            this.btnCarpeta1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnComparar = new System.Windows.Forms.Button();
            this.btnMostrarIguales = new System.Windows.Forms.Button();
            this.barraCarpeta1 = new System.Windows.Forms.ProgressBar();
            this.barraCarpeta2 = new System.Windows.Forms.ProgressBar();
            this.btnCarpeta2 = new System.Windows.Forms.Button();
            this.btnMostrarIgualesMenos = new System.Windows.Forms.Button();
            this.lblBorrar = new System.Windows.Forms.Label();
            this.checkBoxImagen1 = new System.Windows.Forms.CheckBox();
            this.checkBoxImagen2 = new System.Windows.Forms.CheckBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Red;
            this.btnclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.ForeColor = System.Drawing.Color.DarkRed;
            this.btnclose.Location = new System.Drawing.Point(1260, -1);
            this.btnclose.Margin = new System.Windows.Forms.Padding(0);
            this.btnclose.Name = "btnclose";
            this.btnclose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnclose.Size = new System.Drawing.Size(40, 40);
            this.btnclose.TabIndex = 0;
            this.btnclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btntobar
            // 
            this.btntobar.BackColor = System.Drawing.Color.LightBlue;
            this.btntobar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btntobar.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntobar.ForeColor = System.Drawing.Color.DarkRed;
            this.btntobar.Location = new System.Drawing.Point(1220, -1);
            this.btntobar.Margin = new System.Windows.Forms.Padding(0);
            this.btntobar.Name = "btntobar";
            this.btntobar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btntobar.Size = new System.Drawing.Size(40, 40);
            this.btntobar.TabIndex = 2;
            this.btntobar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btntobar.UseVisualStyleBackColor = false;
            this.btntobar.Click += new System.EventHandler(this.btntobar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("AniMe Matrix - MB_EN", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.MinimumSize = new System.Drawing.Size(1300, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1300, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Image Comparer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(83, 129);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(448, 448);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(786, 129);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(448, 448);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // btnruta1
            // 
            this.btnruta1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnruta1.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnruta1.ForeColor = System.Drawing.Color.White;
            this.btnruta1.Location = new System.Drawing.Point(434, 61);
            this.btnruta1.Name = "btnruta1";
            this.btnruta1.Size = new System.Drawing.Size(97, 62);
            this.btnruta1.TabIndex = 8;
            this.btnruta1.Text = "Imagen #1";
            this.btnruta1.UseVisualStyleBackColor = false;
            // 
            // btnruta2
            // 
            this.btnruta2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnruta2.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnruta2.ForeColor = System.Drawing.Color.White;
            this.btnruta2.Location = new System.Drawing.Point(1137, 61);
            this.btnruta2.Name = "btnruta2";
            this.btnruta2.Size = new System.Drawing.Size(97, 62);
            this.btnruta2.TabIndex = 9;
            this.btnruta2.Text = "Imagen #2";
            this.btnruta2.UseVisualStyleBackColor = false;
            this.btnruta2.Click += new System.EventHandler(this.btnruta2_Click_1);
            // 
            // lblRes1
            // 
            this.lblRes1.AutoSize = true;
            this.lblRes1.Font = new System.Drawing.Font("ROG Fonts", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRes1.ForeColor = System.Drawing.Color.White;
            this.lblRes1.Location = new System.Drawing.Point(79, 590);
            this.lblRes1.Name = "lblRes1";
            this.lblRes1.Size = new System.Drawing.Size(175, 23);
            this.lblRes1.TabIndex = 10;
            this.lblRes1.Text = "Resolucion: ";
            // 
            // lblPeso1
            // 
            this.lblPeso1.AutoSize = true;
            this.lblPeso1.Font = new System.Drawing.Font("ROG Fonts", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeso1.ForeColor = System.Drawing.Color.White;
            this.lblPeso1.Location = new System.Drawing.Point(79, 610);
            this.lblPeso1.Name = "lblPeso1";
            this.lblPeso1.Size = new System.Drawing.Size(89, 23);
            this.lblPeso1.TabIndex = 11;
            this.lblPeso1.Text = "Peso: ";
            // 
            // lblFecha1
            // 
            this.lblFecha1.AutoSize = true;
            this.lblFecha1.Font = new System.Drawing.Font("ROG Fonts", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha1.ForeColor = System.Drawing.Color.White;
            this.lblFecha1.Location = new System.Drawing.Point(79, 630);
            this.lblFecha1.Name = "lblFecha1";
            this.lblFecha1.Size = new System.Drawing.Size(104, 23);
            this.lblFecha1.TabIndex = 12;
            this.lblFecha1.Text = "Fecha: ";
            // 
            // lblFecha2
            // 
            this.lblFecha2.AutoSize = true;
            this.lblFecha2.Font = new System.Drawing.Font("ROG Fonts", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha2.ForeColor = System.Drawing.Color.White;
            this.lblFecha2.Location = new System.Drawing.Point(782, 630);
            this.lblFecha2.Name = "lblFecha2";
            this.lblFecha2.Size = new System.Drawing.Size(104, 23);
            this.lblFecha2.TabIndex = 15;
            this.lblFecha2.Text = "Fecha: ";
            // 
            // lblPeso2
            // 
            this.lblPeso2.AutoSize = true;
            this.lblPeso2.Font = new System.Drawing.Font("ROG Fonts", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeso2.ForeColor = System.Drawing.Color.White;
            this.lblPeso2.Location = new System.Drawing.Point(782, 610);
            this.lblPeso2.Name = "lblPeso2";
            this.lblPeso2.Size = new System.Drawing.Size(89, 23);
            this.lblPeso2.TabIndex = 14;
            this.lblPeso2.Text = "Peso: ";
            // 
            // lblRes2
            // 
            this.lblRes2.AutoSize = true;
            this.lblRes2.Font = new System.Drawing.Font("ROG Fonts", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRes2.ForeColor = System.Drawing.Color.White;
            this.lblRes2.Location = new System.Drawing.Point(782, 590);
            this.lblRes2.Name = "lblRes2";
            this.lblRes2.Size = new System.Drawing.Size(175, 23);
            this.lblRes2.TabIndex = 13;
            this.lblRes2.Text = "Resolucion: ";
            // 
            // lblNombre1
            // 
            this.lblNombre1.AutoSize = true;
            this.lblNombre1.Font = new System.Drawing.Font("ROG Fonts", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre1.ForeColor = System.Drawing.Color.White;
            this.lblNombre1.Location = new System.Drawing.Point(80, 101);
            this.lblNombre1.Name = "lblNombre1";
            this.lblNombre1.Size = new System.Drawing.Size(98, 18);
            this.lblNombre1.TabIndex = 16;
            this.lblNombre1.Text = "Nombre: ";
            // 
            // lblNombre2
            // 
            this.lblNombre2.AutoSize = true;
            this.lblNombre2.Font = new System.Drawing.Font("ROG Fonts", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre2.ForeColor = System.Drawing.Color.White;
            this.lblNombre2.Location = new System.Drawing.Point(783, 101);
            this.lblNombre2.Name = "lblNombre2";
            this.lblNombre2.Size = new System.Drawing.Size(98, 18);
            this.lblNombre2.TabIndex = 17;
            this.lblNombre2.Text = "Nombre: ";
            // 
            // btnCarpeta1
            // 
            this.btnCarpeta1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnCarpeta1.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarpeta1.ForeColor = System.Drawing.Color.White;
            this.btnCarpeta1.Location = new System.Drawing.Point(610, 313);
            this.btnCarpeta1.Name = "btnCarpeta1";
            this.btnCarpeta1.Size = new System.Drawing.Size(97, 62);
            this.btnCarpeta1.TabIndex = 18;
            this.btnCarpeta1.Text = "Folder #1";
            this.btnCarpeta1.UseVisualStyleBackColor = false;
            this.btnCarpeta1.Click += new System.EventHandler(this.btnCarpeta1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(83, 129);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(448, 446);
            this.listBox1.TabIndex = 20;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(786, 129);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(448, 446);
            this.listBox2.TabIndex = 21;
            // 
            // btnComparar
            // 
            this.btnComparar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnComparar.Font = new System.Drawing.Font("Franklin Gothic Medium", 12.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComparar.ForeColor = System.Drawing.Color.White;
            this.btnComparar.Location = new System.Drawing.Point(610, 236);
            this.btnComparar.Name = "btnComparar";
            this.btnComparar.Size = new System.Drawing.Size(97, 62);
            this.btnComparar.TabIndex = 22;
            this.btnComparar.Text = "Compare Folders";
            this.btnComparar.UseVisualStyleBackColor = false;
            this.btnComparar.Click += new System.EventHandler(this.btnComparar_Click);
            // 
            // btnMostrarIguales
            // 
            this.btnMostrarIguales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnMostrarIguales.Font = new System.Drawing.Font("Franklin Gothic Medium", 12.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarIguales.ForeColor = System.Drawing.Color.White;
            this.btnMostrarIguales.Location = new System.Drawing.Point(660, 495);
            this.btnMostrarIguales.Name = "btnMostrarIguales";
            this.btnMostrarIguales.Size = new System.Drawing.Size(97, 62);
            this.btnMostrarIguales.TabIndex = 23;
            this.btnMostrarIguales.Text = "Repeated +";
            this.btnMostrarIguales.UseVisualStyleBackColor = false;
            this.btnMostrarIguales.Click += new System.EventHandler(this.btnMostrarIguales_Click);
            // 
            // barraCarpeta1
            // 
            this.barraCarpeta1.BackColor = System.Drawing.Color.White;
            this.barraCarpeta1.Location = new System.Drawing.Point(610, 373);
            this.barraCarpeta1.Name = "barraCarpeta1";
            this.barraCarpeta1.Size = new System.Drawing.Size(97, 10);
            this.barraCarpeta1.Step = 1;
            this.barraCarpeta1.TabIndex = 24;
            // 
            // barraCarpeta2
            // 
            this.barraCarpeta2.Location = new System.Drawing.Point(610, 460);
            this.barraCarpeta2.Name = "barraCarpeta2";
            this.barraCarpeta2.Size = new System.Drawing.Size(97, 10);
            this.barraCarpeta2.Step = 1;
            this.barraCarpeta2.TabIndex = 26;
            // 
            // btnCarpeta2
            // 
            this.btnCarpeta2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnCarpeta2.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarpeta2.ForeColor = System.Drawing.Color.White;
            this.btnCarpeta2.Location = new System.Drawing.Point(610, 400);
            this.btnCarpeta2.Name = "btnCarpeta2";
            this.btnCarpeta2.Size = new System.Drawing.Size(97, 62);
            this.btnCarpeta2.TabIndex = 25;
            this.btnCarpeta2.Text = "Folder #2";
            this.btnCarpeta2.UseVisualStyleBackColor = false;
            this.btnCarpeta2.Click += new System.EventHandler(this.btnCarpeta2_Click);
            // 
            // btnMostrarIgualesMenos
            // 
            this.btnMostrarIgualesMenos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnMostrarIgualesMenos.Font = new System.Drawing.Font("Franklin Gothic Medium", 12.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarIgualesMenos.ForeColor = System.Drawing.Color.White;
            this.btnMostrarIgualesMenos.Location = new System.Drawing.Point(557, 495);
            this.btnMostrarIgualesMenos.Name = "btnMostrarIgualesMenos";
            this.btnMostrarIgualesMenos.Size = new System.Drawing.Size(97, 62);
            this.btnMostrarIgualesMenos.TabIndex = 27;
            this.btnMostrarIgualesMenos.Text = "Repeated  -";
            this.btnMostrarIgualesMenos.UseVisualStyleBackColor = false;
            this.btnMostrarIgualesMenos.Click += new System.EventHandler(this.btnMostrarIgualesMenos_Click);
            // 
            // lblBorrar
            // 
            this.lblBorrar.AutoSize = true;
            this.lblBorrar.Font = new System.Drawing.Font("AniMe Matrix - MB_EN", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBorrar.ForeColor = System.Drawing.SystemColors.Control;
            this.lblBorrar.Location = new System.Drawing.Point(576, 129);
            this.lblBorrar.Name = "lblBorrar";
            this.lblBorrar.Size = new System.Drawing.Size(164, 18);
            this.lblBorrar.TabIndex = 28;
            this.lblBorrar.Text = "Erase Picture";
            // 
            // checkBoxImagen1
            // 
            this.checkBoxImagen1.AutoSize = true;
            this.checkBoxImagen1.Font = new System.Drawing.Font("AniMe Matrix - MB_EN", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxImagen1.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBoxImagen1.Location = new System.Drawing.Point(579, 151);
            this.checkBoxImagen1.Name = "checkBoxImagen1";
            this.checkBoxImagen1.Size = new System.Drawing.Size(46, 36);
            this.checkBoxImagen1.TabIndex = 29;
            this.checkBoxImagen1.Text = "1";
            this.checkBoxImagen1.UseVisualStyleBackColor = true;
            this.checkBoxImagen1.CheckedChanged += new System.EventHandler(this.checkBoxImagen1_CheckedChanged);
            // 
            // checkBoxImagen2
            // 
            this.checkBoxImagen2.AutoSize = true;
            this.checkBoxImagen2.Font = new System.Drawing.Font("AniMe Matrix - MB_EN", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxImagen2.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBoxImagen2.Location = new System.Drawing.Point(682, 151);
            this.checkBoxImagen2.Name = "checkBoxImagen2";
            this.checkBoxImagen2.Size = new System.Drawing.Size(58, 36);
            this.checkBoxImagen2.TabIndex = 30;
            this.checkBoxImagen2.Text = "2";
            this.checkBoxImagen2.UseVisualStyleBackColor = true;
            this.checkBoxImagen2.CheckedChanged += new System.EventHandler(this.checkBoxImagen2_CheckedChanged);
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnBorrar.Font = new System.Drawing.Font("Franklin Gothic Medium", 12.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.ForeColor = System.Drawing.Color.White;
            this.btnBorrar.Location = new System.Drawing.Point(610, 275);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(97, 28);
            this.btnBorrar.TabIndex = 31;
            this.btnBorrar.Text = "Refresh";
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1300, 754);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.checkBoxImagen2);
            this.Controls.Add(this.checkBoxImagen1);
            this.Controls.Add(this.lblBorrar);
            this.Controls.Add(this.btnMostrarIgualesMenos);
            this.Controls.Add(this.barraCarpeta2);
            this.Controls.Add(this.btnCarpeta2);
            this.Controls.Add(this.barraCarpeta1);
            this.Controls.Add(this.btnMostrarIguales);
            this.Controls.Add(this.btnComparar);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnCarpeta1);
            this.Controls.Add(this.lblNombre2);
            this.Controls.Add(this.lblNombre1);
            this.Controls.Add(this.lblFecha2);
            this.Controls.Add(this.lblPeso2);
            this.Controls.Add(this.lblRes2);
            this.Controls.Add(this.lblFecha1);
            this.Controls.Add(this.lblPeso1);
            this.Controls.Add(this.lblRes1);
            this.Controls.Add(this.btnruta2);
            this.Controls.Add(this.btnruta1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btntobar);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btntobar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnruta1;
        private System.Windows.Forms.Button btnruta2;
        private System.Windows.Forms.Label lblRes1;
        private System.Windows.Forms.Label lblPeso1;
        private System.Windows.Forms.Label lblFecha1;
        private System.Windows.Forms.Label lblFecha2;
        private System.Windows.Forms.Label lblPeso2;
        private System.Windows.Forms.Label lblRes2;
        private System.Windows.Forms.Label lblNombre1;
        private System.Windows.Forms.Label lblNombre2;
        private System.Windows.Forms.Button btnCarpeta1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btnComparar;
        private System.Windows.Forms.Button btnMostrarIguales;
        private System.Windows.Forms.ProgressBar barraCarpeta1;
        private System.Windows.Forms.ProgressBar barraCarpeta2;
        private System.Windows.Forms.Button btnCarpeta2;
        private System.Windows.Forms.Button btnMostrarIgualesMenos;
        private System.Windows.Forms.Label lblBorrar;
        private System.Windows.Forms.CheckBox checkBoxImagen1;
        private System.Windows.Forms.CheckBox checkBoxImagen2;
        private System.Windows.Forms.Button btnBorrar;
    }
}

