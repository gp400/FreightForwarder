using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data.Models.IAS;

public partial class IasContext : DbContext
{
    public IasContext()
    {
    }

    public IasContext(DbContextOptions<IasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyUsr100> CompanyUsr100s { get; set; }

    public virtual DbSet<Membership> Memberships { get; set; }

    public virtual DbSet<Password> Passwords { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<Usr100> Usr100s { get; set; }

    public virtual DbSet<Usr100Role> Usr100Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=66.98.69.13;Database=IAS;User Id=sa;Password=P455w0rd54321;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EMPRESA__3214EC27F50D8F13");

            entity.ToTable("Company");

            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.Address2).IsUnicode(false);
            entity.Property(e => e.AltPhone).IsUnicode(false);
            entity.Property(e => e.BusinessName).IsUnicode(false);
            entity.Property(e => e.City).IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateFormat).IsUnicode(false);
            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.Facebook).IsUnicode(false);
            entity.Property(e => e.Fax).IsUnicode(false);
            entity.Property(e => e.Instagram).IsUnicode(false);
            entity.Property(e => e.InvoicesNotes).IsUnicode(false);
            entity.Property(e => e.Logo).IsUnicode(false);
            entity.Property(e => e.Phone).IsUnicode(false);
            entity.Property(e => e.PostalCode).IsUnicode(false);
            entity.Property(e => e.Rnc).IsUnicode(false);
            entity.Property(e => e.Slogan).IsUnicode(false);
            entity.Property(e => e.State).IsUnicode(false);
            entity.Property(e => e.Tradename).IsUnicode(false);
            entity.Property(e => e.Twitter).IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Website).IsUnicode(false);
            entity.Property(e => e.YouTube).IsUnicode(false);
        });

        modelBuilder.Entity<CompanyUsr100>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__COMPANY___3214EC273A0252F0");

            entity.ToTable("Company_Usr100");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyUsr100s)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__COMPANY_U__COMPA__3A81B327");

            entity.HasOne(d => d.Usr100).WithMany(p => p.CompanyUsr100s)
                .HasForeignKey(d => d.Usr100Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__COMPANY_U__USR10__3B75D760");
        });

        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Membersh__3213E83F1AF1A9F6");

            entity.ToTable("Membership");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationId).IsUnicode(false);
            entity.Property(e => e.Comment).IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.EmailResetToken).IsUnicode(false);
            entity.Property(e => e.EmailResetTokenExpired).IsUnicode(false);
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");
            entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");
            entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");
            entity.Property(e => e.MobilePin)
                .IsUnicode(false)
                .HasColumnName("MobilePIN");
            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.PasswordAnswer).IsUnicode(false);
            entity.Property(e => e.PasswordQuestion).IsUnicode(false);
            entity.Property(e => e.PasswordResetToken).IsUnicode(false);
            entity.Property(e => e.PasswordResetTokenExpired).IsUnicode(false);
            entity.Property(e => e.PasswordResetTokenLifetime).HasColumnType("datetime");
            entity.Property(e => e.PasswordSalt).IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Memberships)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Membershi__UserI__72C60C4A");
        });

        modelBuilder.Entity<Password>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PASSWORD__3214EC27BB58BCA4");

            entity.ToTable("Password");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Password1)
                .IsUnicode(false)
                .HasColumnName("Password");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Usr100).WithMany(p => p.Passwords)
                .HasForeignKey(d => d.Usr100Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PASSWORD__USR100__3E52440B");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PERMISO__3214EC274AACCA04");

            entity.ToTable("Permission");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ROL__3214EC27325FF0DF");

            entity.ToTable("Role");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Nombre).IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.Roles)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ROL__EMPRESAID__1DE57479");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ROL_PERM__3214EC27887639A2");

            entity.ToTable("Role_Permission");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ROL_PERMI__PERMI__239E4DCF");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ROL_PERMI__ROLID__22AA2996");
        });

        modelBuilder.Entity<Usr100>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USR100__3214EC27AE71D764");

            entity.ToTable("Usr100");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.LastName).IsUnicode(false);
            entity.Property(e => e.Mail).IsUnicode(false);
            entity.Property(e => e.MiddleName).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Observations).IsUnicode(false);
            entity.Property(e => e.PasswordExpires).HasColumnType("datetime");
            entity.Property(e => e.Picture).IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Usr100Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USR100_R__3214EC270EE37C46");

            entity.ToTable("Usr100_Role");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Role).WithMany(p => p.Usr100Roles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USR100_RO__ROLEI__37A5467C");

            entity.HasOne(d => d.Usr100).WithMany(p => p.Usr100Roles)
                .HasForeignKey(d => d.Usr100Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USR100_RO__USR10__36B12243");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
