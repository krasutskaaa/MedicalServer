using CourseworkMedicalServer.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseworkMedicalServer.Data;

public class TestsStoreDBContext(DbContextOptions<TestsStoreDBContext> options)
    : DbContext(options)
{
    public DbSet<Doctor> Doctors => Set<Doctor>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Test> Tests => Set<Test>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Test>(entity =>
        {
            entity
            .HasOne(test => test.Doctor)
            .WithMany(doctor => doctor.Tests)
            .HasForeignKey(test => test.DoctorId);

            entity
            .HasOne(test => test.Patient)
            .WithMany()
            .HasForeignKey(test => test.PatientId);
        });
    }
}
