using SupermarketAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.DTO
{
    public class ProductUpdateDTO
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public int QuantityInPackage { get; set; }
        [Required]
        public int UnitOfMeasurement { get; set; }
        
        [Required]
        public int CategoryId { get; set; }

    }
}
