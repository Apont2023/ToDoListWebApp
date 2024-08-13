internal class Program
{
    private static void Main(string[] args)
    {
        // 1) Konfigurera och skapa själva applikationen. Den hanterar alla tjänster och middleware som behövs för applikationen.
        var builder = WebApplication.CreateBuilder(args);

        // 2) Lägga till tjänster 'Services' till DI-kontainer. 'AddControllersWithViews()' lägger till stöd för controllers och vyer, vilket är nödvändigt för att köra en MVC-applikation.
        builder.Services.AddControllersWithViews();

        // 3) Skapar en instans av WebApplication som används för att konfigurera och köra applikationen.
        var app = builder.Build();

        // 4) Konfigurera HTTP-request pipeline, vid fel HTTP Strict Transport Security aktiveras och tvingar webbläsaren använda HTTPS.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        // 5) Hantera HTPPS och statiska filer.
        // Omdirigerar alla HTTP-förfrågningar till HTTPS, vilket är viktigt för säkerhet.
        app.UseHttpsRedirection();

        // Gör det möjligt för applikationen att servera statiska filer som CSS, JavaScript, bilder etc. från wwwroot-mappen.
        app.UseStaticFiles();

        // 6) Aktiverar routing i applikationen, vilket är nödvändigt för att kunna matcha inkommande HTTP-förfrågningar till controllers och actions.
        app.UseRouting();

        // 7) Hantera användarautorisering, detta är en standardkomponent som förbereder appen för att hantera behörigheter om det behövs i framtiden.
        app.UseAuthorization();

        // 8) Konfigurera standardroute. Denna rutt innebär att om inget specifikt anges, kommer applikationen att använda HomeController och köra Index-action.
        //    Det valfria id-parametern kan användas för att skicka ett ID till action-metoden.
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        // Startar webapplikationen och börjar lyssna efter inkommande HTTP-förfrågningar.
        app.Run();
    }
}