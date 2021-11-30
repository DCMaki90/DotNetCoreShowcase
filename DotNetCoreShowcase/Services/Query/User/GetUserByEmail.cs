using DotNetCoreShowcase.Models.Showcase;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetCoreShowcase.Services.User
{
    public class GetUserByEmail
    {
        public class Query : IRequest<Users>
        {
            public string Email { get; set; }
            public Query(string email)
            {
                this.Email = email;
            }
        }
        public class QueryHandler : IRequestHandler<Query, Users>
        {
            private ShowcaseGeneratedContext _showcaseGeneratedContext;

            public QueryHandler(ShowcaseGeneratedContext showcaseGeneratedContext)
            {
                _showcaseGeneratedContext = showcaseGeneratedContext;
            }

            public async Task<Users> Handle(Query request, CancellationToken cancellationToken)
            {
                return await Task.Run(() =>_showcaseGeneratedContext.Users.FirstOrDefault(user => user.Email == request.Email));
            }
        }
    }
}
