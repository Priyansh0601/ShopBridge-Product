using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.Interfaces
{
    public interface IRepository<T, AddItem, UpdateItem,DeatilsItem>
    {
        public  Task<int> Add(AddItem product);
        public Task<bool> Update(UpdateItem product);
        public Task<bool> Delete(int id);
        public Task<IEnumerable<DeatilsItem>> GetAll();
        public Task<DeatilsItem> GetSingle(int id);
    }
}
