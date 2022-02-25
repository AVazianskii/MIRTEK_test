namespace MIRTEK_test
{
    internal class Chain_of_responcibility
    {
        static Handler_template Head = new Head_title_handler();
        static Handler_template Number = new Number_of_elements_handler();
        static Handler_template Model_name = new Model_name_handler();
        static Handler_template Production_Year = new Production_year_handler();
        static Handler_template Engine_Volume = new Engine_volume_handler();
        static Handler_template Number_of_Doors = new Number_of_doors_handler();
        static Handler_template Tail = new Tail_handler();

        internal static void Setup_chain()
        {
            Head.SetNext(Number).SetNext(Model_name).SetNext(Production_Year).SetNext(Engine_Volume).SetNext(Number_of_Doors);
        }
        internal static void Run_chain_from_head(byte[] cmd_byte_array, List<Car_template> auto_park, Car_template Car, List<byte> byte_array)
        {
            Head.Handle(cmd_byte_array, auto_park, Car, byte_array);
        }
        internal static void Run_chain_from_main_body(byte[] cmd_byte_array, List<Car_template> auto_park, Car_template Car, List<byte> byte_array)
        {
            Model_name.Handle(cmd_byte_array, auto_park, Car, byte_array);
        }
        internal static void Run_chain_from_tail(byte[] cmd_byte_array, List<Car_template> auto_park, Car_template Car, List<byte> byte_array)
        {
            Tail.Handle(cmd_byte_array, auto_park, Car, byte_array);
        }
    }
}
