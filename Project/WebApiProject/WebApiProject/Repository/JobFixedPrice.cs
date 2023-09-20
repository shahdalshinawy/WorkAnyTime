using Microsoft.EntityFrameworkCore;
using WebApiProject.Models;

namespace WebApiProject.Repository
{
	public class JobFixedPrice :IjobFixedPrice
	{
		Context context1;
		public JobFixedPrice(Context context)
		{
			context1 = context;

		}
		public List<Job> jobByFixedPrice()
		{
			return context1.Job.Include(p => p.Profile).Include(q => q.Category).Include(pp=>pp.Proposals).Where(w => w.IsHourly == false).ToList();
		}
	}
}
