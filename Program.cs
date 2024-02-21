using INTEXAPP2.Data;
using INTEXAPP2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(connectionString));

builder.Services.AddDbContext<mummiesContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("Mummies"));
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddIdentity<IdentityUser,IdentityRole>(options =>
{


        //Password requirements
        options.SignIn.RequireConfirmedAccount = true;
        options.Password.RequiredLength = 15;

        //Rate Limiting (Throttling) See NIST SP800-63b 5.2.2 https://pages.nist.gov/800-63-3/sp800-63b.html#throttle
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

        

    })
    .AddDefaultUI()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();


builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential 
    // cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;

    options.MinimumSameSitePolicy = SameSiteMode.None;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.Use(async (context, next) => {
    context.Response.Headers.Add("Content-Security-Policy-Report-Only", "default-src 'self';" +
        "script-src 'self' https://use.fontawesome.com/releases/ https://cdn.jsdelivr.net/npm/bootstra https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js 'sha256-m1igTNlg9PL5o60ru2HIIK6OPQet2z9UgiEAhCyg/RU=' 'sha256-m1igTNlg9PL5o60ru2HIIK6OPQet2z9UgiEAhCyg/RU=' " +
        "'unsafe-eval'; " +
        "style-src-elem https://fonts.googleapis.com/cs https://fonts.googleapis.co https://fonts.googleapis.com/ https://localhost:7236/css/st https://localhost:7236/css/style https://localhost:7236/css/styles.css 'sha256-Jc7XaRBVYMy6h6FvjL32miHrOGOxYV+OP4swZ/9Gysw=' " +
        "'sha256-47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=' 'sha256-tVFibyLEbUGj+pO/ZSi96c01jJCvzWilvI5Th+wLeGE=' ;" +
        "style-src 'sha256-Ct5C9fEkB6ZfA+NaOcP64/kCqftP+hwQeqVQBEy7mZY=' 'sha256-//3VLAhlL5VTo6oTJVHkyYmfyPgMkdUtCoy7Cky3yc4=' 'sha256-NaXLljQTiI+l5JPR1WJ4g2oc5R5uc+YY4zD8em0jB5E=' 'nonce-kfjdiDF453' https://fonts.googleapis.com/cs 'sha256-Ie5/DbtPf3nDXUFDND0wn4NtC+ucwwuBQa8cWyUfWRk=' 'sha256-tVFibyLEbUGj+pO/ZSi96c01jJCvzWilvI5Th+wLeGE=' 'sha256-Ie5/DbtPf3nDXUFDND0wn4NtC+ucwwuBQa8cWyUfWRk=' " +
        "'sha256-47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=' 'sha256-NaXLljQTiI+l5JPR1WJ4g2oc5R5uc+YY4zD8em0jB5E=' " +
        "'sha256-tVFibyLEbUGj+pO/ZSi96c01jJCvzWilvI5Th+wLeGE=' 'unsafe-eval ;" +

        "font-src 'self'  https://at.alicdn.com/t/font_2553510_ https://fonts.gstatic.com/s/lora/v32/ https://fonts.gstatic.com/s/opensa https://at.alicdn.com/t/font_2553510_61agzg96wm8.woff?t=1631948257467 https://fonts.gstatic.com/s/opensans/v34/memtYaGs126MiZpBA-UFUIcVXSCEkx2cmqvXlWqWtE6F15M.woff2  " +
        "https://at.alicdn.com/t/font_2553510_61agzg96wm8.ttf?t=1631948257467 https://fonts.gstatic.com/s/opensans/v34/memtYaGs126MiZpBA-UFUIcVXSCEkx2cmqvXlWqWvU6F15M.woff2 https://fonts.gstatic.com/s/opensans/v34/memtYaGs126MiZpBA-UFUIcVXSCEkx2cmqvXlWqWuU6F.woff2 " +
        "https://fonts.gstatic.com/s/opensans/v34/memtYaGs126MiZpBA-UFUIcVXSCEkx2cmqvXlWqWtU6F15M.woff2 https://fonts.gstatic.com/s/opensans/v34/memtYaGs126MiZpBA-UFUIcVXSCEkx2cmqvXlWqWuU6F.woff2 https://fonts.gstatic.com/s/opensans/v34/memtYaGs126MiZpBA-UFUIcVXSCEkx2cmqvXlWqWtU6F15M.woff2 " +
        "https://fonts.gstatic.com/s/opensans/v34/memtYaGs126MiZpBA-UFUIcVXSCEkx2cmqvXlWqWtU6F15M.woff2 https://fonts.gstatic.com/s/opensans/v34/memvYaGs126MiZpBA-UvWbX2vVnXBbObj2OVTSKmu1aB.woff2 " +
        "https://fonts.gstatic.com/s/opensans/v34/memtYaGs126MiZpBA-UFUIcVXSCEkx2cmqvXlWqWtU6F15M.woff2 https://fonts.gstatic.com/s/opensans/v34/memvYaGs126MiZpBA-UvWbX2vVnXBbObj2OVTSumu1aB.woff2 https://fonts.gstatic.com/s/opensans/v34/memtYaGs126MiZpBA-UFUIcVXSCEkx2cmqvXlWqWuk6F15M.woff2 " +
        "https://fonts.gstatic.com/s/opensans/v34/memvYaGs126MiZpBA-UvWbX2vVnXBbObj2OVTSOmu1aB.woff2 https://fonts.gstatic.com/s/opensans/v34/memtYaGs126MiZpBA-UFUIcVXSCEkx2cmqvXlWqWu06F15M.woff2 https://fonts.gstatic.com/s/opensans/v34/memvYaGs126MiZpBA-UvWbX2vVnXBbObj2OVTSOmu1aB.woff2 " +
        "https://fonts.gstatic.com/s/opensans/v34/memvYaGs126MiZpBA-UvWbX2vVnXBbObj2OVTS-muw.woff2 https://fonts.gstatic.com/s/opensans/v34/memtYaGs126MiZpBA-UFUIcVXSCEkx2cmqvXlWqWtk6F15M.woff2 https://fonts.gstatic.com/s/opensans/v34/memvYaGs126MiZpBA-UvWbX2vVnXBbObj2OVTSymu1aB.woff2 " +
        "https://fonts.gstatic.com/s/opensans/v34/memtYaGs126MiZpBA-UFUIcVXSCEkx2cmqvXlWqWt06F15M.woff2 https://fonts.gstatic.com/s/opensans/v34/memvYaGs126MiZpBA-UvWbX2vVnXBbObj2OVTS2mu1aB.woff2 https://fonts.gstatic.com/s/opensans/v34/memvYaGs126MiZpBA-UvWbX2vVnXBbObj2OVTSCmu1aB.woff2 " +
        "https://fonts.gstatic.com/s/opensans/v34/memvYaGs126MiZpBA-UvWbX2vVnXBbObj2OVTSGmu1aB.woff2 data:font/woff2/charset=utf-8/base64/d09GMgABAAAAAFukAA0AAAAA2FAAAFtLAAEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP0ZGVE0cGh4GYACCShEICoOISIKwbQuDaAABNgIkA4NuBCAFhQ4HlFUbo6lVB3K3AwikSpsioop260Yi7Bcn5Zb9/3HpONzCVwWcBHkkAjU5ULNoJXYhKXDI2VHF3hC06X6AelxLkLUkaXc9w26Zzsf5QRmPcugfZZXl7bfbGdg28ic5ee37pXv76i9JoKuquhGly1Z1twxCYhEGmUFJhENiL54bf8PzbfN9BTz4nCr/KyDI4Ykogvq/3oDghSfgWXndCZVYdthh2ko7rJZZrcy1+e04t1qtc6lb7tRWu1qJtdZhtqt2xf+uZT82c6QKtCXABbrAlsHV8cROjLre8yXPHJjvnZYab7YgBQqCQMuJQ0cAkiZwkA1cjr4KdFD7V/qd0QiCbyV2EGwHjgIsKPwSz9...uV3Ep3BkpAlwMwYDEvFWY1zbFHamKa9hGq43WCrXQCuU4xZ5MdYYRNjpUy4PXebFQ7GqaTldU/KhbseC6TMmuBVtLi9Amy+dsUopHrfH9yTc1TOpQcnStbDkAP38xRBPvZkIgPHM6qQ2HiDZMxBofkWXvW4eEHk7v78696W7S2mwXQ8zrTi4+qHfljnhGDaZ2VND3D3SZmzoYqbjxolcYPE2p7qqeF5hI421LIzFCnEtVWORuCAuVQ0QIvfFotxuJsMB5g01VtsxwoaHeMp0CoQP9UpEaalAUZ9Rgk0B3VuPitpc3bnPE6GA867d+CyaXzMaNCMyslAb7a2cQnhOkiydlgHOasyoXN/+6kRz87w8V7AZq2PgmWb287XPO+yCIMaTrdHK8yl/u3Udq1uGdoObPFm7NLOO55fObRzm6EQPZjb3euwbzTMzmNW/DiE88JdvzLHull5+DSW7R8NV55/x+Snm4uvpECpc6fbexjaReNa5kDqgudGpM5PVAA " +
        "'unsafe-eval';" +
        "img-src 'self'; " +
        "connect-src 'self' wss://localhost:44385/INTEXAPP2/ ws://localhost:20275/9ef2184299d34e6c837624781258dec1/browserLinkSignalR/connect?transport=webSockets&connectionToken=AQAAANCMnd8BFdERjHoAwE%2FCl%2BsBAAAA91WL4%2BbGUE2DZUeBhEYswQAAAAACAAAAAAAQZgAAAAEAACAAAABmMt7bm3flzIP2Ete%2F%2FJyQFKnxr2JZ0B98MGz3uyL%2FagAAAAAOgAAAAAIAACAAAADxyoFHW4oLJ0NZBr0ajmtQcnX0Z1uUe5bFIOjCcN42qTAAAAC0ZbeacrjMljLJ2YRobKR9OblOvB5stUg%2FmniNmroOqpg5tXNHc%2FjGHUAW5aU9%2BUJAAAAAD90YFfWTQJMarXTP8lz08JqZ9uCrVdiFTfc7%2BgkI9ZBGAF6OKrwapwfQ9D0PDui%2Ft1sDSupvVXlJW%2B2UQlyDrg%3D%3D&requestUrl=https%3A%2F%2Flocalhost%3A7236%2F&browserName=&userAgent=Mozilla%2F5.0+(Windows+NT+10.0%3B+Win64%3B+x64)+AppleWebKit%2F537.36+(KHTML%2C+like+Gecko)+Chrome%2F111.0.0.0+Safari%2F537.36&browserIdKey=window.browserLink.initializationData.browserId&browserId=bb59-5cd3&tid=5 " +
        "http://localhost:20275/9ef2184299d34e6c837624781258dec1/browserLinkSignalR/negotiate?requestUrl=https%3A%2F%2Flocalhost%3A7236%2F&browserName=&userAgent=Mozilla%2F5.0+(Windows+NT+10.0%3B+Win64%3B+x64)+AppleWebKit%2F537.36+(KHTML%2C+like+Gecko)+Chrome%2F111.0.0.0+Safari%2F537.36&browserIdKey=window.browserLink.initializationData.browserId&browserId=7587-0667&clientProtocol=1.3&_=1681416009346;");

    await next();
});



app.UseCookiePolicy();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute("typepage", "", "{Controller=Home}/{action=BurialSummary}/{filter}/{pageNum}");
app.MapControllerRoute("Second", "{controller}/{action}/{id?}");
app.MapControllerRoute("Paging", "{controller=Home}/{action=BurialSummary}/{pageNum}");
app.MapControllerRoute("type", "{Controller =Home}/{action=BurialSummary}/{filter}/{pageNum=1}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapRazorPages();

app.Run();
