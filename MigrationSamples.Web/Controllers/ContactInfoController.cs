using EFCoreSecondLevelCacheInterceptor;
using Microsoft.AspNetCore.Mvc;
using MigrationSamples.Data.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationSamples.Web.Controllers
{
    public class ContactInfoController : Controller
    {
        private readonly DataContext _dataContext;

        public ContactInfoController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var orders = _dataContext.ContactInfos
                .Cacheable(CacheExpirationMode.Sliding, TimeSpan.FromMinutes(5))
                .ToList();
            return View(orders);

            // Below is an example of the same query, using caching, in NHibernate.
            //using (var session = CreateSessionFactory.GetFactory().OpenSession())
            //using (var transaction = session.BeginTransaction())
            //{
            //    var contactInfos = session.Query<ContactInfo>().WithOptions(o => o.SetCacheable(true).SetCacheMode(CacheMode.Normal)).ToList();
            //    return View(contactInfos);
            //}
        }
    }
}
