using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using UZeroConsole.Monitoring;

namespace UZeroConsole.WebConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //PerformanceCounter cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            //PerformanceCounter memory = new PerformanceCounter("Process", "Working Set - Private", "_Total");


            //var tracker = new PerformanceTracker();

            //while (true)
            //{
            //    Thread.Sleep(1000);
            //    var info = PerformanceModule.Current();
            //    //CPU
            //    string msg = string.Format("{0}:{1}%，{2}:{3}",
            //        "CPU", info.CPUUsagePercent,
            //        "Memory", info.RAMUsedPercent);
            //    Console.WriteLine(msg);

            //    var b = 1;
            //}

            Console.Write(System.IO.Directory.GetCurrentDirectory());
            Console.ReadLine();
        }



    }
}

//this.cinf = new ComputerInfo();
//        public double GetMemoryPercent()  //获取占用内存的百分比
//{
//    var usedMem = this.cinf.TotalPhysicalMemory - this.cinf.AvailablePhysicalMemory; //总内存减去可用的内存
//    return Math.Round((double)(usedMem / Convert.ToDecimal(this.cinf.TotalPhysicalMemory) * 100), 2, MidpointRounding.AwayFromZero);
//}
//public HardDiskInfo GetHardDiskInfoByName(string diskName)//根据盘符获取磁盘信息
//{
//    DriveInfo drive = new DriveInfo(diskName);
//    return new HardDiskInfo { FereeSpace = GetDriveData(drive.AvailableFreeSpace), TotalSpace = GetDrieData(drive.TotalSizw), Name = drive.Name };
//}
//public IEnumerable<HardDiskInfo> GetAllHardDiskInfo() //获取所有驱动信息
//{
//    List<HardDiskInfo> list = new List<HardDiskInfo>();
//    foreach (DriverInfo d in DriveInfo.GetDrives())
//    {
//        if (d.IsReady)
//        {
//            list.Add(new HardDiskInfo { Name = d.Name, FreeSpace = this.GetDriveData(d.AvailableFreeSpace), TotalSpace = this.GetDriveData(d.TotalSize) });
//        }
//    }
//    return list;
//}
//private string GetDriveData(long data)//将磁盘大小的单位由byte转化为G
//{
//    return (data / Convert.ToDouble(1024) / Convert.ToDouble(1024) / Convert.ToDouble(1024).ToString("0.00");
//}
//calss HardDiskInfo//自定义类
//{
//     public string Name
//{
//    get;
//    set;
//}
//public string FreeSpace
//{
//    get;
//    set;
//}
//public string TotalSpace
//{
//    get;
//    set;
//}
