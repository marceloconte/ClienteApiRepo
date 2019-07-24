using Clientes.Domain.Data.Mongo.Database;
using System;
using Xunit;

namespace Clientes.Test
{
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            DataBaseService.Initialize();

        }

        public void Dispose()
        {

        }
    }

    [CollectionDefinition("DatabaseInitialize")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
