using Protos.CreateRole;
using Protos.Login;
using Protos.Register;
// using UnityEngine;

public class SocketManager : Singleton<SocketManager>
{
    public void SendMsg_Login(string account, string password)
    {
        LoginReq req = new LoginReq() { account = account, password = Util.Md5Sum(password) };
        Globals.Instance.SendMsg<LoginReq>(Consts_CommandId.C2S_Login, req);
    }

    public void SendMsg_Register(string account, string password)
    {
        RegisterReq req = new RegisterReq() { account = account, password = Util.Md5Sum(password) };
        Globals.Instance.SendMsg<RegisterReq>(Consts_CommandId.C2S_Register, req);
    }

    public void SendMsg_CreateRole(string username, string profession)
    {
        CreateRoleReq req = new CreateRoleReq() { username = username, profession = profession };
        Globals.Instance.SendMsg<CreateRoleReq>(Consts_CommandId.C2S_CreateRole, req);
    }
}
