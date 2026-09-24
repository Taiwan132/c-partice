using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
namespace MyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LogoutController : ControllerBase
{

	private MyApi.Core.Core core = new MyApi.Core.Core();

    [HttpPost]
    public object Post(User user)
    {
      // 檢查 token
	  // 檢查帳號是否重複
		string sql = """
		SELECT * FROM user
		WHERE token = @token
		""";
		var parameters = new Dictionary<string, object>
		{
			{ "@token", user.token },
		};

		using var  reader = core.Select(sql, parameters);


		if (!reader.Read())
		{
			return new
			{
				status = "-1",
				msg = "Token 不存在",
			};
		}

		string update_login = """
		UPDATE user
		SET token = NULL,
			expired_date = NULL,
			login_status = 0
		WHERE token = @token
		""";

		var update_login_parameters = new Dictionary<string, object>
		{
			{ "@token", user.token },
		};

		int result = core.Execute(update_login, update_login_parameters);

		if (result == 1)
		{
			return new
			{
				status = "0",
				msg = "登出成功",
			};
		}

		return new
		{
			status = "-1",
			msg = "登出失敗",
		};
			
    }
}