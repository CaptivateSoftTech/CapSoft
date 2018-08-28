using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapSoft.Core.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        DBModel dbContext;
        public DBModel Init()
        {
            return dbContext ?? (dbContext = new DBModel());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
