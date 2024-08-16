using CourseworkMedicalServer.Abstractions;

namespace CourseworkMedicalServer.Dtos;

public record class PatientFullInfo(

    Guid Id,
    string Name,
    string Gender,
    DateOnly Birthday,
    string? Description,
    DateTime CreatedAt,
    DateTime? UpdatedAt
    );
