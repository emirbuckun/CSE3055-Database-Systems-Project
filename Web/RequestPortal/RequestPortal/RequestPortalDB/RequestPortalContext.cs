using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RequestPortal.RequestPortalDB;

public partial class RequestPortalContext : DbContext
{
    public RequestPortalContext()
    {
    }

    public RequestPortalContext(DbContextOptions<RequestPortalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdvanceRequest> AdvanceRequests { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<EducationRequest> EducationRequests { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<GetAdvanceRequestView> GetAdvanceRequestViews { get; set; }

    public virtual DbSet<GetEducationRequestView> GetEducationRequestViews { get; set; }

    public virtual DbSet<GetEmployeeView> GetEmployeeViews { get; set; }

    public virtual DbSet<GetLeaveRequestView> GetLeaveRequestViews { get; set; }

    public virtual DbSet<GetOverTimeRequestView> GetOverTimeRequestViews { get; set; }

    public virtual DbSet<GetRequestWithFlowView> GetRequestWithFlowViews { get; set; }

    public virtual DbSet<GetTravelRequestView> GetTravelRequestViews { get; set; }

    public virtual DbSet<GetUserRoleView> GetUserRoleViews { get; set; }

    public virtual DbSet<LeaveRequest> LeaveRequests { get; set; }

    public virtual DbSet<OverTimeRequest> OverTimeRequests { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestFlow> RequestFlows { get; set; }

    public virtual DbSet<TravelRequest> TravelRequests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\EMIR;Database=RequestPortal;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdvanceRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__AdvanceR__33A8519AC4B4274A");

            entity.ToTable("AdvanceRequest");

            entity.Property(e => e.RequestId)
                .ValueGeneratedNever()
                .HasColumnName("RequestID");
            entity.Property(e => e.ApprovedAmount).HasColumnType("smallmoney");
            entity.Property(e => e.RequestedAmount).HasColumnType("smallmoney");

            entity.HasOne(d => d.Request).WithOne(p => p.AdvanceRequest)
                .HasForeignKey<AdvanceRequest>(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AdvanceRe__Reque__30F848ED");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__City__F2D21A96DD8DB782");

            entity.ToTable("City");

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CityName).HasMaxLength(50);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Company__2D971C4CCC29E4FE");

            entity.ToTable("Company");

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CompanyName).HasMaxLength(50);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCD2FA8ECD6");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName).HasMaxLength(50);
        });

        modelBuilder.Entity<EducationRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Educatio__33A8519AE64DE6C7");

            entity.ToTable("EducationRequest");

            entity.Property(e => e.RequestId)
                .ValueGeneratedNever()
                .HasColumnName("RequestID");
            entity.Property(e => e.EducationName).HasMaxLength(150);
            entity.Property(e => e.EndDate).HasColumnType("smalldatetime");
            entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

