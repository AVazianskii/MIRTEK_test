﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIRTEK_test
{
    internal class Ford : Car_template
    {
        internal Ford(string? model_name, int? number_of_doors, int? production_year, double? engine_volume)
                : base(model_name, number_of_doors, production_year, engine_volume)
        {

        }
    }
}
