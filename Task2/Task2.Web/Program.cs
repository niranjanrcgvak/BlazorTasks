using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Task2.Web;
using Task2.Web.Services;
using Task2.Web.StateProvider;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<TodoService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CustomStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomStateProvider>());
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7115/") });

await builder.Build().RunAsync();