            entity.HasOne(d => d.Request).WithOne(p => p.EducationRequest)
                .HasForeignKey<EducationRequest>(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Education__Reque__33D4B598");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Ssn).HasName("PK__Employee__CA33E0E584DA2F3F");

            entity.ToTable("Employee");

            entity.Property(e => e.Ssn).ValueGeneratedNever();
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.FirstName).HasMaxLength(25);
            entity.Property(e => e.LastName).HasMaxLength(25);
            entity.Property(e => e.Mail).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.City).WithMany(p => p.Employees)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Employee__CityID__1CF15040");

            entity.HasOne(d => d.Company).WithMany(p => p.Employees)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Employee__Compan__1DE57479");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Employee__Depart__1ED998B2");

            entity.HasOne(d => d.ManagerSsnNavigation).WithMany(p => p.InverseManagerSsnNavigation)
                .HasForeignKey(d => d.ManagerSsn)
                .HasConstraintName("FK__Employee__Manage__1B0907CE");

            entity.HasOne(d => d.User).WithMany(p => p.Employees)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Employee__UserID__1BFD2C07");
        });

        modelBuilder.Entity<GetAdvanceRequestView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetAdvanceRequest_View");

            entity.Property(e => e.ApprovedAmount).HasColumnType("smallmoney");
            entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Explanation).HasMaxLength(250);
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.RequestedAmount).HasColumnType("smallmoney");
        });

        modelBuilder.Entity<GetEducationRequestView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetEducationRequest_View");

            entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");
            entity.Property(e => e.EducationName).HasMaxLength(150);
            entity.Property(e => e.EndDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Explanation).HasMaxLength(250);
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.StartDate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<GetEmployeeView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetEmployee_View");

            entity.Property(e => e.CityName).HasMaxLength(50);
            entity.Property(e => e.CompanyName).HasMaxLength(50);
            entity.Property(e => e.DepartmentName).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(51);
            entity.Property(e => e.Mail).HasMaxLength(50);
            entity.Property(e => e.ManagerName).HasMaxLength(51);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.UserName).HasMaxLength(25);
            entity.Property(e => e.UserPassword).HasMaxLength(25);
        });

        modelBuilder.Entity<GetLeaveRequestView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetLeaveRequest_View");

            entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");
            entity.Property(e => e.EndDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Explanation).HasMaxLength(250);
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.RequestReason).HasMaxLength(250);
            entity.Property(e => e.StartDate).HasColumnType("smalldatetime");
            entity.Property(e => e.TotalDay).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<GetOverTimeRequestView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetOverTimeRequest_View");

            entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.Explanation).HasMaxLength(250);
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
        });

        modelBuilder.Entity<GetRequestWithFlowView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetRequestWithFlow_View");

            entity.Property(e => e.FlowCloseDate).HasColumnType("smalldatetime");
            entity.Property(e => e.FlowCreateDate).HasColumnType("smalldatetime");
            entity.Property(e => e.FlowExplanation).HasMaxLength(250);
            entity.Property(e => e.RequestCreateDate).HasColumnType("smalldatetime");
            entity.Property(e => e.RequestExplanation).HasMaxLength(250);
            entity.Property(e => e.RequestFlowId).HasColumnName("RequestFlowID");
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
        });

        modelBuilder.Entity<GetTravelRequestView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetTravelRequest_View");

            entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Destination).HasMaxLength(50);
            entity.Property(e => e.EndDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Explanation).HasMaxLength(250);
            entity.Property(e => e.Origin).HasMaxLength(50);
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.StartDate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<GetUserRoleView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetUserRole_View");

            entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Role).HasMaxLength(25);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserName).HasMaxLength(25);
            entity.Property(e => e.UserPassword).HasMaxLength(25);
        });

        modelBuilder.Entity<LeaveRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__LeaveReq__33A8519A3F4DF285");

            entity.ToTable("LeaveRequest");

            entity.Property(e => e.RequestId)
                .ValueGeneratedNever()
                .HasColumnName("RequestID");
            entity.Property(e => e.EndDate).HasColumnType("smalldatetime");
            entity.Property(e => e.RequestReason).HasMaxLength(250);
            entity.Property(e => e.StartDate).HasColumnType("smalldatetime");
            entity.Property(e => e.TotalDay).HasComputedColumnSql("(datediff(day,[StartDate],[EndDate]))", false);

            entity.HasOne(d => d.Request).WithOne(p => p.LeaveRequest)
                .HasForeignKey<LeaveRequest>(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LeaveRequ__Reque__5CD6CB2B");
        });

        modelBuilder.Entity<OverTimeRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__OverTime__33A8519AC6167AE5");

            entity.ToTable("OverTimeRequest");

            entity.Property(e => e.RequestId)
                .ValueGeneratedNever()
                .HasColumnName("RequestID");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");

            entity.HasOne(d => d.Request).WithOne(p => p.OverTimeRequest)
                .HasForeignKey<OverTimeRequest>(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OverTimeR__Reque__36B12243");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Request__33A8519A9BFD386B");

            entity.ToTable("Request", tb => tb.HasTrigger("InsertFlowAfterInsertedRequest"));

            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Explanation).HasMaxLength(250);
        });

        modelBuilder.Entity<RequestFlow>(entity =>
        {
            entity.HasKey(e => e.RequestFlowId).HasName("PK__RequestF__0F241EDF3EDB47D5");

            entity.ToTable("RequestFlow");

            entity.HasIndex(e => e.RequestId, "IX_RequestID");

            entity.Property(e => e.RequestFlowId).HasColumnName("RequestFlowID");
            entity.Property(e => e.CloseDate).HasColumnType("smalldatetime");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Explanation).HasMaxLength(250);
            entity.Property(e => e.RequestId).HasColumnName("RequestID");

            entity.HasOne(d => d.ApproverSsnNavigation).WithMany(p => p.RequestFlows)
                .HasForeignKey(d => d.ApproverSsn)
                .HasConstraintName("FK__RequestFl__Appro__25869641");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestFlows)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK__RequestFl__Reque__267ABA7A");
        });

        modelBuilder.Entity<TravelRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__TravelRe__33A8519A6E1D78C0");

            entity.ToTable("TravelRequest");

            entity.Property(e => e.RequestId)
                .ValueGeneratedNever()
                .HasColumnName("RequestID");
            entity.Property(e => e.Destination).HasMaxLength(50);
            entity.Property(e => e.EndDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Origin).HasMaxLength(50);
            entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

            entity.HasOne(d => d.Request).WithOne(p => p.TravelRequest)
                .HasForeignKey<TravelRequest>(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TravelReq__Reque__2C3393D0");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACEA60159C");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.UserName).HasMaxLength(25);
            entity.Property(e => e.UserPassword).HasMaxLength(25);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.Role }).HasName("PK__UserRole__FA2998BF31ECB8ED");

            entity.ToTable("UserRole");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Role).HasMaxLength(25);

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserRole__UserID__182C9B23");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
