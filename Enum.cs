using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class Enum<T> : IComparable, IComparable<T>, IFormattable
        where T : struct, IComparable, IFormattable, IConvertible
    {
        private readonly T wrappedEnum;

        public Enum(T immutableEnumValue)
        {
            this.wrappedEnum = immutableEnumValue;
        }

        public T Base
        {
            get
            {
                return wrappedEnum;
            }
        }

        #region static methods overriden

        [ComVisibleAttribute(true)]
        public static string Format(object value, string format)
        {
            return Enum.Format(typeof(T), value, format);
        }

        [ComVisibleAttribute(true)]
        public static string GetName(object value)
        {
            return Enum.GetName(typeof(T), value);
        }

        [ComVisibleAttribute(true)]
        public static string[] GetNames()
        {
            return Enum.GetNames(typeof(T));
        }

        [ComVisibleAttribute(true)]
        public static Type GetUnderlyingType()
        {
            return Enum.GetUnderlyingType(typeof(T));
        }

        [ComVisibleAttribute(true)]
        public static IEnumerable<T> GetValues()
        {
            return Enum.GetValues(typeof(T)).OfType<T>();
        }

        [ComVisibleAttribute(true)]
        public static bool IsDefined(object value)
        {
            return Enum.IsDefined(typeof(T), value);
        }

        [ComVisibleAttribute(true)]
        public static object Parse(string value, bool ignoreCase = false)
        {
            return Enum.Parse(typeof(T), value, ignoreCase);
        }

        public static bool TryParse(string value, out T result)
        {
            return Enum.TryParse<T>(value, out result);
        }

        public static bool TryParse(string value, bool ignoreCase, out T result)
        {
            return Enum.TryParse<T>(value, ignoreCase, out result);
        }

        #region ToObject

        [ComVisibleAttribute(true)]
        public static T ToObject(byte value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }

        [ComVisibleAttribute(true)]
        public static T ToObject(Int16 value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }

        [ComVisibleAttribute(true)]
        public static T ToObject(Int32 value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }

        [ComVisibleAttribute(true)]
        public static T ToObject(Int64 value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }

        [ComVisibleAttribute(true)]
        public static T ToObject(object value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }

        [ComVisibleAttribute(true)]
        public static T ToObject(SByte value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }

        [ComVisibleAttribute(true)]
        public static T ToObject(UInt16 value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }

        [ComVisibleAttribute(true)]
        public static T ToObject(UInt32 value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }

        [ComVisibleAttribute(true)]
        public static T ToObject(UInt64 value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }

        #endregion

        #endregion

        public int CompareTo(object obj)
        {
            return ((IComparable)wrappedEnum).CompareTo(obj);
        }

        public int CompareTo(T other)
        {
            return ((IComparable)wrappedEnum).CompareTo(other);
        }

        public override bool Equals(object obj)
        {
            return wrappedEnum.Equals(obj);
        }

        public bool Equals(T obj)
        {
            return wrappedEnum.Equals(obj);
        }

        public override int GetHashCode()
        {
            return wrappedEnum.GetHashCode();
        }

        public override string ToString()
        {
            return wrappedEnum.ToString();
        }

        public string ToString(IFormatProvider formatProvider)
        {
            // depricated
            return wrappedEnum.ToString(formatProvider);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            // depricated
            return wrappedEnum.ToString(format, formatProvider);
        }

        public string ToString(string format)
        {
            Enum x = (Enum)((object)wrappedEnum);
            return x.ToString(format);
        }

        public bool HasFlag(T flag)
        {
            Enum x = (Enum)((object)wrappedEnum); 
            return x.HasFlag((Enum)((object)flag));
        }
    }
}
