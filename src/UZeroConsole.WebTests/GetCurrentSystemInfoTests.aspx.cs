using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using System.Management;
using System.Text;
using System.Runtime.InteropServices;

namespace UZeroConsole.WebTests
{
    public partial class GetCurrentSystemInfoTests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SystemInfo systemInfo = new SystemInfo();
                Response.Write("操作系统：" + systemInfo.GetOperationSystemInName() + "<br>");
                Response.Write("CPU编号：" + systemInfo.GetCpuId() + "<br>");
                Response.Write("硬盘编号：" + systemInfo.GetMainHardDiskId() + "<br>");
                Response.Write("Windows目录所在位置：" + systemInfo.GetSysDirectory() + "<br>");
                Response.Write("系统目录所在位置：" + systemInfo.GetWinDirectory() + "<br>");
                MemoryInfo memoryInfo = systemInfo.GetMemoryInfo();
                CpuInfo cpuInfo = systemInfo.GetCpuInfo();
                Response.Write("dwActiveProcessorMask" + cpuInfo.dwActiveProcessorMask + "<br>");
                Response.Write("dwAllocationGranularity" + cpuInfo.dwAllocationGranularity + "<br>");
                Response.Write("CPU个数：" + cpuInfo.dwNumberOfProcessors + "<br>");
                Response.Write("OEM ID：" + cpuInfo.dwOemId + "<br>");
                Response.Write("页面大小" + cpuInfo.dwPageSize + "<br>");
                Response.Write("CPU等级" + cpuInfo.dwProcessorLevel + "<br>");
                Response.Write("dwProcessorRevision" + cpuInfo.dwProcessorRevision + "<br>");
                Response.Write("CPU类型" + cpuInfo.dwProcessorType + "<br>");
                Response.Write("lpMaximumApplicationAddress" + cpuInfo.lpMaximumApplicationAddress + "<br>");
                Response.Write("lpMinimumApplicationAddress" + cpuInfo.lpMinimumApplicationAddress + "<br>");
                Response.Write("CPU类型：" + cpuInfo.dwProcessorType + "<br>");
                Response.Write("可用交换文件大小：" + memoryInfo.dwAvailPageFile + "<br>");
                Response.Write("可用物理内存大小：" + memoryInfo.dwAvailPhys + "<br>");
                Response.Write("可用虚拟内存大小" + memoryInfo.dwAvailVirtual + "<br>");
                Response.Write("操作系统位数：" + memoryInfo.dwLength + "<br>");
                Response.Write("已经使用内存大小：" + memoryInfo.dwMemoryLoad + "<br>");
                Response.Write("交换文件总大小：" + memoryInfo.dwTotalPageFile + "<br>");
                Response.Write("总物理内存大小：" + memoryInfo.dwTotalPhys + "<br>");
                Response.Write("总虚拟内存大小：" + memoryInfo.dwTotalVirtual + "<br>");
            }
        }
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct CpuInfo
    {
        /// <summary>
        /// OEM ID
        /// </summary>
        public uint dwOemId;
        /// <summary>
        /// 页面大小
        /// </summary>
        public uint dwPageSize;
        public uint lpMinimumApplicationAddress;
        public uint lpMaximumApplicationAddress;
        public uint dwActiveProcessorMask;
        /// <summary>
        /// CPU个数
        /// </summary>
        public uint dwNumberOfProcessors;
        /// <summary>
        /// CPU类型
        /// </summary>
        public uint dwProcessorType;
        public uint dwAllocationGranularity;
        /// <summary>
        /// CPU等级
        /// </summary>
        public uint dwProcessorLevel;
        public uint dwProcessorRevision;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MemoryInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public uint dwLength;
        /// <summary>
        /// 已经使用的内存
        /// </summary>
        public uint dwMemoryLoad;
        /// <summary>
        /// 总物理内存大小
        /// </summary>
        public uint dwTotalPhys;
        /// <summary>
        /// 可用物理内存大小
        /// </summary>
        public uint dwAvailPhys;
        /// <summary>
        /// 交换文件总大小
        /// </summary>
        public uint dwTotalPageFile;
        /// <summary>
        /// 可用交换文件大小
        /// </summary>
        public uint dwAvailPageFile;
        /// <summary>
        /// 总虚拟内存大小
        /// </summary>
        public uint dwTotalVirtual;
        /// <summary>
        /// 可用虚拟内存大小
        /// </summary>
        public uint dwAvailVirtual;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SystemTimeInfo
    {
        /// <summary>
        /// 年
        /// </summary>
        public ushort wYear;
        /// <summary>
        /// 月
        /// </summary>
        public ushort wMonth;
        /// <summary>
        /// 星期
        /// </summary>
        public ushort wDayOfWeek;
        /// <summary>
        /// 天
        /// </summary>
        public ushort wDay;
        /// <summary>
        /// 小时
        /// </summary>
        public ushort wHour;
        /// <summary>
        /// 分钟
        /// </summary>
        public ushort wMinute;
        /// <summary>
        /// 秒
        /// </summary>
        public ushort wSecond;
        /// <summary>
        /// 毫秒
        /// </summary>
        public ushort wMilliseconds;
    }

    public class SystemInfo
    {
        private const int CHAR_COUNT = 128;
        public SystemInfo()
        {

        }
        [DllImport("kernel32")]
        private static extern void GetWindowsDirectory(StringBuilder WinDir, int count);

        [DllImport("kernel32")]
        private static extern void GetSystemDirectory(StringBuilder SysDir, int count);

        [DllImport("kernel32")]
        private static extern void GetSystemInfo(ref CpuInfo cpuInfo);

        [DllImport("kernel32")]
        private static extern void GlobalMemoryStatus(ref MemoryInfo memInfo);

        [DllImport("kernel32")]
        private static extern void GetSystemTime(ref SystemTimeInfo sysInfo);

        /// <summary>
        /// 查询CPU编号
        /// </summary>
        /// <returns></returns>
        public string GetCpuId()
        {
            ManagementClass mClass = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mClass.GetInstances();
            string cpuId = null;
            foreach (ManagementObject mo in moc)
            {
                cpuId = mo.Properties["ProcessorId"].Value.ToString();
                break;
            }
            return cpuId;
        }

        /// <summary>
        /// 查询硬盘编号
        /// </summary>
        /// <returns></returns>
        public string GetMainHardDiskId()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            String hardDiskID = null;
            foreach (ManagementObject mo in searcher.Get())
            {
                hardDiskID = mo["SerialNumber"].ToString().Trim();
                break;
            }
            return hardDiskID;
        }

        /// <summary>
        /// 获取Windows目录
        /// </summary>
        /// <returns></returns>
        public string GetWinDirectory()
        {
            StringBuilder sBuilder = new StringBuilder(CHAR_COUNT);
            GetWindowsDirectory(sBuilder, CHAR_COUNT);
            return sBuilder.ToString();
        }

        /// <summary>
        /// 获取系统目录
        /// </summary>
        /// <returns></returns>
        public string GetSysDirectory()
        {
            StringBuilder sBuilder = new StringBuilder(CHAR_COUNT);
            GetSystemDirectory(sBuilder, CHAR_COUNT);
            return sBuilder.ToString();
        }

        /// <summary>
        /// 获取CPU信息
        /// </summary>
        /// <returns></returns>
        public CpuInfo GetCpuInfo()
        {
            CpuInfo cpuInfo = new CpuInfo();
            GetSystemInfo(ref cpuInfo);
            return cpuInfo;
        }

        /// <summary>
        /// 获取系统内存信息
        /// </summary>
        /// <returns></returns>
        public MemoryInfo GetMemoryInfo()
        {
            MemoryInfo memoryInfo = new MemoryInfo();
            GlobalMemoryStatus(ref memoryInfo);
            return memoryInfo;
        }

        /// <summary>
        /// 获取系统时间信息
        /// </summary>
        /// <returns></returns>
        public SystemTimeInfo GetSystemTimeInfo()
        {
            SystemTimeInfo systemTimeInfo = new SystemTimeInfo();
            GetSystemTime(ref systemTimeInfo);
            return systemTimeInfo;
        }

        /// <summary>
        /// 获取系统名称
        /// </summary>
        /// <returns></returns>
        public string GetOperationSystemInName()
        {
            OperatingSystem os = System.Environment.OSVersion;
            string osName = "UNKNOWN";
            switch (os.Platform)
            {
                case PlatformID.Win32Windows:
                    switch (os.Version.Minor)
                    {
                        case 0: osName = "Windows 95"; break;
                        case 10: osName = "Windows 98"; break;
                        case 90: osName = "Windows ME"; break;
                    }
                    break;
                case PlatformID.Win32NT:
                    switch (os.Version.Major)
                    {
                        case 3: osName = "Windws NT 3.51"; break;
                        case 4: osName = "Windows NT 4"; break;
                        case 5:
                            if (os.Version.Minor == 0)
                            {
                                osName = "Windows 2000";
                            }
                            else if (os.Version.Minor == 1)
                            {
                                osName = "Windows XP";
                            }
                            else if (os.Version.Minor == 2)
                            {
                                osName = "Windows Server 2003";
                            }
                            break;
                        case 6: osName = "Longhorn"; break;
                    }
                    break;
            }
            return String.Format("{0},{1}", osName, os.Version.ToString());
        }
    }
}