﻿namespace QuinielasApi.Models.Entities;

public class QuinielaConfigurationDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Read { get; set; }
    public double? Value { get; set; }
    public int QuinielaId { get; set; }
    public Quiniela Quiniela { get; set; } = default!;
    
}

public class QuinielaConfigurationInsertDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Read { get; set; }
    public double? Value { get; set; }
    public int QuinielaId { get; set; }
    public Quiniela Quiniela { get; set; } = default!;

}

public class QuinielaConfigurationUpdateDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Read { get; set; }
    public double? Value { get; set; }
    public int QuinielaId { get; set; }
    public Quiniela Quiniela { get; set; } = default!;
    
}