// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using static System.Console;
using GrpcClient;

namespace gRPC.Client;
public class Console
{
  static void Main(string[] args)
  {
    using var channel = GrpcChannel.ForAddress("http://localhost:8000");
    var client = new GetPersonService.GetPersonServiceClient(channel);
    var reply = client.GetPerson(new PersonIdReq(){Id=1});

    PersonClss _personClss = reply.Person;
    WriteLine(_personClss.Ad);
  }
}
