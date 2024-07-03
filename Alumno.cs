using System;

public class Alumno
{
    public int Indice { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string DNI { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Domicilio { get; set; }
    public bool EstaActivo { get; set; }

    public override string ToString()
    {
        return $"{Indice},{Nombre},{Apellido},{DNI},{FechaNacimiento:yyyy-MM-dd},{Domicilio},{EstaActivo};";
    }

    public static Alumno FromString(string serializedData)
    {
        string[] data = serializedData.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        return new Alumno
        {
            Indice = int.Parse(data[0]),
            Nombre = data[1],
            Apellido = data[2],
            DNI = data[3],
            FechaNacimiento = DateTime.Parse(data[4]),
            Domicilio = data[5],
            EstaActivo = bool.Parse(data[6])
        };
    }
}
