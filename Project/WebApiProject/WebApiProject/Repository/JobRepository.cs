using Microsoft.EntityFrameworkCore;
using WebApiProject.Models;

namespace WebApiProject.Repository
{
    public class JobRepository<T> : IRepository<T> where T : class
    {
        Context _context;
        public JobRepository(Context context)
        {
            _context = context;
        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }


        public List<T> getall(string s)
        {
            return _context.Set<T>().Include(s).ToList();
        }

        public T GetById(int id)
        {

            return _context.Find<T>(id);
        }

        public void Create(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
        }
        public void Update(T tt)
        {
            // T teemp = c.Find<T>(tt);
            _context.Update<T>(tt);
            _context.SaveChanges();
        }
        public void Delete(T tt)
        {
            _context.Remove<T>(tt);
            _context.SaveChanges();
        }

        public T getbyidString(string id)
        {

            return _context.Find<T>(id);
        }
    }

}
