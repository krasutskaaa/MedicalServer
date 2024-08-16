using CourseworkMedicalServer.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace CourseworkMedicalServer.Dtos;

public record class CreatePatientDto(
    [Required][StringLength(50)]
    string Name,
    [Required]
    string Gender,
    [Required]
    DateOnly Birthday,
    string? Description

);
