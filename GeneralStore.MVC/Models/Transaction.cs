using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneralStore.MVC.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Required]
        [ForeignKey(nameof(Product))]
        [Display(Name = "Product Name")]
        public int ProductId { get; set; }
        [Required]
        [ForeignKey(nameof(Customer))]
        [Display(Name = "Customer Name")]
        public int CustomerId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfTransaction { get; set; }
        public int Quantity { get; set; }

        private ApplicationDbContext _db = new ApplicationDbContext();

        public string CustomerName { get { return _db.Customers.Find(CustomerId).FullName; } }
        public string ProductName { get { return _db.Products.Find(ProductId).Name; }}

        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }

    }
}