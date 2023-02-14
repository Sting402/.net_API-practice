using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace test1.Models;

public partial class BlogContext : DbContext
{
    public BlogContext()
    {
    }

    public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<MealOrder> MealOrders { get; set; }

    public virtual DbSet<MealProvide> MealProvides { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<OrderHistory> OrderHistories { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Site> Sites { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=localhost;Database=FOX;User=sa;Password=12345678;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId);

            entity.Property(e => e.DeptId)
                .HasMaxLength(10)
                .HasColumnName("Dept_ID");
            entity.Property(e => e.DeptDesc)
                .HasMaxLength(500)
                .HasColumnName("Dept_Desc");
            entity.Property(e => e.DeptName)
                .HasMaxLength(6)
                .HasColumnName("Dept_Name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.WorkerId).HasName("PK_dbo.Employees");

            entity.Property(e => e.WorkerId)
                .HasMaxLength(10)
                .HasColumnName("Worker_ID");
            entity.Property(e => e.CName)
                .HasMaxLength(50)
                .HasColumnName("C_Name");
            entity.Property(e => e.DefaultMealOrder)
                .HasMaxLength(2)
                .HasColumnName("Default_MealOrder");
            entity.Property(e => e.DefaultMealType)
                .HasMaxLength(2)
                .HasColumnName("Default_MealType");
            entity.Property(e => e.DefaultRest)
                .HasMaxLength(20)
                .HasColumnName("Default_Rest");
            entity.Property(e => e.EName)
                .HasMaxLength(50)
                .HasColumnName("E_Name");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMail");
            entity.Property(e => e.Jwt)
                .HasMaxLength(500)
                .HasColumnName("JWT");
            entity.Property(e => e.Menu).HasMaxLength(1000);
            entity.Property(e => e.ModifyDate)
                .HasColumnType("date")
                .HasColumnName("Modify_Date");
            entity.Property(e => e.NdId)
                .HasMaxLength(10)
                .HasColumnName("ND_ID");
            entity.Property(e => e.OdId)
                .HasMaxLength(10)
                .HasColumnName("OD_ID");
            entity.Property(e => e.Password).HasMaxLength(20);
            entity.Property(e => e.PrExcel)
                .HasMaxLength(11)
                .HasColumnName("PR_Excel");
            entity.Property(e => e.Shift).HasMaxLength(2);
            entity.Property(e => e.Status).HasMaxLength(10);
            entity.Property(e => e.Type).HasMaxLength(1);
            entity.Property(e => e.WorkerDesc)
                .HasMaxLength(500)
                .HasColumnName("Worker_Desc");

            entity.HasOne(d => d.DefaultRestNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DefaultRest)
                .HasConstraintName("FK_dbo.Employees_Restaurants");

            entity.HasOne(d => d.Nd).WithMany(p => p.EmployeeNds)
                .HasForeignKey(d => d.NdId)
                .HasConstraintName("FK_dbo.Employees_Departments1");

            entity.HasOne(d => d.Od).WithMany(p => p.EmployeeOds)
                .HasForeignKey(d => d.OdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Employees_Departments");
        });

        modelBuilder.Entity<MealOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.Property(e => e.OrderId)
                .HasMaxLength(20)
                .HasColumnName("Order_ID");
            entity.Property(e => e.DeptId)
                .HasMaxLength(10)
                .HasColumnName("Dept_ID");
            entity.Property(e => e.MealNumber).HasColumnName("Meal_Number");
            entity.Property(e => e.MealOrder1)
                .HasMaxLength(2)
                .HasColumnName("Meal_Order");
            entity.Property(e => e.MealType)
                .HasMaxLength(2)
                .HasColumnName("Meal_Type");
            entity.Property(e => e.OrderDate)
                .HasColumnType("date")
                .HasColumnName("Order_Date");
            entity.Property(e => e.OrderDesc)
                .HasMaxLength(500)
                .HasColumnName("Order_Desc");
            entity.Property(e => e.RestId)
                .HasMaxLength(20)
                .HasColumnName("Rest_ID");
            entity.Property(e => e.RoleId)
                .HasMaxLength(10)
                .HasColumnName("Role_ID");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("Update_Time");
            entity.Property(e => e.WorkerId)
                .HasMaxLength(10)
                .HasColumnName("Worker_ID");

            entity.HasOne(d => d.Dept).WithMany(p => p.MealOrders)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK_MealOrders_Departments");

            entity.HasOne(d => d.Rest).WithMany(p => p.MealOrders)
                .HasForeignKey(d => d.RestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MealOrders_Restaurants");

            entity.HasOne(d => d.Role).WithMany(p => p.MealOrders)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_MealOrders_Roles");

            entity.HasOne(d => d.Worker).WithMany(p => p.MealOrders)
                .HasForeignKey(d => d.WorkerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MealOrders_dbo.Employees");
        });

        modelBuilder.Entity<MealProvide>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MealProvide");

            entity.Property(e => e.MealOrder)
                .HasMaxLength(2)
                .HasColumnName("Meal_Order");
            entity.Property(e => e.MealType)
                .HasMaxLength(2)
                .HasColumnName("Meal_Type");
            entity.Property(e => e.Month).HasMaxLength(2);
            entity.Property(e => e.MpDesc)
                .HasMaxLength(500)
                .HasColumnName("MP_Desc");
            entity.Property(e => e.MpId)
                .HasMaxLength(10)
                .HasColumnName("MP_ID");
            entity.Property(e => e.SiteId)
                .HasMaxLength(3)
                .HasColumnName("Site_ID");
            entity.Property(e => e.SupplierId)
                .HasMaxLength(50)
                .HasColumnName("Supplier_ID");
            entity.Property(e => e.Year).HasMaxLength(4);
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.Property(e => e.NewsId)
                .HasMaxLength(20)
                .HasColumnName("News_ID");
            entity.Property(e => e.IsVip).HasColumnName("Is_VIP");
            entity.Property(e => e.NewsContent)
                .HasMaxLength(1000)
                .HasColumnName("News_Content");
            entity.Property(e => e.NewsFileLink)
                .HasMaxLength(200)
                .HasColumnName("News_FileLink");
            entity.Property(e => e.NewsTitle)
                .HasMaxLength(50)
                .HasColumnName("News_Title");
        });

