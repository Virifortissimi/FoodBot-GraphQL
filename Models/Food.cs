using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace FoodBotGqlApi.Models
{
    /// <summary>
    /// Represents any food or dish that can be prepared .
    /// </summary>
    public class Food
    {
        /// <summary>
        /// Represents the unique ID for the food.
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Represents the name for the food.
        /// </summary>
        [Required]
        public string NameOfFood { get; set; }
        /// <summary>
        /// Represents the name for the ingredients needed for this food.
        /// </summary>
        [Required]
        public string Ingredients { get; set; }
        /// <summary>
        /// Represents the name for the person who suggested or upload the food.
        /// </summary>
        public string OwnerName { get; set; }   

        //Navigation Properties       
        /// <summary>
        /// This is the list of available preparations for this food.
        /// </summary> 
        public ICollection<Preparation> Preparations { get; set; } = new List<Preparation>();
    }
}