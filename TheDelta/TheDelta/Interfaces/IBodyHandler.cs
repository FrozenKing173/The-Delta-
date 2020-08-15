using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheDelta.Models;

namespace TheDelta.Interfaces
{
    public interface IBodyHandler
    {
        public Task<VehicleBody> Build(string body);
    }
}
