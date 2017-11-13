using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using TSA.Mongo.Dto;
using TSA.Mongo.Entities;
using TSA.Mongo.Mongo;

namespace TSA.Mongo.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Insert()
        {
            var rep = new PessoaRepository();
            var dados = rep.BuscarPessoas();

            var col = GetCollection<PessoaDto>("pessoa");
            col.InsertMany(dados);
        }

        [TestMethod]
        public void Update()
        {
            var col = GetCollection<PessoaDto>("pessoa");
            var filter = Builders<PessoaDto>.Filter.Eq("_id", "b9b04ead-71cd-2544-af00-6916da538445");
            var update = Builders<PessoaDto>.Update.Set("Telefones.Operadora", "5");
            var result = col.UpdateOne(filter, update);
        }

        private IMongoCollection<T> GetCollection<T>(string collectionName) where T : class
        {
            var client = new MongoClient("mongodb://tania:tania123@localhost:27017");
            var database = client.GetDatabase("Sorriso");
            var col = database.GetCollection<T>(collectionName);
            return col;
        }

        [TestInitialize()]
        public void Initialize()
        {
            MongoDocumentConfig.RegisterClassMap();
        }
    }
}
