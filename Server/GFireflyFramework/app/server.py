#! /usr/bin/python
# coding=utf8

"""
测试服务端和客户端的连接、通讯和protobuf的使用
"""

from gfirefly.server.globalobject import netserviceHandle
from gfirefly.server.globalobject import GlobalObject

from protos.protos.CreateRole_pb2 import CreateRoleRes, CreateRoleReq
from protos.protos.Login_pb2 import LoginRes, LoginReq
from protos.protos.Register_pb2 import RegisterRes, RegisterReq


def doConnectionMade(conn):
    """当连接建立时调用的方法"""
    str = 'welcome\r\n'
    GlobalObject().netfactory.pushObject(1000, str, [conn.transport.sessionno])


def doConnectionLost(conn):
    """当连接断开时调用的方法"""
    # none


# 绑定方法
GlobalObject().netfactory.doConnectionMade = doConnectionMade
GlobalObject().netfactory.doConnectionLost = doConnectionLost


@netserviceHandle
def test_1000(_conn, data):
    """测试"""
    print 'ParseFromString :', data

    # 构造消息
    str = data

    # 发送消息
    GlobalObject().netfactory.pushObject(1000, str, [_conn.transport.sessionno])


@netserviceHandle
def login_1001(_conn, data):
    """用户登录的方法"""
    # 反序列化
    res = LoginReq()
    res.ParseFromString(data)
    print 'ParseFromString :', res

    # 实例化
    model = LoginRes()
    model.result = True
    model.hasRole = True
    model.userId = res.account

    # 序列化
    req = model.SerializeToString()
    print 'SerializeToString :', req

    # 发送消息
    GlobalObject().netfactory.pushObject(1001, req, [_conn.transport.sessionno])


@netserviceHandle
def register_1002(_conn, data):
    """用户注册的方法"""
    # 反序列化
    res = RegisterReq()
    res.ParseFromString(data)
    print 'ParseFromString :', res

    # 实例化
    model = RegisterRes()
    model.result = True

    # 序列化
    req = model.SerializeToString()
    print 'SerializeToString :', req

    # 发送消息
    GlobalObject().netfactory.pushObject(1002, req, [_conn.transport.sessionno])


@netserviceHandle
def createRole_1003(_conn, data):
    """用户创建角色的方法"""
    # 反序列化
    res = CreateRoleReq()
    res.ParseFromString(data)
    print 'ParseFromString :', res

    # 实例化
    model = CreateRoleRes()
    model.result = True
    model.userId = '123456'

    # 序列化
    req = model.SerializeToString()
    print 'SerializeToString :', req

    # 发送消息
    GlobalObject().netfactory.pushObject(1003, req, [_conn.transport.sessionno])