namespace Railway.Infrastructure.Dtos.Procedures.RouteSearch.Concrete;

public class RouteAvailabilityDto
{
    public int Id { get; set; }

    public int RouteId { get; set; }

    public int CoachTypeId { get; set; }

    public string CoachTypeName { get; set; }

    public int TotalSeatsAmount { get; set; }

    public int BookedAmount { get; set; }

    public int AvailableAmount { get; set; }
}
