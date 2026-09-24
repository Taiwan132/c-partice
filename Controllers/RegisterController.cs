using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
namespace MyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegisterController : ControllerBase
{

	private MyApi.Core.Core core = new MyApi.Core.Core();

    [HttpPost]
    public object Post(User user)
    {
	
	// 檢查空字串
       if(string.IsNullOrEmpty(user.Account))
		{
			return new
			{
			   status = "-1",
			   msg = "Acccount is empty",	
			};
		}

		if(string.IsNullOrEmpty(user.Email))
		{
			return new
			{
			   status = "-1",
			   msg = "Email is empty",	
			};
		}

		if(string.IsNullOrEmpty(user.Name))
		{
			return new
			{
			   status = "-1",
			   msg = "Name is empty",	
			};
		}

		// 檢查帳號是否重複
		string sql = """
		SELECT * FROM user
		WHERE account = @account
		""";
		var parameters = new Dictionary<string, object>
		{
			{ "@account", user.Account },
		};

		using var  reader = core.Select(sql, parameters);


		while (reader.Read())
		{
			// 有查到資料
			return new
			{
			   status = "1",
			   msg = reader["account"]+"已經存在",	
			};
		}

		//	登入到期時間 30 分鐘
		long createdTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

		DateTime expiresDate = DateTime.UtcNow.AddMinutes(30);

		// 準備寫入 db user
		string insert_sql = """
		INSERT INTO user (account,password,Name,Email,token,expired_date,login_status) VALUE (@account,@password,@Name,@Email,@token,@expired_date,1)
		""";

		//	產生 token
		string token =  core.get_token();

		var insert_parameters  = new Dictionary<string, object>
		{
			{ "@account", user.Account },
			{ "@password", core.encode(user.Password) },
			{ "@Name", user.Name },
			{ "@Email", user.Email },
			{ "@token", token },
			{"@expired_date",expiresDate}
		};

		int execute  = core.Execute(insert_sql, insert_parameters );
	    if(execute == 1) {
			return new
			{
				status = "1",
				msg = "success",
				toke= token,	
				expired_time=expiresDate,
			};
		}else
		{
			return new
			{
				status = "1",
				msg = "fail",
			};
		}
    }
}