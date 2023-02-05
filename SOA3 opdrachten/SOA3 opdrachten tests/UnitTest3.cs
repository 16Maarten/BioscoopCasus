using SOA3_opdrachten.Models;

namespace SOA3_opdrachten_tests
{
    public class UnitTest3
    {
        [Fact]
        public void PremiumStudent()
        {

            var movieScreening10euro = new MovieScreening(new Movie("Sharknado 2"), new DateTime(2023, 2, 6, 8, 30, 0), 10);

            var movieTickets = new List<MovieTicket>() {
                new MovieTicket(movieScreening10euro, true, 1, 1)
            };

            var studentOrder = new Order(1, true);
            studentOrder.movieTickets.AddRange(movieTickets);

            Assert.Equal(12.0, studentOrder.CalculatePrice());
        }

        [Fact]
        public void PremiumStudentSecondFree()
        {

            var movieScreening10euro = new MovieScreening(new Movie("Sharknado 2"), new DateTime(2023, 2, 6, 8, 30, 0), 10);

            var movieTickets = new List<MovieTicket>() {
                new MovieTicket(movieScreening10euro, true, 1, 1),
                new MovieTicket(movieScreening10euro, true, 1, 2)
            };

            var studentOrder = new Order(1, true);
            studentOrder.movieTickets.AddRange(movieTickets);

            Assert.Equal(12.0, studentOrder.CalculatePrice());
        }

        [Fact]
        public void PremiumNonStudent()
        {

            var movieScreening10euro = new MovieScreening(new Movie("Sharknado 2"), new DateTime(2023, 2, 6, 8, 30, 0), 10);

            var movieTickets = new List<MovieTicket>() {
                new MovieTicket(movieScreening10euro, true, 1, 1),
            };

            var studentOrder = new Order(1, false);
            studentOrder.movieTickets.AddRange(movieTickets);
            Assert.Equal(13.0, studentOrder.CalculatePrice());
        }

        [Fact]
        public void PremiumNonStudentSecondFree()
        {

            var movieScreening10euro = new MovieScreening(new Movie("Sharknado 2"), new DateTime(2023, 2, 6, 8, 30, 0), 10);

            var movieTickets = new List<MovieTicket>() {
                new MovieTicket(movieScreening10euro, true, 1, 1),
            };

            var studentOrder = new Order(1, false);
            studentOrder.movieTickets.AddRange(movieTickets);
            Assert.Equal(13.0, studentOrder.CalculatePrice());
        }

        [Fact]
        public void StudentNot10PercentSale()
        {

            var movieScreening10euro = new MovieScreening(new Movie("Sharknado 2"), new DateTime(2023, 2, 5, 8, 30, 0), 10);

            var movieTickets = new List<MovieTicket>() {
                new MovieTicket(movieScreening10euro, true, 1, 1),
                new MovieTicket(movieScreening10euro, true, 1, 2),
                new MovieTicket(movieScreening10euro, true, 1, 3),
                new MovieTicket(movieScreening10euro, true, 1, 4),
                new MovieTicket(movieScreening10euro, true, 1, 5),
                new MovieTicket(movieScreening10euro, true, 1, 6)

            };

            var studentOrder = new Order(1, true);
            studentOrder.movieTickets.AddRange(movieTickets);

            Assert.Equal(60.0, studentOrder.CalculatePrice());
        }
        [Fact]
        public void NonStudent10PercentSale()
        {

            var movieScreening10euro = new MovieScreening(new Movie("Sharknado 2"), new DateTime(2023, 2, 5, 8, 30, 0), 10);

            var movieTickets = new List<MovieTicket>() {
                new MovieTicket(movieScreening10euro, true, 1, 1),
                new MovieTicket(movieScreening10euro, true, 1, 2),
                new MovieTicket(movieScreening10euro, true, 1, 3),
                new MovieTicket(movieScreening10euro, true, 1, 4),
                new MovieTicket(movieScreening10euro, true, 1, 5),
                new MovieTicket(movieScreening10euro, true, 1, 6)

            };

            var studentOrder = new Order(1, false);
            studentOrder.movieTickets.AddRange(movieTickets);

            Assert.Equal(70.2, studentOrder.CalculatePrice());
        }

    }
}