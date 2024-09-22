using AuthrorizationMicroservice;
using AuthrorizationMicroservice.Infrastructure;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Authorization = AuthrorizationMicroservice.Services.Authorization;

var builder = WebApplication.CreateBuilder(args);
const string version = "v0.0.1";


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new DefaultInfrastructureModule());
});

builder.Services.AddGrpc();
builder.Services.AddMvc();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapGrpcService<Authorization>();
app.UseSwagger();
app.UseSwaggerUI();
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.UseStaticFiles();

app.MapControllers();

app.Run();
