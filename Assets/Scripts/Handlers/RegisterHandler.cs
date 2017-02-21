using Protos.CreateRole;
using UnityEngine;

public class RegisterHandler : IHandler
{
    public int commandId { get { return Consts_CommandId.S2C_CreateRole; } }

    public void Execute(MessageBody data)
    {
        CreateRoleRes res = Util.Deserialize<CreateRoleRes>(data.msg);
        if (res != null)
        {
            // 注册成功
            if (res.result)
            {
                Debug.Log("创建成功!!!");
                Debug.Log("result : " + res.result);
                Debug.Log("result : " + res.characterId);
            }
            else
            {
                Debug.Log("注册失败!!!");
            }
        }
    }
}
