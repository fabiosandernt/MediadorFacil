﻿// <auto-generated />
using System;
using MediadorFacil.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MediadorFacil.Infrastructure.Migrations
{
    [DbContext(typeof(MediadorFacilContext))]
    [Migration("20230708215214_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConvencaoColetivaSindicato", b =>
                {
                    b.Property<Guid>("ConvencaoColetivasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SindicatosId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ConvencaoColetivasId", "SindicatosId");

                    b.HasIndex("SindicatosId");

                    b.ToTable("ConvencaoColetivaSindicato");
                });

            modelBuilder.Entity("EmpresaSindicato", b =>
                {
                    b.Property<Guid>("EmpresasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SindicatosId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EmpresasId", "SindicatosId");

                    b.HasIndex("SindicatosId");

                    b.ToTable("EmpresaSindicato");
                });

            modelBuilder.Entity("MediadorFacil.Domain.Account.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Empresas", (string)null);
                });

            modelBuilder.Entity("MediadorFacil.Domain.Account.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("MediadorFacil.Domain.InstrumentoColetivo.ConvencaoColetiva", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeSindicatoPatronal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeSindicatoPatronal");

                    b.Property<string>("NomeSindicatoTrabalhador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeSindicatoTrabalhador");

                    b.Property<string>("NumeroProcesso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NumeroProcesso");

                    b.Property<string>("NumeroRegistro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NumeroRegistro");

                    b.Property<string>("NumeroSolicitacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NumeroSolicitacao");

                    b.Property<string>("TipoInstrumentoColetivo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TipoInstrumentoColetivo");

                    b.HasKey("Id");

                    b.ToTable("ConvencoesColetivas", (string)null);
                });

            modelBuilder.Entity("MediadorFacil.Domain.InstrumentoColetivo.Sindicato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Cnpj");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RazaoSocial");

                    b.Property<int?>("TipoSindicato")
                        .HasColumnType("int")
                        .HasColumnName("TipoSindicato");

                    b.HasKey("Id");

                    b.ToTable("Sindicatos", (string)null);
                });

            modelBuilder.Entity("MediadorFacil.Domain.InstrumentoColetivo.Vigencia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConvencaoColetivaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataFim");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInicio");

                    b.HasKey("Id");

                    b.HasIndex("ConvencaoColetivaId");

                    b.ToTable("Vigencias", (string)null);
                });

            modelBuilder.Entity("ConvencaoColetivaSindicato", b =>
                {
                    b.HasOne("MediadorFacil.Domain.InstrumentoColetivo.ConvencaoColetiva", null)
                        .WithMany()
                        .HasForeignKey("ConvencaoColetivasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediadorFacil.Domain.InstrumentoColetivo.Sindicato", null)
                        .WithMany()
                        .HasForeignKey("SindicatosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmpresaSindicato", b =>
                {
                    b.HasOne("MediadorFacil.Domain.Account.Empresa", null)
                        .WithMany()
                        .HasForeignKey("EmpresasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediadorFacil.Domain.InstrumentoColetivo.Sindicato", null)
                        .WithMany()
                        .HasForeignKey("SindicatosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MediadorFacil.Domain.Account.Empresa", b =>
                {
                    b.HasOne("MediadorFacil.Domain.Account.User", "User")
                        .WithMany("Empresas")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MediadorFacil.Domain.Account.User", b =>
                {
                    b.OwnsOne("MediadorFacil.Domain.Account.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasMaxLength(1024)
                                .HasColumnType("nvarchar(1024)")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("MediadorFacil.Domain.Account.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Password");

                            b1.HasKey("UserId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();
                });

            modelBuilder.Entity("MediadorFacil.Domain.InstrumentoColetivo.Vigencia", b =>
                {
                    b.HasOne("MediadorFacil.Domain.InstrumentoColetivo.ConvencaoColetiva", "ConvencaoColetiva")
                        .WithMany("Vigencias")
                        .HasForeignKey("ConvencaoColetivaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConvencaoColetiva");
                });

            modelBuilder.Entity("MediadorFacil.Domain.Account.User", b =>
                {
                    b.Navigation("Empresas");
                });

            modelBuilder.Entity("MediadorFacil.Domain.InstrumentoColetivo.ConvencaoColetiva", b =>
                {
                    b.Navigation("Vigencias");
                });
#pragma warning restore 612, 618
        }
    }
}