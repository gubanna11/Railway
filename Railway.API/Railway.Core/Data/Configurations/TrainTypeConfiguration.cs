﻿using Railway.Core.Entities;

namespace Railway.Core.Data.Configurations;

/// <summary>
/// Configurations for TrainType entity.
/// The relationship with Train is configured in <see cref="TrainConfiguration">
/// The relationship with TrainTypeDetail is configured in <see cref="TrainTypeDetailConfiguration">
/// </summary>
public class TrainTypeConfiguration : BaseEntityConfiguration<TrainType>
{
}
