namespace WebApiProject.Repository
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
        public List<T> getall(string s); // to make include by s as object in the dbset 
        public T GetById(int id);
        public void Create(T Jop);
        public void Update(T Jop);
        public void Delete(T Jop);
        public T getbyidString(string id);
    }
}
