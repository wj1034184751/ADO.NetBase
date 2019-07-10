using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeidatR.Test
{
    public class Ping : IRequest<string>
    {
    }

    public class PingHandler : IRequestHandler<Ping, string>
    {
        public Task<string> Handle(Ping request,CancellationToken toekn)
        {
            return Task.FromResult("Pong");
        }
    }
}
