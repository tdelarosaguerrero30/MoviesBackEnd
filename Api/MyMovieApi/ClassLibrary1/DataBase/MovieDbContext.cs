using Microsoft.EntityFrameworkCore;
using MyMovie.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovie.Api.DataBase
{
    public class MovieDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        { }
        #region  Entities Definitions
        /// <summary>
        /// this table will be used to store investigators
        /// </summary>
        public DbSet<Movie> Movies { get; set; }
        /// <summary>
        /// this table is used for uploaded documents
        /// </summary>
        public DbSet<Review> Reviews { get; set; }
        /// <summary>
        /// This table is used to indicate to researchers that a researcher is subscribed
        /// </summary>
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = MovieDb.db");
            base.OnConfiguring(optionsBuilder);
        }
        #endregion
    }
}
