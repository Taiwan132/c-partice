using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
namespace MyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{

	private MyApi.Core.Core core = new MyApi.Core.Core();

    [HttpPost]
    public object Post(User user)
    {
      // 檢查帳號存不存在
		string sql = """
		SELECT * FROM user
		WHERE account = @account
		""";
		var parameters = new Dictionary<string, object>
		{
			{ "@account", user.Account },
		};

		using var  reader = core.Select(sql, parameters);


		if (!reader.Read())
		{
			// 查無資料
			return new
			{
				status = "-1",
				msg = "帳號不存在",	
			};
		}
		
		string password = core.encode(user.Password) ;
		while (reader.Read())
		{
			// 檢查密碼輸入正不正確
			 if ((string)reader["password"] != password)
			{
				return new
				{
					status = "-1",
					msg = "密碼錯誤",	
				};
			}

		}
		// 更新登入過期時間
		//	登入到期時間 30 分鐘
		long createdTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

		DateTime expiresDate = DateTime.UtcNow.AddMinutes(30);

		//	產生 token
		string token =  core.get_token();

		string update_login_expired_time = """
		UPDATE user SET `expired_date` = '@expired_date' , `token` = '@token' WHERE `account` = @account
		""";
		var update_parameters = new Dictionary<string, object>
		{
			{ "@account", user.Account },
			{ "@expired_date",update_login_expired_time},
			{ "@token",token}
		};

		int update_result = core.Execute(update_login_expired_time, update_parameters);
		if (update_result == 1) {
			return new
			{
				status = "0",
				msg = "登入成功",	
				token = token
			};
		} else
		{
			return new
			{
				status = "-1",
				msg = "登入失敗",	
			};
		}
    }
}