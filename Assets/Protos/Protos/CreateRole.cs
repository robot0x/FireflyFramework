//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Protos/CreateRole.proto
namespace Protos.CreateRole
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CreateRoleReq")]
  public partial class CreateRoleReq : global::ProtoBuf.IExtensible
  {
    public CreateRoleReq() {}
    
    private string _username;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"username", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string username
    {
      get { return _username; }
      set { _username = value; }
    }
    private string _profession;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"profession", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string profession
    {
      get { return _profession; }
      set { _profession = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CreateRoleRes")]
  public partial class CreateRoleRes : global::ProtoBuf.IExtensible
  {
    public CreateRoleRes() {}
    
    private bool _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool result
    {
      get { return _result; }
      set { _result = value; }
    }

    private string _characterId = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"characterId", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string characterId
    {
      get { return _characterId; }
      set { _characterId = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}