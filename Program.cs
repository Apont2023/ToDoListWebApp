internal class Program
{
    private static void Main(string[] args)
    {
        // 1) Konfigurera och skapa sj�lva applikationen. Den hanterar alla tj�nster och middleware som beh�vs f�r applikationen.
        var builder = WebApplication.CreateBuilder(args);

        // 2) L�gga till tj�nster 'Services' till DI-kontainer. 'AddControllersWithViews()' l�gger till st�d f�r controllers och vyer, vilket �r n�dv�ndigt f�r att k�ra en MVC-applikation.
        builder.Services.AddControllersWithViews();

        // 3) Skapar en instans av WebApplication som anv�nds f�r att konfigurera och k�ra applikationen.
        var app = builder.Build();

        // 4) Konfigurera HTTP-request pipeline, vid fel HTTP Strict Transport Security aktiveras och tvingar webbl�saren anv�nda HTTPS.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        // 5) Hantera HTPPS och statiska filer.
        // Omdirigerar alla HTTP-f�rfr�gningar till HTTPS, vilket �r viktigt f�r s�kerhet.
        app.UseHttpsRedirection();

        // G�r det m�jligt f�r applikationen att servera statiska filer som CSS, JavaScript, bilder etc. fr�n wwwroot-mappen.
        app.UseStaticFiles();

        // 6) Aktiverar routing i applikationen, vilket �r n�dv�ndigt f�r att kunna matcha inkommande HTTP-f�rfr�gningar till controllers och actions.
        app.UseRouting();

        // 7) Hantera anv�ndarautorisering, detta �r en standardkomponent som f�rbereder appen f�r att hantera beh�righeter om det beh�vs i framtiden.
        app.UseAuthorization();

        // 8) Konfigurera standardroute. Denna rutt inneb�r att om inget specifikt anges, kommer applikationen att anv�nda HomeController och k�ra Index-action.
        //    Det valfria id-parametern kan anv�ndas f�r att skicka ett ID till action-metoden.
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        // Startar webapplikationen och b�rjar lyssna efter inkommande HTTP-f�rfr�gningar.
        app.Run();
    }
}