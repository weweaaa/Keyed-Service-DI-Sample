using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyedSvc.Lib.Core.Services
{
    public interface I核心商業邏輯服務
    {
        public Task 執行核心功能Func(string input);
    }

    public class 核心商業邏輯服務 : I核心商業邏輯服務
    {
        private readonly IServiceProvider serviceProvider;

        public 核心商業邏輯服務(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;

            Console.WriteLine(nameof(核心商業邏輯服務) + "實作 已建立");
            Console.WriteLine("");
        }

        public async Task 執行核心功能Func(string input)
        {

            // =============================================================================
            // keyed service 注入解析範例
            // =============================================================================

            var svc = this.serviceProvider.GetKeyedService<I報告平台>(input);

            if (svc == null)
            {
                Console.WriteLine($"找不到對應的服務：{input}");
                return;
            }

            await svc.產生年度報表();
        }
    }
}
