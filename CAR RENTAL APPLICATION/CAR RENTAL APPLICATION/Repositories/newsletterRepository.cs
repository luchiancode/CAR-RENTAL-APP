using mdb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mdb.Repositories
{
    public class newsletterRepository : RepositoryBase<newsletter>, InewsletterRepository
    {
        public newsletterRepository(mdbContext newsletterContext)
            : base(newsletterContext)
        {
        }

    }
}
