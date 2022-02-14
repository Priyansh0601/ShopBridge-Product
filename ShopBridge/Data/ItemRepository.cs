using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBridge.Interfaces;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Data
{
    public class ProductsRepository: IRepository<Product, ProductAddDto, ProductUpdateDto, ProductDetailsDto>
    {
        ShopBridgeDbContext _dbcontext;
        public ProductsRepository(ShopBridgeDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> Add(ProductAddDto product)
        {
            var addproduct = product.ToProduct();
           var obj=await _dbcontext.Item.AddAsync(addproduct); //product.ToEntity()
            await _dbcontext.SaveChangesAsync();
            return addproduct.Id;//
        }

        public async Task<bool> Delete(int Id)
        {
            var item = await _dbcontext.Item.FirstOrDefaultAsync(x => x.Id==Id);
            if (item != null)
            {
                _dbcontext.Item.Remove(item);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ProductDetailsDto>> GetAll()
        {
            var list = await _dbcontext.Item.ToListAsync();
            var details = list.Select(x => x.ToDto());
            return details;
        }
        public async Task<ProductDetailsDto> GetSingle(int id)
        {
            var product = await _dbcontext.Item.FindAsync(id);
            if (product == null)
                return null ;
            var details = product.ToDto();
            return details;
        }
        public async Task<bool> Update(ProductUpdateDto product)
        {
            var item = await _dbcontext.Item.FirstOrDefaultAsync(x=>x.Id==product.Id);
            if (item == null)
                return false;

            item.Name = product.Name;
            item.Description = product.Description;
            item.Price = product.Price;

            _dbcontext.Item.Update(item);
            await _dbcontext.SaveChangesAsync();
            return true;
        }      
    }
}
