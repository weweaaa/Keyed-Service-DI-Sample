using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyedSvc.Lib.第三方.Services
{
    public interface I第三方套件封裝服務
    {
        public Task 提供呼叫第三方套件的封裝方法();
    }

    internal class 第三方套件封裝服務 : I第三方套件封裝服務
    {
        private readonly HttpClient httpClient;

        internal 第三方套件封裝服務(HttpClient httpClient)
        {
            this.httpClient = httpClient;

            Console.WriteLine(nameof(第三方套件封裝服務) + "實作 已建立");
            Console.WriteLine("");
        }

        public async Task 提供呼叫第三方套件的封裝方法()
        {
            var result = await this.httpClient.GetAsync("https://www.travel.taipei/open-api");
            
            if (result != null)
            {
                Console.WriteLine("呼叫第三方套件的封裝方法：執行 httpClient Get ...");
                Console.WriteLine($"Http Get Status Code：{result.StatusCode}");
                Console.WriteLine("");
            }
        }
    }
}
