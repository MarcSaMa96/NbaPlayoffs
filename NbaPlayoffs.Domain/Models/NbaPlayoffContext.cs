using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NbaPlayoffs.Domain.Models;

public partial class NbaPlayoffContext : DbContext
{
    public NbaPlayoffContext()
    {
    }

    public NbaPlayoffContext(DbContextOptions<NbaPlayoffContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Conference> Conferences { get; set; }

    public virtual DbSet<FavouriteTeam> FavouriteTeams { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerPosition> PlayerPositions { get; set; }

    public virtual DbSet<PlayerRecord> PlayerRecords { get; set; }

    public virtual DbSet<PlayoffGuess> PlayoffGuesses { get; set; }

    public virtual DbSet<PlayoffGuessHeader> PlayoffGuessHeaders { get; set; }

    public virtual DbSet<PlayoffRank> PlayoffRanks { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamRecord> TeamRecords { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conference>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Conferen__3214EC072853B351");

            entity.ToTable("Conference");

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<FavouriteTeam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Favourit__3214EC07BAEB0A68");

            entity.ToTable("FavouriteTeam");

            entity.HasIndex(e => e.Email, "UQ__Favourit__A9D10534AE175F89").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(50);

            entity.HasOne(d => d.IdTeamNavigation).WithMany(p => p.FavouriteTeams)
                .HasForeignKey(d => d.IdTeam)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FavouriteTeam_Team");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Player__3214EC070D6617A3");

            entity.ToTable("Player");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.PlayerPosition).WithMany(p => p.Players)
                .HasForeignKey(d => d.PlayerPositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Player_PlayerPosition");
        });

        modelBuilder.Entity<PlayerPosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlayerPo__3214EC07F88A6688");

            entity.ToTable("PlayerPosition");

            entity.Property(e => e.Code)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasMaxLength(10);
        });

        modelBuilder.Entity<PlayerRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlayerRe__3214EC072FFBFC8B");

            entity.ToTable("PlayerRecord");

            entity.HasOne(d => d.Player).WithMany(p => p.PlayerRecords)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayerRecord_Player");

            entity.HasOne(d => d.TeamRecord).WithMany(p => p.PlayerRecords)
                .HasForeignKey(d => d.TeamRecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayerRecord_TeamRecord");
        });

        modelBuilder.Entity<PlayoffGuess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlayoffG__3214EC0745A8660D");

            entity.ToTable("PlayoffGuess");

            entity.HasIndex(e => new { e.TeamRecordId, e.PlayoffGuessHeaderId }, "UC_TeamRecord_PlayoffGuessHeader").IsUnique();

            entity.HasOne(d => d.PlayoffGuessHeader).WithMany(p => p.PlayoffGuesses)
                .HasForeignKey(d => d.PlayoffGuessHeaderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayoffGuess_PlayoffGuessHeader");

            entity.HasOne(d => d.PlayoffRank).WithMany(p => p.PlayoffGuesses)
                .HasForeignKey(d => d.PlayoffRankId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayoffGuess_PlayoffRank");

            entity.HasOne(d => d.TeamRecord).WithMany(p => p.PlayoffGuesses)
                .HasForeignKey(d => d.TeamRecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayoffGuess_TeamRecord");
        });

        modelBuilder.Entity<PlayoffGuessHeader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlayoffG__3214EC0786540EAD");

            entity.ToTable("PlayoffGuessHeader");

            entity.HasIndex(e => e.Email, "UQ__PlayoffG__A9D105341823BBF7").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(50);
        });

        modelBuilder.Entity<PlayoffRank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlayoffR__3214EC071A3F4019");

            entity.ToTable("PlayoffRank");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(50);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Team__3214EC074C6B3D4E");

            entity.ToTable("Team");

            entity.HasIndex(e => e.Name, "UQ__Team__737584F6F47D9D5F").IsUnique();

            entity.Property(e => e.ImageRoute).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Conference).WithMany(p => p.Teams)
                .HasForeignKey(d => d.ConferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Team_Conference");
        });

        modelBuilder.Entity<TeamRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TeamReco__3214EC07E94561E4");

            entity.ToTable("TeamRecord");

            entity.HasIndex(e => new { e.TeamId, e.Year }, "UC_TeamRecord").IsUnique();

            entity.HasOne(d => d.Team).WithMany(p => p.TeamRecords)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamRecord_Team");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
