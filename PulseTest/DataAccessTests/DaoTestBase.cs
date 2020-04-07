using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PulsePI.Models;

namespace PulseTest.DataAccessTests
{
    public class DaoTestBase
    {
        public DbContextOptions<PulsePiDBContext> GetTestOptions()
        {
            return new DbContextOptionsBuilder<PulsePiDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
        }
    }
}
