using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Container.EF
{
    public class DbOptions 
    {

    }


    public class ContainerDbContext : DbContext
    {
        public ContainerDbContext(IOptions<DbOptions> options)
        {

        }


    }
}