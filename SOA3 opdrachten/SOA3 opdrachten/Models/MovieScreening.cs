using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    //public double GetPricePerSeat() => throw new NotImplementedException();

    public override string ToString()
    {
        return string.Empty;
    }
}
