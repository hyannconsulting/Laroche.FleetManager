﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Laroche.FleetManager.Domain.BaseObjects;
using System;
using System.Collections.Generic;

namespace Laroche.FleetManager.Domain.Entities;

public partial class Affectation : BaseEntity
{
    public int AffectationId { get; set; }

    public int? ConducteurId { get; set; }

    public int? VehiculeId { get; set; }

    public DateTime? DateDebut { get; set; }

    public DateTime? DateFin { get; set; }

    public virtual Conducteur Conducteur { get; set; }

    public virtual Vehicule Vehicule { get; set; }
}