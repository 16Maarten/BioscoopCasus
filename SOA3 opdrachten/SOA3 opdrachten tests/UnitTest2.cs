using SOA3_opdrachten.Models;

namespace SOA3_opdrachten_tests
{
    public class UnitTest2
    {
        [Fact]
        public void StudentNot10PercentSale()
        {

            var movieScreening10euro = new MovieScreening(new Movie("Sharknado 2"), new DateTime(2023, 2, 5, 8, 30, 0), 10);

            var movieTickets = new List<MovieTicket>() {
                new MovieTicket(movieScreening10euro, false, 1, 1), 
                new MovieTicket(movieScreening10euro, false, 1, 2),
                new MovieTicket(movieScreening10euro, false, 1, 3),
                new MovieTicket(movieScreening10euro, false, 1, 4),
                new MovieTicket(movieScreening10euro, false, 1, 5),
                new MovieTicket(movieScreening10euro, false, 1, 6)

            };

            var studentOrder = new Order(1, true);
            studentOrder.movieTickets.AddRange(movieTickets);

            Assert.Equal(50.0, studentOrder.CalculatePrice());
        }

        [Fact]
        public void NonStudent10PercentSale()
        {

            var movieScreening10euro = new MovieScreening(new Movie("Sharknado 2"), new DateTime(2023, 2, 5, 8, 30, 0), 10);

            var movieTickets = new List<MovieTicket>() {
                new MovieTicket(movieScreening10euro, false, 1, 1),
                new MovieTicket(movieScreening10euro, false, 1, 2),
                new MovieTicket(movieScreening10euro, false, 1, 3),
                new MovieTicket(movieScreening10euro, false, 1, 4),
                new MovieTicket(movieScreening10euro, false, 1, 5),
                new MovieTicket(movieScreening10euro, false, 1, 6)
            };

            var studentOrder = new Order(1, false);
            studentOrder.movieTickets.AddRange(movieTickets);

            Assert.Equal(54.0, studentOrder.CalculatePrice());
        }

    }
}