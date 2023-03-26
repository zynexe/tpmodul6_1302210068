using System;

class SayaTubeVideo
{
    private int id;
    private string title;
    public int playCount;

    public SayaTubeVideo(string title)
    {
        if (title == null)
            throw new ArgumentNullException("Title cannot be null.");

        if (title.Length > 100)
            throw new ArgumentException("Title length cannot be more than 100 characters.");

        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count <= 0)
            throw new ArgumentOutOfRangeException("Count must be a positive integer.");

        checked
        {
            try
            {
                this.playCount += count;
            }
            catch (OverflowException ex)
            {
                throw new InvalidOperationException("Play count exceeded the maximum limit.", ex);
            }
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Video ID: {0}", this.id);
        Console.WriteLine("Title: {0}", this.title);
        Console.WriteLine("Play Count: {0}", this.playCount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        string videoTitle = "Tutorial Design By Contract – Raffa Zuhayr";
        SayaTubeVideo video = null;

        try
        {
            video = new SayaTubeVideo(videoTitle);

            // Tes preconditions
            //videoTitle = null; // ngetes title precondition
            //videoTitle = new string('a', 101); // nge test title length precondition

            video.PrintVideoDetails();

            // Tes exception
            for (int i = 0; i < 10000001; i++) // nge test overflow exception
            {
                 video.IncreasePlayCount(1);
            }

            
            video.IncreasePlayCount(100);

            Console.WriteLine("\n play count baru adalah {0}", video.playCount);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
