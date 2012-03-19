using System;
using System.ComponentModel.DataAnnotations;

namespace Yame.Models.Domain
{
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the Product class.
        /// </summary>
        public Product()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        public bool Discontinued { get; set; }

        public override string ToString()
        {
            return String.Format("ID:{0} Name:{1} Category:{2} Discontinued:{3}",
                Id, Name, Category, Discontinued);
        }
    }
}
