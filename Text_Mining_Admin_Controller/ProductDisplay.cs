using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Mining_Admin_Controller
{
public class ProductDisplay
{
    public int ProductId { get; set; }
    public string ImageUrl { get; set; }
    public Image ProductImage { get; set; } // Thuộc tính lưu ảnh
    public string Name { get; set; }
    public decimal? Price { get; set; }
    public string CategoryName { get; set; }
    public int? StockQuantity { get; set; }
    public string Description { get; set; }
}

}
