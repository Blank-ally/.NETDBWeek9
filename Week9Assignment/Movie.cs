public class Movie : Media
{  string Type = "Movie";
    public Movie(string id,string title, string[] genres)
    {
        ID = id;
        Title =  title;
        Genres = genres;
     
      
    }

  
    public string ID { get; set; }
    public string Title { get; set; }
    public string[] Genres { get; set; }
    public override string GetType()
    {
        return Type;
    }

    public override string ToString()
    {
        return $"\nType: {Type}\nID: {ID}\nTitle: {Title}\nGenres: {string.Join(',', Genres)}";
    }
}