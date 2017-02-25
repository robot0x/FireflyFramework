#coding:utf8

from protos.protos.Login_pb2 import LoginRes

# 实例化
model = LoginRes()
model.result = True
model.hasRole = True
model.userId = '123456'

# 序列化
req = model.SerializeToString()
print 'SerializeToString :', req

# 反序列化
res = LoginRes()
res.ParseFromString(req)
print 'ParseFromString :', res