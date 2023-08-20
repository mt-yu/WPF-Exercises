using AutoMapper;
using MyToDo.Api.Context;
using MyToDo.Share.DataTransfers;
using MyToDo.Share.Extensions;

namespace MyToDo.Api.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork work;
        private readonly IMapper mapper;

        public LoginService(IUnitOfWork work, IMapper mapper)
        {
            this.work = work;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> LoginAsync(string Account, string Password)
        {
            try
            {
                Password.GetMD5();
                var user = await work.GetRepository<User>().GetFirstOrDefaultAsync(predicate: x => x.Account.Equals(Account) && x.PassWord.Equals(Password));

                if (user == null) 
                {
                    return new ApiResponse("账号或密码错误，请重试!", false);
                }
                return new ApiResponse(true, user);
            }
            catch (Exception)
            {

                return new ApiResponse("登录失败", false);
            }
        }

        public async Task<ApiResponse> RegisterAsync(UserDto model)
        {
            try
            {
                var dbUser = mapper.Map<User>(model);
                var repository = work.GetRepository<User>();
                var dbUserFind = await repository.GetFirstOrDefaultAsync(predicate: x => x.Account.Equals(dbUser.Account));

                if (dbUserFind != null)
                {
                    return new ApiResponse($"当前账号:{dbUser.Account}已存在，请重新注册!", false);
                }

                dbUser.CreateDateTime = DateTime.Now;
                dbUser.PassWord = dbUser.PassWord.GetMD5();
                await repository.InsertAsync(dbUser);

                if (await work.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, dbUser);
                }

                return new ApiResponse("注册失败，请稍后重试", false);
            }
            catch (Exception)
            {

                return new ApiResponse("注册账号失败", false);
            }
        }
    }
}
