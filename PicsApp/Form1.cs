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
        public bool compared = false;
        public int spins = 0;

        public string filePath1;
        public string filePath2;


        public string imageResPath1;
        public string imageResPath2;

        public string fileName1;
        public string fileName2;

        public DateTime fileDate1;
        public DateTime fileDate2;

        public double fileSize1;
        public double fileSize2;

        private bool isDragging;
        private Point offset;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            formStyles(sender, e);
        }

        private void formStyles(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            btnruta1.FlatStyle = FlatStyle.Flat;
            btnruta1.FlatAppearance.BorderSize = 0;
            btnruta2.FlatStyle = FlatStyle.Flat;
            btnruta2.FlatAppearance.BorderSize = 0;
            btnclose.FlatStyle = FlatStyle.Flat;
            btnclose.FlatAppearance.BorderSize = 0;
            btnCarpeta1.FlatStyle = FlatStyle.Flat;
            btnCarpeta1.FlatAppearance.BorderSize = 0;
            btnCarpeta2.FlatStyle = FlatStyle.Flat;
            btnCarpeta2.FlatAppearance.BorderSize = 0;
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
            listBox1.Hide();
            listBox2.Hide();
            label1.MouseDown += TitleLabel_MouseDown;
            label1.MouseMove += TitleLabel_MouseMove;
            label1.MouseUp += TitleLabel_MouseUp;
            btnruta1.Click += btnruta1_Click;
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
                    filePath1 = openFileDialog.FileName;
                fileName1 = Path.GetFileName(filePath1);
                btnruta1.BackColor = Color.Green;
                if (compared == false)
                {
                    Comparar();
                    if (spins > 2 && fileName1 != fileName2)
                    {
                        MessageBox.Show("Los archivos deben tener el mismo nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnruta1.BackColor = Color.Red;
                        btnruta2.BackColor = Color.Red;
                        spins = 0;
                    }
                    compared = false;
                }
            }
        }


        private void btnruta2_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    filePath2 = openFileDialog.FileName;
                fileName2 = Path.GetFileName(filePath2);
                btnruta2.BackColor = Color.Green;
                if (compared == false)
                {
                    Comparar();
                    if (spins > 2 && fileName1 != fileName2)
                    {
                        MessageBox.Show("Los archivos deben tener el mismo nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnruta1.BackColor = Color.Red;
                        btnruta2.BackColor = Color.Red;
                        spins = 0;
                    }
                    compared = false;
                }
            }
        }


        public void Comparar()
        {
            if (fileName1 == fileName2)
            {
                lblRes1.Visible = true;
                lblRes2.Visible = true;
                lblFecha1.Visible = true;
                lblFecha2.Visible = true;
                lblPeso1.Visible = true;
                lblPeso2.Visible = true;
                lblNombre1.Visible = true;
                lblNombre2.Visible = true;


                imageResPath1 = filePath1;
                Size resolution = ObtenerResolucionImagen(imageResPath1);
                lblRes1.Text = $"Resolucion: {resolution.Width} x {resolution.Height}";

                FileInfo fileInfo = new FileInfo(filePath1);
                fileDate1 = fileInfo.CreationTime;
                lblFecha1.Text = $"Fecha: {fileDate1.ToString()}";

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

                imageResPath2 = filePath2;
                Size resolution2 = ObtenerResolucionImagen(imageResPath2);
                lblRes2.Text = $"Resolucion: {resolution2.Width} x {resolution2.Height}";

                FileInfo fileInfo2 = new FileInfo(filePath2);
                fileDate2 = fileInfo2.CreationTime;
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

                lblNombre1.Text = $"Nombre:{fileName1.ToString()}";
                lblNombre2.Text = $"Nombre:{fileName2.ToString()}";

                if (filePath1 != filePath2)
                {
                    pictureBox1.Image = Image.FromFile(filePath1);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.Image = Image.FromFile(filePath2);
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    btnruta1.BackColor = Color.Green;
                    btnruta2.BackColor = Color.Green;
                    compared = true;
                }
                else
                {
                    MessageBox.Show("La carpeta no puede ser la misma", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnruta1.BackColor = Color.Red;
                    btnruta2.BackColor = Color.Red;
                }

            }
            spins++;
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





























        public int pressedBtn = 0;
        public string shortPath1;
        public string shortPath2;

        public string imageRes1X;
        public string imageRes1Y;
        public string imageRes2X;
        public string imageRes2Y;

        private List<string> archivosCarpeta1 = new List<string>();
        private List<string> archivosCarpeta2 = new List<string>();

        List<List<object>> imageParameters = new List<List<object>>();


        private void btnCarpeta1_Click(object sender, EventArgs e)
        {
            pressedBtn = 1;
            SeleccionarCarpeta(archivosCarpeta1, listBox1);
            pressedBtn = 0;
        }

        private void btnCarpeta2_Click(object sender, EventArgs e)
        {
            pressedBtn = 2;
            SeleccionarCarpeta(archivosCarpeta2, listBox2);
            pressedBtn = 0;
        }

        public class Image1
        {
            // Propiedades de la clase
            public string ResolutionX { get; set; }
            public string ResolutionY { get; set; }
            public double Weight { get; set; }
            public string Name { get; set; }
            public DateTime Date { get; set; }

            public Image1(string resolutionX, string resolutionY, double weight, string name, DateTime date)
            {
                ResolutionX = resolutionX;
                ResolutionY = resolutionY;
                Weight = weight;
                Name = name;
                Date = date;
            }
        }


        public void obtenerRuta()
        {
            if (pressedBtn == 1)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath1 = openFileDialog.FileName;
                        fileName1 = Path.GetFileName(filePath1);
                    }
                }
            }
            else if (pressedBtn == 2)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath2 = openFileDialog.FileName;
                        fileName2 = Path.GetFileName(filePath2);
                    }
                }
            }
        }

        private void ObtenerRutaCorta()
        {
            if (pressedBtn == 1)
            {
                int indexUltimaDiagonal = filePath1.LastIndexOf('\\');

                if (indexUltimaDiagonal != -1)
                {
                    shortPath1 = filePath1.Substring(0, indexUltimaDiagonal);
                    lblPeso1.Text = shortPath1;
                }
            }
            else if (pressedBtn == 2)
            {
                int indexUltimaDiagonal = filePath2.LastIndexOf('\\');

                if (indexUltimaDiagonal != -1)
                {
                    shortPath2 = filePath2.Substring(0, indexUltimaDiagonal);
                    lblPeso1.Text = shortPath2;
                }
            }
        }

        private void SeleccionarCarpeta(List<string> listaArchivos, ListBox listBox)
        {
            obtenerRuta();
            ObtenerRutaCorta();
            if (pressedBtn == 1)
            {
                string[] archivos = Directory.GetFiles(shortPath1);

                //listaArchivos.Clear();
                //listBox.Items.Clear();

                foreach (string archivo in archivos)
                {
                    listaArchivos.Add(Path.GetFileName(archivo));
                    listBox.Items.Add(Path.GetFileName(archivo));
                }
                btnCarpeta1.BackColor = Color.Green;
            }
            else if (pressedBtn == 2) 
            {
                string[] archivos = Directory.GetFiles(shortPath2);

                //listaArchivos.Clear();
                //listBox.Items.Clear();

                foreach (string archivo in archivos)
                {
                    listaArchivos.Add(Path.GetFileName(archivo));
                    listBox.Items.Add(Path.GetFileName(archivo));
                }
                btnCarpeta2.BackColor = Color.Green;
            }
        }

        public void CrearInstancias()
        {
            List<string> imageNames = new List<string> {  };

            List<Image> images = new List<Image>();

            foreach (string name in imageNames)
            {
                Image1 newImage = new Image1(resolutionX: imageRes1X , resolutionY: imageRes1Y, weight: fileSize1, name: name, date: fileDate1);

                List<object> parameters = new List<object>
                {
                    newImage.ResolutionX,
                    newImage.ResolutionY,
                    newImage.Weight,
                    newImage.Name,
                    newImage.Date
                };
                imageParameters.Add(parameters);
            }
        }

        public void CalcularPeso()
        {
            long fileSizeInBytes = ObtenerPesoArchivo(filePath1);
            double fileSizeInKB = fileSizeInBytes / 1024.0;
            double fileSizeInMB = fileSizeInKB / 1024.0;

            if (pressedBtn == 1)
            {
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
                fileSize1 = fileSizeInMB;
            }
            else if (pressedBtn == 2) 
            {
                if (fileSizeInBytes <= 1023)
                {
                    lblPeso2.Text = $"Peso: {fileSizeInBytes.ToString("F2")} Bytes";
                }
                else if (fileSizeInKB <= 1023)
                {
                    lblPeso2.Text = $"Peso: {fileSizeInKB.ToString("F2")} KB";
                }
                else if (fileSizeInMB <= 1023)
                {
                    lblPeso2.Text = $"Peso: {fileSizeInMB.ToString("F2")} MB";
                }
                fileSize2 = fileSizeInMB;
            }
        }

        public void ObtenerResolucionImagenes(string rutaImagen)
        {
            if (pressedBtn == 1)
            {
                using (Bitmap imagen = new Bitmap(rutaImagen))
                {
                    imageRes1X = imagen.Width.ToString();
                    imageRes1Y = imagen.Height.ToString();
                }
            }
            else if (pressedBtn == 2)
            {
                using (Bitmap imagen = new Bitmap(rutaImagen))
                {
                    // Obtén la resolución y almacénala en la variable pública
                    imageRes2X = imagen.Width.ToString();
                    imageRes2Y = imagen.Height.ToString();
                }
            }
        }

        public void ObtenerFecha()
        {
            if (pressedBtn == 1)
            {
                FileInfo fileInfo = new FileInfo(filePath1);
                fileDate1 = fileInfo.CreationTime;
                lblFecha1.Text = $"Fecha: {fileDate1.ToString()}";
            }
            else if (pressedBtn == 2)
            {
                FileInfo fileInfo = new FileInfo(filePath2);
                fileDate2 = fileInfo.CreationTime;
                lblFecha2.Text = $"Fecha: {fileDate1.ToString()}";
            }
        }
    }
}