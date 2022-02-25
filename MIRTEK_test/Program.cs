using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace MIRTEK_test
{
    internal class Program
    {
        static int port = 8005;
        static void Main(string[] args)
        {
            bool first_start = true;

            // Создаем записи с машиной
            Car_template Nissan = new Nissan("Nissan", null, 2008, 1.6);
            Car_template Ford = new Ford("Ford", 5, 2020, 2.0);
            Car_template Opel = new Opel("Opel", 3, 2014, null);
            List<Car_template> Auto_park = new List<Car_template>();            // имеющийся автопарк у дилера
            List<Car_template> Requested_auto_park = new List<Car_template>();  // запрошенное количество машин
            Auto_park.Add(Nissan);
            Auto_park.Add(Ford);
            Auto_park.Add(Opel);

            List <byte> Result_byte_answer = new List<byte>(); // сюда будет складываться байтовая последовательность 

            Chain_of_responcibility.Setup_chain();

            // устанавливаем порт и адрес, через которое осуществляется подключение
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            // создаем сокет
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // связываем сокет с локальной точкой, по которой будем принимать данные
            listenSocket.Bind(ipPoint);

            // начинаем прослушивание
            listenSocket.Listen(10);

            Console.WriteLine("Сервер запущен");

            while (true)
            {
                Socket handler = listenSocket.Accept();
                int bytes = 0; // количество полученных байтов
                byte[] received_data = new byte[3]; // буфер для получаемых данных
                
                do
                {
                    bytes = handler.Receive(received_data);
                }
                while (handler.Available > 0);
                Console.WriteLine("запрос клиента: ");
                Console.WriteLine("Тип команды: " + received_data[0].ToString());
                if (received_data[0] > 1)
                {
                    Console.WriteLine("Номер машины: " + received_data[1].ToString());
                    if (received_data[0] > 2)
                    {
                        Console.WriteLine("Вызываемый параметр: " + received_data[2].ToString());
                    }
                }

                Request_configuration.Setup_answer(ref received_data, Requested_auto_park, Auto_park);

                //
                // - здесь запуск цепочки обработчиков с выводом окончательного результата в Result_byte_answer
                // - который затем превращается в data_to_send через Result_byte_answer.ToArray()

                foreach (Car_template Car in Requested_auto_park)
                {
                    if (first_start)
                    {
                        Chain_of_responcibility.Run_chain_from_head(received_data, Requested_auto_park, Car, Result_byte_answer);
                        first_start = false;
                    }
                    else 
                    {
                        Chain_of_responcibility.Run_chain_from_main_body(received_data, Requested_auto_park, Car, Result_byte_answer);
                    }
                    if (Requested_auto_park.IndexOf(Car) == (Requested_auto_park.Capacity - 2))
                    {
                        Chain_of_responcibility.Run_chain_from_tail(received_data, Requested_auto_park, Car, Result_byte_answer);
                    }
                }
                
                // отправляем ответ
                byte[] data_to_send = Result_byte_answer.ToArray();
                handler.Send(data_to_send);
                Requested_auto_park.Clear();
                Result_byte_answer.Clear();                     // Очищаем ответ на запрос
                data_to_send = Result_byte_answer.ToArray();    // очищаем массив байтов, отправляемый клиенту
                // закрываем сокет
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
        }
    }
}
