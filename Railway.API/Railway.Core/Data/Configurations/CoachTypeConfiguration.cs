﻿using Railway.Core.Entities;

namespace Railway.Core.Data.Configurations;

/// <summary>
/// Configurations for CoachType entity.
/// The relationship with RouteDetail is configured in <see cref="RouteDetailConfiguration">
/// The relationship with TrainTypeDetail is configured in <see cref="TrainTypeDetailConfiguration">
/// </summary>
public class CoachTypeConfiguration : BaseEntityConfiguration<CoachType>
{
}