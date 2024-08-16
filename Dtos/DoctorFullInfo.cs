using CourseworkMedicalServer.Abstractions.Entities;
using CourseworkMedicalServer.Abstractions;

namespace CourseworkMedicalServer.Dtos;

public record class DoctorFullInfo(

    Guid Id,
    string Name,
    string Gender,
    string Username,
    string Specialization,
    DateTime CreatedAt,
    DateTime? UpdatedAt
    );
