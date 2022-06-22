using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using PcyhoHospital;
using PcyhoHospital.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddDbContext<WorkbazeContext>(
    options =>
        options.UseSqlServer("Server=LAB4-08;Database=Workbaze;Trusted_Connection=True;")
    );
await builder.Build().RunAsync();
