using CourseworkMedicalServer.Data;
using CourseworkMedicalServer.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("TestsStore");
builder.Services.AddSqlite<TestsStoreDBContext>(connString);
var app = builder.Build();
app.MapDoctorsEndpoints();
app.MapPatientsEndpoints();
app.MapTestsEndpoints();
await app.MigrateDbAsync();

app.Run();
