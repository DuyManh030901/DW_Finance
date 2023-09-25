using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BTL_HTTTQL.Models;

public partial class QltcktContext : DbContext
{
    public QltcktContext()
    {
    }

    public QltcktContext(DbContextOptions<QltcktContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<BalanceRec> BalanceRecs { get; set; }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<BuyBill> BuyBills { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<LendRec> LendRecs { get; set; }

    public virtual DbSet<LoanRec> LoanRecs { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductBuyBill> ProductBuyBills { get; set; }

    public virtual DbSet<ProductSellBill> ProductSellBills { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<SalaryTable> SalaryTables { get; set; }

    public virtual DbSet<SellBill> SellBills { get; set; }

    public virtual DbSet<Summary> Summaries { get; set; }

    public virtual DbSet<Tax> Taxes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source= DESKTOP-F6NLJ96\\SQLEXPRESS;Initial Catalog=QLTCKT;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Acid);

            entity.ToTable("ACCOUNT");

            entity.Property(e => e.Acid)
                .ValueGeneratedNever()
                .HasColumnName("ACID");
            entity.Property(e => e.Accode).HasColumnName("ACCode");
            entity.Property(e => e.Desc)
                .HasMaxLength(250)
                .HasColumnName("DESC");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
        });

        modelBuilder.Entity<BalanceRec>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BalanceR__3214EC27BB80F8FC");

            entity.ToTable("BalanceRec");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Accode).HasColumnName("ACCODE");
            entity.Property(e => e.Accr).HasColumnName("ACCR");
            entity.Property(e => e.Acdr).HasColumnName("ACDR");
            entity.Property(e => e.Amount)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BraId).HasColumnName("BraID");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Term)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.AccodeNavigation).WithMany(p => p.BalanceRecs)
                .HasForeignKey(d => d.Accode)
                .HasConstraintName("FK_BalanceRec_ACCOUNT");

            entity.HasOne(d => d.Bra).WithMany(p => p.BalanceRecs)
                .HasForeignKey(d => d.BraId)
                .HasConstraintName("FK_BalanceRec_Branch");
        });

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.BraId).HasName("PK__Branch__BA8865BA4A711BA9");

            entity.ToTable("Branch");

            entity.Property(e => e.BraId).HasColumnName("BraID");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BuyBill>(entity =>
        {
            entity.HasKey(e => e.DocId).HasName("PK__BuyBill__3EF1888D073D092D");

            entity.ToTable("BuyBill");

            entity.Property(e => e.DocId).HasColumnName("DocID");
            entity.Property(e => e.BraId).HasColumnName("BraID");

            entity.HasOne(d => d.Bra).WithMany(p => p.BuyBills)
                .HasForeignKey(d => d.BraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BuyBill_Branch");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Dpmid).HasName("PK__Departme__24FD81958D6DDDF7");

            entity.ToTable("Department");

            entity.Property(e => e.Dpmid).HasColumnName("DPMID");
            entity.Property(e => e.BraId).HasColumnName("BraID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NumOfEmployees)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__AF2DBA79C51F2926");

            entity.ToTable("Employee");

            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Bank)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CardId).HasColumnName("CardID");
            entity.Property(e => e.Dpmid).HasColumnName("DPMID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Sex)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TaxId).HasColumnName("TaxID");

            entity.HasOne(d => d.Dpm).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Dpmid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Department");

            entity.HasOne(d => d.Tax).WithMany(p => p.Employees)
                .HasForeignKey(d => d.TaxId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Tax");
        });

        modelBuilder.Entity<LendRec>(entity =>
        {
            entity.HasKey(e => e.LendRecId).HasName("PK__LendRec__537B49024E0C4CB2");

            entity.ToTable("LendRec");

            entity.Property(e => e.LendRecId).HasColumnName("LendRecID");
            entity.Property(e => e.Acid).HasColumnName("ACID");
            entity.Property(e => e.BraId).HasColumnName("BraID");
            entity.Property(e => e.Desc)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Expired)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PnId).HasColumnName("PnID");
            entity.Property(e => e.Time).HasColumnType("date");
            entity.Property(e => e.Uid).HasColumnName("UID");

            entity.HasOne(d => d.Ac).WithMany(p => p.LendRecs)
                .HasForeignKey(d => d.Acid)
                .HasConstraintName("FK_LendRec_ACCOUNT");

            entity.HasOne(d => d.Bra).WithMany(p => p.LendRecs)
                .HasForeignKey(d => d.BraId)
                .HasConstraintName("FK_LendRec_Branch");

            entity.HasOne(d => d.Pn).WithMany(p => p.LendRecs)
                .HasForeignKey(d => d.PnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LendRec_Partner");
        });

        modelBuilder.Entity<LoanRec>(entity =>
        {
            entity.HasKey(e => e.LoanRecId).HasName("PK__LoanRec__4EE61EFCD3ADBF6F");

            entity.ToTable("LoanRec");

            entity.Property(e => e.LoanRecId).HasColumnName("LoanRecID");
            entity.Property(e => e.Acid).HasColumnName("ACID");
            entity.Property(e => e.BraId).HasColumnName("BraID");
            entity.Property(e => e.Desc)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Expried)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PnId).HasColumnName("PnID");
            entity.Property(e => e.Time)
                .HasColumnType("date")
                .HasColumnName("time");
            entity.Property(e => e.Uid).HasColumnName("UID");

            entity.HasOne(d => d.Ac).WithMany(p => p.LoanRecs)
                .HasForeignKey(d => d.Acid)
                .HasConstraintName("FK_LoanRec_ACCOUNT");

            entity.HasOne(d => d.Bra).WithMany(p => p.LoanRecs)
                .HasForeignKey(d => d.BraId)
                .HasConstraintName("FK_LoanRec_Branch");

            entity.HasOne(d => d.Pn).WithMany(p => p.LoanRecs)
                .HasForeignKey(d => d.PnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LoanRec_Partner");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Log__3214EC27D6FC8713");

            entity.ToTable("Log");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Action)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Time).HasColumnType("date");
            entity.Property(e => e.Uid).HasColumnName("UID");

            entity.HasOne(d => d.UidNavigation).WithMany(p => p.Logs)
                .HasForeignKey(d => d.Uid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Log_User");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.PnId).HasName("PK__Partner__A4000125E87D257E");

            entity.ToTable("Partner");

            entity.Property(e => e.PnId).HasColumnName("PnID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Desc)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TaxId).HasColumnName("TaxID");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProId).HasName("PK__Product__620295F0FD77C62A");

            entity.ToTable("Product");

            entity.Property(e => e.ProId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ProID");
            entity.Property(e => e.BraId).HasColumnName("BraID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PnId).HasColumnName("PnID");

            entity.HasOne(d => d.Pn).WithMany(p => p.Products)
                .HasForeignKey(d => d.PnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Partner");

            entity.HasOne(d => d.Pro).WithOne(p => p.Product)
                .HasForeignKey<Product>(d => d.ProId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Product_BuyBill");

            entity.HasOne(d => d.ProNavigation).WithOne(p => p.Product)
                .HasForeignKey<Product>(d => d.ProId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Product_SellBill");
        });

        modelBuilder.Entity<ProductBuyBill>(entity =>
        {
            entity.HasKey(e => e.ProId).HasName("PK__Product___620295F0CCE0FEA4");

            entity.ToTable("Product_BuyBill");

            entity.Property(e => e.ProId).HasColumnName("ProID");
            entity.Property(e => e.DocId).HasColumnName("DocID");
        });

        modelBuilder.Entity<ProductSellBill>(entity =>
        {
            entity.HasKey(e => e.ProId).HasName("PK__Product___620295F04F61B090");

            entity.ToTable("Product_SellBill");

            entity.Property(e => e.ProId).HasColumnName("ProID");
            entity.Property(e => e.DocId).HasColumnName("DocID");
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Salary__3214EC27A9971C32");

            entity.ToTable("Salary");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.Stid).HasColumnName("STID");

            entity.HasOne(d => d.Emp).WithMany(p => p.Salaries)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Salary_Employee");

            entity.HasOne(d => d.St).WithMany(p => p.Salaries)
                .HasForeignKey(d => d.Stid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Salary_SalaryTable");
        });

        modelBuilder.Entity<SalaryTable>(entity =>
        {
            entity.HasKey(e => e.Stid).HasName("PK__SalaryTa__A60B1C98EA753261");

            entity.ToTable("SalaryTable");

            entity.Property(e => e.Stid).HasColumnName("STID");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Time).HasColumnType("date");
            entity.Property(e => e.Total).HasColumnName("total");
        });

        modelBuilder.Entity<SellBill>(entity =>
        {
            entity.HasKey(e => e.DocId).HasName("PK__SellBill__3EF1888D55B8AC22");

            entity.ToTable("SellBill");

            entity.Property(e => e.DocId).HasColumnName("DocID");
            entity.Property(e => e.BraId).HasColumnName("BraID");
            entity.Property(e => e.CusAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CusPhone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Customer)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TaxId).HasColumnName("TaxID");

            entity.HasOne(d => d.Bra).WithMany(p => p.SellBills)
                .HasForeignKey(d => d.BraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SellBill_Branch");

            entity.HasOne(d => d.Tax).WithMany(p => p.SellBills)
                .HasForeignKey(d => d.TaxId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SellBill_Tax");
        });

        modelBuilder.Entity<Summary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Summary__3214EC2732C174EF");

            entity.ToTable("Summary");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Balance)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Detail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TaxId).HasColumnName("TaxID");
            entity.Property(e => e.Term)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Tax).WithMany(p => p.Summaries)
                .HasForeignKey(d => d.TaxId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Summary_Tax");
        });

        modelBuilder.Entity<Tax>(entity =>
        {
            entity.HasKey(e => e.TaxId).HasName("PK__Tax__711BE08CA15A1F83");

            entity.ToTable("Tax");

            entity.Property(e => e.TaxId).HasColumnName("TaxID");
            entity.Property(e => e.TaxType)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK__User__C5B19602356B6E4A");

            entity.ToTable("User");

            entity.Property(e => e.Uid).HasColumnName("UID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BraId).HasColumnName("BraID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Sex)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Usename)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Bra).WithMany(p => p.Users)
                .HasForeignKey(d => d.BraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Branch");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
