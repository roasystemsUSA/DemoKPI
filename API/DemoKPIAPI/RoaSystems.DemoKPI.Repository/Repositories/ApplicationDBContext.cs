using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RoaSystems.DemoKPI.Model.Model;

namespace RoaSystems.DemoKPI.Repository.Repositories
{
    public partial class ApplicationDBContext : DbContext
    {
        private string _connectionString;
        public IConfiguration Configuration { get; }
        public ApplicationDBContext()
        {
        }
        public ApplicationDBContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
            _connectionString = ((Pomelo.EntityFrameworkCore.MySql.Infrastructure.Internal.MySqlOptionsExtension)options.Extensions.ElementAt(1)).ConnectionString;
        }

        public virtual DbSet<PoliticalParty> PoliticalParties { get; set; }
        public virtual DbSet<Politician> Politicians { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<PositionOccupied> PositionsOccupied { get; set; }
        public virtual DbSet<PoliticalAffiliation> PoliticalAffiliations { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<Flag> Flags { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(_connectionString, ServerVersion.Parse("5.7.42-mysql"));
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<PoliticalParty>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.ToTable("PoliticalParties");

                entity.Property(e => e.Name)
                    .HasMaxLength(512)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
 
                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Orientation)
                    .HasMaxLength(30)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Url)
                    .HasMaxLength(512)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Logo)
                    .HasMaxLength(512)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(256)
                    .HasColumnName("CREATED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreationDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("CREATION_DATE");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("LAST_UPDATE_DATE");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(256)
                    .HasColumnName("LAST_UPDATED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Deleted).HasColumnName("DELETED");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(256)
                    .HasColumnName("DELETED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DeletedDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("DELETED_DATE");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.ToTable("Positions");

                entity.Property(e => e.Name)
                    .HasMaxLength(512)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Scope)
                    .HasMaxLength(30)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(256)
                    .HasColumnName("CREATED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
                entity.Property(e => e.CreationDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("CREATION_DATE");
                entity.Property(e => e.Deleted).HasColumnName("DELETED");
                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(256)
                    .HasColumnName("DELETED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
                entity.Property(e => e.DeletedDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("DELETED_DATE");
                entity.Property(e => e.Description).HasColumnType("text");
                entity.Property(e => e.LastUpdateDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("LAST_UPDATE_DATE");
                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(256)
                    .HasColumnName("LAST_UPDATED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });


            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.ToTable("Logs");
                entity.Property(e => e.Id).HasMaxLength(256).UseCollation("utf8_general_ci").HasCharSet("utf8");
                entity.Property(e => e.Message).HasColumnType("LONGTEXT");
                entity.Property(e => e.MessageTemplate).HasColumnType("LONGTEXT");
                entity.Property(e => e.Level).HasMaxLength(128).UseCollation("utf8_general_ci").HasCharSet("utf8");
                entity.Property(e => e.TimeStamp).HasColumnType("timestamp").HasColumnName("TimeStamp");
                entity.Property(e => e.Exception).HasColumnType("LONGTEXT");
                entity.Property(e => e.Properties).HasColumnType("LONGTEXT");
                entity.Property(e => e.LogEvent).HasMaxLength(128).UseCollation("utf8_general_ci").HasCharSet("utf8");
            });

            modelBuilder.Entity<Politician>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.ToTable("Politicians");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(128)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.LastName)
                    .HasMaxLength(128)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DateOfBirth)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("CREATION_DATE");

                entity.Property(e => e.PlaceOfBirth)
                    .HasMaxLength(256)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");


                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(256)
                    .HasColumnName("CREATED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreationDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("CREATION_DATE");

                entity.Property(e => e.Deleted).HasColumnName("DELETED");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(256)
                    .HasColumnName("DELETED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DeletedDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("DELETED_DATE");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("LAST_UPDATE_DATE");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(256)
                    .HasColumnName("LAST_UPDATED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                //entity.HasOne(d => d.PoliticalAffiliations).WithMany(p => p.Politicians)
                //    .HasForeignKey(d => d.PoliticianId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_PoliticianId_PoliticalAffiliations");
            });


            modelBuilder.Entity<PoliticalAffiliation>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.ToTable("PoliticalAffiliations");

                entity.HasIndex(e => e.PoliticalPartyId, "FK_PoliticalPartyId_PoliticalAffiliations");

                entity.HasIndex(e => e.PoliticianId, "FK_PoliticianId_PoliticalAffiliations");

                entity.Property(e => e.SeparationReasonOfficial).HasColumnType("text");

                entity.Property(e => e.SeparationReasonReal).HasColumnType("text");

                entity.Property(e => e.FromDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("FromDate");

                entity.Property(e => e.ToDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("ToDate");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(256)
                    .HasColumnName("CREATED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreationDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("CREATION_DATE");

                entity.Property(e => e.Deleted).HasColumnName("DELETED");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(256)
                    .HasColumnName("DELETED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DeletedDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("DELETED_DATE");
                
                entity.Property(e => e.LastUpdateDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("LAST_UPDATE_DATE");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(256)
                    .HasColumnName("LAST_UPDATED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.PoliticalParty).WithMany(p => p.PoliticalAffiliations)
                    .HasForeignKey(d => d.PoliticalPartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PoliticianId_PoliticalAffiliations");

                entity.HasOne(d => d.Politician).WithMany(p => p.PoliticalAffiliations)
                    .HasForeignKey(d => d.PoliticianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PoliticianId_PoliticalAffiliations");
            });

            modelBuilder.Entity<PositionOccupied>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.ToTable("PositionsOccupied");


                entity.HasIndex(e => e.PositionId, "FK_PositionId_PositionsOccupied");

                entity.HasIndex(e => e.PoliticianId, "FK_PoliticianId_PositionsOccupied");

                entity.Property(e => e.SeparationReasonOfficial).HasColumnType("text");

                entity.Property(e => e.SeparationReasonReal).HasColumnType("text");

                entity.Property(e => e.FromDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("FromDate");

                entity.Property(e => e.ToDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("ToDate");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(256)
                    .HasColumnName("CREATED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreationDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("CREATION_DATE");

                entity.Property(e => e.Deleted).HasColumnName("DELETED");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(256)
                    .HasColumnName("DELETED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DeletedDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("DELETED_DATE");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("LAST_UPDATE_DATE");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(256)
                    .HasColumnName("LAST_UPDATED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Position).WithMany(p => p.PositionsOccupied)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PositionId_PositionsOccupied");

                entity.HasOne(d => d.Politician).WithMany(p => p.PositionsOccupied)
                    .HasForeignKey(d => d.PoliticianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PoliticianId_PositionsOccupied");
            });



            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.ToTable("Issues");

                entity.HasIndex(e => e.PositionOccupedId, "FK_PositionOccupedId_Issues");

                entity.Property(e => e.IssueDesc).HasColumnType("text");

                entity.Property(e => e.Status)
                    .HasMaxLength(128)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(256)
                    .HasColumnName("CREATED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreationDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("CREATION_DATE");

                entity.Property(e => e.Deleted).HasColumnName("DELETED");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(256)
                    .HasColumnName("DELETED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DeletedDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("DELETED_DATE");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("LAST_UPDATE_DATE");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(256)
                    .HasColumnName("LAST_UPDATED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");


                entity.HasOne(d => d.PositionOccupied).WithMany(p => p.Issues)
                    .HasForeignKey(d => d.PositionOccupedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PositionOccupied_Issues");
            });

            modelBuilder.Entity<Flag>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.ToTable("Flags");

                entity.HasIndex(e => e.IssueId, "FK_IssueId_Flags");

                entity.Property(e => e.FlagType)
                    .HasMaxLength(1024)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(256)
                    .HasColumnName("CREATED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreationDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("CREATION_DATE");

                entity.Property(e => e.Deleted).HasColumnName("DELETED");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(256)
                    .HasColumnName("DELETED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DeletedDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("DELETED_DATE");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("LAST_UPDATE_DATE");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(256)
                    .HasColumnName("LAST_UPDATED_BY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Issue).WithMany(p => p.Flags)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IssueId_Flags");
            });


            OnModelCreatingPartial(modelBuilder);
        }



        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
