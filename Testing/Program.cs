using HardwarePriceHistory.Data.Repository.Product;
using HardwarePriceHistory.Pichau.Models;
using Spectre.Console;


AnsiConsole.Status()
    .Start("Thinking...", ctx =>
    {
        // Simulate some work
        AnsiConsole.MarkupLine("Doing some work...");
        Thread.Sleep(1000);

        // Update the status and spinner
        ctx.Status("Thinking some more");
        ctx.Spinner(Spinner.Known.Star);
        ctx.SpinnerStyle(Style.Parse("green"));

        // Simulate some work
        AnsiConsole.MarkupLine("Doing some more work...");
        Thread.Sleep(2000);
    });