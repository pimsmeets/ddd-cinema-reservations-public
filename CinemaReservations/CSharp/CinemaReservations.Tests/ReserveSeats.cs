namespace CinemaReservations.Tests 
{
    public class ReserveSeats {
        public string ShowId { get; }
        public int PartyRequested { get; }

        public ReserveSeats(string showId, int partyRequested) {
            this.ShowId = showId;
            this.PartyRequested = partyRequested;
        }
    }
}