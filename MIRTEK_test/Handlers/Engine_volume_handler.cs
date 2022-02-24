using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIRTEK_test
{
    internal class Engine_volume_handler : Handler_template
    {
        public override object Handle(byte[] cmd_byte_array, List<Car_template> auto_park, Car_template Car, List<byte> byte_array)
        {
            if ((cmd_byte_array[0] == 1) | (cmd_byte_array[0] == 2) | ((cmd_byte_array[0] == 3) & (cmd_byte_array[2] == 3)))
            {
                    byte_array.Add(0x13);
                    if (Car.Get_Engine_volume() != null)
                    {
                        foreach (byte element in BitConverter.GetBytes((double)Car.Get_Engine_volume()))
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
