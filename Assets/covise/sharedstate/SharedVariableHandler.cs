using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using covise.serialisation;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace covise.sharedstate
{
    #region Base
    public interface SharedVariableInterface
    {
        public Type getFieldType();

        public TokenBuffer getAsTokenbuffer();
        public void setFromTokenBuffer(TokenBuffer buffer, ref int position);
        
        public void setFromTokenBuffer(TokenBuffer buffer, int position);

    }

    public abstract class SharedVariablePointer<T, V>: SharedVariableInterface
    {
        public T sharedObject;
        public int sharedInstanceID;
        public FieldInfo sharedVariable;

        public SharedVariablePointer(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
        {
            this.sharedObject = sharedObject;
            this.sharedInstanceID = sharedInstanceID;
            this.sharedVariable = sharedVariable;
        }

        public Type getFieldType()
        {
            return sharedVariable.FieldType;
        }

        public abstract TokenBuffer getAsTokenbuffer();

        public abstract void setFromTokenBuffer(TokenBuffer buffer, ref int position);

        public void setFromTokenBuffer(TokenBuffer buffer, int postion = 0)
        {
            setFromTokenBuffer(buffer, ref postion);
        }

        public V getValue()
        {
            if (typeof(V) != sharedVariable.FieldType)
            {
                Debug.LogWarning("Field " + sharedVariable.Name + " of type "+ sharedVariable.FieldType + 
                                 " in Class " + sharedObject.GetType() + " has a shared variable pointer of type " + 
                                 typeof(V) + ". Please ensure that casting is possible !");
            }

            return (V)sharedVariable.GetValue(sharedObject);
        }

        public void setValue(V value)
        {
            if (value.GetType() != sharedVariable.FieldType)
            {
                Debug.LogWarning("Field " + sharedVariable.Name + " of type "+ sharedVariable.FieldType + 
                                 " in Class " + sharedObject.GetType() + " has a shared variable pointer of type " + 
                                 typeof(V) + ". Please ensure that casting is possible !");
            }
            
            sharedVariable.SetValue(sharedObject, value);
        }
    }

    #endregion

    #region Tools
    public class SharedPointerFactory
    {
        //private static Dictionary<Type, ConstructorInfo> pointers = new Dictionary<Type, ConstructorInfo>();
        //FIXME: Dynamic Pointer registration does not work with generics ! (since no any type exists)
        /* public static void registerDefault()
        {
            registerSharedPointerType(typeof(SharedBoolPointer<object>), typeof(bool));
            registerSharedPointerType(typeof(SharedIntPointer<object>), typeof(int));
            registerSharedPointerType(typeof(SharedFloatPointer<object>), typeof(float));
        }

        public static bool registerSharedPointerType(Type sharedPointer, Type fieldType)
        {
            if (pointers.Keys.Contains(fieldType))
            {
                Debug.LogWarning("Overriding Shared Pointer for Type: " + fieldType);
            }

            if (!typeof(SharedVariableInterface).IsAssignableFrom(sharedPointer))
            {
                throw new Exception(sharedPointer + " MUST implement SharedVariableInterface !");
            }

            ConstructorInfo[] infos = sharedPointer.GetConstructors();

            for (int i = 0; i < infos.Length; i++)
            {
                ParameterInfo[] param = infos[i].GetParameters();
                
                if (checkParam(param[1], typeof(int)) && checkParam(param[2], typeof(FieldInfo)))
                {
                    pointers.Add(fieldType, infos[i]);
                    Debug.Log("Registered Pointer " + sharedPointer + " for Type " + fieldType);
                    return true;
                }
            }

            throw new Exception(sharedPointer + " MUST have Constructor with Singnature (Any, int, FieldInfo) !");
        }

        private static bool checkParam(ParameterInfo info, Type type, bool isIn = false, bool isOut = false)
        {
            return info.ParameterType == type && info.IsIn == isIn && info.IsOut == isOut;
        } */

        /// <summary>
        /// Creates a new Shared Variable pointer
        /// </summary>
        /// <param name="sharedObject">Object Instance containing the shared variable</param>
        /// <param name="sharedInstanceID">Instance ID for the shared instance</param>
        /// <param name="sharedVariable">Field to share as a shared object</param>
        /// <typeparam name="T">Type param for the Type of the Object Instance</typeparam>
        /// <returns>The SharedVariableInterface for the given instance and field</returns>
        /// <exception cref="Exception">Thrown when no suitable shared variable pointer is registered for fields with
        /// the type of shared Variable</exception>
        public static SharedVariableInterface createPointer<T>(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
        {
            #region Primitives
            
            if (sharedVariable.FieldType == typeof(bool))
            {
                return new SharedBoolPointer<T>(sharedObject, sharedInstanceID, sharedVariable);
            }
            
            if (sharedVariable.FieldType == typeof(long))
            {
                return new SharedLongPointer<T>(sharedObject, sharedInstanceID, sharedVariable);
            }
            
            if (sharedVariable.FieldType == typeof(ulong))
            {
                return new SharedULongPointer<T>(sharedObject, sharedInstanceID, sharedVariable);
            }
            
            if (sharedVariable.FieldType == typeof(int))
            {
                return new SharedIntPointer<T>(sharedObject, sharedInstanceID, sharedVariable);
            }
            
            if (sharedVariable.FieldType == typeof(uint))
            {
                return new SharedUIntPointer<T>(sharedObject, sharedInstanceID, sharedVariable);
            }
            
            if (sharedVariable.FieldType == typeof(short))
            {
                return new SharedShortPointer<T>(sharedObject, sharedInstanceID, sharedVariable);
            }
            
            if (sharedVariable.FieldType == typeof(ushort))
            {
                return new SharedUShortPointer<T>(sharedObject, sharedInstanceID, sharedVariable);
            }
            
            if (sharedVariable.FieldType == typeof(float))
            {
                return new SharedFloatPointer<T>(sharedObject, sharedInstanceID, sharedVariable);
            }
            
            if (sharedVariable.FieldType == typeof(double))
            {
                return new SharedDoublePointer<T>(sharedObject, sharedInstanceID, sharedVariable);
            }

            if (sharedVariable.FieldType == typeof(string))
            {
                return new SharedStringPointer<T>(sharedObject, sharedInstanceID, sharedVariable);
            }
            
            if (sharedVariable.FieldType == typeof(byte))
            {
                return new SharedBytePointer<T>(sharedObject, sharedInstanceID, sharedVariable);
            }
            
            if (sharedVariable.FieldType == typeof(char))
            {
                return new SharedCharPointer<T>(sharedObject, sharedInstanceID, sharedVariable);
            }
            
            #endregion

            #region Objects

            if (sharedVariable.FieldType == typeof(Vector2))
            {
                return new SharedVector2Pointer<T>(sharedObject, sharedInstanceID, sharedVariable);
            }

            if (sharedVariable.FieldType == typeof(Vector2Int))
            {
                return new SharedVector2IntPointer<T>(sharedObject, sharedInstanceID, sharedVariable);
            }
            
            if (sharedVariable.FieldType == typeof(Vector3))
            {
                return new SharedVector3Pointer<T>(sharedObject, sharedInstanceID, sharedVariable);
            }

            if (sharedVariable.FieldType == typeof(Vector3Int))
            {
                return new SharedVector3IntPointer<T>(sharedObject, sharedInstanceID, sharedVariable);
            }
            
            if (sharedVariable.FieldType == typeof(Vector4))
            {
                return new SharedVector4Pointer<T>(sharedObject, sharedInstanceID, sharedVariable);
            }
            
            if (sharedVariable.FieldType == typeof(Matrix4x4))
            {
                return new SharedMatrix4x4Pointer<T>(sharedObject, sharedInstanceID, sharedVariable);
            }

            if (typeof(IShareable).IsAssignableFrom(sharedVariable.FieldType))
            {
                
            }

            #endregion
            
            /*if (pointers.Keys.Contains(sharedVariable.FieldType))
            {

                return (SharedVariableInterface)pointers[sharedVariable.FieldType].Invoke(new object[] {sharedObject, sharedInstanceID, sharedVariable});
            }
            else
            {
                throw new Exception("Could not find a SharedPointer for the FieldType " + sharedVariable.FieldType + " at Field " + sharedVariable.Name + " in Type " + typeof(T));
            }*/
            
            throw new Exception("Could not find a SharedPointer for the FieldType " + sharedVariable.FieldType + " at Field " + sharedVariable.Name + " in Type " + typeof(T));
        }
    }
    
    #endregion
    
    #region Implementations

    #region Primitives

    public class SharedBoolPointer<T> : SharedVariablePointer<T, bool>
    {
        public SharedBoolPointer(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
            : base(sharedObject, sharedInstanceID, sharedVariable)
        {
        }

        public override TokenBuffer getAsTokenbuffer()
        {
            TokenBuffer buffer = new TokenBuffer();
            buffer.append(getValue());
            return buffer;
        }

        public override void setFromTokenBuffer(TokenBuffer buffer, ref int position)
        {
            bool value = buffer.getBool(ref position);
            setValue(value);
        }
    }
    
    public class SharedLongPointer<T> : SharedVariablePointer<T, long>
    {
        public SharedLongPointer(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
            : base(sharedObject, sharedInstanceID, sharedVariable)
        {
        }
        
        public override TokenBuffer getAsTokenbuffer()
        {
            TokenBuffer buffer = new TokenBuffer();
            buffer.append(getValue());
            return buffer;
        }

        public override void setFromTokenBuffer(TokenBuffer buffer, ref int position)
        {
            long value = buffer.getLong(ref position);
            setValue(value);
        }
    }
    
    public class SharedULongPointer<T> : SharedVariablePointer<T, ulong>
    {
        public SharedULongPointer(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
            : base(sharedObject, sharedInstanceID, sharedVariable)
        {
        }
        
        public override TokenBuffer getAsTokenbuffer()
        {
            TokenBuffer buffer = new TokenBuffer();
            buffer.append(getValue());
            return buffer;
        }

        public override void setFromTokenBuffer(TokenBuffer buffer, ref int position)
        {
            ulong value = buffer.getULong(ref position);
            setValue(value);
        }
    }
    
    public class SharedIntPointer<T> : SharedVariablePointer<T, int>
    {
        public SharedIntPointer(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
            : base(sharedObject, sharedInstanceID, sharedVariable)
        {
        }
        
        public override TokenBuffer getAsTokenbuffer()
        {
            TokenBuffer buffer = new TokenBuffer();
            buffer.append(getValue());
            return buffer;
        }

        public override void setFromTokenBuffer(TokenBuffer buffer, ref int position)
        {
            int value = buffer.getInt(ref position);
            setValue(value);
        }
    }
    
    public class SharedUIntPointer<T> : SharedVariablePointer<T, uint>
    {
        public SharedUIntPointer(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
            : base(sharedObject, sharedInstanceID, sharedVariable)
        {
        }
        
        public override TokenBuffer getAsTokenbuffer()
        {
            TokenBuffer buffer = new TokenBuffer();
            buffer.append(getValue());
            return buffer;
        }

        public override void setFromTokenBuffer(TokenBuffer buffer, ref int position)
        {
            uint value = buffer.getUInt(ref position);
            setValue(value);
        }
    }
    
    public class SharedShortPointer<T> : SharedVariablePointer<T, short>
    {
        public SharedShortPointer(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
            : base(sharedObject, sharedInstanceID, sharedVariable)
        {
        }
        
        public override TokenBuffer getAsTokenbuffer()
        {
            TokenBuffer buffer = new TokenBuffer();
            buffer.append(getValue());
            return buffer;
        }

        public override void setFromTokenBuffer(TokenBuffer buffer, ref int position)
        {
            short value = (short)buffer.getInt(ref position);
            setValue(value);
        }
    }
    
    public class SharedUShortPointer<T> : SharedVariablePointer<T, ushort>
    {
        public SharedUShortPointer(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
            : base(sharedObject, sharedInstanceID, sharedVariable)
        {
        }
        
        public override TokenBuffer getAsTokenbuffer()
        {
            TokenBuffer buffer = new TokenBuffer();
            buffer.append(getValue());
            return buffer;
        }

        public override void setFromTokenBuffer(TokenBuffer buffer, ref int position)
        {
            ushort value = (ushort)buffer.getUInt(ref position);
            setValue(value);
        }
    }
    
    public class SharedFloatPointer<T> : SharedVariablePointer<T, float>
    {
        public SharedFloatPointer(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
            : base(sharedObject, sharedInstanceID, sharedVariable)
        {
        }
        
        public override TokenBuffer getAsTokenbuffer()
        {
            TokenBuffer buffer = new TokenBuffer();
            buffer.append(getValue());
            return buffer;
        }

        public override void setFromTokenBuffer(TokenBuffer buffer, ref int position)
        {
            float value = buffer.getFloat(ref position);
            setValue(value);
        }
    }
    
    public class SharedDoublePointer<T> : SharedVariablePointer<T, double>
    {
        public SharedDoublePointer(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
            : base(sharedObject, sharedInstanceID, sharedVariable)
        {
        }
        
        public override TokenBuffer getAsTokenbuffer()
        {
            TokenBuffer buffer = new TokenBuffer();
            buffer.append(getValue());
            return buffer;
        }

        public override void setFromTokenBuffer(TokenBuffer buffer, ref int position)
        {
            double value = buffer.getDouble(ref position);
            setValue(value);
        }
    }
    
    public class SharedStringPointer<T> : SharedVariablePointer<T, string>
    {
        public SharedStringPointer(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
            : base(sharedObject, sharedInstanceID, sharedVariable)
        {
        }
        
        public override TokenBuffer getAsTokenbuffer()
        {
            TokenBuffer buffer = new TokenBuffer();
            buffer.append(getValue());
            return buffer;
        }

        public override void setFromTokenBuffer(TokenBuffer buffer, ref int position)
        {
            string value = buffer.getString(ref position);
            setValue(value);
        }
    }
    
    public class SharedBytePointer<T> : SharedVariablePointer<T, byte>
    {
        public SharedBytePointer(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
            : base(sharedObject, sharedInstanceID, sharedVariable)
        {
        }
        
        public override TokenBuffer getAsTokenbuffer()
        {
            TokenBuffer buffer = new TokenBuffer();
            buffer.append(getValue());
            return buffer;
        }

        public override void setFromTokenBuffer(TokenBuffer buffer, ref int position)
        {
            byte value = buffer.getByte(ref position);
            setValue(value);
        }
    }

    public class SharedCharPointer<T> : SharedVariablePointer<T, char>
    {
        public SharedCharPointer(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
            : base(sharedObject, sharedInstanceID, sharedVariable)
        {
        }
        
        public override TokenBuffer getAsTokenbuffer()
        {
            TokenBuffer buffer = new TokenBuffer();
            buffer.append(getValue());
            return buffer;
        }

        public override void setFromTokenBuffer(TokenBuffer buffer, ref int position)
        {
            char value = buffer.getChar(ref position);
            setValue(value);
        }
    }
    
    #endregion

    #region Objects
    
    public class SharedVector2Pointer<T> : SharedVariablePointer<T, Vector2>
    {
        public SharedVector2Pointer(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
            : base(sharedObject, sharedInstanceID, sharedVariable)
        {
        }
        
        public override TokenBuffer getAsTokenbuffer()
        {
            TokenBuffer buffer = new TokenBuffer();
            Vector2 value = getValue();
            buffer.append(value.x);
            buffer.append(value.y);
            return buffer;
        }

        public override void setFromTokenBuffer(TokenBuffer buffer, ref int position)
        {
            float x = buffer.getFloat(ref position);
            float y = buffer.getFloat(ref position);
            setValue(new Vector2(x, y));
        }
    }

    public class SharedVector2IntPointer<T> : SharedVariablePointer<T, Vector2Int>
    {
        public SharedVector2IntPointer(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
            : base(sharedObject, sharedInstanceID, sharedVariable)
        {
        }
        
        public override TokenBuffer getAsTokenbuffer()
        {
            TokenBuffer buffer = new TokenBuffer();
            Vector2Int value = getValue();
            buffer.append(value.x);
            buffer.append(value.y);
            return buffer;
        }

        public override void setFromTokenBuffer(TokenBuffer buffer, ref int position)
        {
            int x = buffer.getInt(ref position);
            int y = buffer.getInt(ref position);
            setValue(new Vector2Int(x, y));
        }
    }
    
    public class SharedVector3Pointer<T> : SharedVariablePointer<T, Vector3>
    {
        public SharedVector3Pointer(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
            : base(sharedObject, sharedInstanceID, sharedVariable)
        {
        }
        
        public override TokenBuffer getAsTokenbuffer()
        {
            TokenBuffer buffer = new TokenBuffer();
            Vector3 value = getValue();
            buffer.append(value.x);
            buffer.append(value.y);
            buffer.append(value.z);
            return buffer;
        }

        public override void setFromTokenBuffer(TokenBuffer buffer, ref int position)
        {
            float x = buffer.getFloat(ref position);
            float y = buffer.getFloat(ref position);
            float z = buffer.getFloat(ref position);
            setValue(new Vector3(x, y, z));
        }
    }

    public class SharedVector3IntPointer<T> : SharedVariablePointer<T, Vector3Int>
    {
        public SharedVector3IntPointer(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
            : base(sharedObject, sharedInstanceID, sharedVariable)
        {
        }
        
        public override TokenBuffer getAsTokenbuffer()
        {
            TokenBuffer buffer = new TokenBuffer();
            Vector3Int value = getValue();
            buffer.append(value.x);
            buffer.append(value.y);
            buffer.append(value.z);
            return buffer;
        }

        public override void setFromTokenBuffer(TokenBuffer buffer, ref int position)
        {
            int x = buffer.getInt(ref position);
            int y = buffer.getInt(ref position);
            int z = buffer.getInt(ref position);
            setValue(new Vector3Int(x, y, z));
        }
    }

    public class SharedVector4Pointer<T> : SharedVariablePointer<T, Vector4>
    {
        public SharedVector4Pointer(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
            : base(sharedObject, sharedInstanceID, sharedVariable)
        {
        }
        
        public override TokenBuffer getAsTokenbuffer()
        {
            TokenBuffer buffer = new TokenBuffer();
            Vector4 value = getValue();
            buffer.append(value.x);
            buffer.append(value.y);
            buffer.append(value.z);
            buffer.append(value.w);
            return buffer;
        }

        public override void setFromTokenBuffer(TokenBuffer buffer, ref int position)
        {
            float x = buffer.getFloat(ref position);
            float y = buffer.getFloat(ref position);
            float z = buffer.getFloat(ref position);
            float w = buffer.getFloat(ref position);
            setValue(new Vector4(x, y, z, w));
        }
    }
    
    public class SharedMatrix4x4Pointer<T> : SharedVariablePointer<T, Matrix4x4>
    {
        public SharedMatrix4x4Pointer(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
            : base(sharedObject, sharedInstanceID, sharedVariable)
        {
        }

        public override TokenBuffer getAsTokenbuffer()
        {
            TokenBuffer buffer = new TokenBuffer();
            Matrix4x4 value = getValue();
            buffer.append(value.m00);
            buffer.append(value.m01);
            buffer.append(value.m02);
            buffer.append(value.m03);
            buffer.append(value.m10);
            buffer.append(value.m11);
            buffer.append(value.m12);
            buffer.append(value.m13);
            buffer.append(value.m20);
            buffer.append(value.m21);
            buffer.append(value.m22);
            buffer.append(value.m23);
            buffer.append(value.m30);
            buffer.append(value.m31);
            buffer.append(value.m32);
            buffer.append(value.m33);
            return buffer;
        }

        public override void setFromTokenBuffer(TokenBuffer buffer, ref int position)
        {
            float[] m = new float[16];

            for (int i = 0; i < 16; i++)
            {
                m[i] = buffer.getFloat(ref position);
            }
            
            setValue(new Matrix4x4(new Vector4(m[0], m[1], m[2], m[3]),
                new Vector4(m[4], m[5], m[6], m[7]),
                new Vector4(m[8], m[9], m[10], m[11]),
                new Vector4(m[12], m[13], m[14], m[15])));
        }
    }
    
    public class SharedShareablePointer<T> : SharedVariablePointer<T, IShareable>
    {
        public SharedShareablePointer(T sharedObject, int sharedInstanceID, FieldInfo sharedVariable)
            : base(sharedObject, sharedInstanceID, sharedVariable)
        {
        }
        
        public override TokenBuffer getAsTokenbuffer()
        {
            TokenBuffer buffer = new TokenBuffer();
            getValue().serialize(buffer);
            return buffer;
        }

        public override void setFromTokenBuffer(TokenBuffer buffer, ref int position)
        {
            getValue().deserialize(buffer, ref position);
        }
    }
    
    #endregion
    
    #endregion
}