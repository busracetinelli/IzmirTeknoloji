using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IzmirTeknoloji.Application.Dtos.TransactionHistory;
using IzmirTeknoloji.Application.Dtos.Users;
using IzmirTeknoloji.Application.Interfaces;
using IzmirTeknoloji.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IzmirTeknoloji.Application.Features.Users.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IApplicationDbContext _context;

        public GetUserQueryHandler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, IApplicationDbContext context)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null || !user.Identity.IsAuthenticated)
                throw new UnauthorizedAccessException("Kullanıcı bulunamadı veya oturum açılmamış.");

            var userIdClaim = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null)
                throw new UnauthorizedAccessException("Kullanıcı bulunamadı.");

            var userId = Guid.Parse(userIdClaim);

            var response = await _userRepository.GetByIdAsync(userId);
            var userDto = new UserDto
            {
                Id = response.Id,
                Email = response.Email,
                RoleId = response.RoleId
            };
            return userDto;
        }
    }
}
