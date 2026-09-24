# ASP.NET Core Web API - Login / Register

使用 C#、ASP.NET Core Web API、MariaDB、MySqlConnector 實作的登入／註冊 API 練習作品。

## 使用技術

* C#
* ASP.NET Core Web API
* MariaDB
* MySqlConnector
* SQL
* Postman
* Git / GitHub

## 功能

* 使用者註冊
* 使用者登入
* 帳號存在檢查
* 密碼 Hash
* Token 產生
* Token 有效期限
* MariaDB 資料庫操作
* SQL Parameterized Query

## API 範例

### 1. Register

**POST**

```text
/api/Register
```

Request：

```json
{
    "account": "test",
    "email": "test@test.com",
    "Name": "測試",
    "password": "123456"
}
```

Response：

```json
{
    "status": "1",
    "msg": "success",
    "token": "zkTz8SLL...Id4lT8=",
    "expired_time": "2026-09-24T03:56:33.9785391Z"
}
```

### 2. Login

**POST**

```text
/api/Login
```

Request：

```json
{
    "account": "test",
    "password": "123456"
}
```

Response：

```json
{
    "status": "0",
    "msg": "登入成功",
    "token": "O6LMF2ZP...MYaIPQ="
}
```

## 登入流程

```text
Client
  ↓
Login API
  ↓
Controller
  ↓
MariaDB 查詢帳號
  ↓
Password Hash 比對
  ↓
驗證成功
  ↓
產生 Token
  ↓
更新 Token 有效期限
  ↓
回傳登入結果
```

## 專案架構

```text
MyApi/
├── Controllers/
│   ├── LoginController.cs
│   └── RegisterContr
```
