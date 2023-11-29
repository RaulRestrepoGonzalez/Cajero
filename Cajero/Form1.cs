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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ClosedXML.Excel;

namespace Cajero
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtValor.Text = "50000";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtValor.Text = "100000";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtValor.Text = "200000";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtValor.Text = "300000";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtValor.Text = "500000";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtValor.Text = "1000000";
        }

        private List<string> transacciones = new List<string>();
        int[] billetes = { 0, 0, 0, 0 };
        //public int cantidad;
        public void Cantidad(int cantidad)
        {
            //int[] billetes = { 0, 0, 0, 0 };
            int[] contadoresBilletes = {1, 1, 1, 1};
            int contador = 1;

            do
            {
                // Verificar si hay suficiente cantidad para un billete de 10,000 y si el contador de billetes está activo
                if (cantidad - 10000 >= 0 && contadoresBilletes[0] == 1)
                {
                    cantidad = cantidad - 10000;
                    billetes[0] = billetes[0] + 1;
                }

                // Verificar si hay suficiente cantidad para un billete de 20,000 y si el contador de billetes está activo
                if (cantidad - 20000 >= 0 && contadoresBilletes[1] == 1)
                {
                    cantidad = cantidad - 20000;
                    billetes[1] = billetes[1] + 1;
                }

                // Verificar si hay suficiente cantidad para un billete de 50,000 y si el contador de billetes está activo
                if (cantidad - 50000 >= 0 && contadoresBilletes[2] == 1)
                {
                    cantidad = cantidad - 50000;
                    billetes[2] = billetes[2] + 1;
                }

                // Verificar si hay suficiente cantidad para un billete de 100,000 y si el contador de billetes está activo
                if (cantidad - 100000 >= 0 && contadoresBilletes[3] == 1)
                {
                    cantidad = cantidad - 100000;
                    billetes[3] = billetes[3] + 1;
                }

                // Actualizar los contadores de billetes y el contador principal
                if (contador == 1)
                {
                    contador = contador + 1;
                    contadoresBilletes = new int[] { 0, 1, 1, 1}; // 10k, 20k, 50k, 100k
                }
                else if (contador == 2)
                {
                    contador = contador + 1;
                    contadoresBilletes = new int[] { 0, 0, 1, 1 }; // 10k, 20k, 50k, 100k
                }
                else if (contador == 3)
                {
                    contador = contador + 1;
                    contadoresBilletes = new int[] { 0, 0, 0, 1 }; // 10k, 20k, 50k, 100k
                }
                else if (contador == 4)
                {
                    contador = 1;
                    contadoresBilletes = new int[] { 1, 1, 1, 1 }; // 10k, 20k, 50k, 100k
                }
                else
                {
                    Console.WriteLine("\nHa ocurrido un error:");
                    break;
                }
            } while (cantidad != 0);

            label100.Text = billetes[3].ToString();
            label50.Text = billetes[2].ToString();
            label20.Text = billetes[1].ToString();
            label10.Text = billetes[0].ToString();

            transacciones.Add($"Retiro de {contadoresBilletes} pesos - 10k: {billetes[0]} - 20k: {billetes[1]} - 50k: {billetes[2]} - 100k: {billetes[3]}");
        }

        private void ExportarTransacciones(int cantidad)
        {
            // Obtener la fecha actual
            DateTime fechaActual = DateTime.Now;

            // Obtener la ruta del escritorio del usuario
            string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Crear el nombre del archivo basado en la fecha actual
            string nombreArchivo = $"Transacciones_{fechaActual.ToString("yyyyMMdd")}.xlsx";

            // Crear la ruta completa del archivo
            string rutaCompleta = Path.Combine(rutaEscritorio, nombreArchivo);

            // Verificar si el archivo ya existe para la fecha actual
            bool archivoExiste = File.Exists(rutaCompleta);

            // Crear un nuevo libro de Excel o abrir el existente
            var workbook = archivoExiste ? new XLWorkbook(rutaCompleta) : new XLWorkbook();

            // Obtener o crear la hoja de cálculo
            var worksheet = archivoExiste ? workbook.Worksheet(1) : workbook.Worksheets.Add("Transacciones");

            // Si el archivo no existía, agregar encabezados
            if (!archivoExiste)
            {
                worksheet.Cell(1, 1).Value = "Fecha y Hora";
                worksheet.Cell(1, 2).Value = "Cantidad Retirada";
                worksheet.Cell(1, 3).Value = "Billetes de 10k";
                worksheet.Cell(1, 4).Value = "Billetes de 20k";
                worksheet.Cell(1, 5).Value = "Billetes de 50k";
                worksheet.Cell(1, 6).Value = "Billetes de 100k";
            }

            // Obtener la última fila utilizada
            int ultimaFila = worksheet.LastRowUsed()?.RowNumber() ?? 1;

            // Agregar la nueva transacción
            worksheet.Cell(ultimaFila + 1, 1).Value = fechaActual.ToString("yyyy-MM-dd HH:mm:ss");
            worksheet.Cell(ultimaFila + 1, 2).Value = cantidad;
            worksheet.Cell(ultimaFila + 1, 3).Value = billetes[0];
            worksheet.Cell(ultimaFila + 1, 4).Value = billetes[1];
            worksheet.Cell(ultimaFila + 1, 5).Value = billetes[2];
            worksheet.Cell(ultimaFila + 1, 6).Value = billetes[3];

            // Guardar el libro de Excel
            workbook.SaveAs(rutaCompleta);

            // Mostrar un mensaje de éxito
            MessageBox.Show($"Transacción registrada en: {rutaCompleta}");
        }


        private void button8_Click(object sender, EventArgs e)
        {

            // Verificar si la cantidad ingresada no es un número válido o es mayor a 1,000,000
            if (!int.TryParse(txtValor.Text , out int cantidad) || cantidad > 1000000)
            {
                MessageBox.Show("Por favor ingrese un número válido.");
                return;
            }

            // Verificar si la cantidad no es múltiplo de 10,000
            if (cantidad % 10000 != 0)
            {
                MessageBox.Show("La cantidad debe ser múltiplo de 10,000.");
            }
            else
            {
                // Mostrar un mensaje de retiro exitoso
                MessageBox.Show("Retirando " + cantidad + " pesos.");

                
                // Calcular las cantidades de billetes
                Cantidad(cantidad);
                ExportarTransacciones(cantidad);
            } 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtValor.Text = "";
            label10.Text = "0";
            label20.Text = "0";
            label50.Text = "0";
            label100.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
        }
    }
}
