var builder = DistributedApplication.CreateBuilder(args);

var carvedRockDb = builder.AddPostgres("postgres").AddDatabase("CarvedRockPostgres");

var identity = builder.AddProject<Projects.CarvedRock_Identity>("carvedrock-identity");
var idEndpoint = identity.GetEndpoint("https");

var api = builder.AddProject<Projects.CarvedRock_Api>("carvedrock-api")
    .WithEnvironment("Auth__Authority", idEndpoint)
    .WithReference(carvedRockDb).WaitFor(carvedRockDb);

builder.AddProject<Projects.CarvedRock_WebApp>("carvedrock-webapp")
    .WithEnvironment("Auth__Authority", idEndpoint)
    .WithEnvironment("CarvedRock__ApiBaseUrl", api.GetEndpoint("https"));

builder.Build().Run();
