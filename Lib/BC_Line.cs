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


internal class BC_Line : BC_ControllableData {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal BC_Line(global::System.IntPtr cPtr, bool cMemoryOwn) : base(BIMcollab_LinePINVOKE.BC_Line_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(BC_Line obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~BC_Line() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          BIMcollab_LinePINVOKE.delete_BC_Line(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public BC_Line(BC_3DPoint startPoint, BC_3DPoint endPoint) : this(BIMcollab_LinePINVOKE.new_BC_Line(BC_3DPoint.getCPtr(startPoint), BC_3DPoint.getCPtr(endPoint)), true) {
    if (BIMcollab_LinePINVOKE.SWIGPendingException.Pending) throw BIMcollab_LinePINVOKE.SWIGPendingException.Retrieve();
  }

  public BC_3DPoint GetStartPoint() {
    global::System.IntPtr cPtr = BIMcollab_LinePINVOKE.BC_Line_GetStartPoint(swigCPtr);
    BC_3DPoint ret = (cPtr == global::System.IntPtr.Zero) ? null : new BC_3DPoint(cPtr, false);
    return ret;
  }

  public BC_3DPoint GetEndPoint() {
    global::System.IntPtr cPtr = BIMcollab_LinePINVOKE.BC_Line_GetEndPoint(swigCPtr);
    BC_3DPoint ret = (cPtr == global::System.IntPtr.Zero) ? null : new BC_3DPoint(cPtr, false);
    return ret;
  }

}