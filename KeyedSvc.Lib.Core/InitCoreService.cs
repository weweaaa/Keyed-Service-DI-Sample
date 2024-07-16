using KeyedSvc.Lib.Core.Services;
using KeyedSvc.Lib.第三方;
using KeyedSvc.Lib.第三方.Services;
using Microsoft.Extensions.DependencyInjection;

namespace KeyedSvc.Lib.Core
{
    public static class InitCoreService
    {
        /// <summary>
        /// 提供外部 DI 容器注入服務 擴充方法
        /// </summary>
        public static IServiceCollection AddCoreService(this IServiceCollection services)
        {
            // 外部 DI 服務注入
            services.Add第三方CoreService();

            // 內部 DI 服務注入
            services.AddScoped<I核心商業邏輯服務, 核心商業邏輯服務>();

            // =============================================================================
            // keyed service 注入註冊範例
            // =============================================================================

            // 【作法一】如果實作的服務 Class 存取範圍為 public，則可使用此寫法
            services.AddKeyedScoped<I報告平台, 公開報告>("public");
            // 這段會使 Run Time 時期出現錯誤，因為內部報告的存取範圍為 internal。
            // 錯誤訊息：【System.InvalidOperationException:
            //                  'A suitable constructor for type 'KeyedSvc.Lib.Core.Services.內部報告' could not be located.
            //                  Ensure the type is concrete and services are registered for all parameters of a public constructor.
            //           '】
            //services.AddKeyedScoped<I報告平台, 內部報告>("internal");


            // 【作法二】如果期望實作的服務 Class 存取範圍為 internal，則使用以下寫法
            services.AddKeyedScoped(typeof(I報告平台), KeyedService.AnyKey, (provider, o) =>
            {
                var extension = provider.GetRequiredService<I第三方套件封裝服務>();

                switch (o)
                {
                    case "internal":
                        return new 內部報告(extension);
                    case "public":
                        return new 公開報告(extension);
                    default:
                        throw new NotSupportedException();
                }
            });

            return services;
        }
    }
}
