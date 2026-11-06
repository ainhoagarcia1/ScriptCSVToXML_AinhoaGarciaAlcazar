using System.Xml;
static public class XmlManager
{
    public static List<Pelicula> Leer(string ruta){

        List<Pelicula> catalogo = new List<Pelicula>();

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(ruta);
        foreach(XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes) //por cada pélicula
        {
            Pelicula p = new Pelicula(xmlNode.ChildNodes[0].InnerText, xmlNode.ChildNodes[1].InnerText, xmlNode.ChildNodes[2].InnerText, xmlNode.ChildNodes[3].InnerText, xmlNode.ChildNodes[4].InnerText, xmlNode.ChildNodes[5].InnerText);
            catalogo.Add(p);
        } 
        return catalogo;
    }

    public static void Escribir(string ruta, List<Pelicula> catalogo)
    {
        XmlWriter xmlWriter = XmlWriter.Create(ruta);
        
        xmlWriter.WriteStartDocument();
        xmlWriter.WriteStartElement("peliculas");

        foreach (Pelicula p in catalogo)
        {
            xmlWriter.WriteStartElement("pelicula");

            xmlWriter.WriteStartElement("title");
            xmlWriter.WriteString(p.Title);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Genre");
            xmlWriter.WriteString(p.Genre);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Premiere");
            xmlWriter.WriteString(p.Premiere);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Runtime");
            xmlWriter.WriteString(p.Runtime);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("IMDBScore");
            xmlWriter.WriteString(p.ImdbScore);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Language");
            xmlWriter.WriteString(p.Language);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndElement();
        }
        xmlWriter.WriteEndDocument();
        xmlWriter.Close();
    }
}