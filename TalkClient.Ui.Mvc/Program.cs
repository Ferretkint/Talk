using TalkClient.Ui.Mvc.Services;
using TalkClient.Ui.Mvc.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var appSettings = new AppSettings();
builder.Configuration.GetSection(nameof(AppSettings)).Bind(appSettings);

if (!string.IsNullOrWhiteSpace(appSettings.ApiUrl))
{
    builder.Services.AddHttpClient("TalkApi", options =>
    {
        options.BaseAddress = new Uri(appSettings.ApiUrl);
    });
}

builder.Services.AddScoped<ChatChannelService>();
builder.Services.AddScoped<ChatMessageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
