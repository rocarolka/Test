using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTO;

namespace WebApplication1.Services
{
   public interface IMail
    {
       void Send(ClientInfo data);
    }
}
