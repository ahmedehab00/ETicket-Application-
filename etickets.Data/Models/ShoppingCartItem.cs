using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Movie Movie { get; set; }

        public int Amount {  get; set; }

        public string ShoppingCartId {  get; set; } 
    }
}
