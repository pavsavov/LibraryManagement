using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services.BookService.Contracts
{
    public interface IService<TEntity> where TEntity : class
    {
        /// <summary>
        /// Returns all existing records in collection
        /// </summary>
        /// <returns></returns>
         Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Returns single entity from database collection by given Id.
        /// </summary>
        /// <param name="id">Id of requested entity</param>
        /// <returns></returns>
        Task<TEntity> GetById(string id);

        /// <summary>
        ///Creates new entity in database collection with the givven values; 
        /// </summary>
        /// <param name="entity">New entity which will be added to database collection</param>
        /// <returns></returns>
        Task<TEntity> Create(TEntity entity);

        ///// <summary>
        ///// Removes enitity from database by given object of values
        ///// </summary>
        ///// <param name="entity">Entity which should have values of an existing entity in database</param>
        ///// <returns></returns>
        //Task<bool> Remove(TEntity entity);

        /// <summary>
        /// Removes entity by given id.
        /// </summary>
        /// <param name="id">Id of entity which needs to be removed</param>
        /// <returns></returns>
        Task<DeleteResult> RemoveById(string id);

        /// <summary>
        /// Updates existing record in database
        /// </summary>
        /// <param name="id">Id of existing record</param>
        /// <param name="entity">Object with new valued properties</param>
        /// <returns></returns>
        Task<ReplaceOneResult> Update(string id, TEntity entity);
    }

}
