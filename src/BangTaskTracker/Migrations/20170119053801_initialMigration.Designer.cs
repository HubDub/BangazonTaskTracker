using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BangTaskTracker.Data;

namespace BangTaskTracker.Migrations
{
    [DbContext(typeof(TrackerContext))]
    [Migration("20170119053801_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BangTaskTracker.Models.TrackedTask", b =>
                {
                    b.Property<int>("Taskid")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CompletedOn");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<string>("TaskName")
                        .IsRequired();

                    b.Property<int>("TaskOrderStatus");

                    b.HasKey("Taskid");

                    b.ToTable("TrackedTask");
                });
        }
    }
}
