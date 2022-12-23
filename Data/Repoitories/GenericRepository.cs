using Microsoft.EntityFrameworkCore;

namespace Data.Repoitories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        T FindById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        bool Any(Func<T, bool> query);
        void Save();
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private MenaPharmCompanyContext _context;
        private DbSet<T> table;
        public GenericRepository()
        {
            this._context = new MenaPharmCompanyContext();
            table = _context.Set<T>();
        }
        public GenericRepository(MenaPharmCompanyContext context)
        {
            this._context = context;
            table = _context.Set<T>();
        }
        public void Delete(int id)
        {
            var existing = FindById(id);
            if (existing != null)
                table.Remove(existing);
        }

        public T FindById(int id)
        {
            return table.Find(id);
        }
        public bool Any(Func<T,bool> query)
        {
            return table.Any(query);
        }
        public IEnumerable<T> GetAll()
        {
            return table;
        }

        public T GetById(object id) => table.Find(id);

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
