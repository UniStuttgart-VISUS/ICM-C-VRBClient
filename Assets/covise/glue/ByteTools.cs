using System;
using System.Collections.Generic;
using System.Text;

namespace covise.glue
{
    public class ByteTools
    {
        public static readonly Encoding DEFAULT_ENCODING = new ASCIIEncoding();
        
        #region ByteArray Tools

        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">bytes to put into the array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putData(ref byte[] data, byte[] value, int start = 0, bool swapped=false)
        {
            if (data.Length < start + value.Length)
            {
                throw new ArgumentException("Not enough space in data for value !");
            }
            
            for (int i = 0; i < value.Length; i++)
            {
                data[i + start] = value[swapped ? value.Length - (i + 1) : i];
            }
        }
        
        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref byte[] data, bool value, int start = 0, bool swapped=false)
        {
            putData(ref data, BitConverter.GetBytes(value), start, swapped);
        }

        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref byte[] data, char value, int start = 0, bool swapped=false)
        {
            putData(ref data, BitConverter.GetBytes(value), start, swapped);
        }
        
        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref byte[] data, short value, int start = 0, bool swapped=false)
        {
            putData(ref data, BitConverter.GetBytes(value), start, swapped);
        }
        
        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref byte[] data, int value, int start = 0, bool swapped=false)
        {
            putData(ref data, BitConverter.GetBytes(value), start, swapped);
        }
        
        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref byte[] data, long value, int start = 0, bool swapped=false)
        {
            putData(ref data, BitConverter.GetBytes(value), start, swapped);
        }
        
        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref byte[] data, ushort value, int start = 0, bool swapped=false)
        {
            putData(ref data, BitConverter.GetBytes(value), start, swapped);
        }
        
        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref byte[] data, uint value, int start = 0, bool swapped=false)
        {
            putData(ref data, BitConverter.GetBytes(value), start, swapped);
        }
        
        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref byte[] data, ulong value, int start = 0, bool swapped=false)
        {
            putData(ref data, BitConverter.GetBytes(value), start, swapped);
        }
        
        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref byte[] data, float value, int start = 0, bool swapped=false)
        {
            putData(ref data, BitConverter.GetBytes(value), start, swapped);
        }
        
        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref byte[] data, double value, int start = 0, bool swapped=false)
        {
            putData(ref data, BitConverter.GetBytes(value), start, swapped);
        }

        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref byte[] data, string value, int start = 0, bool swapped = false, 
            Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = DEFAULT_ENCODING;
            }

            byte[] buffer = new byte[encoding.GetByteCount(value)+1];
            encoding.GetBytes(value).CopyTo(buffer, 0);
            buffer[buffer.Length - 1] = 0;

            putData(ref data, buffer, start, swapped);
        }

        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">bytes to put into the array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putData(ref List<byte> data, byte[] value, int start = 0, bool swapped=false)
        {
            if (start >= 0 && data.Count < start + value.Length)
            {
                for (int i = 0; i < value.Length; i++)
                {
                    data.Insert(i + start, value[swapped ? value.Length - (i + 1) : i]);
                }
            }
            else
            {
                for (int i = 0; i < value.Length; i++)
                {
                    data.Add(value[swapped ? value.Length - (i + 1) : i]);
                }
            }
        }
        
        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref List<byte> data, bool value, int start = 0, bool swapped=false)
        {
            putData(ref data, BitConverter.GetBytes(value), start, swapped);
        }

        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref List<byte> data, char value, int start = 0, bool swapped=false)
        {
            putData(ref data, BitConverter.GetBytes(value), start, swapped);
        }
        
        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref List<byte> data, short value, int start = 0, bool swapped=false)
        {
            putData(ref data, BitConverter.GetBytes(value), start, swapped);
        }
        
        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref List<byte> data, int value, int start = 0, bool swapped=false)
        {
            putData(ref data, BitConverter.GetBytes(value), start, swapped);
        }
        
        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref List<byte> data, long value, int start = 0, bool swapped=false)
        {
            putData(ref data, BitConverter.GetBytes(value), start, swapped);
        }
        
        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref List<byte> data, ushort value, int start = 0, bool swapped=false)
        {
            putData(ref data, BitConverter.GetBytes(value), start, swapped);
        }
        
        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref List<byte> data, uint value, int start = 0, bool swapped=false)
        {
            putData(ref data, BitConverter.GetBytes(value), start, swapped);
        }
        
        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref List<byte> data, ulong value, int start = 0, bool swapped=false)
        {
            putData(ref data, BitConverter.GetBytes(value), start, swapped);
        }
        
        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref List<byte> data, float value, int start = 0, bool swapped=false)
        {
            putData(ref data, BitConverter.GetBytes(value), start, swapped);
        }
        
        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref List<byte> data, double value, int start = 0, bool swapped=false)
        {
            putData(ref data, BitConverter.GetBytes(value), start, swapped);
        }

        /// <summary>
        /// Puts the value into the bytearray
        /// </summary>
        /// <param name="data">ByteArray to put data into</param>
        /// <param name="value">value to put into the byte array</param>
        /// <param name="start">first position of data to put the value into</param>
        /// <param name="swapped">if True, swap order of value before copying value into data</param>
        /// <exception cref="ArgumentException">if value length + start exceed data length</exception>
        public static void putValue(ref List<byte> data, string value, int start = 0, bool swapped = false, 
            Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = DEFAULT_ENCODING;
            }

            byte[] buffer = new byte[encoding.GetByteCount(value)+1];
            encoding.GetBytes(value).CopyTo(buffer, 0);
            buffer[buffer.Length - 1] = 0;

            putData(ref data, buffer, start, swapped);
        }
        
        /// <summary>
        /// Gets a value from the data array
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="count">Number of bytes to get</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <param name="encoding">Encoding to use for converting bytes to string</param>
        /// <returns>the requested data in the requested order</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static byte[] getData(ref byte[] data, int count, int start = 0, bool swapped=false)
        {
            byte[] value = new byte[count];
            
            if (data.Length < start + count)
            {
                throw new ArgumentException("Not enough space in data for value !");
            }
            
            for (int i = 0; i < value.Length; i++)
            {
                value[swapped ? value.Length - (i + 1) : i] = data[i + start];
            }

            return value;
        }
        
        /// <summary>
        /// Reads a bool from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read bool value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static bool getBool(ref byte[] data, int start = 0, bool swapped=false)
        {
            return BitConverter.ToBoolean(getData(ref data, 1, start, swapped), 0);
        }

        /// <summary>
        /// Reads a char from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read char value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static char getChar(ref byte[] data, int start = 0, bool swapped=false)
        {
            return BitConverter.ToChar(getData(ref data, 1, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a short (Int16) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read Int16 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static short getShort(ref byte[] data, int start = 0, bool swapped=false)
        {
            return BitConverter.ToInt16(getData(ref data, 2, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a int (Int32) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read Int32 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static int getInt(ref byte[] data, int start = 0, bool swapped=false)
        {
            return BitConverter.ToInt32(getData(ref data, 4, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a long (Int64) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read Int64 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static long getLong(ref byte[] data, int start = 0, bool swapped=false)
        {
            return BitConverter.ToInt64(getData(ref data, 8, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a ushort (UInt16) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read UInt16 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static ushort getUShort(ref byte[] data, int start = 0, bool swapped=false)
        {
            return BitConverter.ToUInt16(getData(ref data, 2, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a uint (UInt32) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read UInt32 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static uint getUInt(ref byte[] data, int start = 0, bool swapped=false)
        {
            return BitConverter.ToUInt32(getData(ref data, 4, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a ulong (UInt64) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read UInt64 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static ulong getULong(ref byte[] data, int start = 0, bool swapped=false)
        {
            return BitConverter.ToUInt64(getData(ref data, 8, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a float (Single) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read single value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static float getFloat(ref byte[] data, int start = 0, bool swapped=false)
        {
            return BitConverter.ToSingle(getData(ref data, 4, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a double from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read double value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static double getDouble(ref byte[] data, int start = 0, bool swapped=false)
        {
            return BitConverter.ToDouble(getData(ref data, 8, start, swapped), 0);
        }

        /// <summary>
        /// Reads a string from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <param name="encoding">Encoding to use for converting bytes to string</param>
        /// <returns>the read string value</returns>
        public static string getString(ref byte[] data, int start = 0, bool swapped = false, 
            Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = DEFAULT_ENCODING;
            }
            
            int bytecount = 0;

            while ((start + bytecount) < data.Length)
            {
                if (data[start + bytecount] == 0)
                {
                    break;
                }

                bytecount++;
            }

            byte[] slice = getData(ref data, bytecount, start, swapped);

            return encoding.GetString(slice);
        }
        
        /// <summary>
        /// Gets a value from the data array
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="count">Number of bytes to get</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <param name="encoding">Encoding to use for converting bytes to string</param>
        /// <returns>the requested data in the requested order</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static byte[] getData(ref byte[] data, int count, uint start = 0, bool swapped=false)
        {
            return getData(ref data, count, (int) start, swapped);
        }
        
        /// <summary>
        /// Reads a bool from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read bool value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static bool getBool(ref byte[] data, uint start = 0, bool swapped=false)
        {
            return BitConverter.ToBoolean(getData(ref data, 1, start, swapped), 0);
        }

        /// <summary>
        /// Reads a char from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read char value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static char getChar(ref byte[] data, uint start = 0, bool swapped=false)
        {
            return BitConverter.ToChar(getData(ref data, 1, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a short (Int16) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read Int16 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static short getShort(ref byte[] data, uint start = 0, bool swapped=false)
        {
            return BitConverter.ToInt16(getData(ref data, 2, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a int (Int32) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read Int32 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static int getInt(ref byte[] data, uint start = 0, bool swapped=false)
        {
            return BitConverter.ToInt32(getData(ref data, 4, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a long (Int64) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read Int64 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static long getLong(ref byte[] data, uint start = 0, bool swapped=false)
        {
            return BitConverter.ToInt64(getData(ref data, 8, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a ushort (UInt16) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read UInt16 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static ushort getUShort(ref byte[] data, uint start = 0, bool swapped=false)
        {
            return BitConverter.ToUInt16(getData(ref data, 2, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a uint (UInt32) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read UInt32 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static uint getUInt(ref byte[] data, uint start = 0, bool swapped=false)
        {
            return BitConverter.ToUInt32(getData(ref data, 4, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a ulong (UInt64) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read UInt64 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static ulong getULong(ref byte[] data, uint start = 0, bool swapped=false)
        {
            return BitConverter.ToUInt64(getData(ref data, 8, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a float (Single) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read single value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static float getFloat(ref byte[] data, uint start = 0, bool swapped=false)
        {
            return BitConverter.ToSingle(getData(ref data, 4, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a double from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read double value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static double getDouble(ref byte[] data, uint start = 0, bool swapped=false)
        {
            return BitConverter.ToDouble(getData(ref data, 8, start, swapped), 0);
        }

        /// <summary>
        /// Reads a string from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <param name="encoding">Encoding to use for converting bytes to string</param>
        /// <returns>the read string value</returns>
        public static string getString(ref byte[] data, uint start = 0, bool swapped = false, 
            Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = DEFAULT_ENCODING;
            }
            
            int bytecount = 0;

            while ((start + bytecount) < data.Length)
            {
                if (data[start + bytecount] == 0)
                {
                    break;
                }

                bytecount++;
            }

            byte[] slice = getData(ref data, bytecount, start, swapped);

            return encoding.GetString(slice);
        }

        #region Byte List Getters

                /// <summary>
        /// Gets a value from the data array
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="count">Number of bytes to get</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <param name="encoding">Encoding to use for converting bytes to string</param>
        /// <returns>the requested data in the requested order</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static byte[] getData(ref List<byte> data, int count, int start = 0, bool swapped=false)
        {
            byte[] value = new byte[count];
            
            if (data.Count < start + count)
            {
                throw new ArgumentException("Not enough space in data for value !");
            }
            
            for (int i = 0; i < value.Length; i++)
            {
                value[swapped ? value.Length - (i + 1) : i] = data[i + start];
            }

            return value;
        }
        
        /// <summary>
        /// Reads a bool from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read bool value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static bool getBool(ref List<byte> data, int start = 0, bool swapped=false)
        {
            return BitConverter.ToBoolean(getData(ref data, 1, start, swapped), 0);
        }

        /// <summary>
        /// Reads a char from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read char value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static char getChar(ref List<byte> data, int start = 0, bool swapped=false)
        {
            return BitConverter.ToChar(getData(ref data, 1, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a short (Int16) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read Int16 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static short getShort(ref List<byte> data, int start = 0, bool swapped=false)
        {
            return BitConverter.ToInt16(getData(ref data, 2, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a int (Int32) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read Int32 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static int getInt(ref List<byte> data, int start = 0, bool swapped=false)
        {
            return BitConverter.ToInt32(getData(ref data, 4, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a long (Int64) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read Int64 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static long getLong(ref List<byte> data, int start = 0, bool swapped=false)
        {
            return BitConverter.ToInt64(getData(ref data, 8, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a ushort (UInt16) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read UInt16 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static ushort getUShort(ref List<byte> data, int start = 0, bool swapped=false)
        {
            return BitConverter.ToUInt16(getData(ref data, 2, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a uint (UInt32) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read UInt32 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static uint getUInt(ref List<byte> data, int start = 0, bool swapped=false)
        {
            return BitConverter.ToUInt32(getData(ref data, 4, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a ulong (UInt64) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read UInt64 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static ulong getULong(ref List<byte> data, int start = 0, bool swapped=false)
        {
            return BitConverter.ToUInt64(getData(ref data, 8, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a float (Single) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read single value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static float getFloat(ref List<byte> data, int start = 0, bool swapped=false)
        {
            return BitConverter.ToSingle(getData(ref data, 4, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a double from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read double value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static double getDouble(ref List<byte> data, int start = 0, bool swapped=false)
        {
            return BitConverter.ToDouble(getData(ref data, 8, start, swapped), 0);
        }

        /// <summary>
        /// Reads a string from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <param name="encoding">Encoding to use for converting bytes to string</param>
        /// <returns>the read string value</returns>
        public static string getString(ref List<byte> data, int start = 0, bool swapped = false, 
            Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = DEFAULT_ENCODING;
            }
            
            int bytecount = 0;

            while ((start + bytecount) < data.Count)
            {
                if (data[start + bytecount] == 0)
                {
                    break;
                }

                bytecount++;
            }

            byte[] slice = getData(ref data, bytecount, start, swapped);

            return encoding.GetString(slice);
        }
        
        /// <summary>
        /// Reads a string from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <param name="encoding">Encoding to use for converting bytes to string</param>
        /// <returns>the read string value</returns>
        public static string getString(ref List<byte> data, out int bytesRead, int start = 0, bool swapped = false, 
            Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = DEFAULT_ENCODING;
            }
            
            int bytecount = 0;

            while ((start + bytecount) < data.Count)
            {
                if (data[start + bytecount] == 0)
                {
                    break;
                }

                bytecount++;
            }

            byte[] slice = getData(ref data, bytecount, start, swapped);

            bytesRead = slice.Length + 1;
            return encoding.GetString(slice);
        }
        
        /// <summary>
        /// Gets a value from the data array
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="count">Number of bytes to get</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <param name="encoding">Encoding to use for converting bytes to string</param>
        /// <returns>the requested data in the requested order</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static byte[] getData(ref List<byte> data, int count, uint start = 0, bool swapped=false)
        {
            return getData(ref data, count, (int) start, swapped);
        }
        
        /// <summary>
        /// Reads a bool from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read bool value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static bool getBool(ref List<byte> data, uint start = 0, bool swapped=false)
        {
            return BitConverter.ToBoolean(getData(ref data, 1, start, swapped), 0);
        }

        /// <summary>
        /// Reads a char from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read char value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static char getChar(ref List<byte> data, uint start = 0, bool swapped=false)
        {
            return BitConverter.ToChar(getData(ref data, 1, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a short (Int16) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read Int16 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static short getShort(ref List<byte> data, uint start = 0, bool swapped=false)
        {
            return BitConverter.ToInt16(getData(ref data, 2, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a int (Int32) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read Int32 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static int getInt(ref List<byte> data, uint start = 0, bool swapped=false)
        {
            return BitConverter.ToInt32(getData(ref data, 4, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a long (Int64) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read Int64 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static long getLong(ref List<byte> data, uint start = 0, bool swapped=false)
        {
            return BitConverter.ToInt64(getData(ref data, 8, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a ushort (UInt16) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read UInt16 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static ushort getUShort(ref List<byte> data, uint start = 0, bool swapped=false)
        {
            return BitConverter.ToUInt16(getData(ref data, 2, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a uint (UInt32) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read UInt32 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static uint getUInt(ref List<byte> data, uint start = 0, bool swapped=false)
        {
            return BitConverter.ToUInt32(getData(ref data, 4, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a ulong (UInt64) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read UInt64 value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static ulong getULong(ref List<byte> data, uint start = 0, bool swapped=false)
        {
            return BitConverter.ToUInt64(getData(ref data, 8, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a float (Single) from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read single value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static float getFloat(ref List<byte> data, uint start = 0, bool swapped=false)
        {
            return BitConverter.ToSingle(getData(ref data, 4, start, swapped), 0);
        }
        
        /// <summary>
        /// Reads a double from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <returns>the read double value</returns>
        /// <exception cref="ArgumentException">if count + start exceed data length</exception>
        public static double getDouble(ref List<byte> data, uint start = 0, bool swapped=false)
        {
            return BitConverter.ToDouble(getData(ref data, 8, start, swapped), 0);
        }

        /// <summary>
        /// Reads a string from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <param name="encoding">Encoding to use for converting bytes to string</param>
        /// <returns>the read string value</returns>
        public static string getString(ref List<byte> data, uint start = 0, bool swapped = false, 
            Encoding encoding = null)
        {
            return getString(ref data, (int)start, swapped, encoding);
        }

        /// <summary>
        /// Reads a string from the given data at the specified position
        /// </summary>
        /// <param name="data">Byte Array to get data from</param>
        /// <param name="start">Start byte of the data</param>
        /// <param name="swapped">if True, swap order of data before copying data into value</param>
        /// <param name="encoding">Encoding to use for converting bytes to string</param>
        /// <returns>the read string value</returns>
        public static string getString(ref List<byte> data, out int bytesRead, uint start = 0, bool swapped = false, 
            Encoding encoding = null)
        {
            return getString(ref data, out bytesRead, (int)start, swapped, encoding);
        }
        
        #endregion
        
        #endregion
        
    }
}