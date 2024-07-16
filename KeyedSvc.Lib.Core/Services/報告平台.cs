using KeyedSvc.Lib.第三方.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyedSvc.Lib.Core.Services
{
    public interface I報告平台
    {
        public Task 產生年度報表();
    }

    // 範例：公開報告，示範：public 公開實作
    public class 公開報告 : I報告平台
    {
        private readonly I第三方套件封裝服務 thirdPartLib;

        public 公開報告(I第三方套件封裝服務 thirdPartLib)
        {
            this.thirdPartLib = thirdPartLib;
        }

        public async Task 產生年度報表()
        {
            Console.WriteLine(nameof(公開報告) + "產生年度報表...");
            
            await this.thirdPartLib.提供呼叫第三方套件的封裝方法();

            Console.WriteLine("");
        }
    }

    // 範例：內部報告，示範：封裝在 KeyedSvc.Lib.Core.Services 內
    internal class 內部報告 : I報告平台
    {
        private readonly I第三方套件封裝服務 thirdPartLib;

        internal 內部報告(I第三方套件封裝服務 thirdPartLib)
        {
            this.thirdPartLib = thirdPartLib;
        }

        public async Task 產生年度報表()
        {
            Console.WriteLine(nameof(內部報告) + "產生年度報表...");
            Console.WriteLine(nameof(內部報告) + "執行產生中...");
            Console.WriteLine(nameof(內部報告) + "產生完成!");
            Console.WriteLine("");

            await Task.CompletedTask;
        }
    }
}
