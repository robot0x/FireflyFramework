using System;
using UnityEngine;

/// <summary>
/// 网络管理类
/// </summary>
public class NetManager : MonoBehaviour
{
    #region 属性
    // IP PORT
    public string IP = "127.0.0.1";
    public int PORT = 9981;

    // 网络框架对象
    private NetBase m_Client;
    // 连接成功回调
    private Action ConnectSuccessCallback;
    // 判断是否断开连接
    private bool m_LostConnect;
    #endregion

    #region 私有方法
    // 进入游戏前初始化
    void Awake()
    {
        _Init();
    }

    // 初始化网络框架
    void _Init()
    {
        m_Client = new NetBase();
        m_Client.OnConnectedEvent += OnConnect;
        m_Client.OnDisConnectedEvent += OnDisConnect;
        m_Client.OnErrorEvent += OnError;
    }

    // 在固定帧数获取消息
    void FixedUpdate()
    {
        if (Connected)
        {
            // 处理消息
            Globals.Instance.ExecuteMsg(m_Client.Loop());
        }
        if (m_LostConnect)
        {
            // 断开连接，通知用户
            m_LostConnect = false;
            _LostConnect();
        }
    }

    // 断开连接，通知用户
    void _LostConnect()
    {
        // TODO
    }
    #endregion

    #region  定义回调
    void OnConnect(object sender, ConnectedEventArgs e)
    {
        Debug.LogWarning("OnConnect");
        if (Connected)
        {
            // 回调函数
            if (ConnectSuccessCallback != null)
            {
                ConnectSuccessCallback();
                ConnectSuccessCallback = null;
            }
        }
        else
        {
            m_LostConnect = true;
        }
    }

    void OnDisConnect(object sender, ConnectedEventArgs e)
    {
        Debug.LogWarning("OnDisConnect");
    }

    void OnError(object sender, ErrorEventArgs e)
    {
        Debug.LogError("OnError");
    }
    #endregion

    // --------------------
    // 下面是一些外界调用的接口
    // --------------------
    #region  公有方法
    // 重新初始化
    public void ReInit()
    {
        _Init();
    }

    // 发起连接，不含回调方法
    public void Connect()
    {
        m_Client.Connect(IP, PORT);
    }

    // 发起连接，含回调方法
    public void Connect(Action callback)
    {
        ConnectSuccessCallback = callback;
        m_Client.Connect(IP, PORT);
    }

    // 写入数据
    public void Send(byte[] buffer)
    {
        if (buffer != null && Connected)
        {
            m_Client.Send(buffer);
        }
    }

    // 关闭连接
    public void Close()
    {
        if (Connected)
        {
            m_Client.Close();
        }
    }

    // 判断是否连接
    public bool Connected
    { get { return m_Client != null && m_Client.Connected; } }
    #endregion
}
