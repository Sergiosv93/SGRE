using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SGRE.Domain.Interfaces;
using SGRE.Infrastructure.Data;

namespace SGRE.Infrastructure.Repositories
{
    public abstract class RepositorioBase<T> : IRepositorio<T> where T : class
    {
        protected readonly SGREDbContext Contexto;
        protected readonly DbSet<T> DbSet;

        protected RepositorioBase(SGREDbContext contexto)
        {
            Contexto = contexto;
            DbSet = contexto.Set<T>();
        }

        public T ObtenerPorId(int id) => DbSet.Find(id);

        public IEnumerable<T> ObtenerTodos() => DbSet.ToList();

        public void Agregar(T entidad)
        {
            DbSet.Add(entidad);
            Contexto.SaveChanges();
        }

        public void Actualizar(T entidad)
        {
            Contexto.Entry(entidad).State = EntityState.Modified;
            Contexto.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var entidad = DbSet.Find(id);
            if (entidad != null)
            {
                DbSet.Remove(entidad);
                Contexto.SaveChanges();
            }
        }
    }
}