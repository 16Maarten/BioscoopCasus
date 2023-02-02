using System.Text;

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
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(movieScreening.ToString());
        sb.AppendLine("[SEAT]");
        sb.AppendLine($"Row number: {rowNr.ToString()}");
        sb.AppendLine($"Seat number: {seatNr.ToString()}");
        sb.AppendLine($"Premium: {(isPremium ? "Yes" : "No")}");
        sb.Append("-------");
        return sb.ToString();
    }
}
