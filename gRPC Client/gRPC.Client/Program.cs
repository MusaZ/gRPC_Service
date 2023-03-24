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
   again:
    Write("İstenilen Id Yi Giriniz(1-5) : ");
    int pID = Convert.ToInt32(ReadLine());
    if(pID < 1 | pID > 5)
    {
      WriteLine("Sınır Değerleri Aşıldı.");
      goto again;
    }   

    var reply = client.GetPerson(new PersonIdReq(){Id=pID});

    PersonClss _personClss = reply.Person;
    WriteLine(_personClss.Ad);
  }
}
