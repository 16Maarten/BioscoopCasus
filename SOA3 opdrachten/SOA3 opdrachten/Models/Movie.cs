namespace SOA3_opdrachten.Models;

public class Movie
{
    public string title { get; private set; }
    public List<MovieScreening> movieScreenings { get; } = new List<MovieScreening>();

    public Movie(string title)
    {
        this.title = title;
    }

    //public void AddScreening(MovieScreening screening) => throw new NotImplementedException();

    public override string ToString()
    {
        return string.Empty;
    }
}
