using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PicsApp
{
    public partial class Form1 : Form
    {
        //private Button openFileButton;
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

        public int pressedBtn = 0;
        public string shortPath1;
        public string shortPath2;
        public bool carpetasSonIguales;

        public string usedSize1;
        public string usedSize2;

        public string imagePath1;
        public string imagePath2;
        public string imageName1;
        public string imageName2;

        public string imageRes1X;
        public string imageRes1Y;
        public string imageRes2X;
        public string imageRes2Y;

        public int imageIndex1;
        public int imageIndex2;
        public int indexed1;
        public int indexed2;

        public int cont = 1;

        public int rutasVerificadas;

        public int duplicadoIndex1;
        public int duplicadoIndex2;

        public int cantidadDeRepetidos = 0;

        public bool validImage1 = false;
        public bool validImage2 = false;
        List<int> indicesEnLista1 = new List<int>();
        List<int> indicesEnLista2 = new List<int>();
        List<string> nombresDuplicados = new List<string>();
        List<string> nombresDeDuplicados1 = new List<string>();
        List<string> nombresDeDuplicados2 = new List<string>();
        List<string> rutasDeDuplicados1 = new List<string>();
        List<string> rutasDeDuplicados2 = new List<string>();
        List<DateTime> fechasDeDuplicados1 = new List<DateTime>();
        List<DateTime> fechasDeDuplicados2 = new List<DateTime>();
        List<double> pesoDeDuplicados1 = new List<double>();
        List<double> pesoDeDuplicados2 = new List<double>();
        List<string> pesoUsadoDeDuplicados1 = new List<string>();
        List<string> pesoUsadoDeDuplicados2 = new List<string>();

        private List<string> listaTotalDeImagenes1 = new List<string>();
        private List<string> listaTotalDeImagenes2 = new List<string>();

        private List<string> archivosCarpeta1 = new List<string>();
        private List<string> archivosCarpeta2 = new List<string>();

        List<List<object>> imageParameters = new List<List<object>>();

        public Imagenes objetoBuscado1;
        public Imagenes objetoBuscado2;

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
            btnComparar.FlatStyle = FlatStyle.Flat;
            btnComparar.FlatAppearance.BorderSize = 0;
            btnMostrarIguales.FlatStyle = FlatStyle.Flat;
            btnMostrarIguales.FlatAppearance.BorderSize = 0;
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
            btnruta1.Hide();
            btnruta2.Hide();
            btnMostrarIguales.Hide();
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

        private void btnCarpeta1_Click(object sender, EventArgs e)
        {
            pressedBtn = 1;
            btnMostrarIguales.Visible = false;
            btnCarpeta1.BackColor = Color.FromArgb(46, 46, 46);
            SeleccionarCarpeta(archivosCarpeta1, listBox1);
            OrdenDeLasCosas();
            pressedBtn = 0;
        }

        private void btnCarpeta2_Click(object sender, EventArgs e)
        {
            pressedBtn = 2;
            btnMostrarIguales.Visible = false;
            btnCarpeta2.BackColor = Color.FromArgb(46, 46, 46);
            SeleccionarCarpeta(archivosCarpeta2, listBox2);
            OrdenDeLasCosas();
            pressedBtn = 0;
        }

        private void btnruta1_Click(object sender, EventArgs e)
        {
            pressedBtn = 1;
            MostrarImagen(indicesEnLista1[cont - 1]);
            //listBox1.Visible = true;
            //listBox1.Items.Add(indicesEnLista1[cont -1]);
            pressedBtn = 0;
        }


        private void btnruta2_Click_1(object sender, EventArgs e)
        {
            pressedBtn = 2;
            MostrarImagen(indicesEnLista2[cont - 1]);
            //listBox1.Visible = true;
            //listBox1.Items.Add(indicesEnLista2[cont -1]);
            pressedBtn = 0;
        }

        private void btnComparar_Click(object sender, EventArgs e)
        {
            if (listaDeImagenes1.Count != 0 && listaDeImagenes2.Count != 0)
            {
                listBox1.Items.Clear();
                nombresDuplicados.Clear();
                BuscarDuplicados();
                ALmacenarIguales();
                foreach (string duplicado in nombresDuplicados)
                {
                    listBox1.Items.Add(duplicado);
                }
                if (nombresDuplicados.Count == 0)
                {
                    btnComparar.BackColor = Color.FromArgb(46, 46, 46);
                    MessageBox.Show("No hay archivos iguales en las carpetas", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnMostrarIguales.Visible = false;
                }
                else
                {
                    btnComparar.BackColor = Color.Green;
                    btnMostrarIguales.Visible = true;
                }
            }
        }

        private void btnMostrarIguales_Click(object sender, EventArgs e)
        {
            cantidadDeRepetidos = nombresDuplicados.Count;

            ObtenerResolucionSecundaria(rutasDeDuplicados1[cont -1]);
            lblRes1.Text = $"Resolucion:{imageRes1X}x{imageRes1Y}";
            ObtenerResolucionSecundaria(rutasDeDuplicados2[cont -1]);
            lblRes2.Text = $"Resolucion:{imageRes2X}x{imageRes2Y}";
            btnruta1_Click(sender, e);
            btnruta2_Click_1(sender, e);
            //CalcularDiferenciaDeIndices1();
            //CalcularDiferenciaDeIndices2();

            if (cantidadDeRepetidos > cont)
            {
                cont++;
            }
            else if (cantidadDeRepetidos == cont)
            {
                cont = 1;
            }
            //listBox1.Items.Add(cont);
        }

        public void OrdenDeLasCosas()
        {
            if (pressedBtn == 1)
            {
                spins = 0;
                validImage1 = false;
                listaDeImagenes1.Clear();
                imageIndex1 = 0;
                imageIndex2 = 0;
                indexed1 = 0;
                indexed2 = 0;
                barraCarpeta1.Value = 0;
                if (shortPath1 != null)
                {
                    string[] archivos1 = Directory.GetFiles(shortPath1);
                    VerificarIgualdadCarpetas();
                    if (carpetasSonIguales == false)
                    {
                        foreach (string archivo in archivos1)
                        {
                            //ObtenerResolucionImagenes(archivo);
                            CalcularPeso(archivo);
                            ObtenerFecha(archivo);
                            RutasEnListas(archivo);
                            CrearInstancias(archivo);
                            BarraDeCarga();
                            //MostrarImagenesEnListBox();
                        }
                    }
                }
            }
            else if (pressedBtn == 2)
            {
                spins = 0;
                validImage2 = false;
                listaDeImagenes2.Clear();
                imageIndex1 = 0;
                imageIndex2 = 0;
                imageIndex1 = 0;
                imageIndex2 = 0;
                barraCarpeta2.Value = 0;
                if (shortPath2 != null)
                {
                    string[] archivos2 = Directory.GetFiles(shortPath2);
                    VerificarIgualdadCarpetas();
                    if (carpetasSonIguales == false)
                    {
                        foreach (string archivo in archivos2)
                        {
                            //ObtenerResolucionImagenes(archivo);
                            CalcularPeso(archivo);
                            ObtenerFecha(archivo);
                            RutasEnListas(archivo);
                            CrearInstancias(archivo);
                            BarraDeCarga();
                            //MostrarImagenesEnListBox();
                        }
                    }
                }
            }
        }

        public class Imagenes
        {
            // Propiedades de la clase
            public int Index { get; set; }
            public string Name { get; set; }
            public string Path { get; set; }
            public DateTime Date { get; set; }
            public double Weight { get; set; }
            public string UsedSize { get; set; }
            public string ResolutionX { get; set; }
            public string ResolutionY { get; set; }


            public Imagenes(int index, string name, string path, DateTime date, double weight, string usedSize, string resolutionX, string resolutionY)
            {
                Index = index;
                Name = name;
                Path = path;
                Date = date;
                Weight = weight;
                UsedSize = usedSize;
                ResolutionX = resolutionX;
                ResolutionY = resolutionY;
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
                if (filePath1 != null)
                {
                    int indexUltimaDiagonal = filePath1.LastIndexOf('\\');
                    if (indexUltimaDiagonal != -1)
                    {
                        shortPath1 = filePath1.Substring(0, indexUltimaDiagonal);
                    }
                }
            }
            else if (pressedBtn == 2)
            {
                if (filePath2 != null)
                {
                    int indexUltimaDiagonal = filePath2.LastIndexOf('\\');
                    if (indexUltimaDiagonal != -1)
                    {
                        shortPath2 = filePath2.Substring(0, indexUltimaDiagonal);
                    }
                }
            }
        }

        private void SeleccionarCarpeta(List<string> listaArchivos, ListBox listBox)
        {
            obtenerRuta();
            ObtenerRutaCorta();
            if (pressedBtn == 1)
            {
                if (shortPath1 != null)
                {
                    string[] archivos = Directory.GetFiles(shortPath1);

                    listaArchivos.Clear();
                    listBox.Items.Clear();

                    foreach (string archivo in archivos)
                    {
                        listaArchivos.Add(Path.GetFileName(archivo));
                        //listBox.Items.Add(Path.GetFileName(archivo));
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una ruta valida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnCarpeta1.BackColor = Color.Red;
                }
            }
            else if (pressedBtn == 2)
            {
                if (shortPath2 != null)
                {
                    string[] archivos = Directory.GetFiles(shortPath2);

                    listaArchivos.Clear();
                    listBox.Items.Clear();

                    foreach (string archivo in archivos)
                    {
                        listaArchivos.Add(Path.GetFileName(archivo));
                        //listBox.Items.Add(Path.GetFileName(archivo));
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una ruta valida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnCarpeta2.BackColor = Color.Red;
                }
            }
        }
        private List<Imagenes> listaDeImagenes1 = new List<Imagenes>();
        List<string> imagePaths1 = new List<string> { };
        private List<Imagenes> listaDeImagenes2 = new List<Imagenes>();
        List<string> imagePaths2 = new List<string> { };

        public void CrearInstancias(string archivo)
        {
            if (pressedBtn == 1)
            {
                if (Path.GetExtension(archivo).Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                    Path.GetExtension(archivo).Equals(".png", StringComparison.OrdinalIgnoreCase) ||
                    Path.GetExtension(archivo).Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                    Path.GetExtension(archivo).Equals(".jfif", StringComparison.OrdinalIgnoreCase) ||
                    Path.GetExtension(archivo).Equals(".webp", StringComparison.OrdinalIgnoreCase))
                {
                    listBox1.Visible = true;
                    imagePaths1.Add(archivo);

                    foreach (string path1 in imagePaths1)
                    {
                        Imagenes newImage = new Imagenes(resolutionX: imageRes1X, resolutionY: imageRes1Y, weight: fileSize1, usedSize: usedSize1, path: path1, date: fileDate1, name: imageName1, index: imageIndex1);

                        List<object> parameters = new List<object>
                    {
                        newImage.ResolutionX,
                        newImage.ResolutionY,
                        newImage.Weight,
                        newImage.UsedSize,
                        newImage.Path,
                        newImage.Date,
                        newImage.Name,
                        newImage.Index,
                    };
                        imageParameters.Add(parameters);
                        listaDeImagenes1.Add(newImage);
                    }
                    imagePaths1.Clear();
                    listaTotalDeImagenes1.Add(archivo);
                    validImage1 = true;
                }
                if (validImage1 == false && spins < 1)
                {
                    listBox1.Items.Clear();
                    MessageBox.Show("No hay archivos de imagen en la Ruta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnCarpeta1.BackColor = Color.Red;
                    spins++;
                }
                if (validImage1)
                {
                    btnCarpeta1.BackColor = Color.Green;
                }
            }
            else if (pressedBtn == 2)
            {
                if (Path.GetExtension(archivo).Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                    Path.GetExtension(archivo).Equals(".png", StringComparison.OrdinalIgnoreCase) ||
                    Path.GetExtension(archivo).Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                    Path.GetExtension(archivo).Equals(".jfif", StringComparison.OrdinalIgnoreCase) ||
                    Path.GetExtension(archivo).Equals(".webp", StringComparison.OrdinalIgnoreCase))
                {
                    listBox2.Visible = true;

                    imagePaths2.Add(archivo);

                    foreach (string path2 in imagePaths2)
                    {
                        Imagenes newImage = new Imagenes(resolutionX: imageRes2X, resolutionY: imageRes2Y, weight: fileSize2, usedSize: usedSize2, path: path2, date: fileDate2, name: imageName2, index: imageIndex2);

                        List<object> parameters = new List<object>
                    {
                        newImage.ResolutionX,
                        newImage.ResolutionY,
                        newImage.Weight,
                        newImage.UsedSize,
                        newImage.Path,
                        newImage.Date,
                        newImage.Name,
                        newImage.Index,
                    };
                        imageParameters.Add(parameters);
                        listaDeImagenes2.Add(newImage);
                    }
                    imagePaths2.Clear();
                    listaTotalDeImagenes2.Add(archivo);
                    validImage2 = true;
                }
                if (validImage2 == false && spins < 1)
                {
                    listBox2.Items.Clear();
                    MessageBox.Show("No hay archivos de imagen en la Ruta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnCarpeta2.BackColor = Color.Red;
                    spins++;
                }
                if (validImage2)
                {
                    btnCarpeta2.BackColor = Color.Green;
                }
            }
        }

        public void CalcularPeso(string rutaImagen)
        {
            long fileSizeInBytes = ObtenerPesoArchivo(rutaImagen);
            double fileSizeInKB = fileSizeInBytes / 1024.0;
            double fileSizeInMB = fileSizeInKB / 1024.0;

            if (pressedBtn == 1)
            {
                if (fileSizeInBytes <= 1023)
                {
                    fileSize1 = fileSizeInBytes;
                    usedSize1 = "B";
                }
                else if (fileSizeInKB <= 1023)
                {
                    fileSize1 = fileSizeInKB;
                    usedSize1 = "KB";
                }
                else if (fileSizeInMB <= 1023)
                {
                    fileSize1 = fileSizeInMB;
                    usedSize1 = "MB";
                }
            }
            else if (pressedBtn == 2)
            {
                if (fileSizeInBytes <= 1023)
                {
                    fileSize2 = fileSizeInBytes;
                    usedSize2 = "B";
                }
                else if (fileSizeInKB <= 1023)
                {
                    fileSize2 = fileSizeInKB;
                    usedSize2 = "KB";
                }
                else if (fileSizeInMB <= 1023)
                {
                    fileSize2 = fileSizeInMB;
                    usedSize2 = "MB";
                }
            }
        }

        public long ObtenerPesoArchivo(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            long fileSizeInBytes = fileInfo.Length;
            return fileSizeInBytes;
        }

        public void ObtenerResolucionImagenes(string rutaImagen)
        {
            if (Path.GetExtension(rutaImagen).Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                Path.GetExtension(rutaImagen).Equals(".png", StringComparison.OrdinalIgnoreCase) ||
                Path.GetExtension(rutaImagen).Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                Path.GetExtension(rutaImagen).Equals(".jfif", StringComparison.OrdinalIgnoreCase) ||
                Path.GetExtension(rutaImagen).Equals(".webp", StringComparison.OrdinalIgnoreCase))
            {
                using (Bitmap imagen = new Bitmap(rutaImagen))
                {
                    imageRes1X = imagen.Width.ToString();
                    imageRes1Y = imagen.Height.ToString();
                }
            }

            if (Path.GetExtension(rutaImagen).Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                Path.GetExtension(rutaImagen).Equals(".png", StringComparison.OrdinalIgnoreCase) ||
                Path.GetExtension(rutaImagen).Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                Path.GetExtension(rutaImagen).Equals(".jfif", StringComparison.OrdinalIgnoreCase) ||
                Path.GetExtension(rutaImagen).Equals(".webp", StringComparison.OrdinalIgnoreCase))
            {
                using (Bitmap imagen = new Bitmap(rutaImagen))
                {
                    imageRes2X = imagen.Width.ToString();
                    imageRes2Y = imagen.Height.ToString();
                }
            }
        }

        public void ObtenerFecha(string rutaImagen)
        {
            if (pressedBtn == 1)
            {
                FileInfo fileInfo = new FileInfo(filePath1);
                fileDate1 = fileInfo.CreationTime;
            }
            else if (pressedBtn == 2)
            {
                FileInfo fileInfo = new FileInfo(filePath2);
                fileDate2 = fileInfo.CreationTime;
            }
        }
        private void MostrarImagenesEnListBox()
        {
            if (pressedBtn == 1)
            {
                listBox1.Items.Clear();

                foreach (Imagenes imagen in listaDeImagenes1)
                {
                    listBox1.Items.Add(imagen.Index);
                    listBox1.Items.Add(imagen.Name);
                    listBox1.Items.Add(imagen.Path);
                    listBox1.Items.Add(imagen.Date);
                    listBox1.Items.Add(imagen.Weight);
                    listBox1.Items.Add(imagen.UsedSize);
                    listBox1.Items.Add(imagen.ResolutionX);
                    listBox1.Items.Add(imagen.ResolutionY);
                }
            }
            else if (pressedBtn == 2)
            {
                listBox2.Items.Clear();

                foreach (Imagenes imagen in listaDeImagenes2)
                {
                    listBox2.Items.Add(imagen.Index);
                    listBox2.Items.Add(imagen.Name);
                    listBox2.Items.Add(imagen.Path);
                    listBox2.Items.Add(imagen.Date);
                    listBox2.Items.Add(imagen.Weight);
                    listBox2.Items.Add(imagen.UsedSize);
                    listBox2.Items.Add(imagen.ResolutionX);
                    listBox2.Items.Add(imagen.ResolutionY);
                }
            }
        }

        public void RutasEnListas(string archivo)
        {
            if (pressedBtn == 1)
            {
                imageName1 = Path.GetFileName(archivo);
                if (rutasVerificadas > 0)
                {
                    imageIndex1++;
                }
                rutasVerificadas++;
            }
            else if (pressedBtn == 2)
            {
                imageName2 = Path.GetFileName(archivo);
                if (rutasVerificadas > 0)
                {
                    imageIndex2++;
                }
                rutasVerificadas++;
            }
        }

        private void VerificarIgualdadCarpetas()
        {
            if (shortPath1 == shortPath2)
            {
                if (pressedBtn == 1)
                {
                    listBox1.Items.Clear();
                    MessageBox.Show("Las carpetas no pueden ser las mismas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnCarpeta1.BackColor = Color.Red;
                }
                else if (pressedBtn == 2)
                {
                    listBox2.Items.Clear();
                    MessageBox.Show("Las carpetas no pueden ser las mismas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnCarpeta2.BackColor = Color.Red;
                }
                carpetasSonIguales = true;
            }
            else
            {
                carpetasSonIguales = false;
            }
        }

        private void MostrarImagen(int imagenABuscar)
        {
            if (pressedBtn == 1 && validImage1 == true)
            {
                lblRes1.Visible = true;
                lblFecha1.Visible = true;
                lblPeso1.Visible = true;
                lblNombre1.Visible = true;
                lblNombre1.Visible = true;

                lblNombre1.Text = $"Nombre:{listaDeImagenes1[imagenABuscar].Name}";
                //lblRes1.Text = $"Resolucion:{listaDeImagenes1[imagenABuscar].ResolutionX.ToString()}x{listaDeImagenes1[imagenABuscar].ResolutionY.ToString()}";
                lblPeso1.Text = $"Peso:{listaDeImagenes1[imagenABuscar].Weight.ToString("F2")} {listaDeImagenes1[imagenABuscar].UsedSize}";
                lblFecha1.Text = $"Fecha:{listaDeImagenes1[imagenABuscar].Date.ToString()}";
                pictureBox1.Image = Image.FromFile(listaDeImagenes1[imagenABuscar].Path);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.BringToFront();
            }
            if (pressedBtn == 2 && validImage2 == true)
            {
                lblRes2.Visible = true;
                lblFecha2.Visible = true;
                lblPeso2.Visible = true;
                lblNombre2.Visible = true;
                lblNombre2.Visible = true;

                lblNombre2.Text = $"Nombre:{listaDeImagenes2[imagenABuscar -1].Name}";
                //lblRes2.Text = $"Resolucion:{listaDeImagenes2[imagenABuscar].ResolutionX.ToString()}x{listaDeImagenes2[imagenABuscar].ResolutionY.ToString()}";
                lblPeso2.Text = $"Peso:{listaDeImagenes2[imagenABuscar -1].Weight.ToString("F2")} {listaDeImagenes2[imagenABuscar - 1].UsedSize}";
                lblFecha2.Text = $"Fecha:{listaDeImagenes2[imagenABuscar - 1].Date.ToString()}";
                pictureBox2.Image = Image.FromFile(listaDeImagenes2[imagenABuscar - 1].Path);
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.BringToFront();
            }
        }

        public void BuscarDuplicados()
        {
            List<Imagenes> interseccion = new List<Imagenes>();

            interseccion = listaDeImagenes1.Join(listaDeImagenes2,
                                imagen1 => imagen1.Name,
                                imagen2 => imagen2.Name,
                                (imagen1, imagen2) => imagen1).ToList();

            foreach (var imagen in interseccion)
            {
                nombresDuplicados.Add(imagen.Name);
            }
            interseccion.Sort();
        }

        public void ALmacenarIguales()
        {
            /*foreach (string duplicado in nombresDuplicados)
            {
                if (objetoBuscado1 != null)
                {
                    indicesEnLista1.Add(objetoBuscado1.Index);
                    nombresDeDuplicados1.Add(objetoBuscado1.Name);
                    fechasDeDuplicados1.Add(objetoBuscado1.Date);
                    rutasDeDuplicados1.Add(objetoBuscado1.Path);
                    pesoDeDuplicados1.Add(objetoBuscado1.Weight);
                    pesoUsadoDeDuplicados1.Add(objetoBuscado1.UsedSize);
                    //listBox1.Items.Add(rutasDeDuplicados1[cont -1].ToString());  
                }
                if (objetoBuscado2 != null)
                {
                    indicesEnLista2.Add(objetoBuscado2.Index);
                    nombresDeDuplicados2.Add(objetoBuscado2.Name);
                    fechasDeDuplicados2.Add(objetoBuscado2.Date);
                    rutasDeDuplicados2.Add(objetoBuscado2.Path);
                    pesoDeDuplicados2.Add(objetoBuscado2.Weight);
                    pesoUsadoDeDuplicados2.Add(objetoBuscado2.UsedSize);
                    //listBox2.Items.Add(rutasDeDuplicados2[cont -1].ToString());
                    //cont++;
                }
                objetoBuscado1 = null;
                objetoBuscado2 = null;
            }
            rutasDeDuplicados1.Sort();
            rutasDeDuplicados2.Sort();*/
        }
        private void BarraDeCarga()
        {
            if (pressedBtn == 1)
            {
                //int cantidadArchivos = Directory.GetFiles(shortPath1).Count();
                List<string> cantidadDeImagenes1 = new List<string>();
                string[] archivos1 = Directory.GetFiles(shortPath1);
                foreach (string archivo in archivos1)
                {
                    if (Path.GetExtension(archivo).Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        Path.GetExtension(archivo).Equals(".png", StringComparison.OrdinalIgnoreCase) ||
                        Path.GetExtension(archivo).Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                        Path.GetExtension(archivo).Equals(".jfif", StringComparison.OrdinalIgnoreCase) ||
                        Path.GetExtension(archivo).Equals(".webp", StringComparison.OrdinalIgnoreCase))
                    {
                        cantidadDeImagenes1.Add(archivo);
                    }
                }
                int cantidadEnNumero = cantidadDeImagenes1.Count();
                barraCarpeta1.Maximum = cantidadEnNumero;
                barraCarpeta1.PerformStep();
            }
            else if (pressedBtn == 2)
            {
                //int cantidadArchivos = Directory.GetFiles(shortPath1).Count();
                List<string> cantidadDeImagenes2 = new List<string>();
                string[] archivos2 = Directory.GetFiles(shortPath2);
                foreach (string archivo in archivos2)
                {
                    if (Path.GetExtension(archivo).Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        Path.GetExtension(archivo).Equals(".png", StringComparison.OrdinalIgnoreCase) ||
                        Path.GetExtension(archivo).Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                        Path.GetExtension(archivo).Equals(".jfif", StringComparison.OrdinalIgnoreCase) ||
                        Path.GetExtension(archivo).Equals(".webp", StringComparison.OrdinalIgnoreCase))
                    {
                        cantidadDeImagenes2.Add(archivo);
                    }
                }
                int cantidadEnNumero = cantidadDeImagenes2.Count();
                barraCarpeta2.Maximum = cantidadEnNumero;
                barraCarpeta2.PerformStep();
            }
        }
        public void ObtenerResolucionSecundaria(string rutaImagen)
        {
            ObtenerResolucionImagenes(rutaImagen);
        }

        /*public int CalcularDiferenciaDeIndices1()
        {
            // Encuentra un objeto común en ambas listas
            string objetoComun = nombresDuplicados[cont -1];

            int indiceEnListaA = listaTotalDeImagenes1.Select((valor, indice) => new { Valor = valor, Indice = indice })
                                  .Where(item => item.Valor == objetoComun)
                                  .Select(item => item.Indice)
                                  .FirstOrDefault();

            int indiceEnListaB = .Select((valor, indice) => new { Valor = valor, Indice = indice })
                                      .Where(item => item.Valor == objetoComun)
                                      .Select(item => item.Indice)
                                      .FirstOrDefault();

            // Calcular la diferencia de índices
            int diferenciaDeIndices = Math.Abs(indiceEnListaA - indiceEnListaB);

            return diferenciaDeIndices1;
        }
        public int CalcularDiferenciaDeIndices2()
        {
            // Encuentra un objeto común en ambas listas
            string objetoComun = nombresDuplicados[cont - 1];

            // Encuentra los índices del objeto en ambas listas
            int indiceEnListaA = listaTotalDeImagenes2.IndexOf(objetoComun);
            int indiceEnListaB = nombresDuplicados.IndexOf(objetoComun);

            int diferenciaDeIndices2 = Math.Abs(indiceEnListaB - indiceEnListaA);

            return diferenciaDeIndices2;
        }*/
    }
}