using eTickets.Data.Data.Base;
using eTickets.Data.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Data.Models
{
    public class Movie:IEntityBase
    {
        [Key]
        public int id { get; set; }
        public string name {  get; set; }   
        public string description { get; set; }
        public double price {  get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory {  get; set; }
        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }
        //Cinema
        public int CinemaId {  get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }
        //Producer
        public int ProducerId {  get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }

    }
}
