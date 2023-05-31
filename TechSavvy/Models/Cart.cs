using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TechSavvy.Models;

namespace TechSavvy.Models
{   
    public class Cart
    { }
    //{
    //    private List<CartLine> lineCollection = new List<CartLine>();
    //    public virtual void AddItem(Product iteam, int quantity)
    //    {
    //        CartLine line = lineCollection
    //                  .Where(p => p.product.ProductId == iteam.ProductId)
    //                     .FirstOrDefault();
    //        if (line == null)
    //        {
    //            lineCollection.Add(new CartLine
    //            {
    //                product = iteam,
                  
    //                category = iteam.category,
    //                Quantity = quantity,
                
    //            });
    //        }
    //        else
    //        {
    //            CartLine linee = lineCollection
    //          .Where(p => p.product.ProductId == iteam.ProductId)
    //             .FirstOrDefault();

    //            if (linee == null)
    //            {
    //                lineCollection.Add(new CartLine
    //                {
    //                    product = iteam,

    //                    category = iteam.category,
    //                    Quantity = quantity,

    //                });
    //            }
    //            else
    //            {
    //                linee.Quantity += quantity;
    //            }
    //        }
    //    }
    //    public virtual void UpadteItemAddItem(Product iteam, int quantity)
    //    {
    //        CartLine line = lineCollection
    //          .Where(p => p.ProductId == iteam.ProductId)
    //             .FirstOrDefault();
    //        if (line == null)
    //        {
    //            CartLine linee = lineCollection
    //           .Where(p => p.product.ProductId == iteam.ProductId)
    //              .FirstOrDefault();

    //            if (linee == null)
    //            {
    //                lineCollection.Add(new CartLine
    //                {
    //                    product = iteam,

    //                    category = iteam.category,
    //                    Quantity = quantity,
    //                });
    //            }
    //            else
    //            {
    //                line.Quantity += quantity;
    //            }
    //        }
    //        else
    //        {
    //            CartLine linee = lineCollection
    //          .Where(p => p.product.ProductId == iteam.ProductId)
    //             .FirstOrDefault();

    //            if (linee == null)
    //            {
    //                lineCollection.Add(new CartLine
    //                {
    //                    product = iteam,

    //                    category = iteam.category,
    //                    Quantity = quantity,

    //                });
    //            }
    //            else
    //            {
    //                line.Quantity += quantity;
    //            }
    //        }
    //    }
    //    public virtual void RemoveLine(Product product) =>
    //    lineCollection.RemoveAll(l => l.product.ProductId == product.ProductId);
    //    public virtual decimal ComputeTotalValue() =>
    //    lineCollection.Sum(e => e.product.price * e.Quantity);
    //    public virtual void Clear() => lineCollection.Clear();
    //    public virtual IEnumerable<CartLine> Lines => lineCollection;
    //}
    //public class CartLine
    //{
    //    public int ProductId { get; set; }

    //    [ForeignKey("CategoryId")]
    //    public virtual Category? category { get; set; }

    //    public Product product { get; set; }
    //    public int Quantity { get; set; }
    //}
}