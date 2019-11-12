using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GR.Data
{
    public class AuthorMap
    {
        public AuthorMap(EntityTypeBuilder<Author> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.LastName).IsRequired();
            entityBuilder.Property(t => t.Email).IsRequired();           
        }
    }
}
