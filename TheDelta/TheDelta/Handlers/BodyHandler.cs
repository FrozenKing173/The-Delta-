using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheDelta.Interfaces;
using TheDelta.Models;

namespace TheDelta.Handlers
{
    public class BodyHandler : IBodyHandler
    {
        public async Task<VehicleBody> Build(string body)
        {
            body = body.ToLower();
            if (body.Equals("thin"))
            {
                return new ThinBody();
            }
            else if (body.Equals("wide"))
            { 
                return new WideBody();
            }
            else
            {
                return new NormalBody();
            }
        }
    }
}
