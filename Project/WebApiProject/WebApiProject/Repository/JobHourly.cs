using Microsoft.EntityFrameworkCore;
using WebApiProject.Models;

namespace WebApiProject.Repository
{
	public class JobHourly:IJobHourly
	{
		Context context;
		public JobHourly(Context _context)
		{
			context = _context;
		}
		public List<Job> jobshourly()
		{
			return context.Job.Include(e=>e.Profile).Include(w=>w.Proposals).Where(h=>h.IsHourly==true).ToList();
		} 
	}
}
