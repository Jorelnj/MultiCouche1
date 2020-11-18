using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCouche1
{
    public class ProductRepoInMemory : IProductRepository
    {
        private static List<Product> data;

        public ProductRepoInMemory()
        {
            if (data == null)
                data = new List<Product>
                {
                    new Product("Admin", "Admin12345", "Administrator"),
                    new Product("Simple user", "Simple12345", "Jorel NJINANG"),
                    new Product("Hostiane", "Hostiane12345", "Hostiane KENE")
                };
        }
        public void Add(Product user, Action<IEnumerable<Product>> callBack)
        {
            data.Add(user);
            if (callBack != null)
                callBack(data);
        }

        public void Delete(Product user, Action<IEnumerable<Product>> callBack)
        {
            data.Remove(user);
            if (callBack != null)
                callBack(data);
        }

        public void Delete(IEnumerable<Product> users, Action<IEnumerable<Product>> callBack)
        {
            foreach(Product u in users)
            {
                data.Remove(u);
            }
            if (callBack != null)
                callBack(data);
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate, Action<IEnumerable<Product>> callBack)
        {
            //return data.Where(predicate);
            var users = data.Where(predicate).ToArray();
    
            if (callBack != null)
                callBack(users);

            return users;
        }

        public IEnumerable<Product> GetAll()
        {
            return data;
            //throw new NotImplementedException();
        }

        public void Set(Product oldProduct, Product newProduct, Action<IEnumerable<Product>> callBack)
        {
            data[data.IndexOf(oldProduct)] = newProduct;

            if (callBack != null)
                callBack(data);
        }
    }
}
