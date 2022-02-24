namespace MIRTEK_test
{
    internal class Model_name_handler : Handler_template
    {
        public override object Handle(byte[] cmd_byte_array, List<Car_template> auto_park, Car_template Car, List<byte> byte_array)
        {
            if ((cmd_byte_array[0] == 1) | (cmd_byte_array[0] == 2) | ((cmd_byte_array[0] == 3) & (cmd_byte_array[2] == 1)))
            {

                    byte_array.Add(0x09);                                               // добавляем признак строки
                    if (Car.Get_Model_name() != null)
                    {
                        int Name_length = Car.Get_Model_name().Length;                  // определяем длину слова
                        foreach (byte element in BitConverter.GetBytes(Name_length))    // конвертируем длину слова в массив байтов
                        {
                            if (element != 0x00)
                            {
                                byte_array.Add(element);                                // складываем каждый байт в общий массив  
                            }
                        }
                        foreach (char letter in Car.Get_Model_name())                   // раскладываем слово на буквы
                        {
                            foreach(byte element in BitConverter.GetBytes(letter))      // конвертируем каждую бувкву в массив байтов
                            {
                                if (element != 0x00)
                                {
                                    byte_array.Add(element);                            // складываем каждый байт в общий массив 
                                }
                            }
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
