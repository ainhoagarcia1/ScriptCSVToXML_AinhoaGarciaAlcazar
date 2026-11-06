public class Filtros
{
   // private List<Pelicula> catalogoFiltrado = new List<Pelicula>();


    public static List<Pelicula> filtradoPorGenero (List<Pelicula> catalogo)
    {
        List<Pelicula> catalogoFiltrado = new List<Pelicula>();
        List<string> generos = new List<string>();

        //Buscar los géneros del catálogo
        foreach(Pelicula peli in catalogo)
        {
            if (!generos.Contains(peli.Genre))
            {
                generos.Add(peli.Genre);
            }
        }

        //Mostrar los géneros del catálogo
        Console.WriteLine("Estos son los generos disponibles:");
        foreach(string gen in generos)
        {
            Console.WriteLine(gen);
        }
        Console.WriteLine();

        //Pedir genero para filtrado
        string generoSeleccionado;
        do
        {
            Console.WriteLine();
            Console.WriteLine("Elige uno de los generos mostrados:");
            generoSeleccionado = Console.ReadLine();
        }while(!generos.Contains(generoSeleccionado));
        
        //Añadir las películas que cumplen la condición
        foreach(Pelicula p in catalogo)
        {
            if (p.Genre == generoSeleccionado)
            {
                catalogoFiltrado.Add(p);
            }
        }
        return catalogoFiltrado;
    }

    public static List<Pelicula> filtradoPorLenguaje(List<Pelicula> catalogo)
     {
        List<Pelicula> catalogoFiltrado = new List<Pelicula>();
        List<string> lenguajes = new List<string>();

        //Buscar los idiomas del catálogo
        foreach(Pelicula peli in catalogo)
        {
            if (!lenguajes.Contains(peli.Language))
            {
                lenguajes.Add(peli.Language);
            }
        }

        //Mostrar los idiomas del catálogo
        Console.WriteLine("Estos son los generos disponibles:");
        foreach(string lan in lenguajes)
        {
            Console.WriteLine(lan);
        }
        Console.WriteLine();

        //Selección de lenguaje
        string lenguajeSeleccionado;
        do
        {
            Console.WriteLine();
            Console.WriteLine("Elige uno de los lenguajes mostrados:");
            lenguajeSeleccionado = Console.ReadLine();
        }while(!lenguajes.Contains(lenguajeSeleccionado));

        //Añadir las películas que cumplen la condición
        foreach(Pelicula p in catalogo)
        {
            if (p.Language == lenguajeSeleccionado)
            {
                catalogoFiltrado.Add(p);
            }
        }
        return catalogoFiltrado;
    }

    
    public static List<Pelicula> filtrarPorAño(List<Pelicula> catalogo)
     {
        List<Pelicula> catalogoFiltrado = new List<Pelicula>();
        int añoSeleccionado = 0;      

        //Selección año filtrado
        bool error = true;
        do
        {
            Console.WriteLine();
            Console.WriteLine("Desde que año quieres filtrar las peliculas:");
            try
            {
                añoSeleccionado = int.Parse(Console.ReadLine());
                error = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Introduce un número");                
            }
        }while(error);

        //Añadir las películas que cumplen la condición
        int año;
        foreach(Pelicula p in catalogo)
        {
            año = añoPelicula(p.Premiere);
            if (año >= añoSeleccionado)
            {
                catalogoFiltrado.Add(p);
            }
        }
        return catalogoFiltrado;
    }


    //Devuelve solo el año de la fecha de estreno
    static int añoPelicula(String fechaCompleta)
    {
        string[] fechaPorPartes = fechaCompleta.Split(" ");
        int año;
        try
        {
            año = int.Parse(fechaPorPartes[fechaPorPartes.Length - 1]);
        }
        catch
        {
            año=0;
        }
        return año;
    }
}