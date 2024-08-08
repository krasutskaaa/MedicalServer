using CourseworkMedicalServer.Abstractions.Entities;
using CourseworkMedicalServer.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace CourseworkMedicalServer.Dtos;

public record class UpdateDoctorDto(
    [Required][StringLength(50)]
    string Name,
    [Required]
    Gender Gender,
    [Required][RegularExpression(@"^[A-Za-z0-9]+$",
    ErrorMessage =
    "The username must have at least one of the charachters(A-Z,a-z,0-9)")]
    string Username,
    [Required][MinLength(8,
    ErrorMessage = "The field must be al least 8 charachters")]
    string Password,
    [Required]
    Specialization Specialization
);

