

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Microsoft.Data.SqlClient;
using Dashboard.Entites.Entities;
using MachineModel =Dashboard.Entites.Entities.Machine;
using System.Reflection.PortableExecutable;


namespace Dashboard.Entities.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public ApplicationDbContext() { }

       
        public virtual DbSet<MachineModel> Machines { get; set; }     
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);         
            modelBuilder.Entity<MachineModel>().ToTable("Machine");         
            modelBuilder.Entity<Transaction>().ToTable("Transaction");

         
         

            modelBuilder.Entity<MachineModel>().HasData(new Entites.Entities.Machine()
            {
                Id = 1, Name = "t2k", Description = "first machine", Cluster = "Line1"
            });
            modelBuilder.Entity<MachineModel>().HasData(new Entites.Entities.Machine()
            {
                Id = 2,
                Name = "Flex",
                Description = "second machine",
                Cluster = "Line2"
            });
           
        }



        #region -Machine CRUD
        public async Task<List<MachineModel>> GetAllMachines()
        {
            return await Machines.FromSqlRaw("EXECUTE [dbo].[spGetAllMachines]").ToListAsync();
        }

        public int CreateMachine(MachineModel machine)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {

                new SqlParameter("@id", machine.Id),
                new SqlParameter("@name", machine.Name),
                new SqlParameter("@description", machine.Description),
                new SqlParameter("@cluster", machine.Cluster),

            };
            return Database.ExecuteSqlRaw("EXECUTE [dbo].[spCreateMachine] @id, @name, @description, @cluster",
                parameters);
        }
        //public

        public int UpdateMachine(MachineModel machine)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", machine.Id),
                new SqlParameter("@name", machine.Name),
                new SqlParameter("@description", machine.Description),
                new SqlParameter("@cluster", machine.Cluster),
           };
            return Database.ExecuteSqlRaw("EXECUTE [dbo].[spUpdateMachine] @id, @name, @description, @cluster",
                parameters);
        }
        public int DeleteMachine(int id)
        {
            SqlParameter sqlParameter = new SqlParameter("@id", id);
            return Database.ExecuteSqlRaw("EXECUTE [dbo].[spDeleteMachine] @id", sqlParameter);
        }
        //public async Task<MachineModel> GetMachineById(int id)
        //public async IQueryable<MachineModel> GetMachineById(int id)
        public async Task<MachineModel> GetMachineById(int id)
        {
            //
            SqlParameter sqlParameter = new SqlParameter("@id", id);
            //return await Machines.FromSqlRaw("EXECUTE [dbo].[spGetMachineById] @id", sqlParameter);
            //Database.ExecuteSqlRaw("EXECUTE [dbo].[spGetMachineById] @id");
            //return await Machines.FromSqlRaw("EXECUTE [dbo].[spGetAllMachines]").ToListAsync();
            //return await Machines.FromSqlRaw("EXECUTE [dbo].[spGetMachineById] @id", sqlParameter).Select(machine => machine.Id == id);
            //return await Machines.FromSqlRaw("EXECUTE [dbo].[spGetMachineById] @id", sqlParameter).AsEnumerable().SingleOrDefault();
            return await Machines.FromSqlRaw("EXECUTE [dbo].[spGetMachineById] @id", sqlParameter).FirstOrDefaultAsync();
        }

        #endregion


    }
}
