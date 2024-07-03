using System;

public class AlumnoMateria
{
    public int Indice { get; set; }
    public int IndiceAlumno { get; set; }
    public int IndiceMateria { get; set; }
    public string Estado { get; set; }
    public double Nota { get; set; }
    public DateTime Fecha { get; set; }

    public override string ToString()
    {
        return $"{Indice},{IndiceAlumno},{IndiceMateria},{Estado},{Nota},{Fecha:yyyy-MM-dd};";
    }

    public static AlumnoMateria FromString(string serializedData)
    {
        string[] data = serializedData.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        return new AlumnoMateria
        {
            Indice = int.Parse(data[0]),
            IndiceAlumno = int.Parse(data[1]),
            IndiceMateria = int.Parse(data[2]),
            Estado = data[3],
            Nota = double.Parse(data[4]),
            Fecha = DateTime.Parse(data[5])
        };
    }
}
