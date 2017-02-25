using Protos.Register;
using UnityEngine;

public class RegisterHandler : IHandler
{
    public int commandId { get { return Consts_CommandId.S2C_Register; } }

    public void Execute(MessageBody data)
    {
        RegisterRes res = Util.Deserialize<RegisterRes>(data.msg);
        if (res != null)
        {
            // 注册成功
            if (res.result)
            {
                Debug.Log("注册成功!!!");
                Debug.Log("result : " + res.result);
            }
            else
            {
                Debug.Log("注册失败!!!");
            }
        }
    }
}
