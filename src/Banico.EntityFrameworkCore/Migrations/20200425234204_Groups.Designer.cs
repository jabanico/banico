﻿// <auto-generated />
using System;
using Banico.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Banico.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200425234204_Groups")]
    partial class Groups
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("Banico.Core.Entities.AppRoleId", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppRoleId");
                });

            modelBuilder.Entity("Banico.Core.Entities.AppUserId", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppUserId");
                });

            modelBuilder.Entity("Banico.Core.Entities.Config", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Module")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnerUserIds")
                        .HasColumnType("TEXT");

                    b.Property<string>("Owners")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tenant")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Configs");

                    b.HasData(
                        new
                        {
                            Id = "1a1677fd-0b93-4547-a741-ff4c5f705c60",
                            CreatedDate = new DateTimeOffset(new DateTime(2020, 4, 25, 23, 42, 3, 629, DateTimeKind.Unspecified).AddTicks(83), new TimeSpan(0, 0, 0, 0, 0)),
                            Module = "",
                            Name = "initialized",
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Value = "n"
                        },
                        new
                        {
                            Id = "6d4519a7-2ad1-4db8-afb9-4956f6b6ca91",
                            CreatedDate = new DateTimeOffset(new DateTime(2020, 4, 25, 23, 42, 3, 630, DateTimeKind.Unspecified).AddTicks(5058), new TimeSpan(0, 0, 0, 0, 0)),
                            Module = "admin",
                            Name = "canActivate",
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Value = "admin"
                        });
                });

            modelBuilder.Entity("Banico.Core.Entities.ContentItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Alias")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attribute01")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attribute02")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attribute03")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attribute04")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attribute05")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attribute06")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attribute07")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attribute08")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attribute09")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attribute10")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attribute11")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attribute12")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attribute13")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attribute14")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attribute15")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attribute16")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attribute17")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attribute18")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attribute19")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attribute20")
                        .HasColumnType("TEXT");

                    b.Property<int>("ChildCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Module")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnerUserIds")
                        .HasColumnType("TEXT");

                    b.Property<string>("Owners")
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SectionItems")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tags")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tenant")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("ContentItems");
                });

            modelBuilder.Entity("Banico.Core.Entities.ContentItemReaction", b =>
                {
                    b.Property<string>("ContentItemId")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Reaction")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("ContentItemId", "UserId", "Reaction");

                    b.ToTable("ContentItemReaction");
                });

            modelBuilder.Entity("Banico.Core.Entities.ContentItemReactionCount", b =>
                {
                    b.Property<string>("ContentItemId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Reaction")
                        .HasColumnType("TEXT");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.HasKey("ContentItemId", "Reaction");

                    b.ToTable("ContentItemReactionCount");
                });

            modelBuilder.Entity("Banico.Core.Entities.ContentItemTag", b =>
                {
                    b.Property<string>("ContentItemId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tag")
                        .HasColumnType("TEXT");

                    b.HasKey("ContentItemId", "Tag");

                    b.ToTable("ContentItemTags");
                });

            modelBuilder.Entity("Banico.Core.Entities.ContentSectionItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContentItemId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SectionItemId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContentItemId");

                    b.HasIndex("SectionItemId");

                    b.ToTable("ContentSectionItems");
                });

            modelBuilder.Entity("Banico.Core.Entities.Follow", b =>
                {
                    b.Property<string>("Follower")
                        .HasColumnType("TEXT");

                    b.Property<string>("Following")
                        .HasColumnType("TEXT");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("Banico.Core.Entities.Group", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnerUserIds")
                        .HasColumnType("TEXT");

                    b.Property<string>("Owners")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tenant")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Banico.Core.Entities.Invite", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Inviter")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Invites");
                });

            modelBuilder.Entity("Banico.Core.Entities.RoleContent", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContentId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Read")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Write")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleContent");
                });

            modelBuilder.Entity("Banico.Core.Entities.Section", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Modules")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnerUserIds")
                        .HasColumnType("TEXT");

                    b.Property<string>("Owners")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tenant")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Banico.Core.Entities.SectionItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Alias")
                        .HasColumnType("TEXT");

                    b.Property<int>("ChildCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnerUserIds")
                        .HasColumnType("TEXT");

                    b.Property<string>("Owners")
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PathName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PathUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Section")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tenant")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SectionItems");
                });

            modelBuilder.Entity("Banico.Core.Entities.UserContent", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContentId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Read")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Write")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("UserId");

                    b.ToTable("UserContent");
                });

            modelBuilder.Entity("Banico.Core.Entities.UserGroup", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("UserGroup");
                });

            modelBuilder.Entity("Banico.Core.Entities.ContentItem", b =>
                {
                    b.HasOne("Banico.Core.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("Banico.Core.Entities.ContentItemReaction", b =>
                {
                    b.HasOne("Banico.Core.Entities.ContentItem", null)
                        .WithMany("ContentItemReactions")
                        .HasForeignKey("ContentItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Banico.Core.Entities.ContentItemReactionCount", b =>
                {
                    b.HasOne("Banico.Core.Entities.ContentItem", null)
                        .WithMany("ContentItemReactionCounts")
                        .HasForeignKey("ContentItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Banico.Core.Entities.ContentItemTag", b =>
                {
                    b.HasOne("Banico.Core.Entities.ContentItem", null)
                        .WithMany("ContentItemTags")
                        .HasForeignKey("ContentItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Banico.Core.Entities.ContentSectionItem", b =>
                {
                    b.HasOne("Banico.Core.Entities.ContentItem", null)
                        .WithMany("ContentSectionItems")
                        .HasForeignKey("ContentItemId");

                    b.HasOne("Banico.Core.Entities.SectionItem", "SectionItem")
                        .WithMany()
                        .HasForeignKey("SectionItemId");
                });

            modelBuilder.Entity("Banico.Core.Entities.RoleContent", b =>
                {
                    b.HasOne("Banico.Core.Entities.ContentItem", "Content")
                        .WithMany("Roles")
                        .HasForeignKey("ContentId");

                    b.HasOne("Banico.Core.Entities.AppRoleId", "Role")
                        .WithMany("ContentItems")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Banico.Core.Entities.UserContent", b =>
                {
                    b.HasOne("Banico.Core.Entities.ContentItem", "Content")
                        .WithMany("Users")
                        .HasForeignKey("ContentId");

                    b.HasOne("Banico.Core.Entities.AppUserId", "User")
                        .WithMany("ContentItems")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Banico.Core.Entities.UserGroup", b =>
                {
                    b.HasOne("Banico.Core.Entities.Group", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId");

                    b.HasOne("Banico.Core.Entities.AppUserId", "User")
                        .WithMany("Groups")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}