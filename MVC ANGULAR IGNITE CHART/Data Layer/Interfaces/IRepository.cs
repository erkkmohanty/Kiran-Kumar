using System.Collections.Generic;
using Data_Layer.Entities;


namespace Data_Layer.Interfaces
{
    public interface IRepository<T> where T:class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        void Add(T t);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        void Edit(T t);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Remove(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetEntitiesEnumerable();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T FindById(int id);
    }
}
