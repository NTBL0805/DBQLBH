using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class CartItem
    {
        public Products _products { get; set; }
        public int _quantity { get; set; }
    }
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem>Items
        {
            get { return items; }
        }
        public void Add_Product_Cart(Products _pro, int _quan = 1)
        {
            var item = Items.FirstOrDefault(s => s._products.ProductID == _pro.ProductID);
            if (item == null)
                items.Add(new CartItem
                {
                    _products = _pro,
                    _quantity = _quan
                });
            else
                item._quantity += _quan;
        }
        public int Total_quantity()
        {
            return items.Sum(s => s._quantity);
        }
        public decimal Total_money()
        {
            var total = items.Sum(s => s._quantity * s._products.Price);
            return (decimal)total;
        }
        public void Update_quantity(int id, int _new_quan)
        {
            var item = items.Find(s => s._products.ProductID == id);
            if (item != null)
                item._quantity = _new_quan;
        }
        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s._products.ProductID == id);
        }
        public void ClearCart()
        {
            items.Clear();
        }
    } 
}