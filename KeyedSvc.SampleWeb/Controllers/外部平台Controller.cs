using KeyedSvc.Lib.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KeyedSvc.SampleWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class 外部平台Controller : ControllerBase
    {
        private readonly ILogger<外部平台Controller> _logger;
        private readonly I報告平台 reportSvc;

        // 示範 .NET 8 開始才有的 FromKeyedServices 特性
        public 外部平台Controller(ILogger<外部平台Controller> logger, [FromKeyedServices("public")] I報告平台 reportSvc)
        {
            _logger = logger;
            this.reportSvc = reportSvc;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            await this.reportSvc.產生年度報表();

            return "外部平台 Controller 示範，請看 Console 畫面，確認是否有正確地呼叫注入的服務實作。";
        }
    }
}
