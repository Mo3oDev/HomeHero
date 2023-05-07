using Microsoft.EntityFrameworkCore;
using HomeHero.Data;

namespace HomeHero.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HomeHeroContext(
                serviceProvider.GetRequiredService<DbContextOptions<HomeHeroContext>>()))
            {
                if (context.Roles.Any()) return;
                context.Roles.AddRange(
                    new Role
                    {
                        NameRole = "Admon"
                    },
                    new Role
                    {
                        NameRole = "User"
                    }, new Role
                    {
                        NameRole = "PUser"
                    }, new Role
                    {
                        NameRole = "Reviewer"
                    }, new Role
                    {
                        NameRole = "TSupport"
                    }
                    );
                if (context.Locations.Any())
                    return;
                context.Locations.AddRange(
                    new Location { City = "AGUA DE DIOS" },
                    new Location { City = "ALBAN" },
                    new Location { City = "ANAPOIMA" },
                    new Location { City = "ANOLAIMA" },
                    new Location { City = "APULO" },
                    new Location { City = "ARBELAEZ" },
                    new Location { City = "BELTRAN" },
                    new Location { City = "BITUIMA" },
                    new Location { City = "BOJACA" },
                    new Location { City = "CABRERA" },
                    new Location { City = "CACHIPAY" },
                    new Location { City = "CAJICA" },
                    new Location { City = "CAPARRAPI" },
                    new Location { City = "CAQUEZA" },
                    new Location { City = "CARMEN DE CARUPA" },
                    new Location { City = "CHAGUANI" },
                    new Location { City = "CHIA" },
                    new Location { City = "CHIPAQUE" },
                    new Location { City = "CHOACHI" },
                    new Location { City = "CHOCONTA" },
                    new Location { City = "COGUA" },
                    new Location { City = "COTA" },
                    new Location { City = "CUCUNUBA" },
                    new Location { City = "EL COLEGIO" },
                    new Location { City = "EL PEÑON" },
                    new Location { City = "EL ROSAL" },
                    new Location { City = "FACATATIVA" },
                    new Location { City = "FOMEQUE" },
                    new Location { City = "FOSCA" },
                    new Location { City = "FUNZA" },
                    new Location { City = "FUQUENE" },
                    new Location { City = "FUSAGASUGA" },
                    new Location { City = "GACHALA" },
                    new Location { City = "GACHANCIPA" },
                    new Location { City = "GACHETA" },
                    new Location { City = "GAMA" },
                    new Location { City = "GIRARDOT" },
                    new Location { City = "GRANADA" },
                    new Location { City = "GUACHETA" },
                    new Location { City = "GUADUAS" },
                    new Location { City = "GUASCA" },
                    new Location { City = "GUATAQUI" },
                    new Location { City = "GUATAVITA" },
                    new Location { City = "GUAYABAL DE SIQUIMA" },
                    new Location { City = "GUAYABETAL" },
                    new Location { City = "GUTIERREZ" },
                    new Location { City = "JERUSALEN" },
                    new Location { City = "JUNIN" },
                    new Location { City = "LA CALERA" },
                    new Location { City = "LA MESA" },
                    new Location { City = "LA PALMA" },
                    new Location { City = "LA PEÑA" },
                    new Location { City = "LA VEGA" },
                    new Location { City = "LENGUAZAQUE" },
                    new Location { City = "MACHETA" },
                    new Location { City = "MADRID" },
                    new Location { City = "MANTA" },
                    new Location { City = "MEDINA" },
                    new Location { City = "MOSQUERA" },
                    new Location { City = "NARIÑO" },
                    new Location { City = "NEMOCON" },
                    new Location { City = "NILO" },
                    new Location { City = "NIMAIMA" },
                    new Location { City = "NOCAIMA" },
                    new Location { City = "PACHO" },
                    new Location { City = "PAIME" },
                    new Location { City = "PANDI" },
                    new Location { City = "PARATEBUENO" },
                    new Location { City = "PASCA" },
                    new Location { City = "PUERTO SALGAR" },
                    new Location { City = "PULI" },
                    new Location { City = "QUEBRADANEGRA" },
                    new Location { City = "QUETAME" },
                    new Location { City = "QUIPILE" },
                    new Location { City = "RICAURTE" },
                    new Location { City = "SAN ANTONIO DE TEQUENDAMA" },
                    new Location { City = "SAN BERNARDO" },
                    new Location { City = "SAN CAYETANO" },
                    new Location { City = "SAN FRANCISCO" },
                    new Location { City = "SAN JUAN DE RIO SECO" },
                    new Location { City = "SASAIMA" },
                    new Location { City = "SESQUILE" },
                    new Location { City = "SIBATE" },
                    new Location { City = "SILVANIA" },
                    new Location { City = "SIMIJACA" },
                    new Location { City = "SOACHA" },
                    new Location { City = "SOPO" },
                    new Location { City = "SUBACHOQUE" },
                    new Location { City = "SUESCA" },
                    new Location { City = "SUPATA" },
                    new Location { City = "SUSA" },
                    new Location { City = "SUTATAUSA" },
                    new Location { City = "TABIO" },
                    new Location { City = "TAUSA" },
                    new Location { City = "TENA" },
                    new Location { City = "TENJO" },
                    new Location { City = "TIBACUY" },
                    new Location { City = "TIBIRITA" },
                    new Location { City = "TOCAIMA" },
                    new Location { City = "TOCANCIPA" },
                    new Location { City = "TOPAIPI" },
                    new Location { City = "UBALA" },
                    new Location { City = "UBAQUE" },
                    new Location { City = "UBATE" },
                    new Location { City = "UNE" },
                    new Location { City = "UTICA" },
                    new Location { City = "VENECIA" },
                    new Location { City = "VERGARA" },
                    new Location { City = "VIANI" },
                    new Location { City = "VILLAGOMEZ" },
                    new Location { City = "VILLAPINZON" },
                    new Location { City = "VILLETA" },
                    new Location { City = "VIOTA" },
                    new Location { City = "YACOPI" },
                    new Location { City = "ZIPACON" },
                    new Location { City = "ZIPAQUIRA" });
                context.SaveChanges();
            }
        }
    }
}
