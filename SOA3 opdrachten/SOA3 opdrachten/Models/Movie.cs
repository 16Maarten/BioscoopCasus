using Microsoft.VisualBasic;
using System.Text;

namespace SOA3_opdrachten.Models;

public class Movie
{
    public string title { get; private set; }
    public List<MovieScreening> movieScreenings { get; } = new List<MovieScreening>();

    public Movie(string title)
    {
        this.title = title;
    }

    public override string ToString()
    {
        return "Title: " + title;
    }
}
