namespace CourseworkMedicalServer.Dtos;

public record class TestGeneralInfo
(
    Guid PatientId,
    Guid DoctorId,
    float RedBloodCellCount,
    float WhiteBloodCellCount,
    float PlateletCount,
    float HemoglobinTest,
    float HematocritTest,
    float MeanCorpuscularVolume
    );
