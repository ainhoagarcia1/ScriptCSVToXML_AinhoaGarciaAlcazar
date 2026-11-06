using System.Text;
using System.Text.RegularExpressions;

static public class CsvManager
{
    public static List<Pelicula> Leer(string ruta){
        List<Pelicula> catalogo = new List<Pelicula>();

        string[] lines = File.ReadAllLines(ruta);
        Regex csvParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
        
        for(int i=1; i < lines.Length; i++)
        {
            string[] peli = csvParser.Split(lines[i]);
            Pelicula p = new Pelicula(peli[0], peli[1], peli[2].Trim('"'), peli[3], peli[4], peli[5]);
            catalogo.Add(p);
        }
        return catalogo;
    }

    public static void Escribir(string ruta, List<Pelicula> catalogo)
    {   
        
        string linea;
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Title, Genre, Premiere, Runtime, IMBD Score, Language"); //CABECERAS
        foreach (Pelicula p in catalogo)
        {
            linea = p.Title + "," + p.Genre + "," + p.Premiere + "," + p.Runtime + "," + p.ImdbScore + "," + p.Language;
            sb.AppendLine(linea);
        }
        File.WriteAllText(ruta, sb.ToString());

    }
}

