using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace App.Web.Repositories
{
    /*
     * Esta é uma classe abstrata para facilitar o uso do contexto de database
     * Toda classe que se conecta com o banco de dados deve implementar esta classe
     * */
    public abstract class BaseRepository<T> where T:class
    {
        protected readonly ApplicationContext contexto;
        protected readonly DbSet<T> dbSet;

        protected BaseRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
            this.dbSet = contexto.Set<T>();
        }
    }
}