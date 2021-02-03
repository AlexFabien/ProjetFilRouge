using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuizApi.quiz
{
    public partial class QuizContext : DbContext
    {
        public QuizContext()
        {
        }

        public QuizContext(DbContextOptions<QuizContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acteur> Acteur { get; set; }
        public virtual DbSet<ActeurHasQuestion> ActeurHasQuestion { get; set; }
        public virtual DbSet<ActeurHasQuiz> ActeurHasQuiz { get; set; }
        public virtual DbSet<Niveau> Niveau { get; set; }
        public virtual DbSet<Parametrage> Parametrage { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Quiz> Quiz { get; set; }
        public virtual DbSet<Repondu> Repondu { get; set; }
        public virtual DbSet<Reponse> Reponse { get; set; }
        public virtual DbSet<ReponseCandidat> ReponseCandidat { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Technologie> Technologie { get; set; }
        public virtual DbSet<TypeQuestion> TypeQuestion { get; set; }
        public virtual DbSet<Ventillation> Ventillation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=quiz");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acteur>(entity =>
            {
                entity.HasKey(e => e.IdActeur)
                    .HasName("PRIMARY");

                entity.ToTable("acteur");

                entity.HasIndex(e => e.IdRole)
                    .HasName("fk_Utilisateur_Role1_idx");

                entity.Property(e => e.IdActeur).HasColumnName("id_acteur");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Prenom)
                    .HasColumnName("prenom")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Acteur)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("fk_Utilisateur_Role1");
            });

            modelBuilder.Entity<ActeurHasQuestion>(entity =>
            {
                entity.HasKey(e => new { e.IdActeur, e.IdQuestion })
                    .HasName("PRIMARY");

                entity.ToTable("acteur_has_question");

                entity.HasIndex(e => e.IdActeur)
                    .HasName("fk_utilisateur_has_question_utilisateur1_idx");

                entity.HasIndex(e => e.IdEtatReponse)
                    .HasName("fk_utilisateur_has_question_repondu1_idx");

                entity.HasIndex(e => e.IdQuestion)
                    .HasName("fk_utilisateur_has_question_question1_idx");

                entity.HasIndex(e => e.IdReponseCandidat)
                    .HasName("fk_utilisateur_has_question_reponse_candidat1_idx");

                entity.Property(e => e.IdActeur).HasColumnName("id_acteur");

                entity.Property(e => e.IdQuestion).HasColumnName("id_question");

                entity.Property(e => e.Commentaire).HasColumnName("commentaire");

                entity.Property(e => e.IdEtatReponse).HasColumnName("id_etat_reponse");

                entity.Property(e => e.IdReponseCandidat).HasColumnName("id_reponse_candidat");

                entity.HasOne(d => d.IdActeurNavigation)
                    .WithMany(p => p.ActeurHasQuestion)
                    .HasForeignKey(d => d.IdActeur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_utilisateur_has_question_utilisateur1");

                entity.HasOne(d => d.IdEtatReponseNavigation)
                    .WithMany(p => p.ActeurHasQuestion)
                    .HasForeignKey(d => d.IdEtatReponse)
                    .HasConstraintName("fk_utilisateur_has_question_repondu1");

                entity.HasOne(d => d.IdQuestionNavigation)
                    .WithMany(p => p.ActeurHasQuestion)
                    .HasForeignKey(d => d.IdQuestion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_utilisateur_has_question_question1");

                entity.HasOne(d => d.IdReponseCandidatNavigation)
                    .WithMany(p => p.ActeurHasQuestion)
                    .HasForeignKey(d => d.IdReponseCandidat)
                    .HasConstraintName("fk_utilisateur_has_question_reponse_candidat1");
            });

            modelBuilder.Entity<ActeurHasQuiz>(entity =>
            {
                entity.HasKey(e => new { e.IdActeur, e.IdQuiz })
                    .HasName("PRIMARY");

                entity.ToTable("acteur_has_quiz");

                entity.HasIndex(e => e.IdActeur)
                    .HasName("fk_Utilisateur_has_Quiz_Utilisateur1_idx");

                entity.HasIndex(e => e.IdQuiz)
                    .HasName("fk_Utilisateur_has_Quiz_Quiz1_idx");

                entity.Property(e => e.IdActeur).HasColumnName("id_acteur");

                entity.Property(e => e.IdQuiz).HasColumnName("id_quiz");

                entity.HasOne(d => d.IdActeurNavigation)
                    .WithMany(p => p.ActeurHasQuiz)
                    .HasForeignKey(d => d.IdActeur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Utilisateur_has_Quiz_Utilisateur1");

                entity.HasOne(d => d.IdQuizNavigation)
                    .WithMany(p => p.ActeurHasQuiz)
                    .HasForeignKey(d => d.IdQuiz)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Utilisateur_has_Quiz_Quiz1");
            });

            modelBuilder.Entity<Niveau>(entity =>
            {
                entity.HasKey(e => e.IdNiveau)
                    .HasName("PRIMARY");

                entity.ToTable("niveau");

                entity.Property(e => e.IdNiveau).HasColumnName("id_niveau");

                entity.Property(e => e.Libelle)
                    .HasColumnName("libelle")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Parametrage>(entity =>
            {
                entity.HasKey(e => e.IdParametrage)
                    .HasName("PRIMARY");

                entity.ToTable("parametrage");

                entity.HasComment("	");

                entity.Property(e => e.IdParametrage).HasColumnName("id_parametrage");

                entity.Property(e => e.Valeur)
                    .HasColumnName("valeur")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.IdQuestion)
                    .HasName("PRIMARY");

                entity.ToTable("question");

                entity.HasIndex(e => e.IdNiveau)
                    .HasName("fk_Questions_Niveau1_idx");

                entity.HasIndex(e => e.IdTypeQuestion)
                    .HasName("fk_Questions_TypeQuestion1_idx");

                entity.Property(e => e.IdQuestion).HasColumnName("id_question");

                entity.Property(e => e.ExplicationReponse).HasColumnName("explication_reponse");

                entity.Property(e => e.IdNiveau).HasColumnName("id_niveau");

                entity.Property(e => e.IdTypeQuestion).HasColumnName("id_type_question");

                entity.Property(e => e.Libelle).HasColumnName("libelle");

                entity.HasOne(d => d.IdNiveauNavigation)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.IdNiveau)
                    .HasConstraintName("fk_Questions_Niveau1");

                entity.HasOne(d => d.IdTypeQuestionNavigation)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.IdTypeQuestion)
                    .HasConstraintName("fk_Questions_TypeQuestion1");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.HasKey(e => e.IdQuiz)
                    .HasName("PRIMARY");

                entity.ToTable("quiz");

                entity.HasIndex(e => e.IdNiveau)
                    .HasName("fk_Quiz_Niveau1_idx");

                entity.HasIndex(e => e.IdTechnologie)
                    .HasName("fk_Quiz_technologie1_idx");

                entity.Property(e => e.IdQuiz).HasColumnName("id_quiz");

                entity.Property(e => e.IdNiveau).HasColumnName("id_niveau");

                entity.Property(e => e.IdTechnologie).HasColumnName("id_technologie");

                entity.HasOne(d => d.IdNiveauNavigation)
                    .WithMany(p => p.Quiz)
                    .HasForeignKey(d => d.IdNiveau)
                    .HasConstraintName("fk_Quiz_Niveau1");

                entity.HasOne(d => d.IdTechnologieNavigation)
                    .WithMany(p => p.Quiz)
                    .HasForeignKey(d => d.IdTechnologie)
                    .HasConstraintName("fk_Quiz_technologie1");
            });

            modelBuilder.Entity<Repondu>(entity =>
            {
                entity.HasKey(e => e.IdEtatReponse)
                    .HasName("PRIMARY");

                entity.ToTable("repondu");

                entity.Property(e => e.IdEtatReponse).HasColumnName("id_etat_reponse");

                entity.Property(e => e.Libelle)
                    .HasColumnName("libelle")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Reponse>(entity =>
            {
                entity.HasKey(e => e.IdReponse)
                    .HasName("PRIMARY");

                entity.ToTable("reponse");

                entity.HasIndex(e => e.IdQuestion)
                    .HasName("fk_Reponse_Questions1_idx");

                entity.Property(e => e.IdReponse).HasColumnName("id_reponse");

                entity.Property(e => e.IdQuestion).HasColumnName("id_question");

                entity.Property(e => e.Libelle)
                    .HasColumnName("libelle")
                    .HasMaxLength(255);

                entity.Property(e => e.ReponseCorrecte).HasColumnName("reponse_correcte");

                entity.HasOne(d => d.IdQuestionNavigation)
                    .WithMany(p => p.Reponse)
                    .HasForeignKey(d => d.IdQuestion)
                    .HasConstraintName("fk_Reponse_Questions1");
            });

            modelBuilder.Entity<ReponseCandidat>(entity =>
            {
                entity.HasKey(e => e.IdReponseCandidat)
                    .HasName("PRIMARY");

                entity.ToTable("reponse_candidat");

                entity.Property(e => e.IdReponseCandidat).HasColumnName("id_reponse_candidat");

                entity.Property(e => e.Libelle)
                    .HasColumnName("libelle")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PRIMARY");

                entity.ToTable("role");

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Technologie>(entity =>
            {
                entity.HasKey(e => e.IdTechnologie)
                    .HasName("PRIMARY");

                entity.ToTable("technologie");

                entity.Property(e => e.IdTechnologie).HasColumnName("id_technologie");

                entity.Property(e => e.Libelle)
                    .HasColumnName("libelle")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<TypeQuestion>(entity =>
            {
                entity.HasKey(e => e.IdTypeQuestion)
                    .HasName("PRIMARY");

                entity.ToTable("type_question");

                entity.HasComment("			");

                entity.Property(e => e.IdTypeQuestion).HasColumnName("id_type_question");

                entity.Property(e => e.Libelle)
                    .HasColumnName("libelle")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Ventillation>(entity =>
            {
                entity.HasKey(e => new { e.IdNiveauQuiz, e.IdNiveauQuestion })
                    .HasName("PRIMARY");

                entity.ToTable("ventillation");

                entity.HasComment("	");

                entity.HasIndex(e => e.IdNiveauQuestion)
                    .HasName("fk_ventillation_Niveau2_idx");

                entity.HasIndex(e => e.IdNiveauQuiz)
                    .HasName("fk_ventillation_Niveau1_idx");

                entity.Property(e => e.IdNiveauQuiz).HasColumnName("id_niveau_quiz");

                entity.Property(e => e.IdNiveauQuestion).HasColumnName("id_niveau_question");

                entity.Property(e => e.Valeur).HasColumnName("valeur");

                entity.HasOne(d => d.IdNiveauQuestionNavigation)
                    .WithMany(p => p.VentillationIdNiveauQuestionNavigation)
                    .HasForeignKey(d => d.IdNiveauQuestion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ventillation_Niveau2");

                entity.HasOne(d => d.IdNiveauQuizNavigation)
                    .WithMany(p => p.VentillationIdNiveauQuizNavigation)
                    .HasForeignKey(d => d.IdNiveauQuiz)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ventillation_Niveau1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
