using Grpc.Core;
using grpc.server;

namespace grpc.server.Services;

public class GreeterService : Greeter.GreeterBase
{
    // private readonly ILogger<GreeterService> _logger;
    public GreeterService(
        // ILogger<GreeterService> logger
        )
    {
        // _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        //使用到HelloReply和HelloRequest的欄位一定要首字母大寫
        return Task.FromResult(new HelloReply
        {
            Message = $"Hello {request.Name}-{request.Age}",
            Result = "20230618"
        });
    }

    public override Task<GetMyDataReply> GetMyData(GetMyDataRequest request, ServerCallContext context)
    {
        //查詢資料庫，存到GetMyDataReply的物件裡
        //...

        //獲取header
        var headers = context.RequestHeaders;
        var header = headers.FirstOrDefault(x => x.Key == "myheaderrq");

        //定義回傳header
        context.ResponseTrailers.Add(new Metadata.Entry("MyHeaderRp", "testResponse"));

        return Task.FromResult(new GetMyDataReply
        {
            Address = $"Hello {request.Idno}-{request.Carno}",
            Cartype = $"Altis {header.Value}"
        });
    }
}
