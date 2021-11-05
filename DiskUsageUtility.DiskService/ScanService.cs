using System;
using System.Threading;
using System.Threading.Tasks;
using DiskUsageUtility.Interfaces;

namespace DiskUsageUtility.DiskService
{
    public class ScanService : IScanService
    {
        private readonly IDataTreeHandler _dataTreeHandler;
        private Task _scanningTask;
        private CancellationTokenSource _cancellationTokenSource;

        public ScanService(IDataTreeHandler dataTreeHandler)
        {
            _dataTreeHandler = dataTreeHandler;
        }
        
        ~ScanService()
        {
            if (IsScanningInProgress())
            {
                _cancellationTokenSource.Cancel();
            }
        }

        private bool IsScanningInProgress()
        {
            return _scanningTask.Status.Equals(TaskStatus.Running);
        }
        
        public void StartScanning(string driveLabel)
        {
            if (IsScanningInProgress())
            {
                throw new Exception("Scanning is already in progress");
            }

            _cancellationTokenSource = new CancellationTokenSource();
            _scanningTask = Task.Run(() =>
            {
                _dataTreeHandler.ResetDataTree();
                while (!_cancellationTokenSource.IsCancellationRequested)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(DateTime.Now.Second);
                }
            }, _cancellationTokenSource.Token);
        }

        public void StopScanning()
        {
            _cancellationTokenSource.Cancel();
        }

        public int GetScanProgress(string driveLabel)
        {
            throw new System.NotImplementedException();
        }
    }
}