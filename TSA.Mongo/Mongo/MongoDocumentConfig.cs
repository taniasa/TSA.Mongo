using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;
using TSA.Mongo.Dto;

namespace TSA.Mongo.Mongo
{
    public static class MongoDocumentConfig
    {
        public static void RegisterClassMap()
        {
            BsonClassMap.RegisterClassMap<PessoaDto>(x =>
                {
                    x.AutoMap();
                    x.SetIdMember(x.GetMemberMap(c => c.IdDto));
                    x.IdMemberMap.SetIdGenerator(ObjectIdGenerator.Instance);
                });
        }
    }
}
