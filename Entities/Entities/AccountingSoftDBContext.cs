using Microsoft.EntityFrameworkCore;

namespace Entities.Entities
{
    public partial class AccountingSoftDBContext : DbContext
    {
        public AccountingSoftDBContext()
        {
        }

        public AccountingSoftDBContext(DbContextOptions<AccountingSoftDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAccountCatalog> TblAccountCatalogs { get; set; } = null!;
        public virtual DbSet<TblAccountingSeat> TblAccountingSeats { get; set; } = null!;
        public virtual DbSet<TblAllocation> TblAllocations { get; set; } = null!;
        public virtual DbSet<TblCustomer> TblCustomers { get; set; } = null!;
        public virtual DbSet<TblEmployee> TblEmployees { get; set; } = null!;
        public virtual DbSet<TblIdType> TblIdTypes { get; set; } = null!;
        public virtual DbSet<TblLog> TblLogs { get; set; } = null!;
        public virtual DbSet<TblReport> TblReports { get; set; } = null!;
        public virtual DbSet<TblSeatApproval> TblSeatApprovals { get; set; } = null!;
        public virtual DbSet<TblSeat> TblSeat { get; set; } = null!;
        public virtual DbSet<TblSeatDetail> TblSeatDetail { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:proyectorg.database.windows.net,1433;Initial Catalog=DB_RG;Persist Security Info=False;User ID=master;Password=proyectorg23*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAccountCatalog>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__tblAccou__05B22F6066C8692B");

                entity.ToTable("tblAccountCatalog");

                entity.Property(e => e.AccountId).HasColumnName("ACCOUNT_ID").ValueGeneratedOnAdd();


                entity.Property(e => e.AccountName)
                    .HasMaxLength(50)
                    .HasColumnName("ACCOUNT_NAME");

                entity.Property(e => e.AccountCode)
                   .HasMaxLength(50)
                   .HasColumnName("ACCOUNT_CODE");

                entity.Property(e => e.AccountType)
                    .HasMaxLength(50)
                    .HasColumnName("ACCOUNT_TYPE");

                entity.Property(e => e.Conversion)
                    .HasColumnName("CONVERSION");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE");

            });

            modelBuilder.Entity<TblAccountingSeat>(entity =>
            {
                entity.HasKey(e => e.SeatId)
                    .HasName("PK__tblAccou__79B8992383F9F3F7");

                entity.ToTable("tblAccountingSeats");

                entity.Property(e => e.SeatId).HasColumnName("SEAT_ID");

                entity.Property(e => e.AccountId).HasColumnName("ACCOUNT_ID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasColumnName("CREATION_DATE");

                entity.Property(e => e.Currency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CURRENCY");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.Reference)
                    .HasMaxLength(255)
                    .HasColumnName("REFERENCE");

                entity.Property(e => e.SeatValue)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("SEAT_VALUE");

            });

            modelBuilder.Entity<TblAllocation>(entity =>
            {
                entity.HasKey(e => e.AllocationId)
                    .HasName("PK__tblAlloc__712E755AA2D94596");

                entity.ToTable("tblAllocations");

                entity.Property(e => e.AllocationId).HasColumnName("ALLOCATION_ID");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TblAllocations)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblAlloca__CUSTO__5441852A");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblAllocations)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblAlloca__EMPLO__534D60F1");
            });

            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__tblCusto__1CE12D37602B227C");

                entity.ToTable("tblCustomers");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(255)
                    .HasColumnName("CUSTOMER_ADDRESS");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(255)
                    .HasColumnName("CUSTOMER_NAME");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(255)
                    .HasColumnName("EMAIL_ADDRESS");

