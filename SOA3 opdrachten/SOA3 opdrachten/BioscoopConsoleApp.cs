using SOA3_opdrachten.Models;

var movieScreening9euro = new MovieScreening(new Movie("Sharknado 1"), DateTime.Today, 9);
var movieScreening10euro = new MovieScreening(new Movie("Sharknado 2"), DateTime.Today.AddDays(2), 10);

var movieTicketsNonPremium = new List<MovieTicket>() {
    new MovieTicket(movieScreening9euro, false, 1, 1),
    new MovieTicket(movieScreening9euro, false, 1, 2),
    new MovieTicket(movieScreening9euro, true, 1, 3),
    new MovieTicket(movieScreening9euro, true, 1, 4),
    new MovieTicket(movieScreening9euro, true, 1, 5)
};
var movieTicketsNonStudent = new List<MovieTicket>() {
    new MovieTicket(movieScreening10euro, true, 1, 1),
    new MovieTicket(movieScreening10euro, true, 1, 2),
    new MovieTicket(movieScreening10euro, true, 1, 3),
    new MovieTicket(movieScreening10euro, true, 1, 4),
    new MovieTicket(movieScreening10euro, false, 1, 5),
    new MovieTicket(movieScreening10euro, false, 1, 6),
};

var studentOrder = new Order(1, true);
studentOrder.movieTickets.AddRange(movieTicketsNonPremium);
var nonStudentOrder = new Order(2, false);
nonStudentOrder.movieTickets.AddRange(movieTicketsNonStudent);

studentOrder.Export(TicketExportFormat.PLAINTEXT, "studentOrder");
studentOrder.Export(TicketExportFormat.JSON, "studentOrder");
nonStudentOrder.Export(TicketExportFormat.PLAINTEXT, "nonStudentOrder");
nonStudentOrder.Export(TicketExportFormat.JSON, "nonStudentOrder");

Console.WriteLine($"Student order: {studentOrder.CalculatePrice()}");
Console.WriteLine($"Non-student order: {nonStudentOrder.CalculatePrice()}");
