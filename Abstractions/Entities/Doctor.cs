using static System.Net.Mime.MediaTypeNames;

namespace CourseworkMedicalServer.Abstractions.Entities;

public class Doctor : Entity, IAliveEntity
{
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Specialization Specialization { get; set; }
    public ICollection<Test> Tests { get; set; } = new List<Test>();
}

public enum Specialization
{
    Radiologist,
    Surgeon,
    Nephrologist,
    Gynecologist,
    Anesthesiologist,
    Neurologist,
    Oncologist,
    Pathologist,
    Psychiatrist,
    Urologist,
    Cardiologist,
    Dentist,
    Pulmonologist,
    Ophthalmologist,
    Pediatrician
}

