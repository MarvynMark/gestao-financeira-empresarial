﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PenielBikeControle.Data;

#nullable disable

namespace PenielBikeControle.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230122191221_EdicaoNaEstruturaDeEntidades")]
    partial class EdicaoNaEstruturaDeEntidades
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PenielBikeControle.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("DataDeNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PenielBikeControle.Models.ItemVenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ProdutoClienteId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoEstoqueId")
                        .HasColumnType("int");

                    b.Property<int>("VendaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoClienteId");

                    b.HasIndex("ProdutoEstoqueId");

                    b.HasIndex("VendaId");

                    b.ToTable("ItensVenda");
                });

            modelBuilder.Entity("PenielBikeControle.Models.ProdutoCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<string>("Marca")
                        .HasColumnType("longtext");

                    b.Property<string>("Modelo")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("ProdutosCliente");
                });

            modelBuilder.Entity("PenielBikeControle.Models.ProdutoEstoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<string>("Marca")
                        .HasColumnType("longtext");

                    b.Property<string>("Modelo")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("PrecoCusto")
                        .HasColumnType("double");

                    b.Property<double>("PrecoFinal")
                        .HasColumnType("double");

                    b.Property<int>("QtdeEmEstoque")
                        .HasColumnType("int");

                    b.Property<int>("TipoProdutoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoProdutoId");

                    b.ToTable("ProdutosEstoque");
                });

            modelBuilder.Entity("PenielBikeControle.Models.TipoProdutoEstoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TiposProduto");
                });

            modelBuilder.Entity("PenielBikeControle.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("DescontoTotal")
                        .HasColumnType("double");

                    b.Property<bool>("ProdutoEstoqueEntregue")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("VendaPaga")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("VendedorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("PenielBikeControle.Models.Vendedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("DataDeNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Vendedores");
                });

            modelBuilder.Entity("PenielBikeControle.Models.ItemVenda", b =>
                {
                    b.HasOne("PenielBikeControle.Models.ProdutoCliente", "ProdutoCliente")
                        .WithMany()
                        .HasForeignKey("ProdutoClienteId");

                    b.HasOne("PenielBikeControle.Models.ProdutoEstoque", "ProdutoEstoque")
                        .WithMany()
                        .HasForeignKey("ProdutoEstoqueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PenielBikeControle.Models.Venda", "Venda")
                        .WithMany("ItensDaVenda")
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProdutoCliente");

                    b.Navigation("ProdutoEstoque");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("PenielBikeControle.Models.ProdutoCliente", b =>
                {
                    b.HasOne("PenielBikeControle.Models.Cliente", "Cliente")
                        .WithMany("ProdutosCliente")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("PenielBikeControle.Models.ProdutoEstoque", b =>
                {
                    b.HasOne("PenielBikeControle.Models.TipoProdutoEstoque", "TipoProduto")
                        .WithMany()
                        .HasForeignKey("TipoProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoProduto");
                });

            modelBuilder.Entity("PenielBikeControle.Models.Venda", b =>
                {
                    b.HasOne("PenielBikeControle.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PenielBikeControle.Models.Vendedor", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("PenielBikeControle.Models.Cliente", b =>
                {
                    b.Navigation("ProdutosCliente");
                });

            modelBuilder.Entity("PenielBikeControle.Models.Venda", b =>
                {
                    b.Navigation("ItensDaVenda");
                });
#pragma warning restore 612, 618
        }
    }
}
