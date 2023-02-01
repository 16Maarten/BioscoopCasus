using SOA3_opdrachten.Models;

Console.WriteLine("Hello, World!");

var movie1 = new Movie("Sharknado 1");
//var movie2 = new Movie("Sharknado 2");

var movieScreening1 = new MovieScreening(movie1, DateTime.Now, 10);
//var movieScreening2 = new MovieScreening(movie2, DateTime.Now.AddDays(1), 10);

var movieTicket1 = new MovieTicket(movieScreening1, false, 1, 1);
var movieTicket2 = new MovieTicket(movieScreening1, false, 1, 2);

var movieTicket3 = new MovieTicket(movieScreening1, true, 1, 1);
var movieTicket4 = new MovieTicket(movieScreening1, true, 1, 2);

var order1 = new Order(1, false);
var order2 = new Order(2, true);

order1.movieTickets.AddRange(new List<MovieTicket>() { movieTicket1, movieTicket2 });
order2.movieTickets.AddRange(new List<MovieTicket>() { movieTicket3, movieTicket4 });

Console.WriteLine($"Order 1: {order1.CalculatePrice()}");
Console.WriteLine($"Order 2: {order2.CalculatePrice()}");