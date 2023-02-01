using System.Text;

namespace SOA3_opdrachten.Models;

public class MovieScreening
{
    public Movie movie { get; private set; }
    public DateTime dateAndTime { get; private set; }
    public double pricePerSeat { get; private set; }
    public List<MovieTicket> movieTickets { get; } = new List<MovieTicket>();

    public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
    {
        this.dateAndTime = dateAndTime;
        this.pricePerSeat = pricePerSeat;
        this.movie = movie;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Date & time: " + dateAndTime.ToString());
        sb.AppendLine("Price: " + pricePerSeat.ToString());
        sb.AppendLine(movie.ToString());
        return sb.ToString();
    }
}
