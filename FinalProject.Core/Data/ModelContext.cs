using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FinalProject.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AboutTable2> AboutTable2s { get; set; }
        public virtual DbSet<AvaliableTable2> AvaliableTable2s { get; set; }
        public virtual DbSet<ContactUsForm2> ContactUsForm2s { get; set; }
        public virtual DbSet<ContactUsTable2> ContactUsTable2s { get; set; }
        public virtual DbSet<CourseTable2> CourseTable2s { get; set; }
        public virtual DbSet<Exam2> Exam2s { get; set; }
        public virtual DbSet<ExamBooking2> ExamBooking2s { get; set; }
        public virtual DbSet<ExamCertificate2> ExamCertificate2s { get; set; }
        public virtual DbSet<HomeTable2> HomeTable2s { get; set; }
        public virtual DbSet<InvoiceTable2> InvoiceTable2s { get; set; }
        public virtual DbSet<LoginTable2> LoginTable2s { get; set; }
        public virtual DbSet<QuestionBank2> QuestionBank2s { get; set; }
        public virtual DbSet<RoleTable2> RoleTable2s { get; set; }
        public virtual DbSet<StatusTable2> StatusTable2s { get; set; }
        public virtual DbSet<TestimonialTable2> TestimonialTable2s { get; set; }
        public virtual DbSet<UserTable2> UserTable2s { get; set; }
        public virtual DbSet<VisaTable2> VisaTable2s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=JOR17_User165;PASSWORD=Test321;DATA SOURCE=94.56.229.181:3488/traindb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("JOR17_USER165")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<AboutTable2>(entity =>
            {
                entity.HasKey(e => e.Aboutid)
                    .HasName("SYS_C00300045");

                entity.ToTable("ABOUT_TABLE2");

                entity.Property(e => e.Aboutid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ABOUTID");

                entity.Property(e => e.Description1)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION1");

                entity.Property(e => e.Description2)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION2");

                entity.Property(e => e.Homeid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HOMEID");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Title)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.AboutTable2s)
                    .HasForeignKey(d => d.Homeid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ABOUT_TABLE2_FK1");
            });

            modelBuilder.Entity<AvaliableTable2>(entity =>
            {
                entity.HasKey(e => e.Avaliableid)
                    .HasName("SYS_C00300021");

                entity.ToTable("AVALIABLE_TABLE2");

                entity.Property(e => e.Avaliableid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AVALIABLEID");

                entity.Property(e => e.Examid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EXAMID");

                entity.Property(e => e.Examstartdate)
                    .HasPrecision(6)
                    .HasColumnName("EXAMSTARTDATE");

                entity.Property(e => e.Statusid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STATUSID");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.AvaliableTable2s)
                    .HasForeignKey(d => d.Examid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("AVALIABLE_TABLE2_FK1");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.AvaliableTable2s)
                    .HasForeignKey(d => d.Statusid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("AVALIABLE_TABLE2_FK2");
            });

            modelBuilder.Entity<ContactUsForm2>(entity =>
            {
                entity.HasKey(e => e.Contactformid)
                    .HasName("SYS_C00300051");

                entity.ToTable("CONTACT_US_FORM2");

                entity.HasIndex(e => e.Email, "CONTACT_US_FORM2_UQ2")
                    .IsUnique();

                entity.Property(e => e.Contactformid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACTFORMID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Homeid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HOMEID");

                entity.Property(e => e.Message)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.ContactUsForm2s)
                    .HasForeignKey(d => d.Homeid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("CONTACT_US_FORM2_FK1");
            });

            modelBuilder.Entity<ContactUsTable2>(entity =>
            {
                entity.HasKey(e => e.Contacttableid)
                    .HasName("SYS_C00300048");

                entity.ToTable("CONTACT_US_TABLE2");

                entity.Property(e => e.Contacttableid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACTTABLEID");

                entity.Property(e => e.Description1)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION1");

                entity.Property(e => e.Description2)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION2");

                entity.Property(e => e.Description3)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION3");

                entity.Property(e => e.Homeid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HOMEID");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Map)
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasColumnName("MAP");

                entity.Property(e => e.Title)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.ContactUsTable2s)
                    .HasForeignKey(d => d.Homeid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("CONTACT_US_TABLE2_FK1");
            });

            modelBuilder.Entity<CourseTable2>(entity =>
            {
                entity.HasKey(e => e.Courseid)
                    .HasName("SYS_C00300010");

                entity.ToTable("COURSE_TABLE2");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Exam2>(entity =>
            {
                entity.HasKey(e => e.Examid)
                    .HasName("SYS_C00300016");

                entity.ToTable("EXAM2");

                entity.Property(e => e.Examid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EXAMID");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Examduration)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EXAMDURATION");

                entity.Property(e => e.Examprice)
                    .HasColumnType("FLOAT")
                    .HasColumnName("EXAMPRICE");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Passmark)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PASSMARK");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Exam2s)
                    .HasForeignKey(d => d.Courseid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("EXAM2_FK1");
            });

            modelBuilder.Entity<ExamBooking2>(entity =>
            {
                entity.HasKey(e => e.Bookingid)
                    .HasName("SYS_C00300025");

                entity.ToTable("EXAM_BOOKING2");

                entity.Property(e => e.Bookingid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BOOKINGID");

                entity.Property(e => e.Bookingdate)
                    .HasColumnType("DATE")
                    .HasColumnName("BOOKINGDATE");

                entity.Property(e => e.Examdateuser)
                    .HasPrecision(6)
                    .HasColumnName("EXAMDATEUSER");

                entity.Property(e => e.Examid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EXAMID");

                entity.Property(e => e.Exampassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EXAMPASSWORD");

                entity.Property(e => e.Statusid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STATUSID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.ExamBooking2s)
                    .HasForeignKey(d => d.Examid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("EXAM_BOOKING2_FK1");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ExamBooking2s)
                    .HasForeignKey(d => d.Statusid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("EXAM_BOOKING2_FK3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExamBooking2s)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("EXAM_BOOKING2_FK2");
            });

            modelBuilder.Entity<ExamCertificate2>(entity =>
            {
                entity.HasKey(e => e.Certificateid)
                    .HasName("SYS_C00300039");

                entity.ToTable("EXAM_CERTIFICATE2");

                entity.Property(e => e.Certificateid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CERTIFICATEID");

                entity.Property(e => e.Bookingid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BOOKINGID");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.ExamCertificate2s)
                    .HasForeignKey(d => d.Bookingid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CERTIFICATE2_FK2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExamCertificate2s)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CERTIFICATE2_FK1");
            });

            modelBuilder.Entity<HomeTable2>(entity =>
            {
                entity.HasKey(e => e.Homeid)
                    .HasName("SYS_C00300043");

                entity.ToTable("HOME_TABLE2");

                entity.Property(e => e.Homeid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("HOMEID");

                entity.Property(e => e.Description1)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION1");

                entity.Property(e => e.Description2)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION2");

                entity.Property(e => e.Description3)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION3");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Title)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<InvoiceTable2>(entity =>
            {
                entity.ToTable("INVOICE_TABLE2");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Bookingid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BOOKINGID");

                entity.Property(e => e.Paydate)
                    .HasColumnType("DATE")
                    .HasColumnName("PAYDATE");

                entity.Property(e => e.Totalprice)
                    .HasColumnType("FLOAT")
                    .HasColumnName("TOTALPRICE");

                entity.Property(e => e.Visaid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("VISAID");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.InvoiceTable2s)
                    .HasForeignKey(d => d.Bookingid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("INVOICE_TABLE2_FK2");

                entity.HasOne(d => d.Visa)
                    .WithMany(p => p.InvoiceTable2s)
                    .HasForeignKey(d => d.Visaid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("INVOICE_TABLE2_FK1");
            });

            modelBuilder.Entity<LoginTable2>(entity =>
            {
                entity.HasKey(e => e.Loginid)
                    .HasName("SYS_C00300387");

                entity.ToTable("LOGIN_TABLE2");

                entity.HasIndex(e => e.Username, "LOGIN_TABLE2_UQ1")
                    .IsUnique();

                entity.Property(e => e.Loginid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOGINID");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.LoginTable2s)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("LOGIN_TABLE2_FK1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LoginTable2s)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("LOGIN_TABLE2_FK2");
            });

            modelBuilder.Entity<QuestionBank2>(entity =>
            {
                entity.HasKey(e => e.Questionid)
                    .HasName("SYS_C00300012");

                entity.ToTable("QUESTION_BANK2");

                entity.Property(e => e.Questionid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("QUESTIONID");

                entity.Property(e => e.Answeroption1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ANSWEROPTION1");

                entity.Property(e => e.Answeroption2)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ANSWEROPTION2");

                entity.Property(e => e.Answeroption3)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ANSWEROPTION3");

                entity.Property(e => e.Answeroption4)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ANSWEROPTION4");

                entity.Property(e => e.Correctanswer)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CORRECTANSWER");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Questionmark)
                    .HasColumnType("NUMBER")
                    .HasColumnName("QUESTIONMARK");

                entity.Property(e => e.Questiontitle)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("QUESTIONTITLE");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.QuestionBank2s)
                    .HasForeignKey(d => d.Courseid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("QUESTION_BANK2_FK");
            });

            modelBuilder.Entity<RoleTable2>(entity =>
            {
                entity.HasKey(e => e.Roleid)
                    .HasName("SYS_C00300000");

                entity.ToTable("ROLE_TABLE2");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<StatusTable2>(entity =>
            {
                entity.HasKey(e => e.Statusid)
                    .HasName("SYS_C00300019");

                entity.ToTable("STATUS_TABLE2");

                entity.Property(e => e.Statusid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STATUSID");

                entity.Property(e => e.Statusname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUSNAME");
            });

            modelBuilder.Entity<TestimonialTable2>(entity =>
            {
                entity.HasKey(e => e.Testimonialid)
                    .HasName("SYS_C00300055");

                entity.ToTable("TESTIMONIAL_TABLE2");

                entity.Property(e => e.Testimonialid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIALID");

                entity.Property(e => e.Feedback)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FEEDBACK");

                entity.Property(e => e.Homeid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HOMEID");

                entity.Property(e => e.Statusid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STATUSID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.TestimonialTable2s)
                    .HasForeignKey(d => d.Homeid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("TESTIMONIAL_TABLE2_FK3");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.TestimonialTable2s)
                    .HasForeignKey(d => d.Statusid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("TESTIMONIAL_TABLE2_FK1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TestimonialTable2s)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("TESTIMONIAL_TABLE2_FK2");
            });

            modelBuilder.Entity<UserTable2>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("SYS_C00300002");

                entity.ToTable("USER_TABLE2");

                entity.HasIndex(e => e.Phonenumber, "USER_TABLE2_UQ1")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "USER_TABLE2_UQ2")
                    .IsUnique();

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Lname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");

                entity.Property(e => e.Phonenumber)
                    .HasPrecision(10)
                    .HasColumnName("PHONENUMBER");
            });

            modelBuilder.Entity<VisaTable2>(entity =>
            {
                entity.HasKey(e => e.Visaid)
                    .HasName("SYS_C00300032");

                entity.ToTable("VISA_TABLE2");

                entity.HasIndex(e => e.Cvc, "VISA_TABLE2_UQ")
                    .IsUnique();

                entity.Property(e => e.Visaid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VISAID");

                entity.Property(e => e.Balance)
                    .HasColumnType("FLOAT")
                    .HasColumnName("BALANCE");

                entity.Property(e => e.Cardnumber)
                    .HasMaxLength(19)
                    .IsUnicode(false)
                    .HasColumnName("CARDNUMBER");

                entity.Property(e => e.Cvc)
                    .HasPrecision(3)
                    .HasColumnName("CVC");

                entity.Property(e => e.Expirydate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRYDATE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
