using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WatchPartyApi.Models;

namespace WatchPartyApi.Migrations
{
    [DbContext(typeof(WatchPartyDbContext))]
    [Migration("20160817200615_Initial-Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WpApi.Models.Event", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("CancellationReason");

                    b.Property<string>("CreatedByUserId");

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("GameId");

                    b.Property<string>("GooglePlaceId");

                    b.Property<bool>("IsCancelled");

                    b.Property<int>("NumberAttending");

                    b.Property<string>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("TeamId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("WpApi.Models.EventComment", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Comment");

                    b.Property<string>("CreatedByUserId");

                    b.Property<string>("EventId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("NumberOfFlags");

                    b.Property<string>("ParentCommentId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("EventComments");
                });

            modelBuilder.Entity("WpApi.Models.Game", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("GameDate");

                    b.Property<string>("GameTime");

                    b.Property<string>("Opponent");

                    b.Property<string>("OpponentLogo");

                    b.Property<string>("TeamId");

                    b.Property<string>("TvNetwork");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("WpApi.Models.Team", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Conference");

                    b.Property<string>("EspnPageUrl");

                    b.Property<string>("EspnTeamId");

                    b.Property<string>("Icon");

                    b.Property<string>("Mascot");

                    b.Property<string>("Name");

                    b.Property<int>("NationalRank");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("WpApi.Models.User", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WpApi.Models.UserLocation", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("GooglePlaceId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserLocations");
                });

            modelBuilder.Entity("WpApi.Models.UserTeam", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("TeamId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTeams");
                });

            modelBuilder.Entity("WpApi.Models.Event", b =>
                {
                    b.HasOne("WpApi.Models.Game", "Game")
                        .WithMany("Events")
                        .HasForeignKey("GameId");

                    b.HasOne("WpApi.Models.Team", "Team")
                        .WithMany("Events")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("WpApi.Models.EventComment", b =>
                {
                    b.HasOne("WpApi.Models.Event")
                        .WithMany("Comments")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("WpApi.Models.Game", b =>
                {
                    b.HasOne("WpApi.Models.Team", "Team")
                        .WithMany("Games")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("WpApi.Models.UserLocation", b =>
                {
                    b.HasOne("WpApi.Models.User", "User")
                        .WithMany("UserLocations")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WpApi.Models.UserTeam", b =>
                {
                    b.HasOne("WpApi.Models.Team", "Team")
                        .WithMany("UserTeams")
                        .HasForeignKey("TeamId");

                    b.HasOne("WpApi.Models.User", "User")
                        .WithMany("UserTeams")
                        .HasForeignKey("UserId");
                });
        }
    }
}
