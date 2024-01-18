using grpc.server;
using Grpc.Core;
using Grpc.Net.Client;

var channel = GrpcChannel.ForAddress("https://localhost:7218");

// 透過 channel對遠端 grpc server發出 request
var client = new Greeter.GreeterClient(channel);

//使用到HelloReply和HelloRequest的欄位一定要首字母大寫
var reply = client.SayHello(new HelloRequest() // reply是強型別的 HelloReply
{
    Name = "Benson",
    Age = "5"
});
Console.WriteLine(reply.Message);
Console.WriteLine(reply.Result);


//定義header
var headers = new Metadata{
    {"MyHeaderRq","testRequest"}
};
var reply_2 = client.GetMyData(new GetMyDataRequest() // reply是強型別的 HelloReply
{
    Idno = "c123456789",
    Carno = "qwe-789"
}, headers);
Console.WriteLine(reply_2.Address);
Console.WriteLine(reply_2.Cartype);
//獲取response header
// var headersRsp = await reply_2.ResponseHeadersAsync;
// var specificHeader = headersRsp.FirstOrDefault(h => h.Key == "MyHeaderRp")?.Value;
// Console.WriteLine(specificHeader);
