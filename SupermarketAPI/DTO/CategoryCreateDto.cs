﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.DTO
{
    public class CategoryCreateDto
    {

        [Required]
        public string Name { get; set; }
    }
}
