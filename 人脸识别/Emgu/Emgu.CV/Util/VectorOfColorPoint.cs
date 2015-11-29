﻿//----------------------------------------------------------------------------
//
//  Copyright (C) 2004-2015 by EMGU Corporation. All rights reserved.
//
//  Vector of ColorPoint
//
//  This file is automatically generated, do not modify.
//----------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Emgu.CV.Structure;
#if !NETFX_CORE
using System.Runtime.Serialization;
#endif

namespace Emgu.CV.Util
{
   /// <summary>
   /// Wrapped class of the C++ standard vector of ColorPoint.
   /// </summary>
#if !NETFX_CORE
   [Serializable]
   [DebuggerTypeProxy(typeof(VectorOfColorPoint.DebuggerProxy))]
#endif
   public partial class VectorOfColorPoint : Emgu.Util.UnmanagedObject, IInputOutputArray
#if !NETFX_CORE
   , ISerializable
#endif
   {
      private bool _needDispose;
   
      static VectorOfColorPoint()
      {
         CvInvoke.CheckLibraryLoaded();
      }

#if !NETFX_CORE
      /// <summary>
      /// Constructor used to deserialize runtime serialized object
      /// </summary>
      /// <param name="info">The serialization info</param>
      /// <param name="context">The streaming context</param>
      public VectorOfColorPoint(SerializationInfo info, StreamingContext context)
         : this()
      {
         Push((ColorPoint[])info.GetValue("ColorPointArray", typeof(ColorPoint[])));
      }
	  
	  /// <summary>
      /// A function used for runtime serialization of the object
      /// </summary>
      /// <param name="info">Serialization info</param>
      /// <param name="context">Streaming context</param>
      public void GetObjectData(SerializationInfo info, StreamingContext context)
      {
         info.AddValue("ColorPointArray", ToArray());
      }
#endif

      /// <summary>
      /// Create an empty standard vector of ColorPoint
      /// </summary>
      public VectorOfColorPoint()
         : this(VectorOfColorPointCreate(), true)
      {
      }
	  
	  internal VectorOfColorPoint(IntPtr ptr, bool needDispose)
      {
         _ptr = ptr;
         _needDispose = needDispose;
      }

      /// <summary>
      /// Create an standard vector of ColorPoint of the specific size
      /// </summary>
      /// <param name="size">The size of the vector</param>
      public VectorOfColorPoint(int size)
         : this( VectorOfColorPointCreateSize(size), true)
      {
      }
	  
	  /// <summary>
      /// Create an standard vector of ColorPoint with the initial values
      /// </summary>
      /// <param name="values">The initial values</param>
	  public VectorOfColorPoint(ColorPoint[] values)
         :this()
      {
         Push(values);
      }
	  
      /// <summary>
      /// Push an array of value into the standard vector
      /// </summary>
      /// <param name="value">The value to be pushed to the vector</param>
      public void Push(ColorPoint[] value)
      {
         if (value.Length > 0)
         {
            GCHandle handle = GCHandle.Alloc(value, GCHandleType.Pinned);
            VectorOfColorPointPushMulti(_ptr, handle.AddrOfPinnedObject(), value.Length);
            handle.Free();
         }
      }
	  
	  /// <summary>
      /// Convert the standard vector to an array of ColorPoint
      /// </summary>
      /// <returns>An array of ColorPoint</returns>
      public ColorPoint[] ToArray()
      {
         ColorPoint[] res = new ColorPoint[Size];
         if (res.Length > 0)
         {
            GCHandle handle = GCHandle.Alloc(res, GCHandleType.Pinned);
            VectorOfColorPointCopyData(_ptr, handle.AddrOfPinnedObject());
            handle.Free();
         }
         return res;
      }

      /// <summary>
      /// Get the size of the vector
      /// </summary>
      public int Size
      {
         get
         {
            return VectorOfColorPointGetSize(_ptr);
         }
      }

      /// <summary>
      /// Clear the vector
      /// </summary>
      public void Clear()
      {
         VectorOfColorPointClear(_ptr);
      }

      /// <summary>
      /// The pointer to the first element on the vector. In case of an empty vector, IntPtr.Zero will be returned.
      /// </summary>
      public IntPtr StartAddress
      {
         get
         {
            return VectorOfColorPointGetStartAddress(_ptr);
         }
      }
	  
	  /// <summary>
      /// Get the item in the specific index
      /// </summary>
      /// <param name="index">The index</param>
      /// <returns>The item in the specific index</returns>
      public ColorPoint this[int index]
      {
         get
         {
            ColorPoint result = new ColorPoint();
            VectorOfColorPointGetItem(_ptr, index, ref result);
            return result;
         }
      }

      /// <summary>
      /// Release the standard vector
      /// </summary>
      protected override void DisposeObject()
      {
         if (_needDispose && _ptr != IntPtr.Zero)
            VectorOfColorPointRelease(ref _ptr);
      }

	  /// <summary>
      /// Get the pointer to cv::_InputArray
      /// </summary>
      public InputArray GetInputArray()
      {
         return new InputArray( cvInputArrayFromVectorOfColorPoint(_ptr) );
      }
	  
	  /// <summary>
      /// Get the pointer to cv::_OutputArray
      /// </summary>
      public OutputArray GetOutputArray()
      {
         return new OutputArray( cvOutputArrayFromVectorOfColorPoint(_ptr) );
      }

	  /// <summary>
      /// Get the pointer to cv::_InputOutputArray
      /// </summary>
      public InputOutputArray GetInputOutputArray()
      {
         return new InputOutputArray( cvInputOutputArrayFromVectorOfColorPoint(_ptr) );
      }
	  
      internal class DebuggerProxy
      {
         private VectorOfColorPoint _v;

         public DebuggerProxy(VectorOfColorPoint v)
         {
            _v = v;
         }

         public ColorPoint[] Values
         {
            get { return _v.ToArray(); }
         }
      }

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern IntPtr VectorOfColorPointCreate();

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern IntPtr VectorOfColorPointCreateSize(int size);

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern void VectorOfColorPointRelease(ref IntPtr v);

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern int VectorOfColorPointGetSize(IntPtr v);

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern void VectorOfColorPointCopyData(IntPtr v, IntPtr data);

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern IntPtr VectorOfColorPointGetStartAddress(IntPtr v);

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern void VectorOfColorPointPushMulti(IntPtr v, IntPtr values, int count);

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern void VectorOfColorPointClear(IntPtr v);

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern void VectorOfColorPointGetItem(IntPtr vec, int index, ref ColorPoint element);
	  
      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern IntPtr cvInputArrayFromVectorOfColorPoint(IntPtr vec);

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern IntPtr cvOutputArrayFromVectorOfColorPoint(IntPtr vec);

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern IntPtr cvInputOutputArrayFromVectorOfColorPoint(IntPtr vec);
   }
}
