using KeyedSvc.Lib.Core;
using KeyedSvc.Lib.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace KeyedSvc.Sample;

public class Program
{
    public static async Task Main(string[] args)
    {
        var svc = 模擬DI_InjectService();

        // 執行核心商業邏輯
        await svc.執行核心功能Func("public");
        await svc.執行核心功能Func("internal");
    }

    private static I核心商業邏輯服務 模擬DI_InjectService()
    {
        // DI 容器
        var services = new ServiceCollection();

        // 注入服務
        services.AddHttpClient();   // Console 專案要安裝：Microsoft.Extensions.Http 的 Nuget 套件。
        services.AddCoreService();

        // 建立 ServiceProvider
        var provider = services.BuildServiceProvider();     // Console 專案要安裝：Microsoft.Extensions.Hosting 的 Nuget 套件。

        // 取得核心商業邏輯服務
        var coreService = provider.GetService<I核心商業邏輯服務>();

        return coreService;
    }
}
