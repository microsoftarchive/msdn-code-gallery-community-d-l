using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Api.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Api.DbContext
{
    public class ProductContext
    {
        public const string CONNECTION_STRING_NAME = "productmgmt";
        public const string DATABASE_NAME = "ProductsManagement";
        public const string PRODUCTS_COLLECTION_NAME = "Products";

        // This is ok... Normally, they would be put into
        // an IoC container.
        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;
        
        static ProductContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME].ConnectionString;
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(DATABASE_NAME);
        }

        public IMongoClient Client
        {
            get { return _client; }
        }

        public IMongoCollection<Product> Products
        {
            get { return _database.GetCollection<Product>(PRODUCTS_COLLECTION_NAME); }
        }
    }
}