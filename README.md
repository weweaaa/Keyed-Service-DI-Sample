# KeyedSvcDemo 範例專案說明書

## 專案說明

> 使用到 Keyed Service 依賴注入容器的範例專案。
> 用來展示當有一個介面對應多個實作工廠設計模式，並透過 DI 容器來取得實作物件的範例專案。

- KeyedSvc.Lib.Core

  - 負責處理核心商業邏輯相關實作  

  - 提供外部依賴注入的方法，使用時請記得：

    - 設定 `Program.cs` 檔案，註冊服務

    ```csharp
    using KeyedSvc.Lib.Core;
    using KeyedSvc.Lib.Core.Services;

    // 此為 KeyedSvc.Lib.Core 提供已封裝好的 Service
    builder.Services.AddCoreService();
    ```

- KeyedSvc.Lib.第三方
  
  - 提供作為 KeyedSvc.Lib.Core 內實作時，會使用到的第三方套件 DI 注入模組
  
  - 提供外部依賴注入的方法，使用時請記得：

    - 設定 DI 註冊服務

    ```csharp
    using KeyedSvc.Lib.第三方;
    using KeyedSvc.Lib.第三方.Services;

    // 因為有引用到 HttpClient，所以要註冊 HttpClient
    services.AddHttpClient();
    
    // 此為 KeyedSvc.Lib.第三方 提供已封裝好的 Service
    builder.Services.Add第三方CoreService();
    ```

- KeyedSvc.Sample
  
  - 提供 Console 主控台示範如何使用 KeyedSvc.Lib.Core 的範例。

- KeyedSvc.SampleWeb
  
  - 提供 Web API 示範如何使用 KeyedSvc.Lib.Core 的範例。
  
  - - [KEYED SERVICE IN .NET 8](https://medium.com/ricos-note/keyed-service-in-net8-fd663da37768)

## 專案架構

- KeyedSvc.Lib.Core

  - .NET Standard Library

- KeyedSvc.Lib.第三方

  - .NET Standard Library

- KeyedSvc.Sample

  - ASP.NET CORE 8 Console Application
  
- KeyedSvc.SampleWeb

  - ASP.NET CORE 8 Web API

## 專案依賴

- KeyedSvc.Lib.Core 參考：

  - KeyedSvc.Lib.第三方

- KeyedSvc.Lib.第三方 參考：

  - 以使用 `HttpClient` 套件作為示範封裝的第三方套件

- KeyedSvc.Sample 參考：

  - NAO.FileExtension.Core

  - 模擬示範用套件：
    - Microsoft.Extensions.Hosting
    - Microsoft.Extensions.Http
	
- KeyedSvc.SampleWeb 參考：

  - NAO.FileExtension.Core
