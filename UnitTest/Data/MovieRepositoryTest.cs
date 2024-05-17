using Data.DbContexts;
using Data.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using UnitTest.Helpers;

namespace UnitTest.Data;

public class MovieRepositoryTest
{
    AppDbContext dbContext;
    IUnitOfWork unitOfWork;

    [SetUp]
    public void SetUp()
    {
        dbContext = DbContextHelper.GetDbContext();
        unitOfWork = DbContextHelper.GetUnitOfWork();
    }

    [Test]
    [TestCase("Test1")]
    [TestCase("Test2")]
    [TestCase("Test3")]
    [TestCase("Test4")]
    [TestCase("Test5")]

    public async Task AddAsync(string name)
    {
        var movie = new Movie() { Company = "qwert", Description = "qwertyu", Director = "qwertyu", Country = "qwerty", Duration = 123, Title = "qwertyui", Year = 2024 };
        await unitOfWork.Movie.CreateAsync(movie);

        var result = await dbContext.Movies.FirstOrDefaultAsync(p => p.Title == movie.Title);

        Assert.That(result, Is.Not.Null);
    }


        [TearDown]
    public void TearDown()
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Dispose();
    }
}
