using CourseworkMedicalServer.Data;
using CourseworkMedicalServer.Dtos;
using CourseworkMedicalServer.Mapping;
using CourseworkMedicalServer.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace CourseworkMedicalServer.Endpoints;

public static class TestEndpoints
{
    const string GetTestEndpointName = "GetTest";
    public static RouteGroupBuilder MapTestsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("tests")
            .WithParameterValidation();

        //GET/tests

        group.MapGet("/", async (TestsStoreDBContext dbContext) =>
        await dbContext.Tests
        .Select(test => test.ToTestGeneralInfo())
        .AsNoTracking()
        .ToListAsync());

        //GET/tests/1

        group.MapGet("/by-testId/{id}", async (Guid id, TestsStoreDBContext dbContext) =>
        {
            Test? test = await dbContext.Tests.FindAsync(id);

            return test is null ?
            Results.NotFound() : Results.Ok(test.ToTestGeneralInfo());
        })
            .WithName(GetTestEndpointName+"ById");

        //GET//tests/{doctorId}
        group.MapGet("/by-doctorId/{doctorId}", async (Guid doctorId, TestsStoreDBContext dbContext) =>
        {
            List<Test> tests = await dbContext.Tests
            .Where(test => test.DoctorId.Equals(doctorId))
            .ToListAsync();
            return tests is null ?
            Results.NotFound() : Results.Ok(tests);
        })
            .WithName(GetTestEndpointName + "ByDoctorId");


        //POST/tests
        group.MapPost("/", async (CreateTestDto newTest,
            TestsStoreDBContext dbContext) =>
        {
            Test test = newTest.ToEntity();
            dbContext.Tests.Add(test);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetTestEndpointName,
                new { id = test.Id },
                test.ToTestFullInfo());
        });

        //PUT//tests

        group.MapPut("/{id}", async (Guid id, UpdateTestDto updatedTest,
            TestsStoreDBContext dbContext) =>
        {

            var existingTest = await dbContext.Tests.FindAsync(id);
            if (existingTest is null)
            {
                return Results.NotFound();
            }
            dbContext.Entry(existingTest)
            .CurrentValues
            .SetValues(updatedTest.ToEntity(id));
            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        });

        //DELETE/tests/1

        group.MapDelete("/{id}", async (Guid id, TestsStoreDBContext dbContext) =>
        {
            await dbContext.Tests
            .Where(test => test.Id == id)
            .ExecuteDeleteAsync();
            return Results.NoContent();

        });

        return group;
    }
}
