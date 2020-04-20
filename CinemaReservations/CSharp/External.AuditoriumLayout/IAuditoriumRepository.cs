namespace External.AuditoriumLayout
{
    public interface IAuditoriumRepository
    {
        AuditoriumDto FindAuditoriumForScreeningId(string screeningId);
    }
}