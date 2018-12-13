namespace Eticket
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EticketContext : DbContext
    {
        public EticketContext()
            : base("name=EticketContext")
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<CSAgent> CSAgents { get; set; }
        public virtual DbSet<CustTicket> CustTickets { get; set; }
        public virtual DbSet<NewUser> NewUsers { get; set; }
        public virtual DbSet<Supervisor> Supervisors { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TechSupportUser> TechSupportUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<CSAgent>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<CSAgent>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<CSAgent>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<CSAgent>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<CSAgent>()
                .HasMany(e => e.CustTickets)
                .WithOptional(e => e.CSAgent1)
                .HasForeignKey(e => e.CSAgent);

            modelBuilder.Entity<CustTicket>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<CustTicket>()
                .Property(e => e.CustomerEmail)
                .IsUnicode(false);

            modelBuilder.Entity<CustTicket>()
                .Property(e => e.CustomerPhone)
                .IsUnicode(false);

            modelBuilder.Entity<CustTicket>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CustTicket>()
                .Property(e => e.CSAgent)
                .IsUnicode(false);

            modelBuilder.Entity<CustTicket>()
                .Property(e => e.TechSupport)
                .IsUnicode(false);

            modelBuilder.Entity<NewUser>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<NewUser>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NewUser>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<NewUser>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<NewUser>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<TechSupportUser>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TechSupportUser>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<TechSupportUser>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<TechSupportUser>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<TechSupportUser>()
                .HasMany(e => e.CustTickets)
                .WithOptional(e => e.TechSupportUser)
                .HasForeignKey(e => e.TechSupport);
        }
    }
}
