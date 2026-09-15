

using BookHub.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookHub.Infrastructure.Configrations
{
    public class BookConfigration
    {
        
        public class BookConfiguration : IEntityTypeConfiguration<Book>
        {
            public void Configure(EntityTypeBuilder<Book> builder)
            {
                builder.HasKey(b => b.Id);

                builder.Property(b => b.Title)
                       .IsRequired()
                       .HasMaxLength(200);

                builder.Property(b => b.Author)
                       .IsRequired()
                       .HasMaxLength(150);

                builder.Property(b => b.ISBN)
                       .IsRequired()
                       .HasMaxLength(20);

                builder.HasIndex(b => b.ISBN)
                       .IsUnique();

                builder.Property(b => b.Category)
                       .IsRequired()
                       .HasMaxLength(100);

                builder.Property(b => b.AvailableCopies)
                       .IsRequired();
            }
        }
    }
}

