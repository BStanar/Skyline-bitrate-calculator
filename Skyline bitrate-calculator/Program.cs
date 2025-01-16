using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Skyline_bitrate_calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // This file will be in Skyline bitrate-calculator\Skyline bitrate-calculator\bin\Debug\net8.0
            string filePath = @"measurement.json";
            // Set pooling rate, value is in Hz
            int poolingRate = 2;

            try
            {
                ProcessJsonFile(filePath, poolingRate);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}\n\n");
            }


            Console.ReadKey();
        }

        static void ProcessJsonFile(string filePath , int poolingRate)
        {
            // Read all of the text from the file, this function will open the file copy the contents and close the file
            string json = File.ReadAllText(filePath);

            // Json data will deserialize into Data properties
            NetworkDevice device = JsonSerializer.Deserialize<NetworkDevice>(json);
            
            long RxBitRate = CalculateBitrate(poolingRate, device.NIC[0].Rx);
            long TxBitRate = CalculateBitrate(poolingRate, device.NIC[0].Tx);
            
            Console.WriteLine( device.NetworkDeviceToString(RxBitRate, TxBitRate) );
            
        }

        // Calculation of the bitrate
        static long CalculateBitrate(int pooling_rate, string TransferedBitsString)
        {
            // Parsig the string value to long int, the value of Rx is to big for int
            return Int64.Parse(TransferedBitsString) * pooling_rate * 8;
        }
    }
}