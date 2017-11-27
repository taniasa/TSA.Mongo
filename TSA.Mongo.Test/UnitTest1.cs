using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
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
        public void InsertMany()
        {
            var rep = new PessoaRepository();
            var dados = rep.BuscarPessoas();
            var total = dados.Count;
            IMongoTSA tsa = new MongoTSA();
            Help.Restart();
            tsa.AddRange("chaveTania1", dados);
            Help.Stop($"Total insert many: {total}");
        }

        [TestMethod]
        public void InsertManyText()
        {
            var rep = new PessoaRepository();
            var dados = rep.BuscarPessoas();
            var total = dados.Count;
            IMongoTSA tsa = new MongoTSA();
            Help.Restart();
            //foreach (var item in dados)
            //    item.Key = "chaveTania1";
            var values=  JsonConvert.SerializeObject(dados);

            tsa.AddRanges<PessoaDto>("chaveTania1", values);
            Help.Stop($"Total insert many: {total}");

        }

        [TestMethod]
        public void InsertManyAsync()
        {
            InsertManyAsyncInt();
        }

        public void InsertManyAsyncInt()
        {
            var rep = new PessoaRepository();
            var dados = rep.BuscarPessoas();
            System.IO.File.WriteAllText(Help.FileJson, JsonConvert.SerializeObject(dados));
            var total = dados.Count;
            IMongoTSA tsa = new MongoTSA();
            Help.Restart();
            tsa.AddRangeAsync("chaveTania1", dados);

            Help.Stop($"Total insert many: {total}");

        }



        [TestMethod]
        public void GetAllWithFilter()
        {
            IMongoTSA tsa = new MongoTSA();
            var teste = tsa.GetAll<PessoaDto>("chaveTania1", w => w.Nome.ToLower().Contains("tania"));
        }

        [TestMethod]
        public void RemoveAll()
        {
            IMongoTSA tsa = new MongoTSA();
            var teste = tsa.Remove<PessoaDto>("chaveTania1");
        }

        [TestMethod]
        public void RemovePredicate()
        {
            IMongoTSA tsa = new MongoTSA();
            var teste = tsa.Remove<PessoaDto>("chaveTania1", x => x.Id == 1);
        }

        [TestMethod]
        public void GetOne()
        {
            var col = GetCollection<PessoaDto>("pessoa");
            var filter = Builders<PessoaDto>.Filter.Eq(s => s.IdDto, "5a067f6e7e2bb73260f02389");
            var result = col.Find(filter).ToList();
        }

        [TestMethod]
        public void Update()
        {
            var col = GetCollection<PessoaDto>("pessoa");
            var _id = new ObjectId("5a067f6e7e2bb73260f02389");
            var filter = Builders<PessoaDto>.Filter.Eq(s => s.IdDto, _id);
            //teste/
            //var update = Builders<PessoaDto>.Update.Set(s=>s.Situacao, 2);

            //var update = Builders<PessoaDto>.Update.Set("Telefones.$.Operadora", "6");
            var update = Builders<PessoaDto>.Update.Set("Situacao", "6");

            var result = col.UpdateMany(filter, update);
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
