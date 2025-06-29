using LibraryDAL.Interfaces;
using LibrarySystem.DiHelper;
using LibrarySystem.Helper;
using LibrarySystem.Presentation.DiHelper;
using LibrarySystem.Presentation.Filters;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
# region GlobalActionFilter
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<GlobalActionFilter>();
});
#endregion



#region Di
builder.Services.DiServiceAndRepo();
#endregion

# region MappingReg
builder.Services.AllowAutoMapper();
#endregion

#region addCookieSection
builder.Services.AddAuthentication("Library") 
           .AddCookie("Library", options =>
           {
               options.Cookie.Name = "MyAuthCookie";
               options.LoginPath = "/Account/Login"; 
               options.LogoutPath = "/Account/Logout"; 
               options.Cookie.HttpOnly = true; 
               options.Cookie.SecurePolicy = CookieSecurePolicy.Always; 
               options.Cookie.SameSite = SameSiteMode.Strict; 
               options.ExpireTimeSpan = TimeSpan.FromHours(1);
           });
var app = builder.Build();
#endregion

# region SeederForTestDataBecuaseInsertingBookIsNotFromRequirements
using (var scope = app.Services.CreateScope())
{
    try
    {
        var initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();

        var dbExists = await initializer.DatabaseExistsAsync("Library");
        if (!dbExists)
        {
            await initializer.InitializeDatabaseAsync();
            Console.WriteLine("Database initialized.");
        }
        else
        {
            Console.WriteLine("Skipping initialization.");
        }

        var seeder = scope.ServiceProvider.GetRequiredService<IBookRepoistory>();
        var result = await seeder.SeedDummyDataIfNull();
        Console.WriteLine("Seeder Result: " + result);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Startup error While initilize Database With StoredProcedures With this Error : " + ex.Message);
    }
}

#endregion



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
