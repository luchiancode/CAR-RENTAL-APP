using mdb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mdb.Repositories
{
    public class mailingListRepository : RepositoryBase<mailingList>, ImailingListRepository
    {
        public mailingListRepository(mdbContext mailingListContext)
            : base(mailingListContext)
        {
        }
    }
}
