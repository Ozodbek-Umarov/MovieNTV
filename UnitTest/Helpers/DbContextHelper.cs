﻿using Data.DbContexts;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace UnitTest.Helpers;

public static class DbContextHelper
{
    private static readonly DbContextOptions<AppDbContext> options =
        new DbContextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase(databaseName: "movie-app-db")
        .Options;

    public static AppDbContext GetDbContext()
        => new AppDbContext(options);

    public static IUnitOfWork GetUnitOfWork()
        => new UnitOfWork(GetDbContext());
}
