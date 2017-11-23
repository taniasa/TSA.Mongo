using System;
using System.Collections.Generic;
using System.Text;
using TSA.Mongo.Entities;

namespace TSA.Mongo.Mongo
{
    public interface IMongoTSA
    {

        /// <summary>
        /// Realiza o update no cache
        /// </summary>
        /// <param name="key">A chave.</param>
        /// <param name="predicate">A condição</param>
        /// <param name="value">O valor para ser alterado</param>
        /// <returns></returns>
        bool Update<TEntity>(string key, Func<TEntity, bool> predicate, TEntity value) where TEntity : class;

        /// <summary>
        /// Alterar vários valores
        /// </summary>
        /// <param name="key">A chave.</param>
        /// <param name="predicate">A condição</param>
        /// <param name="values">Os valores para serem alterados</param>
        /// <returns></returns>
        int UpdateRange<TEntity>(string key, Func<TEntity, bool> predicate, IEnumerable<TEntity> values) where TEntity : class;

        ///// <summary>
        ///// Realiza o update no cache
        ///// </summary>
        ///// <param name="key">A chave.</param>
        ///// <param name="predicate">A condição</param>
        ///// <param name="value">O valor para ser alterado</param>
        ///// <returns></returns>
        //bool Update<TEntity>(string key, Func<TEntity, bool> predicate, string value) where TEntity : class;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Remove(string key);
        /// <summary>
        /// Deleta o primeiro encontrado de acordo com a condição
        /// </summary>
        /// <param name="key">Chave</param>
        /// <param name="predicate">Condição</param>
        /// <returns></returns>
        bool Remove<TEntity>(string key, Func<TEntity, bool> predicate) where TEntity : class;

        /// <summary>
        /// Deletar todos encontrados de acordo com a condição
        /// </summary>
        /// <param name="key">Chave</param>
        /// <param name="predicate">Condição</param>
        /// <returns></returns>
        int RemoveRange<TEntity>(string key, Func<TEntity, bool> predicate) where TEntity : class;


        /// <summary>
        /// Adiciona um objeto no índice da <paramref name="key"/>.
        /// </summary>
        /// <param name="key">A chave.</param>
        /// <param name="value">O valor.</param>
        bool Add<TEntity>(string key, TEntity value) where TEntity : class;

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //bool Add<TEntity>(string key, string value) where TEntity : class;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        bool AddRange<TEntity>(string key, List<TEntity> values) where TEntity : class, IDto;

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="values"></param>
        ///// <returns></returns>
        //bool AddRange<TEntity>(string key, string values) where TEntity : class;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        List<TEntity> GetAll<TEntity>(string key) where TEntity : class;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<TEntity> GetAll<TEntity>(string key, Func<TEntity, bool> predicate) where TEntity : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="key"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity GetFirstOrDefault<TEntity>(string key, Func<TEntity, bool> predicate) where TEntity : class;
    }
}
