using eTickets.Data.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.Models
{
    public class Producer:IEntityBase
    {
        [Key]
       
        public int id { get; set; }
        
        [Display(Name = "Profile Picture Url")]
        [Required(ErrorMessage = "Profile Picture Url is Required")]
        
        public string ProfilePictureUrl { get; set; }
       
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name Must be between 3 and 50 Chars")]
       
        public string FullName { get; set; }
        
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is Required")]

        public string Bio { get; set; }
        //RelationShips
        public List<Movie> Movies { get; set; }
    }
}
