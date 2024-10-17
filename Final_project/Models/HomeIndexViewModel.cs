using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_project.Models
{
    public class HomeIndexViewModel
    {
        public List<Product> Top6Products { get; set; } // 6 sản phẩm đầu
        public List<Product> Bottom3Products { get; set; } // 3 sản phẩm cuối
        public List<Product> Bottom3nextProducts { get; set; } // 3 sản bên cạnh
    }
}