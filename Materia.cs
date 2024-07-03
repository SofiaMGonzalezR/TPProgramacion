using System;

public class Materia
{
    public int Indice { get; set; }
    public string NombreMateria { get; set; }
    public bool EstaActiva { get; set; }

    public override string ToString()
    {
        return $"{Indice},{NombreMateria},{EstaActiva};";
    }

    public static Materia FromString(string serializedData)
    {
        string[] data = serializedData.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        return new Materia
        {
            Indice = int.Parse(data[0]),
            NombreMateria = data[1],
            EstaActiva = bool.Parse(data[2])
        };
    }
}
