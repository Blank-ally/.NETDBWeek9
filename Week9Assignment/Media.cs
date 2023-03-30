public abstract class Media
{
    public string ID { get; set; }
    public string Title { get; set; }
    public abstract string GetType();
}