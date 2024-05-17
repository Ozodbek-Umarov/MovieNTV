using Data.DbContexts;
using Data.Interfaces;
using Data.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using UnitTest.Helpers;

namespace UnitTest.Data;

public class GenreRepositoryTest
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
        var genres = new Genre() { Name = "Test", Description = "Yana Test"};
        await unitOfWork.Genre.CreateAsync(genres);

        var result = await dbContext.Genres.FirstOrDefaultAsync(p => p.Name == genres.Name);

        Assert.That(result, Is.Not.Null);
    }

    [TearDown]
    public void TearDown()
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Dispose();
    }
}
