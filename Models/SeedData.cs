
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using PROJET_C.Data;
    using System;
    using System.Linq;
    namespace PROJET_C.Models;
    public static class SeedData // Ajout d’une nouvelle classe SeedData dans Models pour créer la base et ajouter un film si besoin
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
        using (var context = new PROJET_CContext(
        serviceProvider.GetRequiredService<
        DbContextOptions<PROJET_CContext>>()))
        {

            context.Database.EnsureCreated();
            // S’il y a déjà des films dans la base
            /*if (context.Continent.Any())
            {
                return; // On ne fait rien
            }*/
            
                // Sinon on en ajoute un
                context.Continent.AddRange(
                new Continent
                {
                    nom = "Europe",
                    Pays = new List<Pay>()
                }
                );
                context.SaveChanges();
            }
        
        using (var context = new PROJET_CContext(
        serviceProvider.GetRequiredService<
        DbContextOptions<PROJET_CContext>>()))
        {

            context.Database.EnsureCreated();
            // S’il y a déjà des films dans la base
            /*if (context.Pay.Any())
            {
                return; // On ne fait rien
            }*/
            
                // Sinon on en ajoute un
                context.Pay.AddRange(
                new Pay
                {
                    nom = "France",
                    ContinentId = 1,
                    Populations = new List<Population>()
                }
                );
                context.SaveChanges();
            
        }
        using (var context = new PROJET_CContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<PROJET_CContext>>()))
        {

            context.Database.EnsureCreated();
            // S’il y a déjà des films dans la base
           /* if (context.Population.Any())
            {
                return; // On ne fait rien
            }*/
            
                // Sinon on en ajoute un
                context.Population.AddRange(
                new Population
                {
                    Year = "2002",
                    nombre = 9876,
                    PayId = 2
                }
                );
                context.SaveChanges();

            }
        
    }
    }

