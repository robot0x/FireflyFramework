# 开发基本情况

## 消息组成：
> * `HEAD_0`  头0  1字节  
`HEAD_1`  头1  1字节  
`HEAD_2`  头2  1字节  
`HEAD_3`  头3  1字节  
`ProtoVersion`  协议版本  1字节  
`ServerVersion`  服务端版本  4字节  
`Length`  消息长度  4字节  
`commandId`  命令号  4字节  
`msg`  消息  msg.Length字节  

## 传输格式：
> 使用 Protobuf 2.5.0 版本  
> `C#` /ProtoGen/protogen -i:/Protos/Login.proto -o:/Protos/Login.cs  
> `Python` /protoc/protoc -I=/Protos/ --python_out=/Protos/ Login.proto  
```
# Login.proto
message LoginReq
{
	required string username = 1;
	required string password = 2;
}
message LoginRes
{
	required bool result = 1;
	optional bool hasRole = 2;
	optional string userId = 3;
}
```
> `Windows` 下 `Unity` Protobuf 安装流程：  
`Download` ： 下载 protobuf-net r640.zip  
`Copy` ： 将 Full\unity\protobuf-net.dl 复制到 Unity工程的Plugins目录下  
> `Windows` 下 `Python` Protobuf 安装流程：  
`Download` ： 下载 protobuf-python-2.5.0.zip 和 protoc-2.5.0-win32.zip  
`Build` : 进入目录 protobuf-2.5.0\python\ 执行 python setup.py build  
`Copy` : 将 protoc-2.5.0-win32\bin\protoc.exe 复制到 protobuf-2.5.0\src\  
`ReBuild` : python setup.py build  
`Test` ： python setup.py test  
`Install` : python setup.py install  

## 传输协议：
> * 客户端到服务端：C2S_XXXX  
1001 C2S_Login  
1002 C2S_Register  
...  
> * 服务端到客户端：S2C_XXXX  
1001 S2C_Login  
1002 S2C_Register  
...  

## 客户端 Unity
### 网络底层框架
> * `NetBase` 网络框架抽象类  
```
public abstract class NetBase
{
    // 事件
    public abstract event OnConnectedHandler OnConnectedEvent;
    public abstract event OnDisConnectedHandler OnDisConnectedEvent;
    public abstract event OnErrorHandler OnErrorEvent;
    // 发起连接
    public abstract void Connect(string ip, int port);
    // 重新连接
    public abstract void ReConnect();
    // 发送消息
    public abstract void Send(byte[] buffer);
    // 获取消息
    public abstract MessageData Loop();
    // 关闭连接
    public abstract void Close();
    // 判断是否连接
    public abstract bool Connected { get; }
}
```
> * `NetThread` 多线程版本  `NetAsyn` 异步版本  
注意：两个版本都有相同的接口，默认使用多线程版本。  
> * `MessageParse` 负责消息解析打包  
public static MessageData Unparse(byte[] buffer) 解析消息  
public static byte[] Parse(int serverVersion, int commandId, byte[] msg) 打包消息 

### Globals类
> * `Globals`  
含NetManager、HandlerManager等管理类  
游戏开始前会自动加载管理类，并发起网络连接  
public void ExecuteMsg(MessageData data) 处理消息  
public void SendMsg<T>(int commandId, T data) 发送消息  

### Managers类
> * `NetManager` 网络管理类  
选择多线程网络（默认）或者异步网络  
断线重连机制  
网络连接事件回调  
获取消息转发消息  
> * `HandlerManger` 消息处理类  
注册handler  
管理handler  
通知handler处理消息   
> * `SocketManager` 消息转发类  
全局单例，封装了所有消息转发函数，外界只需要调用这个类的函数即可与服务端通讯  
public void SendMsg_Login(string account, string password)  
public void SendMsg_Register(string account, string password)  

### Handlers类
> * `IHandler` handler接口
```
public interface IHandler
{
    // 唯一的 Id
    int commandId { get; }
    // 执行方法，线程安全
    void Execute(MessageBody data);
}
```
> * ConnectHandler
> * LoginHandler
> * RegisterHandler

### Utils类
> * `Consts`  C2S常量、S2C常量
> * `Singleton` 普通单例、Unity单例
> * `Util` 序列化、反序列化、Md5加密

### Test类
> * ...对工具类的测试...

## 服务端 Python
> * 服务端架构
clinet ---- net ---- gate ---- scene ---- gate ---- net ---- client  

## GFirefly 总结
> * `Bug修复`
gtwisted ---- core ---- protocols ---- ClientFactory ---- \_\_init\_\_ ---- p.join()  

> * `功能及特性`
1、采用单线程多进程架构，支持自定义的分布式架构；  
2、方便的服务器扩展机制，可快速扩展服务器类型和数量；  
3、与客户端采用TCP长连接，无需考虑粘包等问题；  
4、封装数据缓存服务；  
5、可实现实时热更新数据以及游戏逻辑，客户端玩家无感觉；  
6、有几十个基础游戏玩法系统模块提供组装使用。  

> * `详细技术介绍`  
> `master管理节点`：这是用来管理所有节点的节点，如可通过http来关闭所有节点(可回调节点注册的关闭方法)，其实master节点也可以理解为是分布式root节点，其它节点都是remote节点  
> `net前端节点`：net节点是client端连接节点，负责数据包的结束，解包，封包，发送。net节点也是gate节点的分布式节点，由于游戏中流量较大，所以一般net节点只负责解包，封包，然后将解包后的数据转发给gate分布式根节点，处理完毕后再有net节点将处理结果发给client  
> `gate分布式根节点`：net节点将解包的数据发给gate节点后，gate节点可以自己处理数据返回结果，也可以调用remote子节点处理数据  
> `remote子节点`：一般remote子节点都是真正干活的节点  
> `dbfront节点`：这个节点一般是负责管理memcache和数据库交互的节点  
