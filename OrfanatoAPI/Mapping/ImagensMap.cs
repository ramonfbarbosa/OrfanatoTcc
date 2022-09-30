using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrfanatoAPI.Models;

namespace OrfanatoAPI.Mapping;

public class ImagensMap : IEntityTypeConfiguration<Imagens>
{
    public void Configure(EntityTypeBuilder<Imagens> builder)
    {
        builder.ToTable("TAB_IMAGENS");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID_IMAGENS").HasColumnType("INT");
        builder.Property(x => x.ImagemUrl).HasColumnName("IMAGEM_URL").HasColumnType("VARCHAR(MAX)");
        builder.HasOne(x => x.Orfanato).WithMany(x => x.Imagens).HasForeignKey(x => x.OrfanatoId);
    }
}
