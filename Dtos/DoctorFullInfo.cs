using CourseworkMedicalServer.Abstractions.Entities;
using CourseworkMedicalServer.Abstractions;

namespace CourseworkMedicalServer.Dtos;

public record class DoctorFullInfo(

    Guid Id,
    string Name,
    Gender Gender,
    string Username,
    Specialization Specialization,
    DateTime CreatedAt,
    DateTime? UpdatedAt
    );
