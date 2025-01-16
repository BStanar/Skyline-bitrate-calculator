using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Skyline_bitrate_calculator
{
    internal class NetworkDevice
    {
        public string Device { get; set; }
        public string Model { get; set; }
        public NetworkInterfaceCard [] NIC { get; set; }
        

        public string NetworkDeviceToString(long RxBitRate, long TxBitRate)
        {
            return  $"Device: {Device}\n" +
                    $"Model: {Model}\n" +
                    $"Description: {NIC[0].Description}\n" +
                    $"MAC address: {NIC[0].MAC}\n" +
                    $"Timestamp: {NIC[0].Timestamp}\n" +
                    $"Rx: {NIC[0].Rx}\n" +
                    $"Tx: {NIC[0].Tx}\n\n" +
                    $"Rx bit rate: {RxBitRate} bit/s = {RxBitRate/1000000} Mbit/s\n" +
                    $"Tx bit rate: {TxBitRate} bit/s = {TxBitRate / 1000000} Mbit/s";
        }
    }
}
