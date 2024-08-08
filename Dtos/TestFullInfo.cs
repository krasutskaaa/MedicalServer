namespace CourseworkMedicalServer.Dtos;

public record class TestFullInfo
(
    Guid Id,
    Guid PatientId,
    Guid DoctorId,
    float RedBloodCellCount,
    float WhiteBloodCellCount,
    float PlateletCount,
    float HemoglobinTest,
    float HematocritTest,
    float MeanCorpuscularVolume,
    DateTime CreatedAt,
    DateTime? UpdatedAt
    );
