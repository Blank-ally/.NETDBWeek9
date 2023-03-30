public class Video : Media
{
    private string Type = "Video";
    public Video(string id, string title, string [] formats, string length, string[] regions)
    {
        ID = id;
        Title = title;
        Formats = formats;
        Length = length;
        Regions = regions;


    }

    public string ID { get; set; }
    public string Title { get; set; }
    public string[] Formats { get; set; }
    public string Length { get; set; }
    public string[] Regions { get; set; }
    public override string GetType()
    {
        return Type;
    }
    public override string ToString()
    {
        return $"\nType: {Type}\nID: {ID}\nTitle: {Title}\nFormat: {string.Join(',',Formats)}\nLength: {Length}\nRegions: {string.Join(',', Regions)}";

    }
}