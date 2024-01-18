using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static PicsApp.Form1;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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

        List<string> nombresDuplicados = new List<string>();
        private List<Imagenes> listaDeImagenes1 = new List<Imagenes>();
        List<string> imagePaths1 = new List<string> { };
        private List<Imagenes> listaDeImagenes2 = new List<Imagenes>();
        List<string> imagePaths2 = new List<string> { };

        //List<string> nombresDeDuplicados1 = new List<string>();
        //List<string> nombresDeDuplicados2 = new List<string>();
        //List<string> rutasDeDuplicados1 = new List<string>();
        //List<string> rutasDeDuplicados2 = new List<string>();
        //List<DateTime> fechasDeDuplicados1 = new List<DateTime>();
        //List<DateTime> fechasDeDuplicados2 = new List<DateTime>();
        //List<double> pesoDeDuplicados1 = new List<double>();
        //List<double> pesoDeDuplicados2 = new List<double>();
        //List<string> pesoUsadoDeDuplicados1 = new List<string>();
        //List<string> pesoUsadoDeDuplicados2 = new List<string>();

        private List<string> listaTotalDeImagenes1 = new List<string>();
        private List<string> listaTotalDeImagenes2 = new List<string>();

        private List<string> archivosCarpeta1 = new List<string>();
        private List<string> archivosCarpeta2 = new List<string>();

        List<List<object>> imageParameters = new List<List<object>>();


        public Imagenes objetoBuscado1;
        public Imagenes objetoBuscado2;


        public List<Imagenes> interseccionPrincipal1 = new List<Imagenes>();
        public List<Imagenes> interseccionPrincipal2 = new List<Imagenes>();
        public string nombreBuscadoActual1;
        public string nombreBuscadoActual2;
        public string nombreDuplicadoACtual;
        public string rutaDuplicadoActual1;
        public string rutaDuplicadoActual2;
        public double pesoDuplicadoActual1;
        public double pesoDuplicadoActual2;
        public string pesoUsadoDuplicadoActual1;
        public string pesoUsadoDuplicadoActual2;
        public DateTime fechaDuplicadoActual1;
        public DateTime fechaDuplicadoActual2;
        public int resolucionDuplicadoActualX1;
        public int resolucionDuplicadoActualY1;
        public int resolucionDuplicadoActualX2;
        public int resolucionDuplicadoActualY2;

        public string rutaThumbActual1;
        public string rutaThumbActual2;

        public bool carpeta1Seleccionada = false;
        public bool carpeta2Seleccionada = false;

        public bool repetidosVerificados = false;

        HashSet<string> archivosParaBorrar1 = new HashSet<string>();
        HashSet<string> archivosParaBorrar2 = new HashSet<string>();








        public string rutaMiniaturas = "C:\\Picsapp";
        public string rutaCarpetaThumbs1 = "C:\\Picsapp\\Thumbs1";
        public string rutaCarpetaThumbs2 = "C:\\Picsapp\\Thumbs2";

        public List<string> rutasDeImagenesRepetidas1 = new List<string>();
        public List<string> rutasDeImagenesRepetidas2 = new List<string>();

        public int resolucionesDeImagenesRepetidasX1;
        public int resolucionesDeImagenesRepetidasY1;
        public int resolucionesDeImagenesRepetidasX2;
        public int resolucionesDeImagenesRepetidasY2;

        public string rutaDeThumb1;
        public string rutaDeThumb2;
        public string nombreDeThumb1;
        public string nombreDeThumb2;
        public string rutaRealThumb1;
        public string rutaRealThumb2;

        public Size resolucionDeThumb1;
        public Size resolucionDeThumb2;

        List<List<object>> imageParametersThumb = new List<List<object>>();
        List<ThumbsInfo> listaDeThumbs1 = new List<ThumbsInfo>();
        List<List<object>> imageParametersThumb2 = new List<List<object>>();
        List<ThumbsInfo> listaDeThumbs2 = new List<ThumbsInfo>();











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
            btnMostrarIgualesMenos.FlatStyle = FlatStyle.Flat;
            btnMostrarIgualesMenos.FlatAppearance.BorderSize = 0;
            btnBorrar.FlatStyle = FlatStyle.Flat;
            btnBorrar.FlatAppearance.BorderSize = 0;
            btnclose.BringToFront();
            btntobar.FlatStyle = FlatStyle.Flat;
            btntobar.BringToFront();
            btntobar.FlatAppearance.BorderSize = 0;
            btnBorrar1.FlatStyle = FlatStyle.Flat;
            btnBorrar1.FlatAppearance.BorderSize = 0;
            btnBorrar2.FlatStyle = FlatStyle.Flat;
            btnBorrar2.FlatAppearance.BorderSize = 0;
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
            btnComparar.Hide();
            btnCarpeta2.Hide();
            barraCarpeta2.Hide();
            btnMostrarIguales.Hide();
            btnMostrarIgualesMenos.Hide();
            checkBoxImagen1.Hide();
            checkBoxImagen2.Hide();
            btnBorrar1.Hide();
            btnBorrar2.Hide();
            lblBorrar.Hide();
            label1.MouseDown += TitleLabel_MouseDown;
            label1.MouseMove += TitleLabel_MouseMove;
            label1.MouseUp += TitleLabel_MouseUp;
            btnruta1.Click += btnruta1_Click;
        }

        private async void btnclose_Click(object sender, EventArgs e)
        {
            await CloseApp();
        }

        private async Task CloseApp()
        {
            await Task.Delay(0);
            Application.Exit();
        }


        private void btntobar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            //CrearThumbnails("C:\\Users\\cread\\OneDrive\\Pictures\\Apolo\\002.jpg", "C:\\Picsapp\\002.jpeg", 1200, 1600);
            //ObtenerResolucionImagen("C:\\Picsapp\\002.jpeg");
            //IntroducirResoluciones();
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

        private async void btnCarpeta1_Click(object sender, EventArgs e)
        {
            //checkBoxImagen1.Visible = false;
            // checkBoxImagen2.Visible = false;
            btnBorrar1.Visible = false;
            btnBorrar2.Visible = false;
            lblBorrar.Visible = false;
            await Task.Run(() => AccionBotonCarpeta1());
        }

        private void MostrarIgualesFalse()
        {
            btnMostrarIguales.Visible = false;
            btnMostrarIgualesMenos.Visible = false;
        }

        private async Task AccionBotonCarpeta1()
        {
            await Task.Delay(0);
            pressedBtn = 1;
            if (btnMostrarIguales.InvokeRequired)
            {
                btnMostrarIguales.Invoke(new Action(() => MostrarIgualesFalse()));
            }
            btnCarpeta1.BackColor = Color.FromArgb(46, 46, 46);
            SeleccionarCarpeta(archivosCarpeta1, listBox1);
            OrdenDeLasCosas();
            pressedBtn = 0;
        }

        private async void btnCarpeta2_Click(object sender, EventArgs e)
        {
            //checkBoxImagen1.Visible = false;
            //checkBoxImagen2.Visible = false;
            btnBorrar1.Visible = false;
            btnBorrar2.Visible = false;
            lblBorrar.Visible = false;
            await Task.Run(() => AccionBotonCarpeta2());
        }

        private async Task AccionBotonCarpeta2()
        {
            await Task.Delay(0);
            pressedBtn = 2;
            if (btnMostrarIguales.InvokeRequired && btnMostrarIgualesMenos.InvokeRequired)
            {
                btnMostrarIguales.Invoke(new Action(() => MostrarIgualesFalse()));
                btnMostrarIgualesMenos.Invoke(new Action(() => MostrarIgualesFalse()));
            }
            btnCarpeta2.BackColor = Color.FromArgb(46, 46, 46);
            SeleccionarCarpeta(archivosCarpeta2, listBox2);
            OrdenDeLasCosas();
            pressedBtn = 0;
        }

        private void btnruta1_Click(object sender, EventArgs e)
        {
            pressedBtn = 1;
            MostrarImagen();
            //listBox1.Visible = true;
            //listBox1.Items.Add(indicesEnLista1[cont -1]);
            pressedBtn = 0;
        }


        private void btnruta2_Click_1(object sender, EventArgs e)
        {
            pressedBtn = 2;
            MostrarImagen();
            //listBox1.Visible = true;
            //listBox1.Items.Add(indicesEnLista2[cont -1]);
            pressedBtn = 0;
        }

        private void btnComparar_Click(object sender, EventArgs e)
        {
            //checkBoxImagen1.Visible = false;
            //checkBoxImagen2.Visible = false;
            btnBorrar1.Visible = false;
            btnBorrar2.Visible = false;
            lblBorrar.Visible = false;
            if (repetidosVerificados == false)
            {
                CalcularRepetidos();
            }
            if (listaDeImagenes1 != null && listaDeImagenes2 != null && cantidadDeRepetidos != 0)
            {
                listBox1.Items.Clear();
                nombresDuplicados.Clear();
                ViaAlternativa1();
                ViaAlternativa2();
                pictureBox1.Hide();
                pictureBox1.Hide();

                foreach (string duplicado in nombresDuplicados)
                {
                    listBox1.Items.Add(duplicado);
                }
                /*foreach (Imagenes Imagen in interseccionPrincipal1)
                {
                    rutasDeImagenesRepetidas1.Add(Imagen);
                    nombresParaThumbnails1.Add(Imagen);
                    resolucionesDeImagenesRepetidasX1.Add(Imagen);
                }
                foreach (Imagenes Imagen in interseccionPrincipal2)
                {
                    rutasDeImagenesRepetidas2.Add(Imagen);
                    nombresParaThumbnails2.Add(Imagen);
                }*/

                if (cantidadDeRepetidos == 0)
                {
                    btnComparar.BackColor = Color.FromArgb(46, 46, 46);
                    MessageBox.Show("There is no files with the same name in the folders", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnMostrarIguales.Visible = false;
                }
                else
                {
                    btnComparar.BackColor = Color.Green;
                    btnMostrarIguales.Visible = true;
                    btnMostrarIgualesMenos.Visible = true;
                    CrearCarpetaMiniaturas();
                    SuministrarInfoThumbs1();
                    SuministrarInfoThumbs2();
                }
            }
            else
            {
                MessageBox.Show("There are no repeated pictures in the folders", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMostrarIguales_Click(object sender, EventArgs e)
        {
            //cantidadDeRepetidos = nombresDuplicados.Count;
            //ViaAlternativa1();
            //ViaAlternativa2();
            //checkBoxImagen1.Visible = true;
            //checkBoxImagen2.Visible = true;
            btnBorrar1.Visible = true;
            btnBorrar2.Visible = true;
            lblBorrar.Visible = true;
            btnBorrar.Text = "Erase";

            if (cantidadDeRepetidos == 2)
            {
                if (cont == 1)
                {
                    btnMostrarIgualesMenos.Visible = true;
                    btnMostrarIguales.Hide();
                    cont = cont + 1;
                }
            }
            else if (cantidadDeRepetidos > cont)
            {
                cont = cont + 1;
            }
            else if (cantidadDeRepetidos == cont)
            {
                btnMostrarIguales.Visible = false;
            }
            if (cantidadDeRepetidos != cont)
            {
                btnMostrarIgualesMenos.Visible = true;
            }
            CargarDatosActuales();
            //ObtenerResolucionSecundaria(rutaDuplicadoActual1);
            //lblRes1.Text = $"Resolution:{imageRes1X}x{imageRes1Y}";
            btnruta1_Click(sender, e);
            ObtenerResolucionSecundaria(rutaDuplicadoActual2);
            lblRes2.Text = $"Resolution:{imageRes2X}x{imageRes2Y}";
            btnruta2_Click_1(sender, e);
            //CalcularDiferenciaDeIndices1();
            //CalcularDiferenciaDeIndices2();

            /*if (cantidadDeRepetidos > cont)
            {
                cont = cont+1;
            }
            else if (cantidadDeRepetidos == cont)
            {
                btnMostrarIguales.Visible = false;
            }
            if (cantidadDeRepetidos != cont)
            {
                btnMostrarIgualesMenos.Visible = true;
            }*/
            CargarDatosActuales();
            btnruta1_Click(sender, e);
            btnruta2_Click_1(sender, e);

            //CheckCheck1();
            //CheckCheck2();
            CheckBtn1();
            Checkbtn2();
        }

        private void btnMostrarIgualesMenos_Click(object sender, EventArgs e)
        {
            //ViaAlternativa1();
            //ViaAlternativa2();
            //checkBoxImagen1.Visible = true;
            //checkBoxImagen2.Visible = true;
            btnBorrar1.Visible = true;
            btnBorrar2.Visible = true;
            lblBorrar.Visible = true;
            btnBorrar.Text = "Erase";

            if (cantidadDeRepetidos == 2)
            {
                if (cont == 2)
                {
                    btnMostrarIguales.Visible = true;
                    btnMostrarIgualesMenos.Hide();
                    cont = cont - 1;
                }
            }
            else if (cantidadDeRepetidos > cont - 1 && cont > 1)
            {
                cont = cont - 1;
            }
            else if (cont == 1)
            {
                btnMostrarIgualesMenos.Visible = false;
            }
            if (cont != 1)
            {
                btnMostrarIguales.Visible = true;
            }
            CargarDatosActuales();
            ObtenerResolucionSecundaria(rutaDuplicadoActual1);
            lblRes1.Text = $"Resolution:{imageRes1X}x{imageRes1Y}";
            btnruta1_Click(sender, e);
            ObtenerResolucionSecundaria(rutaDuplicadoActual2);
            lblRes2.Text = $"Resolution:{imageRes2X}x{imageRes2Y}";
            btnruta2_Click_1(sender, e);
            //CalcularDiferenciaDeIndices1();
            //CalcularDiferenciaDeIndices2();

            /*if (cantidadDeRepetidos > cont -1 && cont > 1)
            {
                cont = cont - 1;
            }
            else if (cont == 1)
            {
                btnMostrarIgualesMenos.Visible = false;
            }
            if (cont != 1)
            {
                btnMostrarIguales.Visible = true;
            }*/
            //CargarDatosActuales();
            //btnruta1_Click(sender, e);
            //btnruta2_Click_1(sender, e);
            //CheckCheck1();
            //CheckCheck2();
            CheckBtn1();
            Checkbtn2();
        }

        private void checkBoxImagen1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxImagen1.Checked)
            {
                archivosParaBorrar1.Add(rutaThumbActual1);
            }
            else
            {
                archivosParaBorrar1.Remove(rutaThumbActual1);
            }
        }

        private void checkBoxImagen2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxImagen2.Checked)
            {
                archivosParaBorrar2.Add(rutaThumbActual2);
            }
            else
            {
                archivosParaBorrar2.Remove(rutaThumbActual2);
            }
        }

        private void ResetValorBarra1()
        {
            barraCarpeta1.Value = 0;
        }

        private void ResetValorBarra2()
        {
            barraCarpeta2.Value = 0;
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
                if (barraCarpeta1.InvokeRequired)
                {
                    barraCarpeta1.Invoke(new Action(() => ResetValorBarra1()));
                }
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
                if (barraCarpeta2.InvokeRequired)
                {
                    barraCarpeta2.Invoke(new Action(() => ResetValorBarra2()));
                }
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


        private void AbrirArchivoEnHiloPrincipal1()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                filePath1 = openFileDialog.FileName;
            fileName1 = Path.GetFileName(filePath1);
        }

        private void AbrirArchivoEnHiloPrincipal2()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                filePath2 = openFileDialog.FileName;
            fileName2 = Path.GetFileName(filePath2);
        }

        public void obtenerRuta()
        {
            if (pressedBtn == 1)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    if (InvokeRequired)
                    {
                        Invoke(new Action(AbrirArchivoEnHiloPrincipal1));
                    }
                }
            }
            if (pressedBtn == 2)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    if (InvokeRequired)
                    {
                        Invoke(new Action(AbrirArchivoEnHiloPrincipal2));
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

        private void ActualizarListBox1()
        {
            listBox1.Items.Clear();
        }

        private void ActualizarListBox2()
        {
            listBox2.Items.Clear();
        }

        private void BtnCompararVisible()
        {
            btnComparar.Visible = true;
            btnBorrar.Location = new Point(610, 196);
        }

        private void BtnCarpeta2Visible()
        {
            btnCarpeta2.Visible = true;
            barraCarpeta2.Visible = true;
        }

        private void SeleccionarCarpeta(List<string> listaArchivos, ListBox listBox)
        {
            obtenerRuta();
            ObtenerRutaCorta();
            if (pressedBtn == 1)
            {
                if (shortPath1 != null)
                {
                    carpeta1Seleccionada = true;
                    string[] archivos = Directory.GetFiles(shortPath1);

                    listaArchivos.Clear();
                    if (listBox.InvokeRequired)
                    {
                        listBox1.Invoke(new Action(() => ActualizarListBox1()));
                    }

                    foreach (string archivo in archivos)
                    {
                        listaArchivos.Add(Path.GetFileName(archivo));
                        //listBox.Items.Add(Path.GetFileName(archivo));
                    }
                    if (carpeta1Seleccionada == true && carpeta2Seleccionada == true)
                    {
                        if (btnComparar.InvokeRequired)
                        {
                            btnComparar.Invoke(new Action(() => BtnCompararVisible()));
                        }
                    }
                    if (btnComparar.InvokeRequired && barraCarpeta2.InvokeRequired)
                    {
                        btnComparar.Invoke(new Action(() => BtnCarpeta2Visible()));
                        barraCarpeta2.Invoke(new Action(() => BtnCarpeta2Visible()));
                    }
                }
                else
                {
                    MessageBox.Show("Choose a valid path", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    carpeta1Seleccionada = false;
                    btnCarpeta1.BackColor = Color.Red;
                }
            }
            if (pressedBtn == 2)
            {
                if (shortPath2 != null)
                {
                    carpeta2Seleccionada = true;
                    string[] archivos = Directory.GetFiles(shortPath2);

                    listaArchivos.Clear();
                    if (listBox.InvokeRequired)
                    {
                        listBox2.Invoke(new Action(() => ActualizarListBox2()));
                    }

                    foreach (string archivo in archivos)
                    {
                        listaArchivos.Add(Path.GetFileName(archivo));
                        //listBox.Items.Add(Path.GetFileName(archivo));
                    }
                    if (carpeta1Seleccionada == true && carpeta2Seleccionada == true)
                    {
                        if (btnComparar.InvokeRequired)
                        {
                            btnComparar.Invoke(new Action(() => BtnCompararVisible()));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Choose a valid path", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    carpeta2Seleccionada = false;
                    btnCarpeta2.BackColor = Color.Red;
                }
            }
        }


        private void HacerVisibleListbox1()
        {
            listBox1.Visible = true;
        }

        private void LimpiarListbox1()
        {
            listBox1.Items.Clear();
        }

        private void LimpiarListbox2()
        {
            listBox2.Items.Clear();
        }

        private void HacerVisibleListbox2()
        {
            listBox2.Visible = true;
        }

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
                    if (listBox1.InvokeRequired)
                    {
                        listBox1.Invoke(new Action(() => HacerVisibleListbox1()));
                    }
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
                    if (listBox1.InvokeRequired)
                    {
                        listBox1.Invoke(new Action(() => LimpiarListbox1()));
                    }
                    MessageBox.Show("There is no picture files in the folder", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    if (listBox2.InvokeRequired)
                    {
                        listBox2.Invoke(new Action(() => HacerVisibleListbox2()));
                    }

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
                    if (listBox2.InvokeRequired)
                    {
                        listBox2.Invoke(new Action(() => LimpiarListbox2()));
                    }
                    MessageBox.Show("There is no picture files in the folder", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    if (listBox1.InvokeRequired)
                    {
                        listBox1.Invoke(new Action(() => LimpiarListbox1()));
                    }
                    MessageBox.Show("The folders can't be the same", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnCarpeta1.BackColor = Color.Red;
                }
                else if (pressedBtn == 2)
                {
                    if (listBox2.InvokeRequired)
                    {
                        listBox2.Invoke(new Action(() => LimpiarListbox2()));
                    }
                    MessageBox.Show("The Folders can't be the same", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnCarpeta2.BackColor = Color.Red;
                }
                carpetasSonIguales = true;
            }
            else
            {
                carpetasSonIguales = false;
            }
        }

        

        public int cantidadEnNumero;
        private void ActualizarCarpetaDeCarga1()
        {
            barraCarpeta1.Maximum = cantidadEnNumero;
            barraCarpeta1.PerformStep();
        }

        private void ActualizarCarpetaDeCarga2()
        {
            barraCarpeta2.Maximum = cantidadEnNumero;
            barraCarpeta2.PerformStep();
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

                cantidadEnNumero = cantidadDeImagenes1.Count();

                if (barraCarpeta1.InvokeRequired)
                {
                    barraCarpeta1.Invoke(new Action(() => ActualizarCarpetaDeCarga1()));
                }

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
                cantidadEnNumero = cantidadDeImagenes2.Count();

                if (barraCarpeta2.InvokeRequired)
                {
                    barraCarpeta2.Invoke(new Action(() => ActualizarCarpetaDeCarga2()));
                }
            }
        }
        public void ObtenerResolucionSecundaria(string rutaImagen)
        {
            ObtenerResolucionImagenes(rutaImagen);
        }


        public void ViaAlternativa1()
        {
            interseccionPrincipal1.Clear();
            interseccionPrincipal1 = listaDeImagenes1.Join(listaDeImagenes2,
                                imagen1 => imagen1.Name,
                                imagen2 => imagen2.Name,
                                (imagen1, imagen2) => imagen1).ToList();

            cantidadDeRepetidos = interseccionPrincipal1.Count();

            for (int i = 0; i < cantidadDeRepetidos; i++)
            {
                nombresDuplicados.Add(interseccionPrincipal1[i].Name);
            }

        }


        public void ViaAlternativa2()
        {
            interseccionPrincipal2.Clear();
            interseccionPrincipal2 = listaDeImagenes2.Join(listaDeImagenes1,
                                imagen1 => imagen1.Name,
                                imagen2 => imagen2.Name,
                                (imagen1, imagen2) => imagen1).ToList();
        }

        

        private void CalcularRepetidos()
        {
            interseccionPrincipal1.Clear();
            interseccionPrincipal1 = listaDeImagenes1.Join(listaDeImagenes2,
                                imagen1 => imagen1.Name,
                                imagen2 => imagen2.Name,
                                (imagen1, imagen2) => imagen1).ToList();

            cantidadDeRepetidos = interseccionPrincipal1.Count();

            for (int i = 0; i < cantidadDeRepetidos; i++)
            {
                nombresDuplicados.Add(interseccionPrincipal1[i].Name);
            }
        }

        private void BorrarSeleccionados1()
        {
            foreach (string archivo in archivosParaBorrar1)
            {
                if (archivosParaBorrar1.Contains(archivo))
                {
                    try
                    {
                        // Intentar borrar el archivo
                        File.Delete(archivo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"$Error trying to erase file: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show($"The file in the route '{archivo}' couldn't be found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BorrarSeleccionados2()
        {
            foreach (string archivo in archivosParaBorrar2)
            {
                if (archivosParaBorrar2.Contains(archivo))
                {
                    try
                    {
                        // Intentar borrar el archivo
                        File.Delete(archivo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"$Error trying to erase file: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show($"The file in the route '{archivo}' couldn't be found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (archivosParaBorrar1.Count != 0 || archivosParaBorrar2.Count != 0)
            {
                DialogResult selection = MessageBox.Show("Are you sure you want to delete all selected files?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (selection == DialogResult.Yes)
                {
                    pictureBox1.Enabled = false;
                    pictureBox2.Enabled = false;
                    pictureBox1.Image.Dispose();
                    pictureBox2.Image.Dispose();
                    rutaDuplicadoActual1 = null;
                    rutaDuplicadoActual2 = null;
                    rutaThumbActual1 = null;
                    rutaThumbActual2 = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    RefreshAll();
                    BorrarSeleccionados1();
                    BorrarSeleccionados2();
                    archivosParaBorrar1.Clear();
                    archivosParaBorrar2.Clear();
                    string[] archivos1 = Directory.GetFiles(rutaCarpetaThumbs1);
                    foreach (string archivo in archivos1)
                    {
                        File.Delete(archivo);
                    }
                    Directory.Delete(rutaCarpetaThumbs1);

                    string[] archivos2 = Directory.GetFiles(rutaCarpetaThumbs2);
                    foreach (string archivo in archivos2)
                    {
                        File.Delete(archivo);
                    }
                    Directory.Delete(rutaCarpetaThumbs2);

                    Directory.Delete(rutaMiniaturas);
                    //Application.Restart();
                }
            }
            RefreshAll();
            //Application.Restart();
        }

        private void RefreshAll()
        {
            btnBorrar.Text = "Refresh";
            btnBorrar.Location = new Point(610, 275);
            cont = 1;
            spins = 0;
            barraCarpeta1.Value = 0;
            barraCarpeta2.Value = 0;

            btnCarpeta1.BackColor = Color.FromArgb(46, 46, 46);
            btnCarpeta2.BackColor = Color.FromArgb(46, 46, 46);
            btnComparar.BackColor = Color.FromArgb(46, 46, 46);

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
            btnComparar.Hide();
            btnCarpeta2.Hide();
            barraCarpeta2.Hide();
            btnMostrarIguales.Hide();
            btnMostrarIgualesMenos.Hide();
            listBox1.Items.Clear();
            nombresDuplicados.Clear();
            pictureBox1.Hide();
            pictureBox2.Hide();
            lblBorrar.Hide();
            checkBoxImagen1.Hide();
            checkBoxImagen2.Hide();
            btnBorrar1.Hide();
            btnBorrar2.Hide();
            archivosParaBorrar1.Clear();
            archivosParaBorrar2.Clear();

            nombresDuplicados.Clear();
            listaTotalDeImagenes1.Clear();
            listaTotalDeImagenes2.Clear();
            archivosCarpeta1.Clear();
            archivosCarpeta2.Clear();
            imageParameters.Clear();

            interseccionPrincipal1.Clear();
            interseccionPrincipal2.Clear();

            rutasDeImagenesRepetidas1.Clear();
            rutasDeImagenesRepetidas2.Clear();
            imageParametersThumb.Clear();
            listaDeThumbs1.Clear();
            imageParametersThumb2.Clear();
            listaDeThumbs2.Clear();

            /*nombreBuscadoActual1 = "";
            nombreBuscadoActual2 = "";
            nombreDuplicadoACtual = "";
            rutaDuplicadoActual1 = "";
            rutaDuplicadoActual2 = "";
            pesoDuplicadoActual1 = 0;
            pesoDuplicadoActual2 = 0;
            pesoUsadoDuplicadoActual1 = "";
            pesoUsadoDuplicadoActual2 = "";*/
            carpeta1Seleccionada = false;
            carpeta2Seleccionada = false;
            repetidosVerificados = false;
            carpetasSonIguales = false;
            compared = false;
            rutasVerificadas = 0;
            validImage1 = false;
            validImage2 = false;
            carpeta1Seleccionada = false;
            carpeta2Seleccionada = false;
            repetidosVerificados = false;
            filePath1 = null;
            filePath2 = null;
            shortPath1 = null;
            shortPath2 = null;


            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void CheckCheck1()
        {
            if (archivosParaBorrar1.Contains(rutaThumbActual1))
            {
                checkBoxImagen1.CheckState = CheckState.Checked;
            }
            else
            {
                checkBoxImagen1.CheckState = CheckState.Unchecked;
            }
        }
        private void CheckCheck2()
        {
            if (archivosParaBorrar2.Contains(rutaThumbActual2))
            {
                checkBoxImagen2.CheckState = CheckState.Checked;
            }
            else
            {
                checkBoxImagen2.CheckState = CheckState.Unchecked;
            }
        }












        private void CrearCarpetaMiniaturas()
        {
            if (Directory.Exists(rutaMiniaturas)) { }
            else
            {
                // Crear la carpeta si no existe
                Directory.CreateDirectory(rutaMiniaturas);
            }
        }

        private void BorrarCarpetaMiniaturas()
        {
            if (Directory.Exists(rutaMiniaturas))
            {
                Directory.Delete(rutaMiniaturas);
            }
        }

        public void CrearThumbnails(string rutaImagenOriginal, string rutaThumbnail, int ancho, int alto)
        {
            using (Image imagenOriginal = Image.FromFile(rutaImagenOriginal))
            {
                // Calcular nuevas dimensiones manteniendo la proporción
                int nuevaAncho, nuevaAlto;
                MantenerProporcion(imagenOriginal.Width, imagenOriginal.Height, ancho, alto, out nuevaAncho, out nuevaAlto);
                using (Bitmap thumbnail = new Bitmap(nuevaAncho, nuevaAlto))
                {
                    using (Graphics g = Graphics.FromImage(thumbnail))
                    {
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        g.CompositingQuality = CompositingQuality.HighQuality;

                        // Dibujar la miniatura
                        g.DrawImage(imagenOriginal, 0, 0, nuevaAncho, nuevaAlto);

                    }
                    thumbnail.Save(rutaThumbnail, ImageFormat.Jpeg);
                }
            }

        }

        static void MantenerProporcion(int originalAncho, int originalAlto, int nuevoAnchoDeseado, int nuevoAltoDeseado, out int nuevoAncho, out int nuevoAlto)
        {
            nuevoAnchoDeseado = (int)(originalAncho * 0.50);
            nuevoAltoDeseado = (int)(originalAlto * 0.50);

            double proporcionOriginal = (double)originalAncho / originalAlto;

            if (originalAncho > originalAlto)
            {
                nuevoAncho = nuevoAnchoDeseado;
                nuevoAlto = (int)(nuevoAncho / proporcionOriginal);
            }
            else
            {
                nuevoAlto = nuevoAltoDeseado;
                nuevoAncho = (int)(nuevoAlto * proporcionOriginal);
            }
        }

        /*static Size ObtenerResolucionImagen(string rutaArchivo)
        {
            using (Image imagen = Image.FromFile(rutaArchivo))
            {
                return new Size(imagen.Width, imagen.Height);
            }
        }*/



        public void CrearInstanciasParaThumbnails1()
        {

            ThumbsInfo newImage = new ThumbsInfo(rutaArchivo: rutaDeThumb1, resolucion: resolucionDeThumb1, nombre: nombreDeThumb1, resolucionX: resolucionesDeImagenesRepetidasX1, resolucionY: resolucionesDeImagenesRepetidasY1, rutaDelThumb: rutaRealThumb1);

            List<object> parameters = new List<object>
                    {
                        newImage.Resolucion,
                        newImage.RutaArchivo,
                        newImage.Nombre,
                        newImage.ResolucionX,
                        newImage.ResolucionY,
                        newImage.RutaDelThumb,
                    };
            imageParametersThumb.Add(parameters);
            listaDeThumbs1.Add(newImage);
        }


        public void CrearInstanciasParaThumbnails2()
        {

            ThumbsInfo newImage = new ThumbsInfo(rutaArchivo: rutaDeThumb2, resolucion: resolucionDeThumb2, nombre: nombreDeThumb2, resolucionX: resolucionesDeImagenesRepetidasX2, resolucionY: resolucionesDeImagenesRepetidasY2, rutaDelThumb: rutaRealThumb2);

            List<object> parameters = new List<object>
                    {
                        newImage.Resolucion,
                        newImage.RutaArchivo,
                        newImage.Nombre,
                        newImage.ResolucionX,
                        newImage.ResolucionY,
                        newImage.RutaDelThumb,
                    };
            imageParametersThumb2.Add(parameters);
            listaDeThumbs2.Add(newImage);
        }



        class ThumbsInfo
        {
            public string RutaArchivo { get; set; }
            public string RutaDelThumb {  get; set; }
            public Size Resolucion { get; set; }
            public int ResolucionX { get; set; }
            public int ResolucionY { get; set; }
            public string Nombre { get; set; }

            public ThumbsInfo(string rutaArchivo, Size resolucion, string nombre, int resolucionX, int resolucionY, string rutaDelThumb)
            {
                RutaArchivo = rutaArchivo;
                Resolucion = resolucion;
                Nombre = nombre;
                ResolucionX = resolucionX;
                ResolucionY = resolucionY;
                RutaDelThumb = rutaDelThumb;
            }
        }


        /*public void ObtenerRutasdeRepetidas()
        {
            foreach (var imagen in interseccionPrincipal1)
            {
                rutasDeImagenesRepetidas1.Add(imagen.Path);
            }
            foreach (var imagen in interseccionPrincipal2)
            {
                rutasDeImagenesRepetidas2.Add(imagen.Path);
            }
        }*/

        public void SuministrarInfoThumbs1()
        {
            Directory.CreateDirectory(rutaCarpetaThumbs1);
            foreach (var ruta in interseccionPrincipal1)
            {
                nombreDeThumb1 = ruta.Name;
                rutaDeThumb1 = ruta.Path;
                using (Bitmap imagen = new Bitmap(ruta.Path))
                {
                    resolucionesDeImagenesRepetidasX1 = imagen.Width;
                    resolucionesDeImagenesRepetidasY1 = imagen.Height;
                }
                rutaRealThumb1 = rutaCarpetaThumbs1 + "\\" + ruta.Name;
                CrearThumbnails(ruta.Path, rutaRealThumb1, resolucionesDeImagenesRepetidasX1, resolucionesDeImagenesRepetidasY1);
                CrearInstanciasParaThumbnails1();
            }
        }

        public void SuministrarInfoThumbs2()
        {
            Directory.CreateDirectory(rutaCarpetaThumbs2);
            foreach (var ruta in interseccionPrincipal2)
            {
                nombreDeThumb2 = ruta.Name;
                rutaDeThumb2 = ruta.Path;
                using (Bitmap imagen = new Bitmap(ruta.Path))
                {
                    resolucionesDeImagenesRepetidasX2 = imagen.Width;
                    resolucionesDeImagenesRepetidasY2 = imagen.Height;
                }
                rutaRealThumb2 = rutaCarpetaThumbs2 + "\\" + ruta.Name;
                CrearThumbnails(ruta.Path, rutaRealThumb2, resolucionesDeImagenesRepetidasX2, resolucionesDeImagenesRepetidasY2);
                CrearInstanciasParaThumbnails2();
            }
        }



        private void MostrarImagen()
        {
            if (pressedBtn == 1 && validImage1 == true)
            {
                lblRes1.Visible = true;
                lblFecha1.Visible = true;
                lblPeso1.Visible = true;
                lblNombre1.Visible = true;
                lblNombre1.Visible = true;
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox1.BringToFront();
                pictureBox2.BringToFront();

                lblNombre1.Text = $"Name:{nombreBuscadoActual1}";
                lblRes1.Text = $"Resoltion:{resolucionDuplicadoActualX1}x{resolucionDuplicadoActualY1}";
                lblPeso1.Text = $"Weight:{pesoDuplicadoActual1.ToString("F2")} {pesoUsadoDuplicadoActual1}";
                lblFecha1.Text = $"Date:{fechaDuplicadoActual1.ToString()}";
                pictureBox1.Image = Image.FromFile(rutaDuplicadoActual1);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.BringToFront();
            }
            else if (pressedBtn == 2 && validImage2 == true)
            {
                lblRes2.Visible = true;
                lblFecha2.Visible = true;
                lblPeso2.Visible = true;
                lblNombre2.Visible = true;
                lblNombre2.Visible = true;

                lblNombre2.Text = $"Name:{nombreBuscadoActual2}";
                lblRes2.Text = $"Resolution:{resolucionDuplicadoActualX2}x{resolucionDuplicadoActualY2}";
                lblPeso2.Text = $"Weight:{pesoDuplicadoActual2.ToString("F2")} {pesoUsadoDuplicadoActual2}";
                lblFecha2.Text = $"Date:{fechaDuplicadoActual2.ToString()}";
                pictureBox2.Image = Image.FromFile(rutaDuplicadoActual2);
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.BringToFront();
            }
        }



        private void CargarDatosActuales()
        {
            nombreBuscadoActual1 = interseccionPrincipal1[cont - 1].Name;
            pesoDuplicadoActual1 = interseccionPrincipal1[cont - 1].Weight;
            pesoUsadoDuplicadoActual1 = interseccionPrincipal1[cont - 1].UsedSize;
            rutaDuplicadoActual1 = listaDeThumbs1[cont - 1].RutaDelThumb;
            rutaThumbActual1 = interseccionPrincipal1[cont - 1].Path;
            fechaDuplicadoActual1 = interseccionPrincipal1[cont - 1].Date;
            resolucionDuplicadoActualX1 = listaDeThumbs1[cont - 1].ResolucionX;
            resolucionDuplicadoActualY1 = listaDeThumbs1[cont - 1].ResolucionY;

            nombreBuscadoActual2 = interseccionPrincipal2[cont - 1].Name;
            pesoDuplicadoActual2 = interseccionPrincipal2[cont - 1].Weight;
            pesoUsadoDuplicadoActual2 = interseccionPrincipal2[cont - 1].UsedSize;
            rutaDuplicadoActual2 = listaDeThumbs2[cont - 1].RutaDelThumb;
            rutaThumbActual2 = interseccionPrincipal2[cont - 1].Path;
            fechaDuplicadoActual2 = interseccionPrincipal2[cont - 1].Date;
            resolucionDuplicadoActualX2 = listaDeThumbs2[cont - 1].ResolucionX;
            resolucionDuplicadoActualY2 = listaDeThumbs2[cont - 1].ResolucionY;
        }



        private void btnBorrar1_Click(object sender, EventArgs e)
        {
            if (btnBorrar1.BackColor == Color.FromArgb(46, 46, 46))
            {
                archivosParaBorrar1.Add(rutaThumbActual1);
                btnBorrar1.BackColor = Color.Red;
            }
            else
            {
                archivosParaBorrar1.Remove(rutaThumbActual1);
                btnBorrar1.BackColor = Color.FromArgb(46, 46, 46);
            }
        }

        private void btnBorrar2_Click(object sender, EventArgs e)
        {
            if (btnBorrar2.BackColor == Color.FromArgb(46, 46, 46))
            {
                archivosParaBorrar2.Add(rutaThumbActual2);
                btnBorrar2.BackColor = Color.Red;
            }
            else
            {
                archivosParaBorrar2.Remove(rutaThumbActual2);
                btnBorrar2.BackColor = Color.FromArgb(46, 46, 46);
            }
        }

        private void CheckBtn1()
        {
            if (archivosParaBorrar1.Contains(rutaThumbActual1))
            {
                btnBorrar1.BackColor = Color.Red;
            }
            else
            {
                btnBorrar1.BackColor = Color.FromArgb(46, 46, 46);
            }
        }

        private void Checkbtn2()
        {
            if (archivosParaBorrar2.Contains(rutaThumbActual2))
            {
                btnBorrar2.BackColor = Color.Red;
            }
            else
            {
                btnBorrar2.BackColor = Color.FromArgb(46, 46, 46);
            }
        }
    }
}
