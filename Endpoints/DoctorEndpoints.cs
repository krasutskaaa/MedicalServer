using CourseworkMedicalServer.Data;
using SharedLibrary.Dtos;
using SharedLibrary.Mapping;
using SharedLibrary.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseworkMedicalServer.Endpoints;
public static class DoctorEndpoints
{
    const string GetDoctorEndpointName = "GetDoctor";
    public static RouteGroupBuilder MapDoctorsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("doctors")
            .WithParameterValidation();

        //GET/doctors
        group.MapGet("/", async (TestsStoreDBContext dbContext) =>
            await dbContext.Doctors
            .Select(doctor => doctor.ToDoctorGeneralInfo())
            .AsNoTracking().
            ToListAsync());


        //GET/doctors/1
        group.MapGet("/{id:guid}", async (Guid id, TestsStoreDBContext dbContext) =>
        {
            Doctor? doctor = await dbContext.Doctors.FindAsync(id);

            return doctor is null ?
                Results.NotFound() : Results.Ok(doctor.ToDoctorGeneralInfo());


        })
            .WithName(GetDoctorEndpointName+"ById");
        //GET/doctors/username

        group.MapGet("/{username}", async (string username, TestsStoreDBContext dbContext) =>
        {
            Doctor? doctor = await dbContext.Doctors
            .FirstOrDefaultAsync(doctor => doctor.Username.Equals(username));

            return doctor is null ?
            Results.NotFound() : Results.Ok(doctor);
        })
            .WithName(GetDoctorEndpointName + "ByUsername");

        //POST/docotors

        group.MapPost("/", async (CreateDoctorDto newDoctor,
            TestsStoreDBContext dbContext) =>
        {
            Doctor doctor = newDoctor.ToEntity();
            dbContext.Doctors.Add(doctor);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetDoctorEndpointName+"ById",
                new { id = doctor.Id },
                doctor.ToDoctorFullInfo());


        });


        //PUT//doctors
        group.MapPut("/{id}", async (Guid id, UpdateDoctorDto updatedDoctor,
            TestsStoreDBContext dbContext) =>
        {

            var existingDoctor = await dbContext.Doctors.FindAsync(id);
            if (existingDoctor is null)
            {
                return Results.NotFound();
            }
            dbContext.Entry(existingDoctor)
            .CurrentValues
            .SetValues(updatedDoctor.ToEntity(id));

            await dbContext.SaveChangesAsync();
            return Results.NoContent();

        });



        //DELETE/doctors/1
        group.MapDelete("/{id}", async (Guid id, TestsStoreDBContext dbContext) =>
        {
            await dbContext.Doctors
            .Where(doctor => doctor.Id == id)
            .ExecuteDeleteAsync();
            return Results.NoContent();
        });

        return group;
    }
}
