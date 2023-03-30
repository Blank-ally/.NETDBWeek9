 internal class Validate
 {

     List<Int64> IDs = new List<Int64>();
     List<string> Titles = new List<string>();


     private string id;
     private string title;
     private string genre;
     string format;
     string length;
     string region;
     private string season;
     private string episode;
     private string writer;

    private string[] genres;
     private string[] writers;
     private string[] regions;
     private string[] formats;


    public Movie validateMovie(string line)
        {
         

            var ind = line.IndexOf('"');
            if (ind == -1)
            {
                var movie = line.Split(',');

                id = movie[0]; 
                title = movie[1]; 
                genre = movie[2].Replace("|", ", ");
                genres = genre.Split(",");
        }
            else
            {
                 id = line.Substring(0, ind - 1);

                line = line.Substring(ind + 1);
                ind = line.IndexOf('"');

                title = line.Substring(0, ind);
                line = line.Substring(ind + 2);
                
                Console.WriteLine(line);

                genre = line.Replace("|", ", ");
                genres = genre.Split(",");

               
            }
            IDs.Add(Int64.Parse(id));
            Titles.Add(title);
          
           

            return new Movie(id, title, genres) ;
        }
    public Show validateShow(string line)
    {


        var ind = line.IndexOf('"');

        if (ind == -1)
        {
            var show = line.Split(',');

            id = show[0];
            title = show[1];
            season = show[2];
            episode = show[3];
            writer = show[4].Replace("|", ", ");
            writers = writer.Split(",");

        }
        else
        {
            id = line.Substring(0, ind - 1);

            line = line.Substring(ind + 1);

            ind = line.IndexOf('"');

            title = line.Substring(0, ind);

            line = line.Substring(ind + 2);
            season = "";
            episode = "";
            writer = line.Replace("|", ", ");
           writers = writer.Split(",");


        }
        IDs.Add(Int64.Parse(id));
        Titles.Add(title);



        return new Show(id, title, season, episode, writers);
    }
    public Video validateVideo(string line)
    {
   


        var ind = line.IndexOf('"');

        if (ind == -1)
        {
            var video = line.Split(',');

            id = video[0];
            title = video[1];
            format = video[2].Replace("|", ", ");
            formats = format.Split(',');
            length = video[3];
            region = video[4].Replace("|", ", ");
            regions = region.Split(",");

        }
        else
        {
            id = line.Substring(0, ind - 1);

            line = line.Substring(ind + 1);

            ind = line.IndexOf('"');

            title = line.Substring(0, ind);

            line = line.Substring(ind + 2);
            format = line.Replace("|", ", "); 
            formats = format.Split(",");
            length = " ";
            region = line.Replace("|", ", ");
            regions = region.Split(",");


        }
        
        return new Video(id, title, formats, length, regions);
    }

   


       
    }

  