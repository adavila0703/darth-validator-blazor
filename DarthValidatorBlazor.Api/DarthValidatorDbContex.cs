using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarthValidatorBlazor.Api
{
    public class DarthValidatorDbContex : DbContext
    {
        public DarthValidatorDbContex(DbContextOptions<DarthValidatorDbContex> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
