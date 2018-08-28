using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapSoft.Core.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DBModel Init();
    }
}
