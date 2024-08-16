using CourseworkMedicalServer.Abstractions.Entities;
using CourseworkMedicalServer.Abstractions;

namespace CourseworkMedicalServer.Dtos;

public record class DoctorGeneralInfo(
    string Name,
    string Gender,
    string Specialization);
