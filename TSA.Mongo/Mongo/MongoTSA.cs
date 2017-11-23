using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TSA.Mongo.Entities;

namespace TSA.Mongo.Mongo
{
    public class MongoTSA : IMongoTSA
    {
        private IMongoCollection<T> GetCollection<T>(string collectionName) where T : class
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Sorriso");
            var col = database.GetCollection<T>(collectionName);
            return col;
        }

        bool IMongoTSA.Add<TEntity>(string key, TEntity value)
        {
            throw new NotImplementedException();
        }

        bool IMongoTSA.AddRange<TEntity>(string key, List<TEntity> values) 
        {
            var collection = GetCollection<TEntity>(typeof(TEntity).Name);
            //return Enumerable.Empty<TEntity>();
            //foreach (var item in values)
            //    item.Key = key;
            collection.InsertMany(values);
            //});


            //var models = new List<WriteModel<TEntity>>();
            //foreach (var item in values)
            //{
            //    models.Add(new InsertOneModel<TEntity>(item));
            //}
            //collection.BulkWrite(models);
            return true;
        }



        //bool IMongoTSA.AddRangeAsync<TEntity>(string key, List<TEntity> values)
        //{
        //    var collection = GetCollection<TEntity>(nameof(TEntity));

        //    //foreach (var item in values)
        //    //    item.Key = key;
        //    Task.Run(async () =>
        //    {
        //        collection.InsertMany(values);
        //    };
        //    return true;
        //}

        List<TEntity> IMongoTSA.GetAll<TEntity>(string key)
        {
            throw new NotImplementedException();
        }

        List<TEntity> IMongoTSA.GetAll<TEntity>(string key, Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        TEntity IMongoTSA.GetFirstOrDefault<TEntity>(string key, Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        bool IMongoTSA.Remove(string key)
        {
            throw new NotImplementedException();
        }

        bool IMongoTSA.Remove<TEntity>(string key, Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        int IMongoTSA.RemoveRange<TEntity>(string key, Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        bool IMongoTSA.Update<TEntity>(string key, Func<TEntity, bool> predicate, TEntity value)
        {
            throw new NotImplementedException();
        }

        int IMongoTSA.UpdateRange<TEntity>(string key, Func<TEntity, bool> predicate, IEnumerable<TEntity> values)
        {
            throw new NotImplementedException();
        }
    }
}
