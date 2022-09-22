using MQTTnet.Server;
using MQTTnet;
using System.Text;
using static System.Console;

Console.Write("Port에 넣을 숫자값을 입력하세요(기본값 : 1883) : ");
var port = Console.ReadLine();

if (port == "")
{
    port = "1883";
}
// Create the options for MQTT Broker
var options = new MqttServerOptionsBuilder()
    //Set endpoint to localhost
    .WithDefaultEndpoint()
    .WithDefaultEndpointPort(Convert.ToInt32(port));
// Create a new mqtt server
var server = new MqttFactory().CreateMqttServer(options.Build());
WriteLine($"Port 번호 {port} 로 Broker가 생성되었습니다.");

//Add Interceptor for logging incoming messages
server.InterceptingPublishAsync += Server_InterceptingPublishAsync;
server.ClientConnectedAsync += Server_ClientConnectedAsync;
server.ClientDisconnectedAsync += Server_ClientDisConnectedAsync;
// Start the server
await server.StartAsync();
// Keep application running until user press a key
ReadLine();

Task Server_ClientConnectedAsync(ClientConnectedEventArgs arg) //연결 확인
{
    WriteLine($"TimeStamp : {DateTime.Now}, ClientId = {arg.ClientId} 인 클라이언트가 접속하였습니다");
    return Task.CompletedTask;
}
Task Server_ClientDisConnectedAsync(ClientDisconnectedEventArgs arg)  //연결 해제 확인
{
    WriteLine($"TimeStamp : {DateTime.Now}, ClientId = {arg.ClientId} 인 클라이언트가 접속을 종료하였습니다");
    return Task.CompletedTask;
}

Task Server_InterceptingPublishAsync(InterceptingPublishEventArgs arg)
{
    // Convert Payload to string
    var payload = arg.ApplicationMessage?.Payload == null ? null : Encoding.UTF8.GetString(arg.ApplicationMessage.Payload);

    WriteLine(
        " TimeStamp: {0} -- Message: ClientId = {1}, Topic = {2}, Payload = {3}, QoS = {4}, Retain-Flag = {5}",
        DateTime.Now,
        arg.ClientId,
        arg.ApplicationMessage?.Topic,
        payload,
        arg.ApplicationMessage?.QualityOfServiceLevel,
        arg.ApplicationMessage?.Retain);

    string savePath = @$"d:\brokerlog\{DateTime.Now.ToString("yyyy-MM-dd-HH")}_{arg.ApplicationMessage?.Topic}.txt";
    string textValue = $"TimeStamp: {DateTime.Now} - ClientId = {arg.ClientId}, Topic = {arg.ApplicationMessage?.Topic}, Payload = {payload}, QoS = {arg.ApplicationMessage?.QualityOfServiceLevel}, Retain-Flag = {arg.ApplicationMessage?.Retain}\r\n";
    if (!File.Exists(savePath))
    {
        System.IO.File.WriteAllText(savePath, textValue);
    }
    else
    {
        File.AppendAllText(savePath, textValue);
    }

    return Task.CompletedTask;
}