using Autofac;
using Autofac.Extensions.DependencyInjection;
using Facade.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
const string version = "v0.0.1";

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new DefaultInfrastructureModule());
});

builder.Services.AddMvc();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseStaticFiles();

app.MapControllers();

app.Run();