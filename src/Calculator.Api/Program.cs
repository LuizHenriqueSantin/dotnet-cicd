using Calculator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<Calculator.Calculator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/", () => "Calculator API rodando.");

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapGet("/calculator/add", (double a, double b, Calculator.Calculator calculator) =>
    Results.Ok(new { result = calculator.Add(a, b) }));

app.MapGet("/calculator/subtract", (double a, double b, Calculator.Calculator calculator) =>
    Results.Ok(new { result = calculator.Subtract(a, b) }));

app.MapGet("/calculator/multiply", (double a, double b, Calculator.Calculator calculator) =>
    Results.Ok(new { result = calculator.Multiply(a, b) }));

app.MapGet("/calculator/divide", (double a, double b, Calculator.Calculator calculator) =>
{
    try
    {
        return Results.Ok(new { result = calculator.Divide(a, b) });
    }
    catch (DivideByZeroException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
});

app.Run();
