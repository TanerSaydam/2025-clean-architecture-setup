var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CleanArhictecture_2025_WebAPI>("cleanarhictecture-2025-webapi");

builder.Build().Run();
