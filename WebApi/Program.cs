using WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<LuckyNumberGeneratorService>(
        httpClient =>
        {
            httpClient.BaseAddress = new Uri(builder.Configuration.GetValue<string>("LuckyNumberService:ApiUrl"));
        })
    .ConfigurePrimaryHttpMessageHandler(
        () =>
        {
            // this is the httpClient for our internal service. We'll just trust the cert.
            return new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (_, _, _, _) => true
            };
        });
builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationInsightsTelemetry();
// builder.Services.AddApplicationInsightsKubernetesEnricher();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(x=>x.AllowAnyOrigin());
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();