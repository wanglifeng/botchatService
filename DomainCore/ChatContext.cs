using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DomainCore.Models;

namespace DomainCore
{

    class ChatContext : DbContext
    {
        public ChatContext() : base("dbconn") { }

        public DbSet<ChineseLastName> ChineseLastNames { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<StateMessage> StateMessages { get; set; }
        public DbSet<ConstMessage> ConstMessages { get; set; }

    }
}
