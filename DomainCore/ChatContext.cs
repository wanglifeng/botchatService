using DomainCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DomainCore
{

    class ChatContext : DbContext
    {
        public ChatContext() : base("dbconn") { }

        public DbSet<ChineseLastName> ChineseLastNames { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Models.Message> Messages { get; set; }

    }
}
