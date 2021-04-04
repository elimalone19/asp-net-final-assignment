using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_fifth_assignment.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Bowlers book, int quantity)
        {
            CartLine Line = Lines.Where(b => b.Book.BowlerID == book.BowlerID)
                .FirstOrDefault();

            if (Line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = quantity
                });
            }
            else
            {
                Line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Bowlers book) =>
            Lines.RemoveAll(x => x.Book.BowlerID == book.BowlerID);

        public virtual void Clear() => Lines.Clear();
        

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Bowlers Book { get; set; }
            public int Quantity { get; set; }
        }

    }
}
