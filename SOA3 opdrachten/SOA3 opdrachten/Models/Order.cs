namespace SOA3_opdrachten.Models;

public class Order
{
    public int orderNr { get; private set; }
    public bool isStudentOrder { get; private set; }
    public List<MovieTicket> movieTickets { get; private set; } = new List<MovieTicket>();

    public Order(int orderNr, bool isStudentOrder)
    {
        this.orderNr = orderNr;
        this.isStudentOrder = isStudentOrder;
    }

    public double CalculatePrice()
    {
        var calculatedPrice = 0.0;

        if (SecondTicketIsForFree())
        {
            for (int i = 0; i < movieTickets.Count; i++) if (i == 0 || i % 2 == 0) calculatedPrice += TicketPriceAfterPremiumCheck(movieTickets[i]);
        }
        else
        {
            foreach (var ticket in movieTickets) calculatedPrice += TicketPriceAfterPremiumCheck(ticket);
            if (movieTickets.Count >= 6) calculatedPrice = calculatedPrice * .9;
        }

        return calculatedPrice;
    }

    public void Export(TicketExportFormat exportFormat)
    {
        // TO DO: Implementeer de exportfunctionaliteit in formaat .txt en .json.
        // Gebruik File-klasse en StringBuilder-klasse om dit te doen.

        throw new NotImplementedException();
    }
    public bool SecondTicketIsForFree()
    {
        var movieScreeningDayOfWeek = movieTickets[0].movieScreening.dateAndTime.DayOfWeek;
        return isStudentOrder || movieScreeningDayOfWeek == DayOfWeek.Monday || movieScreeningDayOfWeek == DayOfWeek.Tuesday || movieScreeningDayOfWeek == DayOfWeek.Wednesday || movieScreeningDayOfWeek == DayOfWeek.Thursday;
    }

    public double TicketPriceAfterPremiumCheck(MovieTicket movieTicket)
    {
        return movieTicket.GetPrice() + (movieTicket.isPremium ? (isStudentOrder ? 2 : 3) : 0);
    }
}
