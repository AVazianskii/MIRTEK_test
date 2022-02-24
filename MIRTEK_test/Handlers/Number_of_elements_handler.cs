using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIRTEK_test
{
    internal class Number_of_elements_handler : Handler_template
    {
        public override object Handle(byte[] cmd_byte_array, List<Car_template> auto_park, Car_template Car, List<byte> byte_array)
        {
            
            int total_number = 0;
            byte[] temp;
            if (cmd_byte_array[0] == 1) // Если команда вычитать все записи всех машин, то суммируем по 4 записи за каждую машину в коллекции
            {
                foreach(Car_template _Car in auto_park)
                {
                    total_number = total_number + 4;
                }
            }          
            else if (cmd_byte_array[0] == 2)
            {
                total_number = 4; // Если команда вычитать все записи одной машины, то суммируем 4 записи за эту машину в коллекции
            }
            else if (cmd_byte_array[0] == 3)
            {
                total_number = 1; // Если команда вычитать одну запись одной машины, то суммируем 1 записи за эту машину в коллекции
            }
            
            temp = BitConverter.GetBytes(total_number);
            foreach(byte element in temp)
            {
                byte_array.Add(element); // Добавляем количество элементов 
            }
            
            return base.Handle(cmd_byte_array, auto_park, Car, byte_array);
        }
    }
}
