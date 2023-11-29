using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ExportRepository
    {
        string ruta = "Transacciones.txt";

        //public void Guardar(Docente docente)
        //{
        //    FileStream file = new FileStream(ruta, FileMode.Append);
        //    StreamWriter escritor = new StreamWriter(file);
        //    escritor.WriteLine(docente.Escribir());
        //    escritor.Close();
        //    file.Close();
        //}

        //public List<Docente> Consultar()
        //{
        //    List<Docente> docente = new List<Docente>();
        //    FileStream file = new FileStream(ruta, FileMode.OpenOrCreate);
        //    StreamReader lector = new StreamReader(file);
        //    string linea = "";
        //    while ((linea = lector.ReadLine()) != null)
        //    {
        //        Docente docentes = MapearDocente(linea);
        //        docente.Add(docentes);
        //    }
        //    lector.Close();
        //    file.Close();
        //    return docente;
        //}


        //private static Docente MapearDocente(string linea)
        //{
        //    string[] datosDocente = linea.Split(';');
        //    Salario salario = new Salario();
        //    Docente docente = new Docente();
        //    docente.Id = int.Parse(datosDocente[0]);
        //    docente.Nombre = datosDocente[1];
        //    salario.IdSalario = datosDocente[2];
        //    docente.AreaDeDesempeño = datosDocente[3];
        //    docente.AreaDeInvestigacion = datosDocente[4];
        //    docente.Categoria = datosDocente[5];
        //    docente.TotalNomina = double.Parse(datosDocente[6]);
        //    docente.Salario = salario;
        //    return docente;
        //}
    }
}
