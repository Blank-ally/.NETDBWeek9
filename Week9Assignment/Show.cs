public class Show : Media
{
    private string Type = "Show";

 

    public Show(string id, string title, string season, string episode, string[] writer)
    {
        ID = id;
        Title = title;
        Season = season;
        Episode = episode;
        Writer = writer;


    }

    public string ID { get; set; }
    public string Title { get; set; }

   
    public string Season { get; set; }
    public string Episode { get; set; }
    public string[] Writer { get; set; }

    public override string GetType()
    {
        return Type;
    }

    public override string ToString()
    {
        return $"\nType: {Type}\nID: {ID}\nTitle: {Title}\nSeason: {Season}\nEpisode: {Episode}\nWriters: {string.Join(',', Writer)}";
    }

}