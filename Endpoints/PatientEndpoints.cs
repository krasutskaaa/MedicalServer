using CourseworkMedicalServer.Data;
using CourseworkMedicalServer.Dtos;
using CourseworkMedicalServer.Mapping;
using CourseworkMedicalServer.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseworkMedicalServer.Endpoints;

public static class PatientEndpoints
{
    const string GetPatientEndpointName = "GetPatient";
    public static RouteGroupBuilder MapPatientsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("patients")
            .WithParameterValidation();

        //GET/patients
        group.MapGet("/", async (TestsStoreDBContext dbContext) =>
            await dbContext.Patients
            .Select(patient => patient.ToPatientGeneralInfo())
            .AsNoTracking().
            ToListAsync());


        //GET/patients/1
        group.MapGet("/{id}", async (Guid id, TestsStoreDBContext dbContext) =>
        {
            Patient? patient = await dbContext.Patients.FindAsync(id);

            return patient is null ?
                Results.NotFound() : Results.Ok(patient.ToPatientGeneralInfo());


        })
            .WithName(GetPatientEndpointName);
        //GET/patients/{id}
        group.MapGet("/fullInfo/{id}", async (Guid id, TestsStoreDBContext dbContext) =>
        {
            Patient? patient = await dbContext.Patients.FindAsync(id);

            return patient is null ?
                Results.NotFound() : Results.Ok(patient);
        });


        //POST/patients

        group.MapPost("/", async (CreatePatientDto newPatient,
            TestsStoreDBContext dbContext) =>
        {
            Patient patient = newPatient.ToEntity();
            dbContext.Patients.Add(patient);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetPatientEndpointName,
                new { id = patient.Id },
                patient.ToPatientFullInfo());


        });


        //PUT//patients
        group.MapPut("/{id}", async (Guid id, UpdatePatientDto updatedPatient,
            TestsStoreDBContext dbContext) =>
        {

            var existingPatient = await dbContext.Patients.FindAsync(id);
            if (existingPatient is null)
            {
                return Results.NotFound();
            }
            dbContext.Entry(existingPatient)
            .CurrentValues
            .SetValues(updatedPatient.ToEntity(id));

            await dbContext.SaveChangesAsync();
            return Results.NoContent();

        });



        //DELETE/patients/1
        group.MapDelete("/{id}", async (Guid id, TestsStoreDBContext dbContext) =>
        {
            await dbContext.Patients
            .Where(patient => patient.Id == id)
            .ExecuteDeleteAsync();
            return Results.NoContent();
        });

        return group;
    }
}
