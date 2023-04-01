using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading.Channels;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
public class FileService : AbstractFileServices
{
    private readonly Validate check = new();
    //TO DO
    //Convert Data to read json data 
    //Make search  method 
    //fix validation class

    private string file = "Media.json";


    private Media media;
    private Movie movie;
    private Show show;
    private Video video;
    private Validate validate = new Validate();

    private List<Media> mediaList = new();
    private List<Movie> movieList = new();
    private List<Show> showList = new();
    private List<Video> videoList = new();


    public FileService()
    {
        string[] mediaFiles = { "movies.csv", "shows.csv", "videos.csv" };

        for (var i = 0; i < mediaFiles.Length; i++)

            if (File.Exists(mediaFiles[i]))
            {
                var sr = new StreamReader(mediaFiles[i]);
                try
                {
                    sr.ReadLine();


                    while (!sr.EndOfStream)
                    {
                        var line = "";

                        if (mediaFiles[i] == "movies.csv")
                        {
                            
                            line = sr.ReadLine();
                            var des = validate.validateMovie(line);
                            mediaList.Add(des);
                            movieList.Add(des);

                        }
                        else if (mediaFiles[i] == "shows.csv")
                        {
                            line = sr.ReadLine();
                            var des = validate.validateShow(line);
                            line = sr.ReadLine();
                            mediaList.Add(des);
                            showList.Add(des);
                        }
                        else if (mediaFiles[i] == "videos.csv")

                        {
                            line = sr.ReadLine();
                            var des = validate.validateVideo(line);
                            line = sr.ReadLine();
                            mediaList.Add(des);
                            videoList.Add(des);
                        }
                    }
                }

                catch (Exception ex)
                {
                }
                finally
                {
                    sr.Close();
                }

                var sw = new StreamWriter(file, true);
                foreach (Media media in mediaList)
                {
                   

                    sw.WriteLine(JsonConvert.SerializeObject(media));
                }

                sw.Close();
            }
    }


    public override void Read()

    {
        Console.WriteLine("*** I am reading");

        if (File.Exists(file))
        {
            var sr = new StreamReader(file);
            try
            {
               


                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    media = JsonConvert.DeserializeObject<Media>(line);

                    mediaList.Add(media);
                }
            }

            catch (Exception ex)
            {
            }
            finally
            {
                sr.Close();
            }

            for (var i = 0; i < mediaList.Count; i++)
            {
                Console.WriteLine(mediaList[i]);
              
            }
        }
    }


    public override void Write()
    {
        var sw = new StreamWriter(file, true);

        Console.WriteLine("What kind of Media would you like to make \n1.Movie\n2.Show\n3.Video");
        var mediaType = Console.ReadLine();

        switch (mediaType)
        {
            case "1":

               // Console.WriteLine("Movie Id");
                var id = Convert.ToString(movieList.Count + 1);


                Console.WriteLine("Title");
                var title = Console.ReadLine();

                Console.WriteLine("how many genres");
                var genre = Convert.ToInt32(Console.ReadLine());

                // a string array with the size of watchers variable i can add to in my loop 
                var genres = new string[genre];
                // for loop to store the names the user enters followed by a pipe so i don't have to edit the way the file reads 
                for (var i = 0; i < genre; i++)
                {
                    Console.WriteLine("what's the genre");
                    genres[i] = Console.ReadLine();
                }


                Movie movie = new Movie(id, title, genres);
                sw.WriteLine(JsonConvert.SerializeObject(movie));
                mediaList.Add(movie);
                movieList.Add(movie);
                sw.Close();

                break;
            case "2":
                //Console.WriteLine("Show Id");
                id = Convert.ToString(showList.Count + 1); ;

                Console.WriteLine("Title");
                title = Console.ReadLine();

                Console.WriteLine("Season");
                var season = Console.ReadLine();

                Console.WriteLine("Episode");
                var episode = Console.ReadLine();

                Console.WriteLine("how many writers");
                var writer = Convert.ToInt32(Console.ReadLine());

                // a string array with the size of watchers variable i can add to in my loop 
                var writers = new string[writer];
                // for loop to store the names the user enters followed by a pipe so i don't have to edit the way the file reads 
                for (var i = 0; i < writer; i++)
                {
                    Console.WriteLine("who is the writer");
                    writers[i] = Console.ReadLine();
                }


                Show show = new Show(id, title,season,episode,writers);

                sw.WriteLine(JsonConvert.SerializeObject(show));
                mediaList.Add(show);
                showList.Add(show);
                sw.Close();

                break;
            case "3":
               // Console.WriteLine("Video Id");
                id = Convert.ToString(videoList.Count + 1);

                Console.WriteLine("Title");
                title = Console.ReadLine();

                Console.WriteLine("How many formats");
                var format = Convert.ToInt32(Console.ReadLine());
                


                var formats = new string[format];

                for (var i = 0; i < format; i++)
                {
                    Console.WriteLine("what's the format");
                    formats[i] = Console.ReadLine();
                }

                Console.WriteLine("Length");
                var length = Console.ReadLine();

                Console.WriteLine("How many regions");
                var region = Convert.ToInt32(Console.ReadLine());


                var regions = new string[region];

                for (var i = 0; i < region; i++)
                {
                    Console.WriteLine("what's the region");
                    regions[i] = Console.ReadLine();
                }


                Video video = new Video(id, title, formats,length,regions);

                sw.WriteLine(JsonConvert.SerializeObject(video));
                mediaList.Add(video);
                videoList.Add(video);
                sw.Close();

                break;
            default:
                Console.WriteLine("Sorry your input was not valid only 1-3 Is valid input");
                sw.Close();
                break;
        }
    }

    public void Search()
    {
        Console.WriteLine("What Media are you looking for?");
        var search = Console.ReadLine();

      var movies = movieList.Where(m => m.Title.Contains(search, StringComparison.CurrentCultureIgnoreCase)).ToList();
     // movies.ForEach(m => Console.WriteLine(m.Title));
        var shows = showList.Where(m => m.Title.Contains(search, StringComparison.CurrentCultureIgnoreCase)).ToList();
     //   shows.ForEach(m => Console.WriteLine(m.Title));
        var videos = videoList.Where(m => m.Title.Contains(search, StringComparison.CurrentCultureIgnoreCase)).ToList();
      //  videos.ForEach(m => Console.WriteLine(m.Title));



        List<Media> results = new List<Media>(); 
        
       results.AddRange(movies);
      results.AddRange(shows);
       results.AddRange(videos);
       if (results.Count > 0)
       {
           results.ForEach(m => Console.WriteLine($"Your Media: {m}"));
       }
       else
       {
           Console.WriteLine("Sorry we could not find a match to your search");
       }
        //results.ForEach(m => Console.WriteLine($"Your Media: {m.Title}"));
    }
}