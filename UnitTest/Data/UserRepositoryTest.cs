using Data.DbContexts;
using Data.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using UnitTest.Helpers;

namespace UnitTest.Data;

public class UserRepositoryTest
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
        var users = new User() { Email = "qwertyuioigf@gmail.com", FirstName = "Ozodbek", LastName = "Umarov", Password = "bsjhdevbjzd$#$" };
        await unitOfWork.User.CreateAsync(users);
        var result = await dbContext.Users.FirstOrDefaultAsync(p => p.Email == users.Email);

        Assert.That(result, Is.Not.Null);
    }

    [TearDown]
    public void TearDown()
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Dispose();
    }
}
