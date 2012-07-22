using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TheNuggetList.Domain.Entities;

namespace TheNuggetList.WebUI.ViewModels
{
    public class NuggetViewModel
    {

        public NuggetViewModel()
        { }

        public NuggetViewModel(Nugget nugget)
        {
            Description = nugget.Description;
            Title = nugget.Title;
        }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public Nugget BuildNugget()
        {
            return new Nugget()
            {
                Title = Title,
                Description = Description               
            };
        }
    }
}