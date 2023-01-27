using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace DriverTracking.Models
{
    public class DbConnect
    {
        string connectionUrl = "";
        public IMongoDatabase database;
        public DbConnect()
        {
            connectionUrl = "mongodb://" + Program.Serverdbuser + ":" + Program.Serverdbpass + "@" + Program.ServerIP + ":27017"  + "/" + Program.Serverdbname + "";

            var mongoClient = new MongoClient(connectionUrl);
            database = mongoClient.GetDatabase(Program.Serverdbname);

        }

    }
}
