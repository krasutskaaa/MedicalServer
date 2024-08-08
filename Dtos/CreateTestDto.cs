using System.ComponentModel.DataAnnotations;

namespace CourseworkMedicalServer.Dtos;

public record class CreateTestDto
(
    [Required]
    Guid PatientId,
    [Required]
    Guid DoctorId,
    [Required]
    float RedBloodCellCount,
    [Required]
    float WhiteBloodCellCount,
    [Required]
    float PlateletCount,
    [Required]
    float HemoglobinTest,
    [Required]
    float HematocritTest,
    [Required]
    float MeanCorpuscularVolume

    );
