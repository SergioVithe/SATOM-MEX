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
        public MySqlConnection conectar;//= new MySqlConnection("Server=localhost;Database=bdservice; User Id=root;Password=");
        int totalRegistros = 0;
        ClsConexion conectarse = new ClsConexion();
         
        // double[] datEstaticos = new double[] { 49, 68, 70, 98, 100, 95, 70, 96, 85, 100, 83, 89, 60, 66, 55, 55, 65, 77, 80, 92, 93, 70, 87, 74, 66, 95, 65, 87, 45, 77, 67, 93, 60, 75, 69, 52, 82, 78, 92, 56, 98, 58, 56, 70, 70, 74, 75, 64, 77, 50 };
        double[] DatosClientes = { };

        public frmEstadistica()
        {
            InitializeComponent();
            //string[] cadenas = { };
            //ClsInicio acceso = new ClsInicio();
            //cadenas = acceso.datosBaseDatos().Split('=', ';');
            //conectar = new MySqlConnection("Server=" + cadenas[1] + ";Database=" + cadenas[3] + "; User Id=" + cadenas[5] + ";Password=" + cadenas[7]);
          

        }
        public void lol()
        { 
        
            string sFileName = "";

            if (cmbSucursales.SelectedItem.ToString() == "Sucursal 1")
            {
                sFileName = @"C:\datos\feedback.ini";
            }
            else if (cmbSucursales.SelectedItem.ToString() == "Sucursal 2")
            {
                sFileName = @"C:\datos\Selena_Suc1.ini";
            }

            ClsDatos datos = new ClsDatos();
            if (File.Exists(sFileName))
            {
                StreamReader ar = new StreamReader(sFileName);
                string linea = ar.ReadLine();
                ar.Close();
                string[] cadenas = { };
                ClsInicio inicio = new ClsInicio();
                cadenas = inicio.datosBaseDatos().Split('=', ';');
                ClsConexion conexion = new ClsConexion();
                conexion.bd = cadenas[3];
                conexion.pass = cadenas[7];
                conexion.servidor = cadenas[1];
                conexion.user = cadenas[5];
                string cadena = "Server=" + conexion.servidor + ";Database=" + conexion.bd + "; User Id=" + conexion.user + ";Password=" + conexion.pass;
                conexion.cadenadesencriptada = cadena;
                // conexion.cadenadesencriptada = datos.Desencriptar(cadena);
                if (conexion.conexion())
                {
                    if (cmbSucursales.SelectedItem.ToString() == "Sucursal 1")
                    {
                        lblEstado.Text = "Huejutla zona centro";
                    }
                    else if (cmbSucursales.SelectedItem.ToString() == "Sucursal 2")
                    {
                        lblEstado.Text = "San Felipe";
                    }

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
                    cmbE.Focus();
                }
                else if (conexion.conexion() == false)
                {
                    lblEstado.ForeColor = System.Drawing.Color.DarkRed;
                    lblEstado.Text = "Conexión no establecida";
                }
            }
        }

        private void btnExtraer_Click_1(object sender, EventArgs e)
        {
            string sFileName = "";

            if (cmbSucursales.SelectedItem.ToString() == "Sucursal 1")
            {
                sFileName = @"C:\datos\feedback.ini";
            }
            else if (cmbSucursales.SelectedItem.ToString() == "Sucursal 2")
            {
                sFileName = @"C:\datos\Selena_Suc1.ini";
            }

            
            if (conectarse.ObtenerConexion2(sFileName))
            {


                if (cmbSucursales.SelectedItem.ToString() == "Sucursal 1")
                {
                    lblEstado.Text = "Huejutla zona centro";
                }
                else if (cmbSucursales.SelectedItem.ToString() == "Sucursal 2")
                {
                    lblEstado.Text = "San Felipe";
                }

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
                cmbE.Focus();
            }
            else if (conectarse.ObtenerConexion2(sFileName) == false)
            {
                lblEstado.ForeColor = System.Drawing.Color.DarkRed;
                lblEstado.Text = "Conexión no establecida";
            }
            


        }

        public void noordenAList()
        {
            //double[] num = new double[datEstaticos.Length];

            //num = ordenarArray(datEstaticos);
            listBox1.Items.Clear();
            for (int i = 0; i < DatosClientes.Length; i++)
            {
                listBox1.Items.Add(DatosClientes[i]);
            }
        }

        public void ordenaList()
        {
            listBox2.Items.Clear();
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


        double media = 0;
        public void Media()
        {
            media = 0;
            for (int x = 0; x < NumeroDeClase; x++)
            {
                media = media + Convert.ToDouble(dataGridView1.Rows[x].Cells[5].Value.ToString());
            }
            media = media / DatosClientes.Length;
            media = Math.Round(media, 1);
            txtMostrarMedia.Text = media.ToString();
            lblMostrarMedia.Text = media.ToString();
            // MessageBox.Show("Media " + sum);
        }

        double varianza = 0;
        public void Varianza()
        {
            varianza = 0;
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
            lblMostrarDesviacion.Text = desviacion.ToString();

            // MessageBox.Show("Desviación Estandar" + sum3);
        }

        float sum4;
        double sum41;
        //double sum42;
        //double sum43;
        double sum44;
        double medianaa;
        float mas1;
        public void Mediana()
        {
            medianaa = 0;
            mas1 = (DatosClientes.Length + 1);
            sum4 = mas1 / 2;


            sum41 = Math.Round(NumeroDeClase) / 2;
            double fa = 0;
            double clase = Math.Round(sum41);
            //sum42 = (Convert.ToDouble(dataGridView1.Rows[sum41-1].Cells[7].Value.ToString()))+1;

            double aux = Convert.ToDouble(dataGridView1.Rows[0].Cells[0].Value.ToString());
            clase = clase - 1;
            Boolean a = true;
            int colorRow = 0;
            for (int i = 0; i < NumeroDeClase; i++)
            {

                if (Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value.ToString()) == clase && a)
                {
                    fa = Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value.ToString());
                    clase = clase + 1;

                    a = false;
                }
                if (Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value.ToString()) == clase)
                {
                    colorRow = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    aux = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    sum44 = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value.ToString());

                }


            }


            dataGridView1.Rows[colorRow - 1].DefaultCellStyle.BackColor = Color.Brown;
            //sum44 = Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value.ToString());

            //for (int x = 0; x < NumeroDeClase; x++)
            //{
            //    if (Convert.ToDouble(dataGridView1.Rows[x].Cells[3].Value.ToString()) > aux)
            //    {
            //        aux = Convert.ToDouble(dataGridView1.Rows[x].Cells[3].Value.ToString());
            //        sum44 = Convert.ToDouble(dataGridView1.Rows[x].Cells[1].Value.ToString());
            //    }
            //}



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
            double famas1 = 0;
            Boolean bandera = true;
            int colorRow = 0;
            for (int x = 0; x < NumeroDeClase - 1; x++)
            {
                if (bandera == false)
                {
                    famas1 = Convert.ToDouble(dataGridView1.Rows[x].Cells[3].Value.ToString());

                    bandera = true;

                }
                if (Convert.ToDouble(dataGridView1.Rows[x].Cells[3].Value.ToString()) >= aux)
                {
                    colorRow = Convert.ToInt32(dataGridView1.Rows[x].Cells[0].Value.ToString());
                    aux = Convert.ToDouble(dataGridView1.Rows[x].Cells[3].Value.ToString());
                    lm = Convert.ToDouble(dataGridView1.Rows[x].Cells[1].Value.ToString());
                    mo = aux;
                    d1 = Convert.ToDouble(dataGridView1.Rows[x + 1].Cells[3].Value.ToString());
                    try
                    {
                        d2 = Convert.ToDouble(dataGridView1.Rows[x - 1].Cells[3].Value.ToString());
                    }
                    catch (Exception)
                    {
                        d2 = 0;// Convert.ToDouble(dataGridView1.Rows[x ].Cells[3].Value.ToString());
                        //throw;
                    }


                    //aux = aux + 1;
                    bandera = false;
                }


            }

            dataGridView1.Rows[colorRow - 1].DefaultCellStyle.BackColor = Color.DarkGreen;
            d1 = aux - famas1;//8
            double a = mo - d2;
            d2 = a;


            double form = lm + (d1 / (d1 + d2)) * AnchuradeClases;

            //d1 = aux - d1;




            //double formula = lm + (d1 / (d1 + d2)) * AnchuradeClases;
            //int er = Math.Round(Convert.ToInt32(formula));
            //dataGridView1.Rows[].DefaultCellStyle.BackColor = Color.AliceBlue;
            //MessageBox.Show(formula.ToString());
            //   MessageBox.Show("Moda " + formula);

            txtMostrarModa.Text = Math.Round(form, 1).ToString();
            txtProbaMayor.Text = Math.Round((media + 5)).ToString();
            txtProbaMenor.Text = Math.Round((media - 5)).ToString();
            txtProbaMenorEntre.Text = Math.Round((media - 5)).ToString();
            txtProbaMayorEntre.Text = Math.Round((media + 5)).ToString();
        }


        public void histograma()
        {

            if (chart1.Series.Count > 0)
            {
                foreach (var item in chart1.Series)
                {
                    item.Points.Clear();
                }
            }
            if (chart1.Titles.Count > 0)
            {
                chart1.Titles.RemoveAt(0);
            }

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

            if (chart2.Series.Count > 0)
            {
                foreach (var item in chart2.Series)
                {
                    item.Points.Clear();
                }
            }

            if (chart3.Series.Count > 0)
            {
                foreach (var item in chart3.Series)
                {
                    item.Points.Clear();
                }
            }

            if (chart4.Series.Count > 0)
            {
                foreach (var item in chart4.Series)
                {
                    item.Points.Clear();
                }
            }

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



        //private void btnCalculaMenor_Click_1(object sender, EventArgs e)
        //{

        //}
        private void btnCalculaMenor_Click(object sender, EventArgs e)
        {
            double datomenor1 = Convert.ToDouble(txtProbaMenor.Text);

            if (datomenor1 < media)
            {
                CrearCurvaMenor(datomenor1);
                calculaProbabilidadMenor(datomenor1);
                DialogResult result = MessageBox.Show("Realmente desea generar el reporte?", "Esperando confirmación", MessageBoxButtons.YesNo);


                if (result == DialogResult.Yes)
                {
                    GenerarPDFProbabilidad(" Menor ", chart2, datomenor1.ToString());
                }

            }
            else
            {
                MessageBox.Show("El dato debe ser menor a la media.");
            }


        }


        public void calculaProbabilidadMenor(double x)
        {
            double media = 0;
            double desviacion = 0;
            double z = 0;
            double result = 0;
            media = Convert.ToDouble(lblMostrarMedia.Text.ToString());
            desviacion = Convert.ToDouble(lblMostrarDesviacion.Text.ToString());
            z = ((x - media) / desviacion);
            double RedondeoZ = Math.Round(z, 2);
            result = chart1.DataManipulator.Statistics.NormalDistribution(RedondeoZ);
            double multiplicado = result * 100;
            lblMostrarCalculoX.Text = Math.Round(z, 3).ToString();
            lblMostrarX.Text = Math.Round(result, 4).ToString();
            lblMostrarPorCien.Text = Math.Round(multiplicado, 2).ToString() + "% de probabilidad.";
            //MessageBox.Show(result.ToString());
        }


        private void btnCalculaMayor_Click_1(object sender, EventArgs e)
        {
            double datoMayor1 = Convert.ToDouble(txtProbaMayor.Text);
            if (datoMayor1 > media)
            {

                CrearCurvaMayor(datoMayor1);
                calculaProbabilidadMayor(datoMayor1);
                DialogResult result = MessageBox.Show("Realmente desea generar el reporte?", "Esperando confirmación", MessageBoxButtons.YesNo);


                if (result == DialogResult.Yes)
                {
                    GenerarPDFProbabilidad(" Mayor ", chart3, datoMayor1.ToString());
                }
            }
            else
            {
                MessageBox.Show("El dato debe ser mayor a la media.");
            }

        }

        private void btnCalculaEntre_Click_1(object sender, EventArgs e)
        {
            double datomenor = Convert.ToDouble(txtProbaMenorEntre.Text);
            double datomayor = Convert.ToDouble(txtProbaMayorEntre.Text);


            if (datomenor < media && datomayor > media)
            {
                CrearCurvaEntre(datomenor, datomayor);
                calculaProbabilidadEntre(datomenor, datomayor);

                DialogResult result = MessageBox.Show("Realmente desea generar el reporte?", "Esperando confirmación", MessageBoxButtons.YesNo);


                if (result == DialogResult.Yes)
                {
                    GenerarPDFProbabilidad(" Entre ", chart4, datomenor.ToString() + " y " + datomayor.ToString());
                }
            }
            else
            {
                MessageBox.Show("Los datos deben de estar correctos");
            }

        }

        //private void btnCalculaEntre_Click(object sender, EventArgs e)
        //{
        //    double datomenor = Convert.ToDouble(txtProbaMenorEntre.Text);
        //    double datomayor = Convert.ToDouble(txtProbaMayorEntre.Text);
        //    CrearCurvaEntre(datomenor, datomayor);
        //    calculaProbabilidadEntre(datomenor, datomayor);

        //}

        //private void btnCalculaMayor_Click(object sender, EventArgs e)
        //{
        //    double datoMayor1 = Convert.ToDouble(txtProbaMayor.Text);
        //    CrearCurvaMayor(datoMayor1);
        //    calculaProbabilidadMayor(datoMayor1);
        //}

        public void calculaProbabilidadMayor(double x)
        {
            label27.Text = "";
            double media = 0;
            double desviacion = 0;
            double z = 0;
            double result = 0;
            media = Convert.ToDouble(lblMostrarMedia.Text.ToString());
            desviacion = Convert.ToDouble(lblMostrarDesviacion.Text.ToString());
            z = ((x - media) / desviacion);
            result = chart1.DataManipulator.Statistics.NormalDistribution(Math.Round(z, 2));
            double mul = result * 100;



            double multiplicado = 100 - mul;

            lblMostrarCalculoX.Text = Math.Round(z, 4).ToString();
            lblMostrarX.Text = Math.Round(result, 4).ToString();
            lblMostrarPorCien.Text = Math.Round(multiplicado, 2).ToString() + "% de probabilidad.";
            //MessageBox.Show(result.ToString());
        }


        public void calculaProbabilidadEntre(double x, double y)
        {
            double z1 = 0;
            double z2 = 0;
            if (x > y)
            {
                z1 = x;
                z2 = y;
            }
            else
            {
                z1 = y;
                z2 = x;
            }


            double media = 0;
            double desviacion = 0;
            double valorz1 = 0;
            double valorz2 = 0;
            double resultz1 = 0;
            double resultz2 = 0;


            media = Convert.ToDouble(lblMostrarMedia.Text.ToString());
            desviacion = Convert.ToDouble(lblMostrarDesviacion.Text.ToString());



            valorz1 = ((z1 - media) / desviacion);
            resultz1 = chart1.DataManipulator.Statistics.NormalDistribution(Math.Round(valorz1, 2));


            valorz2 = ((z2 - media) / desviacion);
            resultz2 = chart1.DataManipulator.Statistics.NormalDistribution(Math.Round(valorz2, 2));

            double r = Math.Round(resultz1, 2) - Math.Round(resultz2, 2);
            double z = r * 100;
            lblMostrarCalculoX.Text = " Z1= " + Math.Round(valorz1, 4) + "  y  Z2= " + Math.Round(valorz2, 4).ToString();
            lblMostrarX.Text = Math.Round(r, 4).ToString();
            lblMostrarPorCien.Text = Math.Round(z, 2).ToString() + "% de probabilidad.";








        }




        int poblacion = 0;
        double n = 0;
        string dtefechaFinal = "";
        string dtefechaInicial = "";





        private void btnCalcularMuestra_Click(object sender, EventArgs e)
        {
            txtDatosMuestra.Text = Math.Round(calculamuestra(cmbE), 2).ToString();
            btnGraficar.Enabled = true;
        }


        public double calculamuestra(ComboBox y)
        {
            double w = Math.Pow(1.96, 2);
            double re = Math.Pow(0.5, 2) * w;
            double r = poblacion * re;
            double q = poblacion - 1;
            double e = Math.Pow(Convert.ToDouble(y.SelectedItem.ToString()), 2);

            n = (r / ((q * e) + re));
            return Math.Round(n);
        }


        public int totaldatos(string fechainicial, string fechafinal)
        {
            int r = 0;
            using (conectarse.conectar1)
            {
                string query = "SELECT COUNT(dbleIMC) FROM tblcliente WHERE vchFechRegistro BETWEEN '" + fechainicial + " 00:00:00' AND '" + fechafinal + " 23:59:59';";
                
                MySqlCommand cmd = new MySqlCommand(query, conectarse.conectar1);
                r = Convert.ToInt32(cmd.ExecuteScalar());


            }
            conectarse.conectar1.Close();
            totalRegistros = r;
            return r;

        }

        public void GuardardatosArrayBD(string inicial, string final, string limite)
        {
            //double[] num = new double[poblacion];//Cambiar la población, asignarle lo que da la muestra
            List<double> resultado = new List<double>();
            using (conectarse.conectar1)
            {
                string query = "SELECT dbleIMC FROM tblcliente WHERE vchFechRegistro BETWEEN '" + inicial + " 00:00:00' AND '" + final + " 23:59:59' limit " + limite + ";";
                conectarse.conectar1.Open();
                MySqlCommand cmd = new MySqlCommand(query, conectarse.conectar1);
                MySqlDataReader d = cmd.ExecuteReader();


                while (d.Read())
                {
                    resultado.Add(Convert.ToDouble(d["dbleIMC"]));

                }

            }
            DatosClientes = resultado.ToArray();
            conectarse.conectar1.Close();
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



        private void cmbE_Enter(object sender, EventArgs e)
        {
            btnCalcularMuestra.Focus();
        }

        
        private void btnGraficar_Click_1(object sender, EventArgs e)
        {

            double[] DatosClientes = new double[] { };

            GuardardatosArrayBD(dtefechaInicial, dtefechaFinal, txtDatosMuestra.Text);

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


        public void GenerarPDFProbabilidad(String name, Chart x, string datos)
        {
            String Filename = "Reporte de probabilidad " + name + " con " + datos + ", " + dtefechaInicial + " y " + dtefechaFinal + ".pdf";
            Document document = new Document(iTextSharp.text.PageSize.A4, 10, 10, 42, 35);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(Filename, FileMode.Create));
            document.Open();

            //Cargo la imagen desde el almacenamiento
            iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance(@"C:\datos\SATOM-MEX.png");
            PNG.ScaleToFit(100f, 100f);
            PNG.Border = iTextSharp.text.Rectangle.BOX;
            //PNG.BorderColor = iTextSharp.text.BaseColor.WHITE;
            //PNG.BorderWidth = 5f;
            document.Add(PNG);



            document.Add(new Chunk("SATOM-MEX", FontFactory.GetFont("Times New Roman", 15, iTextSharp.text.Font.BOLD)));

            document.Add(new Paragraph("Se muestran los siguientes datos dentro de la probabilidad de " + name + " del IMC de los clientes."));

            document.Add(new Paragraph("La media es " + txtMostrarMedia.Text));
            document.Add(new Paragraph("La desviación estándar es " + txtMostrarDesviacionEstandar.Text));
            document.Add(new Paragraph("El dato " + name + " introducido es " + datos));
            document.Add(new Paragraph("Donde X=" + lblMostrarX.Text));
            document.Add(new Paragraph("Su valor Z=" + lblMostrarCalculoX.Text));
            document.Add(new Paragraph("Su resultado es " + lblMostrarPorCien.Text));





            var chartImage = new MemoryStream();
            x.SaveImage(chartImage, ChartImageFormat.Png);
            iTextSharp.text.Image Chart_image = iTextSharp.text.Image.GetInstance(chartImage.GetBuffer());
            Chart_image.ScaleToFit(600f, 600f);
            document.Add(Chart_image);



            document.Close();

            MessageBox.Show("Reporte de probabilidad " + name + " creado correctamente!!");

        }

        private void btnGenerarPDF_Click_1(object sender, EventArgs e)
        {


            string FileName = "Reporte generado el " + dtefechaInicial + " a " + dtefechaFinal + " " + cmbE.SelectedItem.ToString() + ".pdf";


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
            Chunk datosMuestra = new Chunk("Datos de la población del cliente: " + txtDatosTotales.Text + " entre la fecha " + dtefechaInicial + " y " + dtefechaFinal + ".", FontFactory.GetFont("Times New Roman", 13, iTextSharp.text.Font.BOLD));
            document.Add(new Paragraph(Titulo));
            document.Add(new Paragraph(secundario));
            document.Add(new Paragraph(datosMuestra));
            document.Add(new Paragraph("Grado de confianza: " + cmbE.SelectedItem.ToString() + "."));
            document.Add(new Paragraph("Total de muestra: " + txtDatosMuestra.Text + "."));
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph("Se muestran los siguientes datos: "));





            //Agrego los datos del reporte
            //document.Add(new Paragraph("Reporte de " + dtefechaInicial + " al " + dtefechaFinal + ".", FontFactory.GetFont("Times New Roman", 12, iTextSharp.text.Font.ITALIC)));
            document.Add(new Paragraph("Tamaño de clases: " + txtMostrarNClases.Text, FontFactory.GetFont("Times New Roman", 12, iTextSharp.text.Font.ITALIC)));
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
            Chart_image.ScaleToFit(600f, 600f);
            document.Add(Chart_image);



            document.Close();

            MessageBox.Show("Reporte creado exitosamente!!");

        }

        private void frmEstadistica_Load_1(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }











    }


}
