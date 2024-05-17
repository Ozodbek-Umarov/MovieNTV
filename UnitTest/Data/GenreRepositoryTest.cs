using Data.DbContexts;
using Data.Interfaces;
using Data.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace UnitTest.Data;

public class GenreRepositoryTest
{
    DbContextOptions<AppDbContext> options =
        new DbContextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase(databaseName: "movie-ntv")
        .Options;

    AppDbContext dbContext;
    IUnitOfWork unitOfWork;

    [TearDown]
    public void SetUp()
    {
        dbContext = new AppDbContext(options);
        unitOfWork = new UnitOfWork(dbContext);
    }

    [Test]
    public async Task AddAsync()
    {
        var genres = new Genre() { Name = "Test", Description = "Yana Test", CreatedAt = DateTime.UtcNow };
        await unitOfWork.Genre.CreateAsync(genres);

        var result = await dbContext.Genres.FirstOrDefaultAsync(p => p.Name == genres.Name);

        Assert.That(result, Is.Not.Null);
    }
}

