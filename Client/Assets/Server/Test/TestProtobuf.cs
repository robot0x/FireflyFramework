using UnityEngine;
using Protos.Login;

public class TestProtobuf : MonoBehaviour
{
    void Start()
    {
        LoginReq model = new LoginReq() { account = "maomao", password = "boy" };

        // 序列化
        byte[] req = Util.Serialize(model);
        Debug.Log(System.BitConverter.ToString(req));

        // 反序列化
        LoginReq res = Util.Deserialize<LoginReq>(req);

        // 查看结果
        Debug.Log("account : " + res.account);
        Debug.Log("password : " + res.password);
    }
}
