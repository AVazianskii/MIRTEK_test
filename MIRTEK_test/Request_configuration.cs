namespace MIRTEK_test
{
    internal class Request_configuration
    {
        internal static void Setup_answer(ref byte[] received_data, List<Car_template> Requested_auto_park, List<Car_template> Auto_park)
        {
            if (received_data[0] == 1)
            {
                foreach(Car_template Car in Auto_park)
                {
                    Requested_auto_park.Add(Car);
                }
            }
            else if((received_data[0] == 2) | (received_data[0] == 3))
            {
                Requested_auto_park.Add(Auto_park[received_data[1] - 1]);
            }
        }
    }
}
