namespace Railway.Core.Entities;

public class TrainTypeDetail : BaseEntity
{
    public int TrainTypeId { get; set; }
    public TrainType TrainType { get; set; }

    public int CoachTypeId { get; set; }
    public CoachType CoachType { get; set; }
}
