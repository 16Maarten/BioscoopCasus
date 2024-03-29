﻿using System.Text;
using System.Text.Json;

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

        foreach (var ticket in movieTickets) calculatedPrice += TicketPriceAfterPremiumCheck(ticket);
        if (movieTickets.Count > 1)
        {
            for (int i = 0; i < movieTickets.Count; i++) if (i % 2 == 0) calculatedPrice += TicketPriceAfterPremiumCheck(movieTickets[i]);
        }
        else
        {
            foreach (var ticket in movieTickets) calculatedPrice += TicketPriceAfterPremiumCheck(ticket);
            if (movieTickets.Count >= 6) calculatedPrice *= .9;
        }

        return calculatedPrice;
    }

    public void Export(TicketExportFormat exportFormat, string fileName)
    {
        StringBuilder sb = new StringBuilder();
        if (exportFormat == TicketExportFormat.PLAINTEXT)
        {
            sb.AppendLine("--------------------------------------------");
            sb.AppendLine($"Order number: {orderNr.ToString()}");
            sb.AppendLine($"Student order: {(isStudentOrder ? "Yes" : "No")}");
            sb.AppendLine("--------------------------------------------");
            foreach (var ticket in movieTickets)
            {
                sb.AppendLine($"------Ticket #{movieTickets.FindIndex(x => x == ticket) + 1}------");
                sb.AppendLine(ticket.ToString());
            }
            sb.AppendLine($"\nTOTAL PRICE (after discount): {CalculatePrice()} euro");

            File.WriteAllText($"../../../Exports/{fileName}.text", sb.ToString());
        }
        if (exportFormat == TicketExportFormat.JSON)
        {
            JsonSerializerOptions options = new() { WriteIndented = true };
            sb.AppendLine(JsonSerializer.Serialize(this, options));

            File.WriteAllText($"../../../Exports/{fileName}.json", sb.ToString());
        }
    }
    public bool SecondTicketIsForFree()
    {
        var movieScreeningDayOfWeek = movieTickets[0].movieScreening.dateAndTime.DayOfWeek;
        return isStudentOrder || (movieScreeningDayOfWeek != DayOfWeek.Friday && movieScreeningDayOfWeek != DayOfWeek.Saturday && movieScreeningDayOfWeek != DayOfWeek.Sunday);
    }

    public double TicketPriceAfterPremiumCheck(MovieTicket movieTicket)
    {
        return movieTicket.GetPrice() + (movieTicket.isPremium ? (isStudentOrder ? 2 : 3) : 0);
    }
}
