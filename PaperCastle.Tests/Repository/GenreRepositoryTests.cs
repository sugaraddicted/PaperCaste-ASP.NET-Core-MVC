using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using NUnit.Framework;
using PaperCastle.Core.Entity;
using PaperCastle.Infrastructure.Data;
using PaperCastle.Infrastructure.Data.Repository;

namespace PaperCastle.Tests.Repository
{
    [TestFixture]
    public class GenreRepositoryTests
    {
        private async Task<DataContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new DataContext(options);
            databaseContext.Database.EnsureCreated();

            if(await databaseContext.Genres.CountAsync() <= 0)
            {
                for(int i = 1; i <= 10; i++) {
                    databaseContext.Genres.Add(
                        new Genre()
                        {
                            Id = i,
                            Name = $"Genre{i}",
                            Description = $"Genre{i} description"
                        });
                    await databaseContext.SaveChangesAsync();
                }

            }
            return databaseContext;
        }

        [Test]
        public async Task GenreRepository_CreateGenre_ReturnsBool()
        {
            //Arrange
            var genre = new Genre() { Name = "NewGenre",
                                      Description = "New genre description"};
            var dbContext = await GetDbContext();
            var genreRepository = new GenreRepository(dbContext);

            //Act
            var result = genreRepository.CreateGenre(genre);

            //Assert
            Assert.That(result, Is.True);
        }
        
        [Test]
        public async Task GenreRepository_GetGenreById_ReturnsNeededGenre()
        {
            //Arrange
            var id = 1;
            var dbContext = await GetDbContext();
            var genreRepository = new GenreRepository(dbContext);

            //Act
            var result = genreRepository.GetGenreById(id);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.IsInstanceOf<Genre>(result);
        }


        [Test]
        public async Task GenreRepository_DeleteGenre_ReturnsBool()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var genreRepository = new GenreRepository(dbContext);
            var genre = dbContext.Genres.FirstOrDefault(g => g.Id == 1);

            //Act
            var result = genreRepository.DeleteGenre(genre);

            //Assert
            Assert.That(result, Is.True);
            Assert.That(!dbContext.Genres.Contains(genre));
        }



    }
}
