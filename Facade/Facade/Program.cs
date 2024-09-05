var builder = WebApplication.CreateBuilder(args);
const string version = "v0.0.1";
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddMvc();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint( $"/swagger/{version}/swagger.json", "swaggerName"));
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseDeveloperExceptionPage();
app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseStaticFiles();


app.MapControllers();

app.Run();