namespace CourseworkMedicalServer.Abstractions.Entities;

public class Test : Entity
{
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public float RedBloodCellCount { get; set; }
    public float WhiteBloodCellCount { get; set; }
    public float PlateletCount { get; set; }
    public float HemoglobinTest { get; set; }
    public float HematocritTest { get; set; }
    public float MeanCorpuscularVolume { get; set; }
    public Doctor Doctor { get; set; }
    public Patient Patient { get; set; }


}
