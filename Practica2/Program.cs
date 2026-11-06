int formato, opcion;
List <Pelicula> catalogo;

do
{
    Console.WriteLine("======================================");
    Console.WriteLine("        ¿Cómo quiere exportar?:       ");
    Console.WriteLine("======================================");
    Console.WriteLine("1. De CSV a XML.");
    Console.WriteLine("2. De XML a CSV.");
    Console.WriteLine("0. Salir.");
    Console.WriteLine();
   
    formato = leerInt("Elige una de las opciones del exportación.");
}while(formato != 0 && formato != 1 && formato != 2);

if(formato == 0)
{
    Console.WriteLine("Cerrando programa.");
    return;
}

//// PEDIR LAS 2 RUTAS////
Console.WriteLine();  
    //ORIGEN
string rutaOrigen = pedirRuta("Introduce la ruta del fichero de origen (completa con extensión)");

//Si el fichero no existe dara error
if (!ficheroExiste(rutaOrigen)) 
{
    Console.WriteLine();
    Console.WriteLine("Error: El fichero de origen no existe.");
    Console.WriteLine();
    return;
}
//Comprueba si el fichero tiene la extension correcta
if (!rutaOrigenValida(rutaOrigen, formato)) 
{
    Console.WriteLine();
    Console.WriteLine("Error: El fichero de guardado no tiene la extensión correcta.");
    Console.WriteLine();
    return;
}

Console.WriteLine();
string rutaGuardado = pedirRuta("Introduce la ruta donde quieres guardar el fichero (completa con extensión)");
Console.WriteLine();
if (!rutaGuardadoValida(rutaGuardado, formato)) //Si el fichero no tiene la extension correcta dara error
{
    Console.WriteLine();
    Console.WriteLine("Error: El fichero de guardado no tiene la extensión correcta.");
    Console.WriteLine();
    return;
}

Console.WriteLine("===================");
Console.WriteLine("        Menú:       ");
Console.WriteLine("===================");
Console.WriteLine("1. Exportar todo el documento");
Console.WriteLine("2. Exportar por género");
Console.WriteLine("3. Exportar por año");
Console.WriteLine("4. Exportar por lenguaje");
Console.WriteLine("0. SALIR");
Console.WriteLine();

opcion = leerInt("Elige una de las opciones del menú");


//CREAMOS UNA LISTA DE PELICULAS
if (formato == 1) //archivo a list: De CSV a XML
{
    catalogo = CsvManager.Leer(rutaOrigen);
}
else//De XML a CSV (a la fuerza va a ser 2)
{
    catalogo = XmlManager.Leer(rutaOrigen);
}

switch (opcion)
{
    case 1: //Exportar todo el doc
        guardar(rutaGuardado, formato, catalogo);
        break;

    case 2: //Por género
        catalogo = Filtros.filtradoPorGenero(catalogo);
        guardar(rutaGuardado, formato, catalogo);
        break;

    case 3: //Por año
        catalogo = Filtros.filtrarPorAño(catalogo);
        guardar(rutaGuardado, formato, catalogo);
        break;
                
    case 4: //por Lenguaje
        catalogo = Filtros.filtradoPorLenguaje(catalogo);
        guardar(rutaGuardado, formato, catalogo);
        break;

    case 0: //Salir
        Console.WriteLine("Cerrando la aplicación");
        break;

    default:
        Console.WriteLine("Error: no se eligio ninguna opciones del menú.");
        break;
}


////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////

//GUARDAR ARCHIVO
void guardar(String rutaGuardado, int formato, List <Pelicula> catalogo)
{
    if (formato == 1) //archivo a list: De CSV a XML
    {
        Console.WriteLine();
        Console.WriteLine("Guardando archivo...");
        XmlManager.Escribir(rutaGuardado, catalogo);
        Console.WriteLine();
        Console.WriteLine("Exportación de CSV a XML correcta.");
        Console.WriteLine();
    }
    else if (formato == 2)//De XML a CSV (a la fuerza va a ser 2)
    {
        Console.WriteLine();
        Console.WriteLine("Guardando archivo...");
        CsvManager.Escribir(rutaGuardado, catalogo);
        Console.WriteLine();
        Console.WriteLine("Exportación de XML a CSV correcta.");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("Error al guardar el archivo.");
        
    }
}

//PEDIR INT POR CONSOLA
int leerInt(String msg)
{
    String respuesta;
    int opt=0;
    bool error = true;
    do
    {
        Console.WriteLine(msg);
        respuesta = Console.ReadLine();
        try
            {
                opt = int.Parse(respuesta);
                error = false;
            }
            catch
            {
                Console.WriteLine(" ");
                Console.WriteLine("ERROR: Introduce un número");
            }
    }while(error);

    return opt;
}

//COMPROBAR SI EL FICHERO EXISTE
bool ficheroExiste (String ruta)
{
    if (!File.Exists(ruta))
    {
        return false;
    }
    return true;
}


string pedirRuta(String texto)
{
    Console.WriteLine(texto);
    return Console.ReadLine();
}

//COMPROBAR SI LA RUTA DE ORIGEN TIENE LA EXTENSIÓN CORRECTA
bool rutaOrigenValida(string rutaGuardado, int formato)
{
    string[] rutaPorPartes = rutaGuardado.Split(".");
    string ext = rutaPorPartes[rutaPorPartes.Length-1];

    if(formato == 1 && ext == "csv")
    {
        return true;
    }else if(formato == 2 && ext =="xml")
    {
        return true;
    }
    else
    {
        return false;
    }
}

//COMPROBAR SI LA RUTA DE GUARDADO TIENE LA EXTENSIÓN CORRECTA
bool rutaGuardadoValida(string rutaOrigen, int formato)
{
    string[] rutaPorPartes = rutaOrigen.Split(".");
    string ext = rutaPorPartes[rutaPorPartes.Length-1];

    if(formato == 1 && ext =="xml")
    {
        return true;
    }else if (formato == 2 && ext == "csv")
    {
        return true;
    }
    else
    {
        return false;
    }
}

