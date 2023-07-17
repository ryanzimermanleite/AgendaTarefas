using AgendaTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaTarefas.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) {}

        public DbSet<TarefaModel> Tarefas { get; set; }

        public DbSet<ListaModel> Listas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListaModel>(x =>
            {
                x.ToSqlQuery(
                         "SELECT CONVERT(date, Data, 101) AS DataHr, " +
                         "CONVERT(varchar(5), DATEADD(minute, SUM(DATEDIFF(minute, inicio, final)), '00:00'), 108) AS DiferencaHr," +
                         "COUNT(*) AS TotalTarefas," +
                         "RIGHT('00' + CAST((SUM(DATEDIFF(minute, inicio, final)) / COUNT(*)) / 60 AS VARCHAR(2)), 2) + ':' +" +
                         "RIGHT('00' + CAST((SUM(DATEDIFF(minute, inicio, final)) / COUNT(*)) % 60 AS VARCHAR(2)), 2) AS Media," +
                         "SUM(CASE WHEN Finalizada = 'Sim' THEN 1 ELSE 0 END) AS TotalFinalizadas," +
                         "CONCAT(FORMAT((CAST(SUM(CASE WHEN Finalizada = 'Sim' THEN 1 ELSE 0 END) AS DECIMAL) / NULLIF(COUNT(*), 0)) * 100, 'N2'), '%') AS Percentual " +
                         "FROM tarefas " +
                         "GROUP BY CONVERT(date, Data, 101)" +
                         "HAVING COUNT(*) <> 0;")
                .HasNoKey();
            });
        }
    }
}
