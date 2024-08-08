using CourseworkMedicalServer.Abstractions.Entities;
using CourseworkMedicalServer.Dtos;

namespace CourseworkMedicalServer.Mapping;

public static class TestMapping
{

    public static TestGeneralInfo ToTestGeneralInfo(this Test test)
    {
        return new(
            test.PatientId,
            test.DoctorId,
            test.RedBloodCellCount,
            test.WhiteBloodCellCount,
            test.PlateletCount,
            test.HemoglobinTest,
            test.HematocritTest,
            test.MeanCorpuscularVolume

            );
    }

    public static Test ToEntity(this CreateTestDto test)
    {
        return new Test()
        {
            PatientId = test.PatientId,
            DoctorId = test.DoctorId,
            RedBloodCellCount = test.RedBloodCellCount,
            WhiteBloodCellCount = test.WhiteBloodCellCount,
            PlateletCount = test.PlateletCount,
            HemoglobinTest = test.HemoglobinTest,
            HematocritTest = test.HematocritTest,
            MeanCorpuscularVolume = test.MeanCorpuscularVolume

        };
    }


    public static TestFullInfo ToTestFullInfo(this Test test)
    {
        return new(
            test.Id,
            test.PatientId,
            test.DoctorId,
            test.RedBloodCellCount,
            test.WhiteBloodCellCount,
            test.PlateletCount,
            test.HemoglobinTest,
            test.HematocritTest,
            test.MeanCorpuscularVolume,
            test.CreatedAt,
            test.UpdatedAt
            );
    }


    public static Test ToEntity(this UpdateTestDto test, Guid id)
    {
        return new Test()
        {
            Id = id,
            PatientId = test.PatientId,
            DoctorId = test.DoctorId,
            RedBloodCellCount = test.RedBloodCellCount,
            WhiteBloodCellCount = test.WhiteBloodCellCount,
            PlateletCount = test.PlateletCount,
            HemoglobinTest = test.HemoglobinTest,
            HematocritTest = test.HematocritTest,
            MeanCorpuscularVolume = test.MeanCorpuscularVolume,
            UpdatedAt = DateTime.Now
        };
    }
}
