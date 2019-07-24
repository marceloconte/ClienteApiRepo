using Clientes.Domain.Data.Mongo.Database;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Clientes.Domain.Data.Mongo.Repositories
{
    internal abstract class RepositoryBase<T>
    {
        protected IMongoCollection<T> _coll;

        public RepositoryBase()
        {
            DataBaseService.Initialize();

            _coll = DataBaseService.Database.GetCollection<T>("cliente_tb");
        }

        public List<T> GetAll()
        {
            return _coll.Find(_ => true).ToList();
        }

        public T GetBy(Expression<Func<T, bool>> filter)
        {
            return _coll.Find(filter).FirstOrDefault();
        }

        public bool Exist(Expression<Func<T, bool>> filter)
        {
            return GetBy(filter) != null;
        }

        public void Remove(Expression<Func<T, bool>> filter)
        {
            _coll.FindOneAndDelete<T>(filter);
        }

        public void Insert(T obj)
        {
            _coll.InsertOne(obj);
        }

        public void Insert(List<T> obj)
        {
            _coll.InsertMany(obj);
        }


    }
}
