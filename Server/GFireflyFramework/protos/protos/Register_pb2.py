# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: Register.proto

from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import descriptor_pb2
# @@protoc_insertion_point(imports)




DESCRIPTOR = _descriptor.FileDescriptor(
  name='Register.proto',
  package='',
  serialized_pb='\n\x0eRegister.proto\"0\n\x0bRegisterReq\x12\x0f\n\x07\x61\x63\x63ount\x18\x01 \x02(\t\x12\x10\n\x08password\x18\x02 \x02(\t\"\x1d\n\x0bRegisterRes\x12\x0e\n\x06result\x18\x01 \x02(\x08')




_REGISTERREQ = _descriptor.Descriptor(
  name='RegisterReq',
  full_name='RegisterReq',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='account', full_name='RegisterReq.account', index=0,
      number=1, type=9, cpp_type=9, label=2,
      has_default_value=False, default_value=unicode("", "utf-8"),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    _descriptor.FieldDescriptor(
      name='password', full_name='RegisterReq.password', index=1,
      number=2, type=9, cpp_type=9, label=2,
      has_default_value=False, default_value=unicode("", "utf-8"),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  options=None,
  is_extendable=False,
  extension_ranges=[],
  serialized_start=18,
  serialized_end=66,
)


_REGISTERRES = _descriptor.Descriptor(
  name='RegisterRes',
  full_name='RegisterRes',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='result', full_name='RegisterRes.result', index=0,
      number=1, type=8, cpp_type=7, label=2,
      has_default_value=False, default_value=False,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  options=None,
  is_extendable=False,
  extension_ranges=[],
  serialized_start=68,
  serialized_end=97,
)

DESCRIPTOR.message_types_by_name['RegisterReq'] = _REGISTERREQ
DESCRIPTOR.message_types_by_name['RegisterRes'] = _REGISTERRES

class RegisterReq(_message.Message):
  __metaclass__ = _reflection.GeneratedProtocolMessageType
  DESCRIPTOR = _REGISTERREQ

  # @@protoc_insertion_point(class_scope:RegisterReq)

class RegisterRes(_message.Message):
  __metaclass__ = _reflection.GeneratedProtocolMessageType
  DESCRIPTOR = _REGISTERRES

  # @@protoc_insertion_point(class_scope:RegisterRes)


# @@protoc_insertion_point(module_scope)