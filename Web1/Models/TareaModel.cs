using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Web1.Models
{
    public class TareaModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public string Status { get; set; }
        [Required]
        [Display(Name = "Prioridad")]
        public string Priority { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string? UserId { get; set; }
        public IdentityUser? User {  get; set; }



        public TareaModel()
        {

        }
    }
}
