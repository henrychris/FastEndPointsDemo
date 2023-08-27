using System.ComponentModel.DataAnnotations;

namespace FastEndPointsDemo.Data.Entities;

public class Business
{
    [Key]
    public string Code { get; set; }
}