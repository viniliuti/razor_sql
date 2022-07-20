using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddNotyf(config =>
{
	config.DurationInSeconds = 5;
	config.IsDismissable = true;
	config.Position = NotyfPosition.TopCenter;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStatusCodePages("text/html", "<h1>Error! Status Code {0}</h1>");

app.UseRouting();

app.UseAuthorization();
app.UseNotyf();
app.MapRazorPages();

app.Run();
