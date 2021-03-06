using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lector_de_archivos
{
    public partial class Form1 : Form
    {
        List<Factura> list;
        OdbcConnection odbcConnection;
        OdbcCommand command;
        OdbcDataAdapter dataAdapter;

        public Form1()
        {
            InitializeComponent();
            list = new List<Factura>();
        }

        private bool ValidaLayoutTXT(string ArchivoTXT)
        {
            bool validacion = false;

            if (File.Exists(ArchivoTXT))
            {
                StreamReader reader = new StreamReader(ArchivoTXT);

                string linea1;
                string[] datosLinea;
                
                Factura factura = new Factura(); ;
                
                while ((linea1 = reader.ReadLine()) != null)
                {
                    
                    datosLinea = linea1.Split('=');

                    if (datosLinea[0].Equals("serie")) {
                        factura.serie = datosLinea[1];
                    }

                    if (datosLinea[0].Equals("folio"))
                    {
                        factura.folio = datosLinea[1];
                    }

                }

                this.list.Add(factura);

                reader.Close();
                return validacion;
            }
            else
            {
                return validacion;
            }
        }

        private void ConnectToDataBase()
        {
            try
            {
                string sConn = "Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + this.txtDBPathBox.Text + ";Exclusive=No;";
                //string sConn = "Driver={Microsoft dBase Driver (*.dbf)};datasource=" + this.txtDBPathBox.Text + ";";

                this.odbcConnection = new OdbcConnection(sConn);
                this.odbcConnection.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CheckInvoice()
        {
            int iterador = -1;
            foreach (Factura fact in this.list) {
                iterador++;
                try
                {
                    this.command = new OdbcCommand("SELECT foliocfdi.foliouuid FROM foliocfdi WHERE serie = '" + fact.serie + "' AND folio = " + fact.folio, this.odbcConnection);
                    this.dataAdapter = new OdbcDataAdapter(this.command);

                    DataTable dataTable = new DataTable();

                    this.dataAdapter.Fill(dataTable);

                    if(dataTable.Rows.Count == 1)
                    {
                        this.list[iterador].uuid = dataTable.Rows[0]["foliouuid"].ToString();
                        this.command = new OdbcCommand("DELETE FROM foliocfdi WHERE serie = '" + fact.serie + "' AND folio = " + fact.folio, this.odbcConnection);
                        this.command.ExecuteNonQuery();
                    }
                    else
                    {
                        this.list[iterador].uuid = "NOT FOUND";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            MessageBox.Show("Consultados");

            using (StreamWriter file = new StreamWriter(@"C:\IMPERIAL\DatosFacturas.txt"))
            {
                foreach (Factura fact in list)
                {
                    string data = fact.serie + "," + fact.folio + "," + fact.uuid;

                    file.WriteLine(data);
                }
            }

            MessageBox.Show("Exportados");
        }

        private void Btnstart_Click(object sender, EventArgs e)
        {
            string path = txtPathBox.Text;

            //Carga la lista de archivos txt
            string[] archivosTXT = Directory.GetFiles(path, "*.txt");

            //Procedure para cada archivo encontrado
            foreach (string archivoTXT in archivosTXT)
            {
                bool validacion = false;
                validacion = ValidaLayoutTXT(archivoTXT);
                
            }

            CheckInvoice();
        }

        private void DBConnectionBtn_Click(object sender, EventArgs e)
        {
            ConnectToDataBase();
        }
    }

    public class Factura {

        public string serie { set; get; }
        public string folio { set; get; }
        public string uuid { set; get; }

        public Factura() { 
            
        }


    }
}
