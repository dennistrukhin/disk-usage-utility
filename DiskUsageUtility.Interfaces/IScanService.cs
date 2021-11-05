using System.Threading.Tasks;

namespace DiskUsageUtility.Interfaces
{
    public interface IScanService
    {
        void StartScanning(string driveLabel);
        void StopScanning();
        int GetScanProgress(string driveLabel);
    }
}