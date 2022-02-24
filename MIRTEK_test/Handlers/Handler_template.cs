using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIRTEK_test
{
    // Опредделяем базовый класс обработчика. Каждый объект обработчика будет формировать байтовую последовательность
    // через метод Handle из полей объектов базового класса Car_template.
    internal class Handler_template : IHandler
    {
        private IHandler _nextHandler;
        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }
        public virtual object Handle(byte[] cmd_byte_array, List<Car_template> auto_park, Car_template Car, List<byte> byte_array)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(cmd_byte_array, auto_park, Car, byte_array);
            }
            else
            {
                return null;
            }
        }
    }
}
