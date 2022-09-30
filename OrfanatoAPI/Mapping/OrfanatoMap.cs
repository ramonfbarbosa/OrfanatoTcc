using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrfanatoAPI.Models;

namespace OrfanatoAPI.Mapping;

public class OrfanatoMap : IEntityTypeConfiguration<Orfanato>
{
    public void Configure(EntityTypeBuilder<Orfanato> builder)
    {
        builder.ToTable("TAB_ORFANATO");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID_ORFANATO").HasColumnType("INT");
        builder.Property(x => x.Nome).HasColumnName("NOME").HasColumnType("VARCHAR(150)");
        builder.Property(x => x.Latitude).HasColumnName("LATITUDE").HasColumnType("VARCHAR(150)");
        builder.Property(x => x.Longitude).HasColumnName("LONGITUDE").HasColumnType("VARCHAR(150)");
        builder.Property(x => x.Sobre).HasColumnName("SOBRE").HasColumnType("VARCHAR(150)");
        builder.Property(x => x.Instrucoes).HasColumnName("INSTRUCOES").HasColumnType("VARCHAR(150)");
        builder.Property(x => x.HoraDeAbertura).HasColumnName("HORA_DE_ABERTURA").HasColumnType("VARCHAR(50)");
        builder.Property(x => x.AbertoFimDeSemana).HasColumnName("ABERTO_FIM_DE_SEMANA").HasColumnType("bit");
        builder.Property(x => x.Ativo).HasColumnName("ATIVO").HasColumnType("bit");
        builder.HasMany(x => x.Imagens).WithOne(x => x.Orfanato).HasForeignKey(x => x.OrfanatoId);
    }
}
