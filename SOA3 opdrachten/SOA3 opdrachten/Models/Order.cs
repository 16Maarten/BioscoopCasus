using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    //public int GetOrderNr() => throw new NotImplementedException();

    public double CalculatePrice()
    {
        throw new NotImplementedException();
    }

    public void Export(TicketExportFormat exportFormat)
    {
        throw new NotImplementedException();
    }
}
