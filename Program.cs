using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bursa.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Bursa
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    PaperData.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        //private static void  CreateDatabase()
        //{
        //    var builder = new ConfigurationBuilder();
        //    // установка пути к текущему каталогу
        //    builder.SetBasePath(Directory.GetCurrentDirectory());
        //    // получаем конфигурацию из файла appsettings.json
        //    builder.AddJsonFile("appsettings.json");
        //    // создаем конфигурацию
        //    var config = builder.Build();
        //    string connectionString = config.GetConnectionString("DefaultConnection");
        //    var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        //    var options = optionsBuilder
        //        .UseSqlServer(connectionString)
        //        .Options;
        //    using (ApplicationContext db = new ApplicationContext(options))
        //    {
        //        if(db.Papers.le)
        //        Paper paper1 = new Paper
        //        {
        //            paperId = 1
        //                        ,
        //            paperName = "לאומי"
        //                        ,
        //            paperBursa = Enums.BursaEnum.Israel
        //                        ,
        //            paperType = Enums.PaperTypeEnum.Stocks
        //                        ,
        //            LastDeal = "13:55"
        //                        ,
        //            lastRate = 1684.4
        //                        ,
        //            lastRatePercent = 2.99
        //                        ,
        //            Amount = 1811
        //        };
        //        Paper paper2 = new Paper
        //        {
        //            paperId = 2
        //                            ,
        //            paperName = "טבע"
        //                            ,
        //            paperBursa = Enums.BursaEnum.Israel
        //                            ,
        //            paperType = Enums.PaperTypeEnum.Stocks
        //                            ,
        //            LastDeal = "14:25"
        //                            ,
        //            lastRate = 3185
        //                            ,
        //            lastRatePercent = -0.22
        //                            ,
        //            Amount = 740
        //        };
        //        db.Papers.Add(paper1);
        //        db.Papers.Add(paper2);
        //        db.SaveChanges();

        //    }


        //}
    }
}
