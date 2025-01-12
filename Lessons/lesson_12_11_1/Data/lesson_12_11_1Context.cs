using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lesson_12_11_1.Models;

namespace lesson_12_11_1.Data
{
    public class lesson_12_11_1Context : DbContext
    {
        public lesson_12_11_1Context (DbContextOptions<lesson_12_11_1Context> options)
            : base(options)
        {
        }

        public DbSet<lesson_12_11_1.Models.TvShow> TvShow { get; set; } = default!;
    }
}
