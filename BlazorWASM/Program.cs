using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWASM;
using BlazorWasm.Auth;
using BlazorWASM.Services.Http;
using Domain.Auth;
using HttpClientImpl;
using HttpClientInterfaces;
using Microsoft.AspNetCore.Components.Authorization;
using IAuthService = BlazorWASM.Services.Http.IAuthService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IUserService, UserHttpClient>();
builder.Services.AddScoped<ISubForumService, SubForumHttpClient>();
builder.Services.AddScoped<IPostService, PostHttpClient>();

builder.Services.AddScoped<IAuthService, JwtAuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
AuthorizationPolicies.AddPolicies(builder.Services);

builder.Services.AddScoped(sp => new HttpClient 
    { BaseAddress = new Uri("https://localhost:7255") });

await builder.Build().RunAsync();