using System.Runtime.InteropServices.JavaScript;
using Grpc.Core;
using gRPC;
using gRPC.Models;
using GrpcCServer;
using Google.Protobuf.WellKnownTypes;

namespace gRPC.Services;

public class GreeterService : GetPersonService.GetPersonServiceBase
{
  private readonly ILogger<GreeterService> _logger;
  private List<PersonClss> _personss = new(5);
  public GreeterService(ILogger<GreeterService> logger)
  {
    _logger = logger;
    
    _personss.Add(new PersonClss
    {
      Id = 1,
      Ad = "Aaaaa",
      Soyad = "BBBBBB",
      Yas = 22
    });
    
    _personss.Add(new PersonClss
    {
      Id = 2,
      Ad = "Cccccc",
      Soyad = "DDDDDDD",
      Yas = 2
    });
    
    _personss.Add(new PersonClss
    {
      Id = 3,
      Ad = "Eee",
      Soyad = "Ffffff",
      Yas = 25
    });
    
    _personss.Add(new PersonClss
    {
      Id = 4,
      Ad = "Ggggg",
      Soyad = "ĞĞĞĞĞĞĞ",
      Yas = 77
    });
    
    _personss.Add(new PersonClss
    {
      Id = 5,
      Ad = "Hhhhhh",
      Soyad = "IIIIIIIII",
      Yas = 65
    });
  }

  public override async Task<PersonResp> GetPerson(PersonIdReq personIdReq, ServerCallContext context)
  {
    PersonResp _personResp = new();
    _personResp.Person = _personss.FirstOrDefault(fnd => fnd.Id == personIdReq.Id);
    
    return await Task.FromResult(_personResp);
  }
}