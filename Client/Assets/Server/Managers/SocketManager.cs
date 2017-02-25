using Protos.Login;
using Protos.Register;
// using UnityEngine;

public class SocketManager : Singleton<SocketManager>
{
    public void SendMsg_Login(string username, string password)
    {
        LoginReq req = new LoginReq() { username = username, password = Util.Md5Sum(password) };
        Globals.Instance.SendMsg<LoginReq>(Consts_CommandId.C2S_Login, req);
    }

    public void SendMsg_Register(string username, string password)
    {
        RegisterReq req = new RegisterReq() { username = username, password = Util.Md5Sum(password) };
        Globals.Instance.SendMsg<RegisterReq>(Consts_CommandId.C2S_Register, req);
    }
}
