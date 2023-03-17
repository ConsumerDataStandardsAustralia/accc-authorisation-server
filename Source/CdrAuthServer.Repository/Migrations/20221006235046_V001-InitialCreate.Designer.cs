﻿// <auto-generated />
using System;
using CdrAuthServer.Repository.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CdrAuthServer.Repository.Migrations
{
    [DbContext(typeof(CdrAuthServervDatabaseContext))]
    [Migration("20221006235046_V001-InitialCreate")]
    partial class V001InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CdrAuthServer.Repository.Entities.Client", b =>
                {
                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClientDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ClientIdIssuedAt")
                        .HasColumnType("bigint");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            ClientId = "11111111-1111-1111-1111-111111111111",
                            ClientIdIssuedAt = 0L,
                            ClientName = "Software Product 1"
                        });
                });

            modelBuilder.Entity("CdrAuthServer.Repository.Entities.ClientClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ClientId" }, "IX_ClientClaims_ClientId");

                    b.ToTable("ClientClaims");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = "11111111-1111-1111-1111-111111111111",
                            Type = "SoftwareId",
                            Value = "22222222-2222-2222-2222-222222222222"
                        },
                        new
                        {
                            Id = 2,
                            ClientId = "11111111-1111-1111-1111-111111111111",
                            Type = "JwksUri",
                            Value = "https://localhost:9001/jwks"
                        });
                });

            modelBuilder.Entity("CdrAuthServer.Repository.Entities.Grant", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("GrantType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scope")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UsedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Key");

                    b.ToTable("Grants");

                    b.HasData(
                        new
                        {
                            Key = "12345678-1234-1234-1234-111122223333",
                            ClientId = "c6327f87-687a-4369-99a4-eaacd3bb8210",
                            CreatedAt = new DateTime(2022, 10, 6, 23, 50, 45, 993, DateTimeKind.Utc).AddTicks(9273),
                            Data = "{\"refresh_token\":\"valid-refresh-token\",\"account_id\":[\"123\",\"456\",\"789\"]}",
                            ExpiresAt = new DateTime(2023, 10, 6, 23, 50, 45, 993, DateTimeKind.Utc).AddTicks(9277),
                            GrantType = "cdr_arrangement",
                            Scope = "openid profile cdr:registration common:customer.basic:read common:customer.detail:read bank:accounts.basic:read bank:accounts.detail:read bank:transactions:read bank:payees:read bank:regular_payments:read energy:electricity.servicepoints.basic:read energy:electricity.servicepoints.detail:read energy:electricity.usage:read energy:electricity.der:read energy:accounts.basic:read energy:accounts.detail:read energy:accounts.paymentschedule:read energy:accounts.concessions:read energy:billing:read",
                            SubjectId = "customer1"
                        },
                        new
                        {
                            Key = "valid-refresh-token",
                            ClientId = "c6327f87-687a-4369-99a4-eaacd3bb8210",
                            CreatedAt = new DateTime(2022, 10, 6, 23, 50, 45, 993, DateTimeKind.Utc).AddTicks(9704),
                            Data = "{\"response_type\":\"code id_token\",\"CdrArrangementId\":\"12345678-1234-1234-1234-111122223333\"}",
                            ExpiresAt = new DateTime(2023, 10, 6, 23, 50, 45, 993, DateTimeKind.Utc).AddTicks(9705),
                            GrantType = "refresh_token",
                            Scope = "openid profile cdr:registration common:customer.basic:read common:customer.detail:read bank:accounts.basic:read bank:accounts.detail:read bank:transactions:read bank:payees:read bank:regular_payments:read energy:electricity.servicepoints.basic:read energy:electricity.servicepoints.detail:read energy:electricity.usage:read energy:electricity.der:read energy:accounts.basic:read energy:accounts.detail:read energy:accounts.paymentschedule:read energy:accounts.concessions:read energy:billing:read",
                            SubjectId = "customer1"
                        },
                        new
                        {
                            Key = "expired-refresh-token",
                            ClientId = "c6327f87-687a-4369-99a4-eaacd3bb8210",
                            CreatedAt = new DateTime(2021, 10, 5, 23, 50, 45, 993, DateTimeKind.Utc).AddTicks(9729),
                            Data = "{\"response_type\":\"code id_token\",\"CdrArrangementId\":\"5331d338-6ee8-4d14-b670-fbdb62d6837f\"}",
                            ExpiresAt = new DateTime(2022, 10, 5, 23, 50, 45, 993, DateTimeKind.Utc).AddTicks(9730),
                            GrantType = "refresh_token",
                            Scope = "openid profile cdr:registration common:customer.basic:read common:customer.detail:read bank:accounts.basic:read bank:accounts.detail:read bank:transactions:read bank:payees:read bank:regular_payments:read",
                            SubjectId = "customer1"
                        });
                });

            modelBuilder.Entity("CdrAuthServer.Repository.Entities.SoftwareProduct", b =>
                {
                    b.Property<string>("SoftwareProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BrandId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LegalEntityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LegalEntityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LegalEntityStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoUri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoftwareProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoftwareProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SoftwareProductId");

                    b.ToTable("SoftwareProducts");

                    b.HasData(
                        new
                        {
                            SoftwareProductId = "c6327f87-687a-4369-99a4-eaacd3bb8210",
                            BrandId = "FFB1C8BA-279E-44D8-96F0-1BC34A6B436F",
                            BrandName = "Mock Data Recipient Brand Name",
                            BrandStatus = "ACTIVE",
                            LegalEntityId = "18B75A76-5821-4C9E-B465-4709291CF0F4",
                            LegalEntityName = "Mock Data Recipient Legal Entity Name",
                            LegalEntityStatus = "ACTIVE",
                            LogoUri = "https://cdrsandbox.gov.au/logo192.png",
                            SoftwareProductDescription = "Mock Data Recipient Software Product",
                            SoftwareProductName = "Mock Data Recipient Software Product",
                            Status = "ACTIVE"
                        },
                        new
                        {
                            SoftwareProductId = "22222222-2222-2222-2222-222222222222",
                            BrandId = "BBBBBBBB-2222-2222-2222-222222222222",
                            BrandName = "Active Data Recipient Brand Name",
                            BrandStatus = "ACTIVE",
                            LegalEntityId = "LLLLLLLL-2222-2222-2222-222222222222",
                            LegalEntityName = "Active Data Recipient Legal Entity Name",
                            LegalEntityStatus = "ACTIVE",
                            LogoUri = "https://cdrsandbox.gov.au/logo192.png",
                            SoftwareProductDescription = "Active Data Recipient Software Product",
                            SoftwareProductName = "Active Data Recipient Software Product",
                            Status = "ACTIVE"
                        },
                        new
                        {
                            SoftwareProductId = "99999999-9999-9999-9999-999999999999",
                            BrandId = "BBBBBBBB-2222-2222-2222-222222222222",
                            BrandName = "Active Data Recipient Brand Name",
                            BrandStatus = "ACTIVE",
                            LegalEntityId = "LLLLLLLL-2222-2222-2222-222222222222",
                            LegalEntityName = "Active Data Recipient Legal Entity Name",
                            LegalEntityStatus = "ACTIVE",
                            LogoUri = "https://cdrsandbox.gov.au/logo192.png",
                            SoftwareProductDescription = "Removed Software Product",
                            SoftwareProductName = "Removed Software Product",
                            Status = "REMOVED"
                        });
                });

            modelBuilder.Entity("CdrAuthServer.Repository.Entities.Token", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("BlackListed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("CdrAuthServer.Repository.Entities.ClientClaims", b =>
                {
                    b.HasOne("CdrAuthServer.Repository.Entities.Client", "Client")
                        .WithMany("ClientClaims")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("CdrAuthServer.Repository.Entities.Client", b =>
                {
                    b.Navigation("ClientClaims");
                });
#pragma warning restore 612, 618
        }
    }
}
