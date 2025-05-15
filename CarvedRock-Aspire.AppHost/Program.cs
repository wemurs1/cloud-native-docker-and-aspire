var builder = DistributedApplication.CreateBuilder(args);

var carvedRockDb = builder.AddPostgres("postgres").AddDatabase("CarvedRockPostgres");

builder.AddProject<Projects.CarvedRock_Api>("carvedrock-api").WithReference(carvedRockDb).WaitFor(carvedRockDb);

builder.Build().Run();
