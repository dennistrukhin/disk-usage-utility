using System.Threading.Tasks;
using DiskUsageUtility.Interfaces;
using DiskUsageUtility.Web.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DiskUsageUtility.Web.Controllers
{
    public class DrivesController : BaseController
    {
        private readonly IScanService _scanService;

        public DrivesController(IScanService scanService)
        {
            _scanService = scanService;
        }
        
        [HttpGet]
        public async Task<ResponseDto<bool>> GetDrivesList()
        {
            var drives = System.IO.DriveInfo.GetDrives();

            return ResponseDto<bool>.FromDto(true);
        }

        [HttpPost("scan/start")]
        public async Task<ResponseDto<bool>> ScanStart()
        {
            _scanService.StartScanning("/");
            
            return ResponseDto<bool>.FromDto(true);
        }

        [HttpPost("scan/stop")]
        public async Task<ResponseDto<bool>> ScanStop()
        {
            _scanService.StopScanning();
            
            return ResponseDto<bool>.FromDto(true);
        }
    }
}