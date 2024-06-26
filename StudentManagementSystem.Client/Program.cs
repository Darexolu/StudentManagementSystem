using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StudentManagementSystem.Client;
using StudentManagementSystem.Client.Services;
using StudentManagementSystemShared.StudentRepository;
using StudentsManagementSystem.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

//builder.Services.AddScoped<IStudentRepository, StudentService>();
//builder.Services.AddScoped<ICountryRepository, CountryService>();
//builder.Services.AddScoped<ISystemCodeDetailRepository, SystemCodeDetailsService>();
//builder.Services.AddScoped<ISystemCodeRepository, SystemCodeService>();
//builder.Services.AddScoped<ITeacherRepository, TeacherService>();




builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});
await builder.Build().RunAsync();
