using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace El_que_sea_1
{
    internal class aCCIONES
    {
        private List<Alumno> alumnoList = new List<Alumno>
        {
            new Alumno ("Cindy",20,"LADD",112816,DateTime.Today),
            new Alumno ("Rebeca",20,"LADD",112869,DateTime.Today),
            new Alumno ("Maya",19,"LADD",111111,DateTime.Today),
            new Alumno ("angela",20,"LADD",123456, DateTime.Today)
        };
        public List <Alumno> Mostrar()
        {
            return alumnoList;
        }
       

        public bool ExportaraExcel()
        {
            try
            {
                var rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var rutaArchivo = Path.Combine(rutaEscritorio, "Alumnos.xlsx");

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Alumnos");

                    // Encabezados
                    worksheet.Cell(1, 1).Value = "Nombre";
                    worksheet.Cell(1, 2).Value = "Edad";
                    worksheet.Cell(1, 3).Value = "Carrera";
                    worksheet.Cell(1, 4).Value = "Matricula";
                    worksheet.Cell(1, 5).Value = "Fecha de Nacimiento";

                    // Datos
                    for (int i = 0; i < alumnoList.Count; i++)
                    {
                        var alumno = alumnoList[i];
                        worksheet.Cell(i + 2, 1).Value = alumno.Nombre;
                        worksheet.Cell(i + 2, 2).Value = alumno.Edad;
                        worksheet.Cell(i + 2, 3).Value = alumno.Carrera;
                        worksheet.Cell(i + 2, 4).Value = alumno.Matricula;
                        worksheet.Cell(i + 2, 5).Value = alumno.Fechanacimiento.ToShortDateString();
                    }

                    workbook.SaveAs(rutaArchivo);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public bool ImportarArchivo()
        {
            try
            {
                var rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var rutaArchivo = Path.Combine(rutaEscritorio, "Alumnos.xlsx");

                if (!File.Exists(rutaArchivo))
                    return false;

                using (var workbook = new XLWorkbook(rutaArchivo))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Omitir encabezado

                    foreach (var row in rows)
                    {
                        string nombre = row.Cell(1).GetString();
                        int edad = row.Cell(2).GetValue<int>();
                        string grupo = row.Cell(3).GetString();
                        int matricula = row.Cell(4).GetValue<int>();
                        DateTime fechaIngreso = row.Cell(5).GetDateTime();

                        alumnoList.Add(new Alumno(nombre, edad, grupo, matricula, fechaIngreso));
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
