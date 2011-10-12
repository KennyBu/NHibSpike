using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace NHibernateSpike
{
    class Program
    {
        static void Main()
        {
            var SessionFactory = Fluently.Configure()
                .Database(MsSqlCeConfiguration.Standard.ConnectionString(a => a.FromConnectionStringWithKey("BrandDatabase")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Brand>())
                .BuildSessionFactory();

            using (var session = SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    for (var i = 0; i < 10; i++)
                    {
                        var testId = Guid.NewGuid().ToString("N");
                        
                        var brand = new Brand
                        {
                            Name = "testBrand " + testId,
                            Description = "Test Description " + testId,
                        };

                        session.SaveOrUpdate(brand);
                    }

                    transaction.Commit();
                }
            }
        }
    }
}