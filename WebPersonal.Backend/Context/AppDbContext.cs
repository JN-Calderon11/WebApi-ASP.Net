using Microsoft.EntityFrameworkCore;
using TodoListApi.Models;

namespace TodoListApi.Context
{
    //Creacion del DbContext para la aplicacion, que es la clase que representa la conexion a la base de datos y permite realizar operaciones CRUD (Create, Read, Update, Delete) sobre las entidades.
    public class AppDbContext : DbContext //DbContext es la clase base para trabajar con Entity Framework Core y representa una sesión con la base de datos.
    {
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; } //DbSet representa una colección de entidades de un tipo específico que se pueden consultar y guardar en la base de datos.
        
    }
}
