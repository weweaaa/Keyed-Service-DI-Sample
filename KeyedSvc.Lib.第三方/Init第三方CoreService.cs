using KeyedSvc.Lib.第三方.Services;
using Microsoft.Extensions.DependencyInjection;

namespace KeyedSvc.Lib.第三方
{
    public static class Init第三方CoreService
    {
        /// <summary>
        /// 提供外部 DI 容器注入服務 擴充方法
        /// </summary>
        public static IServiceCollection Add第三方CoreService(this IServiceCollection services)
        {
            services.AddScoped<I第三方套件封裝服務, 第三方套件封裝服務>(provider =>
            {
                // 檢查外部是否有注入 HttpClient
                if (provider.GetRequiredService<HttpClient>() == null)
                {
                    throw new System.ArgumentNullException(nameof(provider));
                }

                return new 第三方套件封裝服務(provider.GetRequiredService<HttpClient>());
            });

            return services;
        }
    }
}
