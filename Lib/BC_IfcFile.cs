// <auto-generated/>
//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


internal class BC_IfcFile : BC_ControllableData {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal BC_IfcFile(global::System.IntPtr cPtr, bool cMemoryOwn) : base(BIMcollab_IfcFilePINVOKE.BC_IfcFile_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(BC_IfcFile obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~BC_IfcFile() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          BIMcollab_IfcFilePINVOKE.delete_BC_IfcFile(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public string GetName() {
    string ret = BIMcollab_IfcFilePINVOKE.BC_IfcFile_GetName(swigCPtr);
    return ret;
  }

  public void SetName(string name) {
    BIMcollab_IfcFilePINVOKE.BC_IfcFile_SetName(swigCPtr, name);
    if (BIMcollab_IfcFilePINVOKE.SWIGPendingException.Pending) throw BIMcollab_IfcFilePINVOKE.SWIGPendingException.Retrieve();
  }

  public string GetDate() {
    string ret = BIMcollab_IfcFilePINVOKE.BC_IfcFile_GetDate(swigCPtr);
    return ret;
  }

  public void SetDate(string date) {
    BIMcollab_IfcFilePINVOKE.BC_IfcFile_SetDate(swigCPtr, date);
    if (BIMcollab_IfcFilePINVOKE.SWIGPendingException.Pending) throw BIMcollab_IfcFilePINVOKE.SWIGPendingException.Retrieve();
  }

  public string GetReference() {
    string ret = BIMcollab_IfcFilePINVOKE.BC_IfcFile_GetReference(swigCPtr);
    return ret;
  }

  public void SetReference(string reference) {
    BIMcollab_IfcFilePINVOKE.BC_IfcFile_SetReference(swigCPtr, reference);
    if (BIMcollab_IfcFilePINVOKE.SWIGPendingException.Pending) throw BIMcollab_IfcFilePINVOKE.SWIGPendingException.Retrieve();
  }

  public string GetProjectIfcGlobalId() {
    string ret = BIMcollab_IfcFilePINVOKE.BC_IfcFile_GetProjectIfcGlobalId(swigCPtr);
    return ret;
  }

  public void SetProjectIfcGlobalId(string ifcGuid) {
    BIMcollab_IfcFilePINVOKE.BC_IfcFile_SetProjectIfcGlobalId(swigCPtr, ifcGuid);
    if (BIMcollab_IfcFilePINVOKE.SWIGPendingException.Pending) throw BIMcollab_IfcFilePINVOKE.SWIGPendingException.Retrieve();
  }

  public string GetSpatialStructureElementIfcGlobalId() {
    string ret = BIMcollab_IfcFilePINVOKE.BC_IfcFile_GetSpatialStructureElementIfcGlobalId(swigCPtr);
    return ret;
  }

  public void SetSpatialStructureElementIfcGlobalId(string ifcGuid) {
    BIMcollab_IfcFilePINVOKE.BC_IfcFile_SetSpatialStructureElementIfcGlobalId(swigCPtr, ifcGuid);
    if (BIMcollab_IfcFilePINVOKE.SWIGPendingException.Pending) throw BIMcollab_IfcFilePINVOKE.SWIGPendingException.Retrieve();
  }

  public bool IsExternal() {
    bool ret = BIMcollab_IfcFilePINVOKE.BC_IfcFile_IsExternal(swigCPtr);
    return ret;
  }

  public void SetExternal(bool isExternal) {
    BIMcollab_IfcFilePINVOKE.BC_IfcFile_SetExternal(swigCPtr, isExternal);
    if (BIMcollab_IfcFilePINVOKE.SWIGPendingException.Pending) throw BIMcollab_IfcFilePINVOKE.SWIGPendingException.Retrieve();
  }

  public BC_IfcFile() : this(BIMcollab_IfcFilePINVOKE.new_BC_IfcFile(), true) {
  }

}