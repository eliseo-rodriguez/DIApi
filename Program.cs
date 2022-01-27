var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<A_Transient>();
builder.Services.AddSingleton<B_Singleton>();
builder.Services.AddScoped<C_Scoped>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/Transient", (A_Transient A) => {
    var r = A.Id;
    return Results.Ok(r);
});

app.MapGet("/Singleton", (B_Singleton B) => {
    var r = B.Id;
    return Results.Ok(r);
});

app.MapGet("/SCoped", (C_Scoped C) => {
    var r = C.Id;
    return Results.Ok(r);
});

app.Run();

public class A_Transient{
    public A_Transient() => Id = Guid.NewGuid();
    public Guid Id { get; set; }
}

public class B_Singleton{
    public B_Singleton() => Id = Guid.NewGuid();
    public Guid Id { get; set; }
}
public class C_Scoped
{
    public C_Scoped() => Id = Guid.NewGuid();
    public Guid Id { get; set; }
}