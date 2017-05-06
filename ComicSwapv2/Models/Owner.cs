using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ComicSwapv2.Models
{
    public class Owner
    {
        [Key]
        [Display(Name = "Owner ID")]
        public int OwnerID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        [Required]
        [Display(Name = "Street Address")]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Comic> Comics;
    }
}