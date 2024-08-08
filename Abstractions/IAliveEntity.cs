namespace CourseworkMedicalServer.Abstractions;

public interface IAliveEntity
{
    public string Name { get; set; }
    public Gender Gender { get; set; }

}

// From consideration of biological identification

public enum Gender
{
    Male,
    Female
}
