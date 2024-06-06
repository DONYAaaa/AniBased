using AniBased.Repository.Interface;
using AniBased.Repository;
using Microsoft.Extensions.DependencyInjection;
using Bogus;
using AniBased.Model.BLL.Service;
using AniBased.Model.BLL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using AniBased.DAL;
using System.Linq;

namespace AniBased.Generator
{
    internal class GeneratorDB
    {
        public async Task Generate()
        {
            string connectionString = "Host=localhost;Username=ed;Password=22041977;Database=AniBASED"; ;
            var serviceProvider = new ServiceCollection()
                .AddScoped<IAnimeRepository, AnimeRepository>(provider => new AnimeRepository(connectionString))
                .AddScoped<IAnimeGenreRepository, AnimeGenreRepository>(provider => new AnimeGenreRepository(connectionString))
                .AddScoped<IAnimeStudioRepository, AnimeStudioRepository>(provider => new AnimeStudioRepository(connectionString))
                .AddScoped<IGenreRepository, GenreRepository>(provider => new GenreRepository(connectionString))
                .AddScoped<IPageAnimeRepository, PageAnimeRepository>(provider => new PageAnimeRepository(connectionString))
                .AddScoped<IPageRepository, PageRepository>(provider => new PageRepository(connectionString))
                .AddScoped<IStudioRepository, StudioRepository>(provider => new StudioRepository(connectionString))
                .AddScoped<IUserPageRepository, UserPageRepository>(provider => new UserPageRepository(connectionString))
                .AddScoped<IUserRepository, UserRepository>(provider => new UserRepository(connectionString))

                .AddScoped<AnimeGenreRepository>()
                .AddScoped<AnimeService>()
                .AddScoped<AnimeStudioService>()
                .AddScoped<GenreService>()
                .AddScoped<PageAnimeService>()
                .AddScoped<PageService>()
                .AddScoped<StudioService>()
                .AddScoped<UserPageRepository>()
                .AddScoped<UserService>()

                .BuildServiceProvider();

            // Пример использования сервисов 
            var animeService = serviceProvider.GetService<AnimeService>();
            var genreService = serviceProvider.GetService<GenreService>();
            var animeGenreService = serviceProvider.GetService<AnimeGenreService>();
            var animeStudioService = serviceProvider.GetService<AnimeStudioService>();
            var pageAnimeService = serviceProvider.GetService<PageAnimeService>();
            var pageService = serviceProvider.GetService<PageService>();
            var studioService = serviceProvider.GetService<StudioService>();
            var userPageService = serviceProvider.GetService<UserPageService>();
            var userService = serviceProvider.GetService<UserService>();

            var genre = GenerateGenre();
            foreach (var item in genre)
            {
                await genreService.CreateGenre(item);
            }

            //var workers = GenerateWorker();
            //foreach (var item in workers)
            //{
            //    workerService.CreateWorker(item);
            //}

            //var installation = GenerateInstallation();
            //var organization = organizationService.GetOrganizationById(5);
            //foreach (var item in installation)
            //{
            //    item.IdOrganization = 5;
            //}
            //foreach (var item in installation)6
            //{
            //    installationService.CreateInstallation(item);
            //}

            //var installationWorker = GenerateInstallation();
            //var worker = workerService.GetWorkerById(5); 
            //foreach (var item in installationWorker) 
            //{ 
            //    installationWorkerService.CreateInstallation(item, worker); 
            //} 

            //var reports = GenerateReport();
            //foreach (var item in reports)
            //{
            //    reportService.CreateReport(item);
            //}
        }

        private async Task AddGenresAsync(IEnumerable<Genre> genres, GenreService genreService)
        {
            var tasks = genres.Select(async genre =>
            {
                await genreService.CreateGenre(genre);
            });

            await Task.WhenAll(tasks);
        }

        private List<Genre> GenerateGenre()
        {
            var faker = new Faker<Genre>()
                .CustomInstantiator(f => new Genre(
                    id: f.Random.Int(min: 0),
                    name: "qwe",
                    description: f.Lorem.Sentence()
                ));
            return faker.Generate(1000);
        }

