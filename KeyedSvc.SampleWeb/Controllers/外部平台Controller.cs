using KeyedSvc.Lib.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KeyedSvc.SampleWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class �~�����xController : ControllerBase
    {
        private readonly ILogger<�~�����xController> _logger;
        private readonly I���i���x reportSvc;

        // �ܽd .NET 8 �}�l�~���� FromKeyedServices �S��
        public �~�����xController(ILogger<�~�����xController> logger, [FromKeyedServices("public")] I���i���x reportSvc)
        {
            _logger = logger;
            this.reportSvc = reportSvc;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            await this.reportSvc.���ͦ~�׳���();

            return "�~�����x Controller �ܽd�A�Ь� Console �e���A�T�{�O�_�����T�a�I�s�`�J���A�ȹ�@�C";
        }
    }
}
