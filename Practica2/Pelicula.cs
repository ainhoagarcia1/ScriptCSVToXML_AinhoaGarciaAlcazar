public class Pelicula
{
    public string Title; 
    public string Genre; 
    public string Premiere;
    public string Runtime; 
    public string ImdbScore;
    public string Language;

    //Constructor:
    public Pelicula(string title, string genre, string premiere, string runtime, string imdbScore, string language)
    {
        Title = title;
        Genre = genre;
        Premiere = premiere;
        Runtime = runtime;
        ImdbScore = imdbScore;
        Language = language;
    }
}

    