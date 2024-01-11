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

namespace PicsApp
{
    public partial class Form1 : Form
    {
        private Button openFileButton;
        public bool comparado = false;
        public int vueltas = 0;

        public string filePath1;
        public string filePath2;
        public string nombreArchivo1;
        public string nombreArchivo2;

        public string imageResPath1;
        public string imageResPath2;

        public string soloNombre1;
        public string soloNombre2;

        public string pesoArchivo1;

        private bool isDragging;
        private Point offset;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            btnruta1.FlatStyle = FlatStyle.Flat;
            btnruta1.FlatAppearance.BorderSize = 0;
            btnruta2.FlatStyle = FlatStyle.Flat;
            btnruta2.FlatAppearance.BorderSize = 0;
            btnclose.FlatStyle = FlatStyle.Flat;
            btnclose.FlatAppearance.BorderSize = 0;
            btnclose.BringToFront();
            btntobar.FlatStyle = FlatStyle.Flat;
            btntobar.BringToFront();
            btntobar.FlatAppearance.BorderSize = 0;

            lblRes1.Hide();
            lblRes2.Hide();
            lblFecha1.Hide();
            lblFecha2.Hide();
            lblPeso1.Hide();
            lblPeso2.Hide();
            lblNombre1.Hide();
            lblNombre2.Hide();

            //string imagePath1 = @"C:\Users\cread\OneDrive\Pictures\Screenshots\Captura de pantalla (5).png";
            //pictureBox1.Image = Image.FromFile(imagePath1);
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;




            label1.MouseDown += TitleLabel_MouseDown;
            label1.MouseMove += TitleLabel_MouseMove;
            label1.MouseUp += TitleLabel_MouseUp;

            btnruta1.Click += btnruta1_Click;

            pesoArchivo1 = filePath1;

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btntobar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void TitleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            offset = e.Location;
        }

        private void TitleLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentCursorPosition = Control.MousePosition;
                this.Location = new Point(currentCursorPosition.X - offset.X, currentCursorPosition.Y - offset.Y);
            }
        }

        private void TitleLabel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }



        private void btnruta1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    nombreArchivo1 = openFileDialog.FileName;
                soloNombre1 = Path.GetFileName(nombreArchivo1);
                btnruta1.BackColor = Color.Green;
                if (comparado == false)
                {
                    Comparar();
                    if (vueltas > 2 && soloNombre1 != soloNombre2)
                    {
                        MessageBox.Show("Los archivos deben tener el mismo nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnruta1.BackColor = Color.Red;
                        btnruta2.BackColor = Color.Red;
                        vueltas = 0;
                    }
                    comparado = false;
                }
            }
        }
        

        private void btnruta2_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    nombreArchivo2 = openFileDialog.FileName;
                soloNombre2 = Path.GetFileName(nombreArchivo2);
                btnruta1.BackColor = Color.Green;
                if (comparado == false)
                {
                    Comparar();
                    if (vueltas > 2 && soloNombre1 != soloNombre2)
                    {
                        MessageBox.Show("Los archivos deben tener el mismo nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnruta1.BackColor = Color.Red;
                        btnruta2.BackColor = Color.Red;
                        vueltas = 0;
                    }
                    comparado = false;
                }
            }
        }


        public void Comparar()
        {
            if (soloNombre1 == soloNombre2)
            {
                lblRes1.Visible = true;
                lblRes2.Visible = true;
                lblFecha1.Visible = true;
                lblFecha2.Visible = true;
                lblPeso1.Visible = true;
                lblPeso2.Visible = true;
                lblNombre1.Visible = true;
                lblNombre2.Visible = true;


                filePath1 = nombreArchivo1;
                string imagePath1 = filePath1;

                imageResPath1 = filePath1;
                Size resolution = ObtenerResolucionImagen(imageResPath1);
                lblRes1.Text = $"Resolucion: {resolution.Width} x {resolution.Height}";

                FileInfo fileInfo = new FileInfo(filePath1);
                DateTime fileDate = fileInfo.CreationTime;
                lblFecha1.Text = $"Fecha: {fileDate.ToString()}";

                long fileSizeInBytes = ObtenerPesoArchivo(filePath1);
                double fileSizeInKB = fileSizeInBytes / 1024.0;
                double fileSizeInMB = fileSizeInKB / 1024.0;


                if (fileSizeInBytes <= 1023)
                {
                    lblPeso1.Text = $"Peso: {fileSizeInBytes.ToString("F2")} Bytes";
                }
                else if (fileSizeInKB <= 1023)
                {
                    lblPeso1.Text = $"Peso: {fileSizeInKB.ToString("F2")} KB";
                }
                else if (fileSizeInMB <= 1023)
                {
                    lblPeso1.Text = $"Peso: {fileSizeInMB.ToString("F2")} MB";
                }

                filePath2 = nombreArchivo2;
                string imagePath2 = filePath2;

                imageResPath2 = filePath2;
                Size resolution2 = ObtenerResolucionImagen(imageResPath2);
                lblRes2.Text = $"Resolucion: {resolution2.Width} x {resolution2.Height}";

                FileInfo fileInfo2 = new FileInfo(filePath2);
                DateTime fileDate2 = fileInfo2.CreationTime;
                lblFecha2.Text = $"Fecha: {fileDate2.ToString()}";

                long fileSizeInBytes2 = ObtenerPesoArchivo(filePath2);
                double fileSizeInKB2 = fileSizeInBytes2 / 1024.0;
                double fileSizeInMB2 = fileSizeInKB2 / 1024.0;


                if (fileSizeInBytes2 <= 1023)
                {
                    lblPeso2.Text = $"Peso: {fileSizeInBytes2.ToString("F2")} Bytes";
                }
                else if (fileSizeInKB2 <= 1023)
                {
                    lblPeso2.Text = $"Peso: {fileSizeInKB2.ToString("F2")} KB";
                }
                else if (fileSizeInMB2 <= 1023)
                {
                    lblPeso2.Text = $"Peso: {fileSizeInMB2.ToString("F2")} MB";
                }

                lblNombre1.Text = $"Nombre:{soloNombre1.ToString()}";
                lblNombre2.Text = $"Nombre:{soloNombre2.ToString()}";

                if (filePath1 != filePath2)
                {
                    pictureBox1.Image = Image.FromFile(imagePath1);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.Image = Image.FromFile(imagePath2);
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    btnruta1.BackColor = Color.Green;
                    btnruta2.BackColor = Color.Green;
                    comparado = true;
                }
                else
                {
                    MessageBox.Show("La carpeta no puede ser la misma", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnruta1.BackColor = Color.Red;
                    btnruta2.BackColor = Color.Red;
                }

            }
            vueltas++;
        }

        static Size ObtenerResolucionImagen(string imageResPath1)
        {
            using (Image image = Image.FromFile(imageResPath1))
            {
                return new Size(image.Width, image.Height);
            }
        }

        static long ObtenerPesoArchivo(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            // Obtener el tamaño en bytes
            long fileSizeInBytes = fileInfo.Length;

            return fileSizeInBytes;
        }

    }
}