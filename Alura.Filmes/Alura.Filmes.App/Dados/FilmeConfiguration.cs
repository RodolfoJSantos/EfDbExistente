﻿using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
	public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
	{
		public void Configure(EntityTypeBuilder<Filme> builder)
		{
			builder
				.ToTable("film");

			builder
				.Property(f => f.Id)
				.HasColumnName("film_id")
				.IsRequired();

			builder
				.Property(f => f.Titulo)
				.HasColumnName("title")
				.HasColumnType("varchar(255)")
				.IsRequired();

			builder
				.Property(f => f.Desscricao)
				.HasColumnName("description")
				.HasColumnType("text");

			builder
				.Property(f => f.AnoLancamento)
				.HasColumnName("release_year")
				.HasColumnType("varchar(4)");

			builder
				.Property(f => f.Duracao)
				.HasColumnName("length")
				.HasColumnType("smallint");

			builder
				.Property<DateTime>("last_update")
				.HasColumnType("datetime")
				.IsRequired();
		}
	}
}