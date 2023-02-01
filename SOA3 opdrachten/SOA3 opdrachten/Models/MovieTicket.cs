namespace SOA3_opdrachten.Models;

public class MovieTicket
{
    public MovieScreening movieScreening { get; private set; }
    public int rowNr { get; private set; }
    public int seatNr { get; private set; }
    public bool isPremium { get; private set; }

    public MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int seatRow, int seatNr) 
    {
        this.rowNr = seatRow;
        this.seatNr = seatNr;
        this.isPremium = isPremiumReservation;
        this.movieScreening = movieScreening;
    }

    public double GetPrice() => movieScreening.pricePerSeat;

    public override string ToString()
    {
        return string.Empty;
    }
}
