using eTickets.Data.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.Models
{
    public class Cinema :IEntityBase
    {
        [Key]
        public int id { get; set; }
       
        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Cinema Logo is Required")]
       
        public string Logo {  get; set; }
       
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Cinema Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name Must be between 3 and 50 Chars")]

        public string Name { get; set; }
       
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Cinema Description is Required")]
        
        public string Description { get; set; }
        //RelationShips
        public List<Movie> Movies { get; set; }
    }
}
