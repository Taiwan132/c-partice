using MySqlConnector;
using System.Security.Cryptography;
using System.Text;

namespace MyApi.Core;

public class Core
{
    private string connectionString =
        "Server=localhost;Port=3306;Database=Pratice;User=root;Password=;";

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }

    // SELECT
    public MySqlDataReader Select(
    string sql,
    Dictionary<string, object> parameters)
	{
		MySqlConnection connection = GetConnection();
		connection.Open();

		MySqlCommand command = new MySqlCommand(sql, connection);

		foreach (var parameter in parameters)
		{
			command.Parameters.AddWithValue(
				parameter.Key,
				parameter.Value
			);
		}

		return command.ExecuteReader();
	}
    // INSERT / UPDATE / DELETE
    public int Execute(
    string sql,
    Dictionary<string, object> parameters)
	{
		using MySqlConnection connection = GetConnection();

		connection.Open();

		using MySqlCommand command = new MySqlCommand(sql, connection);

		foreach (var parameter in parameters)
		{
			command.Parameters.AddWithValue(
				parameter.Key,
				parameter.Value
			);
		}

		return command.ExecuteNonQuery();
}

// 加密
	public string encode(string plaintext)
	{
		string encode_str = Convert.ToHexString(
			MD5.HashData(Encoding.UTF8.GetBytes(plaintext))
		).ToLower();
		return encode_str;
	}
// 產生 token 
    public string get_token()
	{
		string token = Convert.ToBase64String(
			RandomNumberGenerator.GetBytes(32)
		);
		return token;
	}
}