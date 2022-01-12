using Newtonsoft.Json.Serialization;

var CorsPolicy = "MyPolicy";
var builder = WebApplication.CreateBuilder(args);

//CORS setting
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicy,
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                      });
});

// Dependency Injection Implementation
builder.Services.AddSingleton<BusinessLayer.UserOps.IBLUsers, BusinessLayer.UserOps.BLUsers>();
builder.Services.AddSingleton<BusinessLayer.RoleOps.IBLRoles, BusinessLayer.RoleOps.BLRoles>();
builder.Services.AddSingleton<BusinessLayer.StatusOps.IBLStatus, BusinessLayer.StatusOps.BLStatus>();

builder.Services.AddControllers()
        .AddNewtonsoftJson(options =>
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(CorsPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();
