using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceA.Classs
{
    public class UserService
    {
        public List<User> users;

        public UserService()
        {
            users = new List<User>();

            //添加测试数据
            users.Add(new User() { UserName = "admin1", PassWrod = "123", Token = null });
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public string Login(string username, string pwd)
        {
            User user= users.Where(a => a.UserName == username && a.PassWrod == pwd).FirstOrDefault();
            if (user == null)
            {
                return null;
            }

            if (user.Token == null)
            {
                user.Token = Guid.NewGuid().ToString();
            }
            return user.Token;
        }


        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="token"></param>
        public void Logout(string token)
        {
            User user = users.Where(a => a.Token == token).FirstOrDefault();
            if (user != null)
            {
                user.Token = null;
            }
            return;
        }

        public User GetUserByToken(string token)
        {
            return users.Where(a => a.Token == token).FirstOrDefault();
        }

    }
}
