﻿namespace Railway.Core.Entities;

public class TrainType : BaseEntity
{
    public string Name { get; set; }

    public string ImgUrl { get; set; }

    public ICollection<Train> Trains { get; set; }

    public ICollection<TrainTypeDetail> TrainTypeDetails { get; set; }
}
