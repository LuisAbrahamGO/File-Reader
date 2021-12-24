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

namespace Lector_de_archivos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool ValidaLayoutTXT(string ArchivoTXT)
        {
            bool validacion = false;

            if (File.Exists(ArchivoTXT))
            {
                StreamReader reader = new StreamReader(ArchivoTXT);

                string linea1;
                string[] datosLineas;

                
                while ((linea1 = reader.ReadLine()) != null)
                {
                    datosLineas = linea1.Split('=');

                
                }
                //string Emisor_RFC = "";

                /*if (datosLinea1[0].Trim() == "COMPROBANTE")
                {
                    Emisor_RFC = datosLinea2[1].Trim();

                    validacion = ValidaEmisor(Emisor_RFC);
                }*/

                reader.Close();
                return validacion;
            }
            else
            {
                return validacion;
            }
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
                if (validacion)
                {
                    MessageBox.Show("Layout y emisor validos");

                    //CrearComprobanteTXT(archivoTXT);
                }
                else
                {
                    MessageBox.Show("Layout o emisor invalidos");
                }
            }
        }


    }

    public class Factura {

        string serie;
        string folio;

        public Factura() { 
            
        }

        

    }
}
