using FluentNHibernate.Mapping;

namespace NHibernateSpike
{
    public class BrandMap : ClassMap<Brand>
    {
        public BrandMap()
        {
            Table("Brand");

            Id(x => x.BrandId).Column("Id");
            Map(x => x.Name).Column("Name");
            Map(x => x.Description).Column("Description");
        }
    }
}