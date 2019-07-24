using MongoDB.Driver;

namespace Clientes.Domain.Data.Mongo.Database
{
    public static class DataBaseService
    {
        public static string Connection = "mongodb://localhost:27017";
        public static MongoClient Client;
        public static IMongoDatabase Database;

        public static void Initialize()
        {
            Client = new MongoClient(Connection);
            Database = Client.GetDatabase("Clientes_db");
            Database.CreateCollectionAsync("cliente_tb");

        }

    }
}
