namespace CinemaReservations.Tests 
{
    public interface IMovieScreeningRepository {
        MovieScreening FindMovieScreeningById(string screeningId);
    }
}