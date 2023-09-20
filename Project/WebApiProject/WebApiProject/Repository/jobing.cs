using Microsoft.EntityFrameworkCore;
using WebApiProject.Models;

namespace WebApiProject.Repository
{
	public class jobing : Ijobing
	{
		Context context;
		public jobing(Context _context)
		{
			context = _context;
		}

		public List<Job> getall()
		{
			return context.Job.Include(p => p.Profile).Include(p => p.Proposals).ToList();
		}
	}
}
