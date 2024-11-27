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
http://localhost:5145/User/AddUser
http://localhost:5145/User/UpdateUser
http://localhost:5145/User/DeleteUser
http://localhost:5145/User/GetAllUser

http://localhost:5145/Role/AddRole
http://localhost:5145/Role/UpdateRole
http://localhost:5145/Role/DeleteRole
http://localhost:5145/Role/GetAllRoles






