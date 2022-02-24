using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIRTEK_test
{
    internal class Number_of_doors_handler : Handler_template
    {
        public override object Handle(byte[] cmd_byte_array, List<Car_template> auto_park, Car_template Car, List<byte> byte_array)
        {
            if ((cmd_byte_array[0] == 1) | (cmd_byte_array[0] == 2) | ((cmd_byte_array[0] == 3) & (cmd_byte_array[2] == 4)))
            {
                    byte_array.Add(0x12);
                    if (Car.Get_Number_of_doors() != null)
                    {
                        foreach (byte element in BitConverter.GetBytes((int)Car.Get_Number_of_doors()))
                        {
                            byte_array.Add(element);
                        }
                    }
                    else
                    {
                        byte_array.Add(0x15); // при null добавляем признак null. На этом признаке у клиента выведется сообщение "Нет данных"
                    }
            }
            return base.Handle(cmd_byte_array, auto_park, Car, byte_array);
            
        }
    }
}
