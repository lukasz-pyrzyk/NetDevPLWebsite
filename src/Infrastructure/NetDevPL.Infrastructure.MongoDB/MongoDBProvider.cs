﻿using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using NetDevPL.Infrastructure.SharedKernel;

namespace NetDevPL.Infrastructure.MongoDB
{
    public class MongoDBProvider<T>
    {
        private IMongoClient client;
        private IMongoDatabase database;
        private readonly string databaseName;

        private readonly string collectionName;

        public MongoDBProvider(string databaseName, string collectionName)
        {
            this.databaseName = databaseName;
            this.collectionName = collectionName;

            InitDB();
        }

        static MongoDBProvider()
        {
            BsonClassMap.RegisterClassMap<T>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
            });
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
        }

        public IMongoCollection<T> Collection => database.GetCollection<T>(collectionName);

        private void InitDB()
        {
            client = new MongoClient();

            Logger.Info(String.Format("Connecting to Mongo DB:{0} Collection:{1}",databaseName, collectionName));

            database = client.GetDatabase(databaseName);

            if (CollectionExists(database, collectionName)) return;

            CreateCollectionOptions options = new CreateCollectionOptions {AutoIndexId = true};
            database.CreateCollection(collectionName, options);
        }

        private bool CollectionExists(IMongoDatabase db, string collName)
        {
            try
            {
                var filter = new BsonDocument("name", collName);
                var collections = db.ListCollections(new ListCollectionsOptions {Filter = filter});
                return collections.Any();
            }
            catch (System.TimeoutException)
            {
                Logger.Fatal("Mongo Server is not responding. Make sure that MongoDB is properly installed.");
                throw;
            }
        }
    }
}