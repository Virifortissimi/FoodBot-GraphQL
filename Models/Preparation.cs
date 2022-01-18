using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace FoodBotGqlApi.Models
{
    /// <summary>
    /// Represents all preparations attached to a food.
    /// </summary>
    public class Preparation
    {
        /// <summary>
        /// Represents the unique ID for the preparations.
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Represents the how-to for the food.
        /// </summary>
        [Required]
        public string Steps { get; set; }

        //Navigation Properties
        /// <summary>
        /// Represents the unique ID of the food which the preparation belongs.
        /// </summary>
        [Required]
        public int FoodId { get; set; }
        /// <summary>
        /// This is the food to which the preparation belongs.
        /// </summary>
        public Food Food { get; set; }
    }
}