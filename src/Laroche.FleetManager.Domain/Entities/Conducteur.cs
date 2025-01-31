﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Laroche.FleetManager.Domain.Entities;

public partial class Conducteur
{
    public int ConducteurId { get; set; }

    public string Nom { get; set; }

    public string Prenoms { get; set; }

    public string NumeroTelephone { get; set; }

    public DateTime? DateNaissance { get; set; }

    public string PermisConduire { get; set; }

    public DateTime? DateEmbauche { get; set; }

    public virtual ICollection<Affectation> Affectations { get; set; } = new List<Affectation>();

    public virtual ICollection<Deplacement> Deplacements { get; set; } = new List<Deplacement>();

    public virtual ICollection<Incident> Incidents { get; set; } = new List<Incident>();
}