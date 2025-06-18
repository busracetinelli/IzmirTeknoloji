//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Authentication;
//using System.Text;
//using System.Threading.Tasks;
//using IzmirTeknoloji.Application.Features.Auth.Commands.LoginUser;
//using IzmirTeknoloji.Application.Interfaces;
//using IzmirTeknoloji.Application.Interfaces.Repositories;
//using MediatR;

//namespace IzmirTeknoloji.Application.Features.Users.Commands.LoginUser
//{
//    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserResponse>
//    {
//        private readonly IUserRepository _userRepository;
//        private readonly IJwtService _jwtService;

//        public LoginUserCommandHandler(IUserRepository userRepository, IJwtService jwtService)
//        {
//            _userRepository = userRepository;
//            _jwtService = jwtService;
//        }

//        public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
//        {
//            var user = await _userRepository.GetByEmailAndPasswordAsync(request.Email, request.Password);

//            if(user == null)
//                throw new AuthenticationException("ŞE-posta ya da şifre hatalı.");

//            var token = _jwtService.GenerateToken(user);
//            return new LoginUserResponse
//            {
//                Token = token,
//                RoleId = user.RoleId,
//                Email = user.Email,
//                UserId = user.Id
//            };
//        }
//    }
//}
