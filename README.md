Please use postman to test the code 

Steps to call Api:
1)  call login method to generate the token
    [Post] http://localhost:5145/Login/generatetoken
   {
    "UserName": "Abhishek",
    "Password": "Bhatnagar"
    }
2) you'll get response like this
   {
      "statusCode": 200,
      "responseMessage": null,
      "responseData": {
          "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJKd3RTdWJqZWN0IiwianRpIjoiZTgwYzk0OTktZGE0Yi00NzZiLWFlZTYtYjI2NTI2NzAyMzFkIiwiVXNlcklkIjoiQWJoaXNoZWsiLCJleHAiOjE3MzI3MjA1ODcsImlzcyI6Ikp3dElzc3VlciIsImF1ZCI6Ikp3dEF1ZGllbmNlIn0.oVBfaN4Z4f4ym_uSgItKV6oFYeFuBPDrljwdGUS0bWw"
      }

  }

3) Use this token key for authorozing the URL's by "Bearer Token" auth mechanism.

Available Url's are
[Post]http://localhost:5145/User/AddUser 
{
    "UserName" : "Abhishek",
    "Password" : "bhatnagar",
    "RoleID" : 1
}

[Put]http://localhost:5145/User/UpdateUser
{
            "id": 2,
            "userName": "neha",
            "password": "bhatnagar",
            "role": null,
            "roleID": 1
        }

[Delete]http://localhost:5145/User/DeleteUser
{
 "id": 2
}
[Get]http://localhost:5145/User/GetAllUser

[Post]http://localhost:5145/Role/AddRole
{
    "name" : "User1"
}


[Put]http://localhost:5145/Role/UpdateRole
{
    "id":"2",
    "name" : "Role1"
}
[Delete]http://localhost:5145/Role/DeleteRole
{
    "id":"2"
}

[Get]http://localhost:5145/Role/GetAllRoles






