using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Skyline_bitrate_calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"measurement.json";
            int poolingRate = 2;

            try
            {
                ReadJsonFile(filePath, poolingRate);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}\n\n");
            }
        }

        static void ReadJsonFile(string filePath , int poolingRate)
        {
            string json = File.ReadAllText(filePath);
            NetworkDevice device = JsonSerializer.Deserialize<NetworkDevice>(json);
            
            long RxBitRate = CalculateBitrate(poolingRate, device.NIC[0].Rx);
            long TxBitRate = CalculateBitrate(poolingRate, device.NIC[0].Tx);
            
            Console.WriteLine( device.NetworkDeviceToString(RxBitRate, TxBitRate) );
            
            Console.ReadKey();
        }
        static long CalculateBitrate(int pooling_rate, string TransferedBitsString)
        {
            return Int64.Parse(TransferedBitsString) * pooling_rate * 8;
        }
    }
}