using FluentNHibernate.Mapping;
using MigrationSamples.Data.EFCore.FluentNhibernate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationSamples.Data.EFCore.FluentNhibernate.Mappings
{
    public class ContactInfoMap : ClassMap<ContactInfo>
    {
        public ContactInfoMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Email);
            Map(x => x.Phone);
            Table("ContactInfos");
        }
    }
}
