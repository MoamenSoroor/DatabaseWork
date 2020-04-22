using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AutoLotDAL.EF;
using AutoLotDAL.Models;
using AutoLotDAL.Models.Base;



namespace AutoLotDAL.Repos
{
    public class BaseRepo<T> : IDisposable, IRepo<T> where T : EntityBase, new()
    {
        private readonly DbSet<T> table;

        private readonly AutoLotEntities ctx;

        protected AutoLotEntities Context => ctx;

        public BaseRepo()
        {
            ctx = new AutoLotEntities();
            table = ctx.Set<T>();
        }


        public int Add(T entity)
        {
            table.Add(entity);
            return SaveChanges();
        }

        public int AddRange(IList<T> entities)
        {
            table.AddRange(entities);
            return SaveChanges();
        }

        public int Delete(int id, byte[] timeStamp)
        {
            ctx.Entry<T>(new T() { Id = id, Timestamp = timeStamp }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public int Delete(T entity)
        {
            ctx.Entry<T>(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public void Dispose()
        {
            ctx?.Dispose();
        }

        public List<T> ExecuteQuery(string sql)
        {
            return table.SqlQuery(sql).ToList();
        }

        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects)
        {
            return table.SqlQuery(sql, sqlParametersObjects).ToList();
        }

        public virtual List<T> GetAll()
        {
            return table.ToList();
        }

        public T GetOne(int? id)
        {
            return table.Find(id);
        }

        public int Save(T entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        internal int SaveChanges()
        {
            try
            {
                return ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {

                //Thrown when there is a concurrency error
                //for now, just rethrow the exception
                throw;
            }
            catch (DbUpdateException ex)
            {
                //Thrown when database update fails
                //Examine the inner exception(s) for additional
                //details and affected objects
                //for now, just rethrow the exception
                throw;
            }
            catch (CommitFailedException ex)
            {
                //handle transaction failures here
                //for now, just rethrow the exception
                throw;
            }
            catch (Exception ex)
            {
                //some other exception happened and should be handled
                throw;
            }




        }




    }
}
