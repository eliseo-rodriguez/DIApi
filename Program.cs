var builder = WebApplication.CreateBuilder(args);
builder.Services.UseTransientAPI()
                .UseSingletonAPI();

builder.Services.UseScopedAPI();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapTransientApi()
   .MapSingletonApi();

app.MapSingletonApi();

app.Run();
