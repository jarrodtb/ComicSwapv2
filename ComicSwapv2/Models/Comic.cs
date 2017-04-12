using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ComicSwapv2.Models
{
    public enum Condition
    {
        NearMint, VeryFine, Fine, VeryGood, Good, Fair, Poor
    }

    public class Comic
    {
        [Key]
        public int ComicID { get; set; }

        public int OwnerID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Issue { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        [Required]
        public Condition Condition { get; set; }
    }
}