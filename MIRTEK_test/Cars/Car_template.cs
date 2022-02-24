using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIRTEK_test
{
    internal class Car_template
    {
        internal Car_template (string? model_name, int? number_of_doors, int? production_year, double? engine_volume)
        {
            Set_Model_name(model_name);
            Set_Number_of_doors(number_of_doors);
            Set_Production_year(production_year);
            Set_Engine_volume(engine_volume);
        }
        private string? Model_name;
        private int? Number_of_doors;
        private int? Production_year;
        private double? Engine_volume;

        public void Set_Model_name(string? input_string) => Model_name = input_string;
        public string? Get_Model_name() 
        {
            return Model_name; 
        }
        public void Set_Number_of_doors(int? input_int) => Number_of_doors = input_int;
        public int? Get_Number_of_doors()
        {
            return Number_of_doors;
        }
        public void Set_Production_year(int? input_int) => Production_year = input_int;
        public int? Get_Production_year()
        {
            return Production_year;
        }
        public void Set_Engine_volume(double? input_double) => Engine_volume = input_double;
        public double? Get_Engine_volume()
        {
            return Engine_volume;
        }
    }
}
