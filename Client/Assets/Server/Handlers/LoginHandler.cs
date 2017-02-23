using Protos.Login;
using UnityEngine;

public class LoginHandler : IHandler
{
    public int commandId { get { return Consts_CommandId.S2C_Login; } }

    public void Execute(MessageBody data)
    {
        LoginRes res = Util.Deserialize<LoginRes>(data.msg);
        if (res != null)
        {
            // 登录成功
            if (res.result)
            {
                Debug.Log("登录成功!!!");
                Debug.Log("hasRole : " + res.hasRole);
                Debug.Log("userId : " + res.userId);
            }
            else
            {
                Debug.Log("登录失败!!!");
            }
        }
    }
}
