using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIRTEK_test
{
    internal interface IHandler
    {
        // объявляем метод для построения цепочки обработчиков
        IHandler SetNext(IHandler handler);
        // объявляем метод для обработки операции
        object Handle(byte[] cmd_byte_array, List<Car_template> auto_park, Car_template Car, List<byte> byte_array);
    }
}
