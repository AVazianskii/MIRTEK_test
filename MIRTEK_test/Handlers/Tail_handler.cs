using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIRTEK_test
{
    internal class Tail_handler : Handler_template
    {
        public override object Handle(byte[] cmd_byte_array, List<Car_template> auto_park, Car_template Car, List<byte> byte_array)
        {
            byte_array.Add(0x02); // Добавляем признак начала стурктуры данных
            return base.Handle(cmd_byte_array, auto_park, Car, byte_array);
        }
    }
}
