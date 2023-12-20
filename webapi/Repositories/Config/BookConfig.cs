using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi.Models;

namespace webapi.Repositories.config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "101 Dalmaçyalı", Price = 75 },
                  new Book { Id = 2, Title = "Arı Maya", Price = 45 },
                    new Book { Id = 3, Title = "Tutanamayanlar", Price = 15 }


                );
        }
    }
}
