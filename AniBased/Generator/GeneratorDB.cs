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
            string connectionString = "Host=localhost;Username=ed;Password=22041977;Database=AniBASED";
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

            var genre = GenerateStudio();
            foreach (var item in genre)
            {
                await studioService.CreateStudio(item);
            }
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
                    name: f.Lorem.Word()+$"{f.Random.Int(min: 0, max: 100)}" + $"{f.Random.Int(min: 0, max: 100)}",
                    description: f.Lorem.Sentence()
                ));
            return faker.Generate(1000);
        }

        private List<Studio> GenerateStudio()
        {
            var faker = new Faker<Studio>()
                .CustomInstantiator(f => new Studio(
                    name: f.Lorem.Word() + $"{f.Random.Int(min: 0, max: 100)}" + $"{f.Random.Int(min: 0, max: 100)}",
                    description: f.Lorem.Sentence()
                ));
            return faker.Generate(1000);
        }
    }
}
