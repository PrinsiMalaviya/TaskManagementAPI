using Microsoft.EntityFrameworkCore;
using SimpleCRUDAPI.Entities;

namespace SimpleCRUDAPI.DB_Class
{
    public class TaskManagementdb : DbContext
    {
        public TaskManagementdb(DbContextOptions<TaskManagementdb> options) :base(options)
        {

        }
        public DbSet<task_model> tasks { get; set; }
    }
}