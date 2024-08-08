using CourseworkMedicalServer.Abstractions;

namespace CourseworkMedicalServer.Dtos;

public record class PatientGeneralInfo(
    string Name,
    Gender Gender,
    DateOnly Birthday,
    string? Description
    );
