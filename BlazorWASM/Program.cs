using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWASM;
using HttpClientImpl;
using HttpClientInterfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IUserService, UserHttpClient>();
builder.Services.AddScoped<ISubForumService, SubForumHttpClient>();
builder.Services.AddScoped<IPostService, PostHttpClient>();

builder.Services.AddScoped(sp => new HttpClient 
    { BaseAddress = new Uri("https://localhost:7255") });

await builder.Build().RunAsync();