                entity.Property(e => e.IdType).HasColumnName("ID_TYPE");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("PHONE_NUMBER");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.TblCustomers)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblCustom__ID_TY__412EB0B6");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__tblEmplo__CBA14F4870A2C682");

                entity.ToTable("tblEmployees");

                entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .HasColumnName("USERNAME");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(510)
                    .HasColumnName("EMAIL_ADDRESS");


                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Active)
                        .HasColumnName("ACTIVE");

            });

            modelBuilder.Entity<TblIdType>(entity =>
            {
                entity.HasKey(e => e.IdType)
                    .HasName("PK__tblIdTyp__274CEC82783784C9");

                entity.ToTable("tblIdTypes");

                entity.Property(e => e.IdType)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_TYPE");

                entity.Property(e => e.TypeDescription)
                    .HasMaxLength(50)
                    .HasColumnName("TYPE_DESCRIPTION");
            });

            modelBuilder.Entity<TblLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__tblLogs__4364C8827D125C7B");

                entity.ToTable("tblLogs");

                entity.Property(e => e.LogId).HasColumnName("LOG_ID");

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_TIME");

                entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.LogDescription)
                    .HasMaxLength(500)
                    .HasColumnName("LOG_DESCRIPTION");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblLogs)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblLogs__EMPLOYE__49C3F6B7");
            });

            modelBuilder.Entity<TblReport>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PK__tblRepor__B106F6BBBAE0CBF5");

                entity.ToTable("tblReports");

                entity.Property(e => e.ReportId).HasColumnName("REPORT_ID");

                entity.Property(e => e.AccountId).HasColumnName("ACCOUNT_ID");

                entity.Property(e => e.Credits)
                    .HasMaxLength(50)
                    .HasColumnName("CREDITS");

                entity.Property(e => e.Debts)
                    .HasMaxLength(50)
                    .HasColumnName("DEBTS");

                entity.Property(e => e.FinalBalance)
                    .HasMaxLength(50)
                    .HasColumnName("FINAL_BALANCE");

                entity.Property(e => e.InitialBalance)
                    .HasMaxLength(50)
                    .HasColumnName("INITIAL_BALANCE");

                entity.Property(e => e.SeatId).HasColumnName("SEAT_ID");


                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.TblReports)
                    .HasForeignKey(d => d.SeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblReport__SEAT___4F7CD00D");
            });

            modelBuilder.Entity<TblSeatApproval>(entity =>
            {
                entity.HasKey(e => e.ApprovalId)
                    .HasName("PK__tblSeatA__6B47F41C9DEAE5BE");

                entity.ToTable("tblSeatApprovals");

                entity.Property(e => e.ApprovalId).HasColumnName("APPROVAL_ID");

                entity.Property(e => e.ApprovalStatus).HasColumnName("APPROVAL_STATUS");

                entity.Property(e => e.SeatId).HasColumnName("SEAT_ID");

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.TblSeatApprovals)
                    .HasForeignKey(d => d.SeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblSeatAp__SEAT___4CA06362");
            });

            modelBuilder.Entity<TblSeat>(entity =>
            {

                entity.ToTable("tblSeat");

                entity.Property(e => e.ID).HasColumnName("ID").ValueGeneratedOnAdd();

                entity.Property(e => e.DATE_SEAT)
                    .HasColumnName("DATE_SEAT");

                entity.Property(e => e.CURRENCY)
                    .HasColumnName("CURRENCY");

                entity.Property(e => e.EXCHANGE_RATE)
                   .HasColumnName("EXCHANGE_RATE");

                entity.Property(e => e.REFERENCE)
                    .HasColumnName("REFERENCE");

                entity.Property(e => e.CUSTOMER_ID)
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.STATUS)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<TblSeatDetail>(entity =>
            {

                entity.ToTable("tblSeatDetail");

                entity.Property(e => e.ID).HasColumnName("ID").ValueGeneratedOnAdd();

                entity.Property(e => e.SEAT_ID)
                    .HasColumnName("SEAT_ID");

                entity.Property(e => e.ACCOUNT_ID)
                    .HasColumnName("ACCOUNT_ID");

                entity.Property(e => e.AMOUNT)
                   .HasColumnName("AMOUNT");

                entity.Property(e => e.DESCRIPTION)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
