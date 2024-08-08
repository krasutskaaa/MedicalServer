using CourseworkMedicalServer.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace CourseworkMedicalServer.Dtos;

public record class UpdatePatientDto(
    [Required][StringLength(50)]
    string Name,
    [Required]
    Gender Gender,
    [Required]
    DateOnly Birthday,
    string? Description
);
