using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bursa.Models
{
    public class PaperData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var db = new ApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationContext>>()))
            {
                // Look for any papers.
                if (db.Papers.Any())
                {
                    return;   // DB has been created
                }
                BursaType btIsrael = new BursaType { Name = "Israel" };
                BursaType btUsa = new BursaType { Name = "Usa" };
                BursaType btEurope = new BursaType { Name = "Europe" };
                 db.BursaTypeList.AddRange(btIsrael, btUsa, btEurope);

                PaperType ptStock = new PaperType { Name = "מניות" , Bursa = btIsrael };
                db.PaperTypeList.AddRange(
                    ptStock,
                    new PaperType { Name = "איגרות חוב", Bursa = btIsrael },
                    new PaperType { Name = "קרנות", Bursa = btIsrael },
                    new PaperType { Name = " קרנות סל", Bursa = btIsrael },
                    new PaperType { Name = "מעו\"ף", Bursa = btIsrael },
                    new PaperType { Name = "הנפקות", Bursa = btIsrael },
                    new PaperType { Name = " מניות ארה\"ב", Bursa = btUsa },
                    new PaperType { Name = " אופציות ארה\"ב", Bursa = btUsa },
                    new PaperType { Name = "מניות אירוֹפה", Bursa = btEurope}
                    );
                db.Papers.AddRange(
                    new Paper
                    {

                        PaperName = "לאומי",
                        //paperBursa = b1,
                        PaperTypeValue = ptStock,
                        LastDeal = "13:55",
                        LastRate = 1684.4,
                        LastRatePercent = 2.99,
                        Amount = 1811
                    },
                    new Paper
                    {

                        PaperName = "טבע",
                        //paperBursa = b1,
                        PaperTypeValue = ptStock,
                        LastDeal = "14:25",
                        LastRate = 3185,
                        LastRatePercent = -0.22,
                        Amount = 740
                    }

                    );
                db.SaveChanges();
            }
        }
          
    }
}
