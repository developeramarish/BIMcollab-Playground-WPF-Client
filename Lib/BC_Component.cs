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


internal class BC_Component : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal BC_Component(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(BC_Component obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~BC_Component() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          BIMcollab_ComponentPINVOKE.delete_BC_Component(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public string GetIfcGlobalId() {
    string ret = BIMcollab_ComponentPINVOKE.BC_Component_GetIfcGlobalId(swigCPtr);
    return ret;
  }

  public string GetColor() {
    string ret = BIMcollab_ComponentPINVOKE.BC_Component_GetColor(swigCPtr);
    return ret;
  }

  public void SetColor(string color) {
    BIMcollab_ComponentPINVOKE.BC_Component_SetColor(swigCPtr, color);
    if (BIMcollab_ComponentPINVOKE.SWIGPendingException.Pending) throw BIMcollab_ComponentPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool IsSelected() {
    bool ret = BIMcollab_ComponentPINVOKE.BC_Component_IsSelected(swigCPtr);
    return ret;
  }

  public void SetSelected(bool select) {
    BIMcollab_ComponentPINVOKE.BC_Component_SetSelected(swigCPtr, select);
  }

  public bool IsVisible() {
    bool ret = BIMcollab_ComponentPINVOKE.BC_Component_IsVisible(swigCPtr);
    return ret;
  }

  public void SetVisible(bool visible) {
    BIMcollab_ComponentPINVOKE.BC_Component_SetVisible(swigCPtr, visible);
  }

  public BC_Component() : this(BIMcollab_ComponentPINVOKE.new_BC_Component(), true) {
  }

}