        private List<Studio> GenerateStudio()
        {
            var faker = new Faker<Studio>()
                .CustomInstantiator(f => new Studio(
                    name: f.Lorem.Word(),
                    description: f.Lorem.Sentence()
                ));
            return faker.Generate(1000);
        }




        //private List<InstallationWorker> GenerateInstallationWorker()
        //{
        //    var faker = new Faker<InstallationWorker>()
        //        .CustomInstantiator(f => new InstallationWorker(
        //            id: f.Random.Int(min: 0),
        //            idInstallation: f.Random.Int(min: 0, max: 100),
        //            idWorker: f.Random.Int(min: 0, max: 1000)
        //        ));
        //    return faker.Generate(1000);
        //}

        //private List<Organization> GenerateOrganization()
        //{
        //    var faker = new Faker<Organization>()
        //        .CustomInstantiator(f => new Organization(
        //            id: f.Random.Int(min: 0),
        //            name: f.Company.CompanyName(),
        //            numberOfSetups: f.Random.Int(min: 0)
        //        ));
        //    return faker.Generate(1000);
        //}

        //private List<Worker> GenerateWorker()
        //{
        //    var faker = new Faker<Worker>()
        //        .CustomInstantiator(f => new Worker(
        //            id: f.Random.Int(min: 0),
        //            lastName: f.Name.LastName(),
        //            firstName: f.Name.FirstName(),
        //            middleName: f.Name.FirstName() // Use first name as middle name 
        //        ));
        //    return faker.Generate(1000);
        //}

        //private List<Report> GenerateReport()
        //{
        //    var faker = new Faker<Report>()
        //        .CustomInstantiator(f => new Report(
        //    id: f.Random.Int(min: 0, max: 1000),
        //    phototrace: f.Random.Bytes(8),
        //    dateTime: f.Date.Between(new DateTime(2024, 1, 1), DateTime.Now),
        //    diagnosis: f.Random.Bool(),
        //    height: ValidateAndRoundHeight(f.Random.Double(200, 250)),
        //    outerdiameter: ValidateAndRoundOutsideDiameter(f.Random.Double(100, 230)),
        //    innerDiameter: ValidateAndRoundInnerDiameter(f.Random.Double(10, 150)),
        //    coilDiameter: ValidateAndRoundCoilDiameter(f.Random.Double(5, 35)),
        //    perpendicularity: ValidateAndRoundPerpendicularity(f.Random.Double(0, 30)),
        //    kit: f.Random.Int(min: 0),
        //    springMarker: f.Random.Int(min: 0),
        //    cartType: f.Lorem.Word(),
        //    idInstallationWorker: f.Random.Int(min: 5, max: 1004)
        //));
        //    return faker.Generate(1000);
        //}

        //private double ValidateAndRoundHeight(double height)
        //{
        //    if (height < 200 || height > 250)
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(height), "Недопустимое значение для высоты");
        //    }

        //    return Math.Round(height, 1);
        //}

        //private double ValidateAndRoundOutsideDiameter(double outsideDiameter)
        //{
        //    if (outsideDiameter < 100 || outsideDiameter > 230)
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(outsideDiameter), "Недопустимое значение для наружного диаметра");
        //    }

        //    return Math.Round(outsideDiameter, 1);
        //}

        //private double ValidateAndRoundInnerDiameter(double innerDiameter)
        //{
        //    if (innerDiameter < 10 || innerDiameter > 150)
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(innerDiameter), "Недопустимое значение для внутреннего диаметра");
        //    }

        //    return Math.Round(innerDiameter, 1);
        //}

        //private double ValidateAndRoundCoilDiameter(double coilDiameter)
        //{
        //    if (coilDiameter < 5 || coilDiameter > 35)
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(coilDiameter), "Недопустимое значение для диаметра витка");
        //    }

        //    return Math.Round(coilDiameter, 1);
        //}

        //private double ValidateAndRoundPerpendicularity(double perpendicularity)
        //{
        //    if (perpendicularity < 0 || perpendicularity > 30)
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(perpendicularity), "Недопустимое значение для перпендикулярности");
        //    }

        //    return Math.Round(perpendicularity, 1);
        //}
    }
}
