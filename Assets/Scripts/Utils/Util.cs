using System.IO;
using ProtoBuf;

public static class Util
{
    // 序列化
    public static byte[] Serialize<T>(T model)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            Serializer.Serialize<T>(ms, model);
            byte[] result = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(result, 0, result.Length);
            return result;
        }
    }

    // 反序列化
    public static T Deserialize<T>(byte[] data)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            ms.Write(data, 0, data.Length);
            ms.Position = 0;
            T result = Serializer.Deserialize<T>(ms);
            return result;
        }
    }
}
