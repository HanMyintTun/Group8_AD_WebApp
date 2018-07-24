namespace Group8_AD_webapp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LogicUniEf : DbContext
    {
        public LogicUniEf()
            : base("name=LogicUniEf")
        {
        }

        public virtual DbSet<Adjustment> Adjustments { get; set; }
        public virtual DbSet<CollectionPoint> CollectionPoints { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestDetail> RequestDetails { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DeptCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Adjustments)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.ApproverId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Adjustments1)
                .WithRequired(e => e.Employee1)
                .HasForeignKey(e => e.EmpId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Departments)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.DelegateApproverId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Departments1)
                .WithOptional(e => e.Employee1)
                .HasForeignKey(e => e.DeptHeadId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Departments2)
                .WithOptional(e => e.Employee2)
                .HasForeignKey(e => e.DeptRepId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Notifications)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.FromEmp)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Notifications1)
                .WithRequired(e => e.Employee1)
                .HasForeignKey(e => e.ToEmp)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Requests)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.ApproverId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Requests1)
                .WithRequired(e => e.Employee1)
                .HasForeignKey(e => e.EmpId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Adjustments)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.RequestDetails)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request>()
                .HasMany(e => e.RequestDetails)
                .WithRequired(e => e.Request)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Items)
                .WithOptional(e => e.Supplier)
                .HasForeignKey(e => e.SuppCode1);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Items1)
                .WithOptional(e => e.Supplier1)
                .HasForeignKey(e => e.SuppCode2);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Items2)
                .WithOptional(e => e.Supplier2)
                .HasForeignKey(e => e.SuppCode3);
        }
    }
}
