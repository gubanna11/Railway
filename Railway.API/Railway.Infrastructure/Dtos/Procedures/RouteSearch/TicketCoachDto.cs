using System.Collections.Generic;
namespace Railway.Infrastructure.Dtos.Procedures.RouteSearch;

public class TicketCoachDto
{
    public int CoachNumber { get; set; }

    public ICollection<TicketSeatDto> Seats { get; set; }
}
