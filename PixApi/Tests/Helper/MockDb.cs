﻿using Microsoft.EntityFrameworkCore;
using PixApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Helper
{
    internal class MockDb : IDbContextFactory<ApiDbContext>
    {
        public ApiDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase($"InMemoryTestDb-{DateTime.Now.ToFileTimeUtc()}")
                .Options;

            return new ApiDbContext(options);
        }
    }
}
