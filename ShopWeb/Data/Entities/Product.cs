﻿namespace ShopWeb.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DisplayFormat(DataFormatString ="{0:C2}", ApplyFormatInEditMode = false)]
        public Decimal Price { get; set; }

        [Display(Name="Image")]
        public string imageUrl { get; set; }

        [Display(Name = "last Purchase")]
        public DateTime LastPurchase { get; set; }

        [Display(Name = "Last Sale")]
        public DateTime LastSale { get; set; }

        [Display(Name = "Is Available?")]
        public bool IsAvailable { get; set; }

        [DisplayFormat(DataFormatString ="{0:N2}", ApplyFormatInEditMode =false)]
        public double Stock { get; set; }
    }
}
