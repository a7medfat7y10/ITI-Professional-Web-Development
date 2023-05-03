using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLiberary
{
    public class BlazorContext:DbContext
    {
        public BlazorContext( DbContextOptions<BlazorContext> opt):base(opt)
        {

        }


        public virtual DbSet <Trainee> Trainees { get; set; }
        public virtual DbSet <Track> Tracks { get; set; }
    }
}
