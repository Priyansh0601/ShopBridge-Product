using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShopBridge.Models
{
    public class ProductDto
    {
        
        public string Name { get; set; }  
        public string Description { get; set; }
        public float Price { get; set; }
    }

    public class ProductAddDto : ProductDto
    {

        //public int AddedBy { get; set; }
        //public DateTime AddedOn { get; set; }
    }
    public class ProductDetailsDto : ProductDto
    {
        public int Id { get; set; }

        //public bool IsAvailable { get; set; }
        //public List<AuditInfo> HistoyInfo { get; set; }

        //public List<Vendopr> Vendoprs{ get; set; }
        //public List<Review> Reviews{ get; set; }
        //public List<QnA> Reviews { get; set; }
        //public List<Options> Reviews { get; set; }
    }

    public class ProductUpdateDto : ProductDto
    {
        public int Id { get; set; }

        //public int UpdateBy { get; set; }
        //public DateTime UpdateOn { get; set; }
    }

    internal static class ProductExtensions
    {
        internal static ProductDetailsDto ToDto(this Product product)
        {
            return new ProductDetailsDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
            };
        }
    }
    internal static class ProductAddExtensions
    {
        internal static Product ToProduct(this ProductDto product)
        {
            return new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price

            };
        }
    }
}
