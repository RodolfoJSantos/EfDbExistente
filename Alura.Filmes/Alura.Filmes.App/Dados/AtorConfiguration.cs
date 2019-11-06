﻿using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
	class AtorConfiguration : IEntityTypeConfiguration<Ator>
	{
		public void Configure(EntityTypeBuilder<Ator> builder)
		{
			builder
				.ToTable("actor");

			builder
				.Property(p => p.Id)
				.HasColumnName("actor_id");

			builder
				.Property(p => p.PrimeiroNome)
				.HasColumnName("first_name")
				.HasColumnType("varchar(45)")
				.IsRequired();

			builder
				.Property(p => p.UltimoNome)
				.HasColumnName("last_name")
				.HasColumnType("varchar(45)")
				.IsRequired();

			builder
				.Property<DateTime>("last_update")
				.IsRequired()
				.HasColumnType("datetime");
		}
	}
}
