﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Cards
{
    public class CardDeleteModel
    {
        public string Name { get; set; }

        public int DaysActive { get; set; }

        public decimal Price { get; set; }
    }
}