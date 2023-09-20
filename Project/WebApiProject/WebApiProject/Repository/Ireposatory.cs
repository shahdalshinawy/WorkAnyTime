using System.Linq.Expressions;
using WebApiProject.Models;

namespace WebApiProject.repo
{
    public interface Ireposatory<T>
    {


        public List<T> getall();
        public List<T> getall(string s);
        public List<T> getall(string s1, string s2);// to make include by s as opject in the dbset 
        public T getbyidInt(int id);
        public T getbyidString(string id);
        public void create(T course);
        public void update(T course);
        public void delete(T course);

    }
}