        modelBuilder.Entity<OrderHistory>(entity =>
        {
            entity.HasKey(e => e.OhId);

            entity.ToTable("OrderHistory");

            entity.Property(e => e.OhId)
                .HasMaxLength(20)
                .HasColumnName("OH_ID");
            entity.Property(e => e.DeptId)
                .HasMaxLength(10)
                .HasColumnName("Dept_ID");
            entity.Property(e => e.MealNumber).HasColumnName("Meal_Number");
            entity.Property(e => e.MealOrder)
                .HasMaxLength(2)
                .HasColumnName("Meal_Order");
            entity.Property(e => e.MealType)
                .HasMaxLength(10)
                .HasColumnName("Meal_Type");
            entity.Property(e => e.OrderDate)
                .HasColumnType("date")
                .HasColumnName("Order_Date");
            entity.Property(e => e.OrderDesc)
                .HasMaxLength(500)
                .HasColumnName("Order_Desc");
            entity.Property(e => e.RestId)
                .HasMaxLength(20)
                .HasColumnName("Rest_ID");
            entity.Property(e => e.RoleId)
                .HasMaxLength(10)
                .HasColumnName("Role_ID");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("Update_Time");
            entity.Property(e => e.WorkerId)
                .HasMaxLength(10)
                .HasColumnName("Worker_ID");

            entity.HasOne(d => d.Dept).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK_OrderHistory_Departments");

            entity.HasOne(d => d.Rest).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.RestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderHistory_Restaurants");

            entity.HasOne(d => d.Role).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_OrderHistory_Roles");

            entity.HasOne(d => d.Worker).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.WorkerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderHistory_dbo.Employees");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.Property(e => e.PermissionId)
                .HasMaxLength(50)
                .HasColumnName("Permission_ID");
            entity.Property(e => e.PermissionDesc)
                .HasMaxLength(500)
                .HasColumnName("Permission_Desc");
            entity.Property(e => e.RoleId)
                .HasMaxLength(10)
                .HasColumnName("Role_ID");
            entity.Property(e => e.SiteId)
                .HasMaxLength(3)
                .HasColumnName("Site_ID");
            entity.Property(e => e.WokerId)
                .HasMaxLength(10)
                .HasColumnName("Woker_ID");

            entity.HasOne(d => d.Role).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permissions_Roles");

            entity.HasOne(d => d.Site).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.SiteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permissions_Sites");

            entity.HasOne(d => d.Woker).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.WokerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permissions_dbo.Employees");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.RestId);

            entity.Property(e => e.RestId)
                .HasMaxLength(20)
                .HasColumnName("Rest_ID");
            entity.Property(e => e.RestDesc)
                .HasMaxLength(500)
                .HasColumnName("Rest_Desc");
            entity.Property(e => e.RestName)
                .HasMaxLength(50)
                .HasColumnName("Rest_Name");
            entity.Property(e => e.SiteId)
                .HasMaxLength(3)
                .HasColumnName("Site_ID");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleId)
                .HasMaxLength(10)
                .HasColumnName("Role_ID");
            entity.Property(e => e.DeptId)
                .HasMaxLength(10)
                .HasColumnName("Dept_ID");
            entity.Property(e => e.RoleDesc)
                .HasMaxLength(500)
                .HasColumnName("Role_Desc");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("Role_Name");

            entity.HasOne(d => d.Dept).WithMany(p => p.Roles)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK_Roles_Departments");
        });

        modelBuilder.Entity<Site>(entity =>
        {
            entity.Property(e => e.SiteId)
                .HasMaxLength(3)
                .HasColumnName("Site_ID");
            entity.Property(e => e.SiteAddress)
                .HasMaxLength(500)
                .HasColumnName("Site_Address");
            entity.Property(e => e.SiteDesc)
                .HasMaxLength(500)
                .HasColumnName("Site_Desc");
            entity.Property(e => e.SiteName)
                .HasMaxLength(20)
                .HasColumnName("Site_Name");
            entity.Property(e => e.ZipCode).HasMaxLength(6);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.Property(e => e.SupplierId)
                .HasMaxLength(50)
                .HasColumnName("Supplier_ID");
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.ContactPerson).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Jwt)
                .HasMaxLength(500)
                .HasColumnName("JWT");
            entity.Property(e => e.MealType).HasMaxLength(10);
            entity.Property(e => e.Menu).HasMaxLength(1000);
            entity.Property(e => e.Password).HasMaxLength(20);
            entity.Property(e => e.SupplierDesc)
                .HasMaxLength(50)
                .HasColumnName("Supplier_Desc");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(50)
                .HasColumnName("Supplier_Name");
            entity.Property(e => e.Telephone).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.Property(e => e.Username).HasMaxLength(10);
            entity.Property(e => e.Password).HasMaxLength(20);
            entity.Property(e => e.Token).HasMaxLength(50);
            entity.Property(e => e.UserDesc)
                .HasMaxLength(500)
                .HasColumnName("User_Desc");
            entity.Property(e => e.Usertype).HasMaxLength(1);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
