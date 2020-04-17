namespace CinemaReservations.Tests 
{
    interface IMovieScreeningRepsitory {
        MovieScreening FindMovieScreeningById(string screeningId);
    }
}