using eTickets.Data;
using eTickets.Data.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Data.Models
{
    public class NewMovieVM
    {
        public int Id { get; set; } 

        [Display(Name ="Movie name")]
        [Required(ErrorMessage ="Name is required")]
        public string name {  get; set; }
     
         [Display(Name = "Movie description")]
        [Required(ErrorMessage = "Description is required")]
        public string description { get; set; }
       
        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double price {  get; set; }
       
        [Display(Name = " Movie poster URL")]
        [Required(ErrorMessage = "Movie poster URL is required")]
        public string ImageUrl { get; set; }
       
        [Display(Name = " Start Date")]
        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }
       
        [Display(Name = " End Date")]
        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }
       
        [Display(Name = " Select a category ")]
        [Required(ErrorMessage = " Movie category is required ")]
        public MovieCategory MovieCategory {  get; set; }
        //Relationships
        [Display(Name = " Select actor(s) ")]
        [Required(ErrorMessage = " Movie actor(s) is required ")]
        public List<int> ActorIds { get; set; }
       
        [Display(Name = " Select a Cinema ")]
        [Required(ErrorMessage = " Movie Cinema is required ")]
        public int CinemaId {  get; set; }
       
        [Display(Name = " Select a Producer ")]
        [Required(ErrorMessage = " Movie Producer is required ")]
        public int ProducerId {  get; set; }
   

    }
}
