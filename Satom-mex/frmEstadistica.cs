using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//generar reporte en PDF
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace Satom_mex
{
    public partial class frmEstadistica : UserControl
    {

        double NumeroDeClase = 0;
        double Rango = 0;
        double AnchuradeClases = 0;
        double DatoMayor = 0;
        double DatoMenor = 0;
        public MySqlConnection conectar = new MySqlConnection("Server=localhost;Database=bdservice; User Id=root;Password=");
        int totalRegistros = 0;
        // double[] datEstaticos = new double[] { 49, 68, 70, 98, 100, 95, 70, 96, 85, 100, 83, 89, 60, 66, 55, 55, 65, 77, 80, 92, 93, 70, 87, 74, 66, 95, 65, 87, 45, 77, 67, 93, 60, 75, 69, 52, 82, 78, 92, 56, 98, 58, 56, 70, 70, 74, 75, 64, 77, 50 };
        double[] DatosClientes = { };

        public frmEstadistica()
        {
            InitializeComponent();


        }

        public void noordenAList()
        {
            //double[] num = new double[datEstaticos.Length];

            //num = ordenarArray(datEstaticos);
            for (int i = 0; i < DatosClientes.Length; i++)
            {
                listBox1.Items.Add(DatosClientes[i]);
            }
        }

        public void ordenaList()
        {
            double[] num = new double[DatosClientes.Length];

            num = ordenarArray(DatosClientes);
            for (int i = 0; i < DatosClientes.Length; i++)
            {
                listBox2.Items.Add(num[i]);
            }
        }

        public double[] ordenarArray(double[] n)
        {
            double aux;
            for (int i = 0; i < DatosClientes.Length; i++)
            {
                for (int x = i + 1; x < DatosClientes.Length; x++)
                {
                    if (n[x] < n[i])
                    {
                        aux = n[i];
                        n[i] = n[x];
                        n[x] = aux;
                    }
                }
            }
            return n;
        }

        public void Ordenar()
        {
            double auxiliar = 0;
            for (int a = 0; a < DatosClientes.Length - 1; a++)
            {
                for (int b = 0; b < DatosClientes.Length - 1; b++)
                {
                    if (DatosClientes[b] > DatosClientes[b + 1])
                    {
                        auxiliar = DatosClientes[b];
                        DatosClientes[b] = DatosClientes[b + 1];
                        DatosClientes[b + 1] = auxiliar;
                        //listBox1.Items.Add(datEstaticos[b + 1]);
                    }
                }
            }
        }


        public void RegladeSturgess()
        {
            NumeroDeClase = 1 + (3.3 * (Math.Log10(DatosClientes.Length)));
            NumeroDeClase = Math.Round(NumeroDeClase, 1);
            txtMostrarNClases.Text = NumeroDeClase.ToString();
            //lblClases.Text = K.ToString();
        }


        public void VerRango()
        {
            DatoMayor = DatosClientes[DatosClientes.Length - 1];
            DatoMenor = DatosClientes[0];
            Rango = DatoMayor - DatoMenor;
            txtMostrarRango.Text = Rango.ToString();
            //lblRnago.Text = Rango.ToString();
        }



        public void MetodoAnchuradeClase()
        {
            AnchuradeClases = Rango / NumeroDeClase;
            AnchuradeClases = Math.Round(AnchuradeClases, 1);
            txtMostrarAnchura.Text = AnchuradeClases.ToString();

        }


        public void CreaTabla()
        {
            double aux = DatoMenor;
            double acum = 0;
            for (int x = 0; x < NumeroDeClase; x++)
            {
                dataGridView1.Rows.Add(x + 1, //Clase
                                       Math.Round(aux, 1), //Limite inferior
                                       Math.Round(aux + AnchuradeClases, 1), //Limite superior
                                       Contar(Math.Round(aux, 1), Math.Round(aux + AnchuradeClases, 1)), //Frecuencia
                                       Math.Round((((Math.Round(aux, 1) + 0.0001 + Math.Round(aux + AnchuradeClases, 1)) / 2)), 1), //Marca de clase
                                       Contar(Math.Round(aux, 1), Math.Round(aux + AnchuradeClases, 1)) * Math.Round((((Math.Round(aux, 1) + .0001 + Math.Round(aux + AnchuradeClases, 1)) / 2)), 1),//Media
                                       0, //Varianza
                                       Contar(Math.Round(aux, 1), Math.Round(aux + AnchuradeClases, 1)) + acum); //Frecuencia acumulada

                acum = acum + Contar(Math.Round(aux, 1), Math.Round(aux + AnchuradeClases, 1));
                aux = aux + AnchuradeClases;
            }
            Media();
        }



        public void CreaTabla2()
        {
            double aux = DatoMenor;
            double acum = 0;
            dataGridView1.Rows.Clear(); //Limpia la tabla anterior
            dataGridView1.Refresh(); //
            for (int x = 0; x < NumeroDeClase; x++)
            {
                dataGridView1.Rows.Add(x + 1, //Clase
                                       Math.Round(aux, 1), //Limite inferior
                                       Math.Round(aux + AnchuradeClases, 1), //Limite superior
                                       Contar(Math.Round(aux, 1), Math.Round(aux + AnchuradeClases, 1)), //Frecuencia
                                       Math.Round((((Math.Round(aux, 1) + .0001 + Math.Round(aux + AnchuradeClases, 1)) / 2)), 1), //Marca de clase
                                       Contar(Math.Round(aux, 1), Math.Round(aux + AnchuradeClases, 1)) * Math.Round((((Math.Round(aux, 1) + .0001 + Math.Round(aux + AnchuradeClases, 1)) / 2)), 1),//Media
                                       Math.Round((Math.Pow((media - Math.Round((((Math.Round(aux, 1) + .0001 + Math.Round(aux + AnchuradeClases, 1)) / 2)), 1)), 2)) * Contar(Math.Round(aux, 1), Math.Round(aux + AnchuradeClases, 1)), 1),
                                       Contar(Math.Round(aux, 1), Math.Round(aux + AnchuradeClases, 1)) + acum); //Frecuencia acumulada

                acum = acum + Contar(Math.Round(aux, 1), Math.Round(aux + AnchuradeClases, 1));
                aux = aux + AnchuradeClases;
            }
            Varianza();
            desviacionEstandar();
            Mediana();
            Moda();
            histograma();

        }


        double media;
        public void Media()
        {

            for (int x = 0; x < NumeroDeClase; x++)
            {
                media = media + Convert.ToDouble(dataGridView1.Rows[x].Cells[5].Value.ToString());
            }
            media = media / DatosClientes.Length;
            media = Math.Round(media, 1);
            txtMostrarMedia.Text = media.ToString();
           // MessageBox.Show("Media " + sum);
        }

        double varianza;
        public void Varianza()
        {
            for (int x = 0; x < NumeroDeClase; x++)
            {
                varianza = varianza + Convert.ToDouble(dataGridView1.Rows[x].Cells[6].Value.ToString());
            }
            varianza = varianza / (DatosClientes.Length - 1);
            varianza = Math.Round(varianza, 1);
            txtMostrarVarianza.Text = varianza.ToString();
            //MessageBox.Show("total de Varianza" + sum2);
        }
        double desviacion;
        public void desviacionEstandar()
        {
            desviacion = Math.Sqrt(varianza);
            desviacion = Math.Round(desviacion, 1);
            txtMostrarDesviacionEstandar.Text = desviacion.ToString();

           // MessageBox.Show("Desviación Estandar" + sum3);
        }

        float sum4;
        int sum41;
        //double sum42;
        //double sum43;
        double sum44;
        double medianaa;
        float mas1;
        public void Mediana()
        {
            mas1 = (DatosClientes.Length +1);
            sum4 = mas1 / 2;
            sum41 = Convert.ToInt32(NumeroDeClase / 2);
            //sum42 = (Convert.ToDouble(dataGridView1.Rows[sum41-1].Cells[7].Value.ToString()))+1;

            double aux = Convert.ToDouble(dataGridView1.Rows[0].Cells[3].Value.ToString());
            sum44 = Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value.ToString());

            for (int x = 0; x < NumeroDeClase; x++)
            {
                if (Convert.ToDouble(dataGridView1.Rows[x].Cells[3].Value.ToString()) > aux)
                {
                    aux = Convert.ToDouble(dataGridView1.Rows[x].Cells[3].Value.ToString());
                    sum44 = Convert.ToDouble(dataGridView1.Rows[x].Cells[1].Value.ToString());
                }
            }

            
            double fa=Convert.ToDouble(dataGridView1.Rows[sum41-1].Cells[7].Value.ToString());
            medianaa = Math.Round(((sum4 - (1 + fa)) / aux) * AnchuradeClases + sum44, 1);
            txtMostrarMediana.Text = medianaa.ToString();
            //dataGridView1.Rows[(int)medianaa].DefaultCellStyle.BackColor = Color.AliceBlue;
            //MessageBox.Show("Mediana " + medianaa);
        }

        public void Moda()
        {
            //sum41 = Convert.ToInt32(K / 2);

            double aux = Convert.ToDouble(dataGridView1.Rows[0].Cells[3].Value.ToString());
            double d1 = 0, d2 = 0, mo = 0, lm = 0; ;
            for (int x = 0; x < NumeroDeClase - 1; x++)
            {
                if (Convert.ToDouble(dataGridView1.Rows[x].Cells[3].Value.ToString()) > aux)
                {
                    aux = Convert.ToDouble(dataGridView1.Rows[x].Cells[3].Value.ToString());
                    lm = Convert.ToDouble(dataGridView1.Rows[x].Cells[1].Value.ToString());
                    mo = aux;
                    d1 = Convert.ToDouble(dataGridView1.Rows[x + 1].Cells[3].Value.ToString());
                    d2 = Convert.ToDouble(dataGridView1.Rows[x - 1].Cells[3].Value.ToString());
                }
            }

            d1 = mo - d1;
            d2 = mo - d2;

            double formula = lm + (d1 / (d1 + d2)) * AnchuradeClases;
            //int er = Math.Round(Convert.ToInt32(formula));
            //dataGridView1.Rows[].DefaultCellStyle.BackColor = Color.AliceBlue;
            //MessageBox.Show(formula.ToString());
            //   MessageBox.Show("Moda " + formula);

            txtMostrarModa.Text = formula.ToString();
            txtProbaMayor.Text = Math.Round(formula + 3).ToString();
            txtProbaMenor.Text = Math.Round(formula - 2).ToString();
            txtProbaMenorEntre.Text = Math.Round(formula - 2).ToString();
            txtProbaMayorEntre.Text = Math.Round(formula + 3).ToString();
        }


        public void histograma()
        {

            chart1.Titles.Add("Histograma");
            int rep = Convert.ToInt32(NumeroDeClase);

            for (int x = 0; x < rep; x++)
            {
                chart1.Series["Series1"].Points.AddXY(dataGridView1.Rows[x].Cells[1].Value.ToString() + "/" + dataGridView1.Rows[x].Cells[2].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[x].Cells[3].Value.ToString()));
                chart1.Series["Series1"].Points[x].Label = dataGridView1.Rows[x].Cells[3].Value.ToString();
                chart1.Series["Series2"].Points.Add(Convert.ToInt32(dataGridView1.Rows[x].Cells[3].Value.ToString()));

                chart1.Series["Series1"]["PointWidth"] = "1";

            }
        }

        
        

        public int Contar(double men, double may)
        {
            int c = 0;
            for (int x = 0; x < DatosClientes.Length; x++)
            {
                if (DatosClientes[x] >= men && DatosClientes[x] < may)
                { c++; }
            }

            return c;
        }


        double[] p;
        public void Prob()
        {
            double mediap = media;
            double desviacionp = desviacion;
            double inicial = DatoMenor;
            double final = DatoMayor;
            double incremento = 1;
            //double
            int contad = 0;
            double auxill = inicial;

            while (auxill < final)
            {
                auxill = auxill + incremento;
                contad++;
            }
            //contad = contad + 2;
            double acumincre = inicial;

            p = new double[contad];

            for (int x = 0; x < p.Length; x++)
            {
                int sad = Convert.ToInt32(inicial + x);
                p[x] = DistribucionNormal(sad);
            }

            CrearCurva(contad, p, incremento);
        }


        private void CrearCurva(int rep, double[] arr, double inc)
        {

            //int num = rep / 3;
            //int aux = num;
            int dsad = Convert.ToInt32(DatoMenor);
            double acumincre = dsad;
            for (int x = 0; x < rep; x++)
            {

                chart2.Series["Series1"].Points.AddY(arr[x]);
                chart2.Series["Series1"].Points[x].Label = Convert.ToString(dsad + x);

                chart3.Series["Series1"].Points.AddY(arr[x]);
                chart3.Series["Series1"].Points[x].Label = Convert.ToString(dsad + x);

                chart4.Series["Series1"].Points.AddY(arr[x]);
                chart4.Series["Series1"].Points[x].Label = Convert.ToString(dsad + x);
            }

        }


        private double DistribucionNormal(double x)
        {
            double me = media;
            double os = desviacion;
            double pi = Math.PI;
            double es = Math.E;

            double disnorm = (1 / (Math.Sqrt(2 * pi * os))) * Math.Pow(es, -(0.5) * (Math.Pow((x - me) / os, 2)));
            //MessageBox.Show(disnorm.ToString());
            return disnorm;
        }



        private void CrearCurvaMenor(double y)
        {

            double val = DistribucionNormal(y);
            int bandera = 0;

            chart2.Series["Series2"].Points.Clear();

            for (int x = 0; x < p.Length; x++)
            {
                //chart2.Series["Series1"].Points.AddY(arr[x]);
                //chart3.Series["Series2"].Points[x].Label = Convert.ToString(dsad + x);
                if (val >= p[x] && bandera == 0)
                {

                    chart2.Series["Series2"]["PointWidth"] = "1";
                    chart2.Series["Series2"].Points.Add(p[x]);

                }
                else
                {
                    chart2.Series["Series2"].Points.Add(0);
                    chart2.Series["Series2"]["PointWidth"] = "1";
                    bandera = 1;
                }
            }
        }


        private void CrearCurvaMayor(double y)
        {
            double val = DistribucionNormal(y);
            int bandera = 0;

            chart3.Series["Series2"].Points.Clear();

            for (int x = 0; x < p.Length; x++)
            {
                if (val >= p[x] && bandera == 0)
                {
                    chart3.Series["Series2"].Points.Add(0);
                }
                else
                {
                    if (val >= p[x] && bandera == 1)
                    {
                        chart3.Series["Series2"]["PointWidth"] = "1";
                        chart3.Series["Series2"].Points.Add(p[x]);
                    }
                    else
                    {
                        chart3.Series["Series2"].Points.Add(0);
                        chart2.Series["Series2"]["PointWidth"] = "1";
                        bandera = 1;
                    }
                }
            }
        }




        private void CrearCurvaEntre(double y, double d)
        {
            double val1 = DistribucionNormal(y);
            double val2 = DistribucionNormal(d);
            //int bandera = 0;

            chart4.Series["Series2"].Points.Clear();
            double[] auxiliars = new double[p.Length];
            double valor1 = 0;
            double valor2 = 0;

            for (int x = 0; x < p.Length; x++)
            {
                if (p[x] == val1)
                    valor1 = x;
            }
            for (int x = 0; x < p.Length; x++)
            {
                if (p[x] == val2)
                    valor2 = x;
            }

            for (int x = 0; x < p.Length; x++)
            {
                if (valor1 <= x && valor2 >= x)
                {
                    chart4.Series["Series2"].Points.Add(p[x]);
                    chart4.Series["Series2"]["PointWidth"] = "1";
                }
                else
                {
                    chart4.Series["Series2"]["PointWidth"] = "1";
                    chart4.Series["Series2"].Points.Add(0);
                }
            }
        }



        private void btnCalculaMenor_Click_1(object sender, EventArgs e)
        {
            CrearCurvaMenor(Convert.ToDouble(txtProbaMenor.Text));
        }

        private void btnCalculaEntre_Click(object sender, EventArgs e)
        {
            CrearCurvaEntre(Convert.ToDouble(txtProbaMenorEntre.Text), Convert.ToDouble(txtProbaMayorEntre.Text));
        }

        private void btnCalculaMayor_Click(object sender, EventArgs e)
        {
            CrearCurvaMayor(Convert.ToDouble(txtProbaMayor.Text));
        }
        int poblacion =0;
        double n = 0;
        string dtefechaFinal = "";
        string dtefechaInicial = "";
        private void btnExtraer_Click(object sender, EventArgs e)
        {
             dtefechaInicial = dteInicial.Value.Date.ToString("yyyy-MM-dd");
             dtefechaFinal = dteFinal.Value.Date.ToString("yyyy-MM-dd");
           // totaldatos(dtefechaInicial, dtefechaFinal);
            //GuardardatosArrayBD(dtefechaInicial, dtefechaFinal);
            txtDatosTotales.Enabled = false;
            poblacion = totaldatos(dtefechaInicial, dtefechaFinal);
            txtDatosTotales.Text = poblacion.ToString();
            btnCalcularMuestra.Enabled = true;
            //poblacion=Convert.ToInt32( txtDatosTotales.Text);
            //orden();
            //noorden();
            ////xaorden();
            ////Ordenar();
            //RegladeSturgess();
            //VerRango();
            //AnchuradeClase();
            //CreaTabla();
            //CreaTabla2();
            //Prob();
            //txtDatosMuestra.Text=calculamuestra(cmbE).ToString();
        }
        private void btnGraficar_Click(object sender, EventArgs e)
        {
             
            GuardardatosArrayBD(dtefechaInicial, dtefechaFinal,txtDatosMuestra.Text);
            
            noordenAList();//los ordena y los muestra en el listbox1
            ordenaList();//los ordena y los muestra en el listbox1
            Ordenar();
            RegladeSturgess();
            VerRango();
            MetodoAnchuradeClase();
            CreaTabla();
            CreaTabla2();
            Prob();
            btnCalculaMayor.Enabled = true;
            btnCalculaEntre.Enabled = true;
            btnCalculaMenor.Enabled = true;
            btnGenerarPDF.Enabled = true;
            
            
        }

        private void btnCalcularMuestra_Click(object sender, EventArgs e)
        {
            txtDatosMuestra.Text = Math.Round(calculamuestra(cmbE), 2).ToString();
            btnGraficar.Enabled = true;
        }
        
        
        public double calculamuestra(ComboBox y)
        {
            double w= Math.Pow(1.96,2);
            double re=Math.Pow(0.5,2)*w;
        double r = poblacion * re;
            double q=poblacion-1;
            double e=Math.Pow(Convert.ToDouble(y.SelectedItem.ToString()) ,2);

            n = ( r / ((q * e) + re));
            return Math.Round(n);
        }


        public int totaldatos(string fechainicial, string fechafinal)
        {
            int r = 0;
            using (conectar)
            {
                string query = "SELECT COUNT(dbleIMC) FROM tblcliente WHERE vchFechRegistro BETWEEN '" + fechainicial + " 00:00:00' AND '" + fechafinal + " 23:59:59';";
                conectar.Open();
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                r = Convert.ToInt32(cmd.ExecuteScalar());


            }
            conectar.Close();
            totalRegistros = r;
            return r;

        }

        public void GuardardatosArrayBD(string inicial, string final,string limite)
        {
            //double[] num = new double[poblacion];//Cambiar la población, asignarle lo que da la muestra
            List<double> resultado = new List<double>();
            using (conectar)
            {
                string query = "SELECT dbleIMC FROM tblcliente WHERE vchFechRegistro BETWEEN '" + inicial + " 00:00:00' AND '" + final + " 23:59:59' limit " + limite + ";";
                conectar.Open();
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                MySqlDataReader d = cmd.ExecuteReader();


                while (d.Read())
                {
                    resultado.Add(Convert.ToDouble(d["dbleIMC"]));

                }

            }
            DatosClientes = resultado.ToArray();
            conectar.Close();
            for (int i = 0; i < DatosClientes.Length; i++)
            {
                //MessageBox.Show("los datos fueron"+Array[i]);
                listBox1.Items.Add(DatosClientes[i]);
            }
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void frmEstadistica_Load(object sender, EventArgs e)
        {
            btnCalculaEntre.Enabled = false;
            btnCalculaMayor.Enabled = false;
            btnCalculaMenor.Enabled = false;
            btnCalcularMuestra.Enabled = false;
            btnGraficar.Enabled = false;
            btnGenerarPDF.Enabled = false;
            btnExtraer.Focus();
            
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            

            string FileName ="Reporte generado el " + dtefechaInicial + " a " + dtefechaFinal + " " + cmbE.SelectedItem.ToString() +".pdf";
           

            //genera el documento
            Document document = new Document(iTextSharp.text.PageSize.A4, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(document, new FileStream(FileName, FileMode.Create));
            document.Open();

            document.AddAuthor("Empresa SATOM-MEX");
            document.AddCreator("Reporte generado para la toma de desiciones.");
            document.AddKeywords("Reporte en PDF Histograma");
            document.AddSubject("Estadística de la fecha " + dtefechaInicial + " a " + dtefechaFinal + "");
            document.AddTitle("Reporte");


            //Cargo la imagen desde el almacenamiento
            iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance(@"C:\datos\SATOM-MEX.png");
            PNG.ScaleToFit(100f, 100f);
            PNG.Border = iTextSharp.text.Rectangle.BOX;
            //PNG.BorderColor = iTextSharp.text.BaseColor.WHITE;
            //PNG.BorderWidth = 5f;
            document.Add(PNG);

            //Ingreso los titulos que tendra el documento
            Chunk Titulo = new Chunk("SATOM-MEX", FontFactory.GetFont("Times New Roman", 15, iTextSharp.text.Font.BOLD));
            Chunk secundario = new Chunk("Salud Alimentaria y Tratamientos Orgánicos Medicinales de México", FontFactory.GetFont("Times New Roman", 13, iTextSharp.text.Font.BOLD));
            document.Add(new Paragraph(Titulo)); 
            document.Add(new Paragraph(secundario));
            


            //Agrego los datos del reporte
            document.Add(new Paragraph("Reporte de " + dtefechaInicial + " al " + dtefechaFinal + ".", FontFactory.GetFont("Times New Roman", 12, iTextSharp.text.Font.ITALIC)));
            document.Add(new Paragraph("Tamaño de clases: "+txtMostrarNClases.Text, FontFactory.GetFont("Times New Roman", 12, iTextSharp.text.Font.ITALIC)));
            document.Add(new Paragraph("Rango: " + txtMostrarRango.Text, FontFactory.GetFont("Times New Roman", 12, iTextSharp.text.Font.ITALIC)));
            document.Add(new Paragraph("Anchura de clases: " + txtMostrarAnchura.Text, FontFactory.GetFont("Times New Roman", 12, iTextSharp.text.Font.ITALIC)));
            document.Add(new Paragraph("Media: " + txtMostrarMedia.Text, FontFactory.GetFont("Times New Roman", 12, iTextSharp.text.Font.ITALIC)));
            document.Add(new Paragraph("Desviación estándar: " + txtMostrarDesviacionEstandar.Text, FontFactory.GetFont("Times New Roman", 12, iTextSharp.text.Font.ITALIC)));
            document.Add(new Paragraph("Mediana: " + txtMostrarMediana.Text, FontFactory.GetFont("Times New Roman", 12, iTextSharp.text.Font.ITALIC)));
            document.Add(new Paragraph("Moda: " + txtMostrarModa.Text, FontFactory.GetFont("Times New Roman", 12, iTextSharp.text.Font.ITALIC)));
            document.Add(new Paragraph("Varianza: " + txtMostrarVarianza.Text, FontFactory.GetFont("Times New Roman", 12, iTextSharp.text.Font.ITALIC)));
            document.Add(new Paragraph(""));
            document.Add(new Paragraph("Histograma con polígonos de frecuencias", FontFactory.GetFont("Times New Roman", 12, iTextSharp.text.Font.BOLDITALIC)));



           

            //Agrego la imagen que es capturada desde el módulo y lo cargo en el documento
            var chartImage = new MemoryStream();
            chart1.SaveImage(chartImage, ChartImageFormat.Png);
            iTextSharp.text.Image Chart_image = iTextSharp.text.Image.GetInstance(chartImage.GetBuffer());
            Chart_image.ScaleToFit(600f,600f);
            document.Add(Chart_image);



            document.Close();

            MessageBox.Show("Reporte creado exitosamente!!");

            
        }

        

        


       

    }

    
}
