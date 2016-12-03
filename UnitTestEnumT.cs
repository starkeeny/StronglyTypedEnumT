using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace EnumT.UnitTests
{
    /// <summary>
    /// Test Cases are setup with AAA-pattern arrange, act assert
    /// </summary>
    [TestClass]
    public class UnitTestEnumT
    {
        [TestMethod]
        public void TestGetName1()
        {
            // arrange
            object data = 1;

            // act
            var values = Enum<ConsoleColor>.GetName(data);

            // assert
            Assert.AreEqual("DarkBlue", values);
        }

        [TestMethod]
        public void TestGetName7()
        {
            // arrange
            object data = 7;

            // act
            var values = Enum<ConsoleColor>.GetName(data);

            // assert
            Assert.AreEqual("Gray", values);
        }

        [TestMethod]
        public void TestGetName100_outofrange()
        {
            // arrange
            object data = 100;

            // act
            var values = Enum<ConsoleColor>.GetName(data);

            // assert
            Assert.IsNull(values);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetNameNull()
        {
            // arrange
            object data = null;

            // act
            var values = Enum<ConsoleColor>.GetName(data);

            // assert
            Assert.Fail("exception expected");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetNameWrongType()
        {
            // arrange
            object data = "wrong";

            // act
            var values = Enum<ConsoleColor>.GetName(data);

            // assert
            Assert.Fail("exception expected");
        }

        [TestMethod]
        public void TestFormat_G()
        {
            // arrange
            ConsoleColor data = ConsoleColor.Cyan;

            // act
            var values = Enum<ConsoleColor>.Format(data, "G");

            // assert
            Assert.AreEqual("Cyan", values);
        }
        [TestMethod]
        public void TestFormat_G_ValueByNumber()
        {
            // arrange
            object data = 11;

            // act
            var values = Enum<ConsoleColor>.Format(data, "G");

            // assert
            Assert.AreEqual("Cyan", values);
        }

        [TestMethod]
        public void TestFormat_X()
        {
            // arrange
            ConsoleColor data = ConsoleColor.Cyan;

            // act
            var values = Enum<ConsoleColor>.Format(data, "X");

            // assert
            Assert.AreEqual("0000000B", values);
        }

        [TestMethod]
        public void TestFormat_D()
        {
            // arrange
            ConsoleColor data = ConsoleColor.Cyan;

            // act
            var values = Enum<ConsoleColor>.Format(data, "D");

            // assert
            Assert.AreEqual("11", values);
        }

        [TestMethod]
        public void TestFormat_F()
        {
            // arrange
            ConsoleColor data = ConsoleColor.Cyan;

            // act
            var values = Enum<ConsoleColor>.Format(data, "F");

            // assert
            Assert.AreEqual("Cyan", values);
        }

        [TestMethod]
        public void TestFormat_G_Flags()
        {
            // arrange
            var data = System.IO.FileOptions.DeleteOnClose | System.IO.FileOptions.Encrypted;

            // act
            var values = Enum<System.IO.FileOptions>.Format(data, "G");

            // assert
            Assert.AreEqual("Encrypted, DeleteOnClose", values);
        }

        [TestMethod]
        public void TestFormat_X_Flags()
        {
            // arrange
            var data = System.IO.FileOptions.DeleteOnClose | System.IO.FileOptions.Encrypted;

            // act
            var values = Enum<System.IO.FileOptions>.Format(data, "X");

            // assert
            Assert.AreEqual((67108864 | 16384).ToString("X").PadLeft(8, '0'), values);
        }

        [TestMethod]
        public void TestFormat_D_Flags()
        {
            // arrange
            var data = System.IO.FileOptions.DeleteOnClose | System.IO.FileOptions.Encrypted;

            // act
            var values = Enum<System.IO.FileOptions>.Format(data, "D");

            // assert
            Assert.AreEqual((67108864 | 16384).ToString(), values);
        }

        [TestMethod]
        public void TestFormat_F_Flags()
        {
            // arrange
            var data = System.IO.FileOptions.DeleteOnClose | System.IO.FileOptions.Encrypted;

            // act
            var values = Enum<System.IO.FileOptions>.Format(data, "F");

            // assert
            Assert.AreEqual("Encrypted, DeleteOnClose", values);
        }

        [TestMethod]
        public void TestGetNames()
        {
            // arrange

            // act
            var values = Enum<System.GCCollectionMode>.GetNames();

            // assert
            var expectedValues = new string[] { "Default", "Forced", "Optimized" };
            Assert.IsTrue(values.Length == expectedValues.Length &&
                          values.OrderBy(s => s).SequenceEqual(expectedValues.OrderBy(s => s)));
        }

        [TestMethod]
        public void TestGetUnderlyingType()
        {
            // arrange

            // act
            var values = Enum<System.EnvironmentVariableTarget>.GetUnderlyingType();

            // assert
            Assert.AreEqual("System.Int32", values.ToString());
        }

        [TestMethod]
        public void TestCreateObject()
        {
            // arrange 

            // act
            var values = new Enum<System.ConsoleColor>(ConsoleColor.Black);

            // assert
        }

        [TestMethod]
        public void TestCompareBaseObject()
        {
            // arrange

            // act
            var values = new Enum<System.ConsoleKey>(ConsoleKey.A);

            // assert
            Assert.AreEqual<ConsoleKey>(ConsoleKey.A, values.Base);
        }

        [TestMethod]
        public void TestCompareBaseEquals()
        {
            // arrange
            var e = new Enum<System.ConsoleKey>(ConsoleKey.A);

            // act
            var values = ConsoleKey.A.Equals(e.Base);

            // assert
            Assert.IsTrue(values);
        }

        [TestMethod]
        public void TestGetValues()
        {
            // arrange

            // act
            var values = Enum<System.UriKind>.GetValues();

            // assert
            var expectedValues = new[] { UriKind.Absolute, UriKind.Relative, UriKind.RelativeOrAbsolute };
            Assert.IsTrue(values.OrderBy(x => x).SequenceEqual(expectedValues.OrderBy(x => x)));
        }

        [TestMethod]
        public void TestIsDefined()
        {
            // arrange
            object data = 2;

            // act
            var values = Enum<UriKind>.IsDefined(data);

            // assert
            Assert.IsTrue(values);
        }

        [TestMethod]
        public void TestIsDefined_error()
        {
            // arrange
            object data = 57;

            // act
            var values = Enum<UriKind>.IsDefined(data);

            // assert
            Assert.IsFalse(values);
        }

        [TestMethod]
        public void TestParse_ignoreCase()
        {
            // arrange
            string data = "absolute";

            // act
            var values = Enum<UriKind>.Parse(data, true);

            // assert
            Assert.AreEqual(UriKind.Absolute, values);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestParse_wrong()
        {
            // arrange
            string data = "wrong";

            // act
            var values = Enum<UriKind>.Parse(data, true);

            // assert
            Assert.Fail("should have failed");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestParse_dontignoreCase_Fail()
        {
            // arrange
            string data = "absolute";

            // act
            var values = Enum<UriKind>.Parse(data, false);

            // assert
            Assert.Fail("should have failed");
        }

        [TestMethod]
        public void TestParse_dontignoreCaseSuccess()
        {
            // arrange
            string data = "Absolute";

            // act
            var values = Enum<UriKind>.Parse(data, false);

            // assert
            Assert.AreEqual(UriKind.Absolute, values);
        }

        [TestMethod]
        public void TestTryParse_ignoreCase()
        {
            // arrange
            string data = "absolute";

            // act
            UriKind values;
            Enum<UriKind>.TryParse(data, true, out values);

            // assert
            Assert.AreEqual(UriKind.Absolute, values);
        }

        [TestMethod]
        public void TestTryParse_wrong()
        {
            // arrange
            string data = "wrong";

            // act
            UriKind temp;
            var values = Enum<UriKind>.TryParse(data, out temp);

            // assert
            Assert.IsFalse(values);
        }

        [TestMethod]
        public void TestTryParse_ignorecase_wrong()
        {
            // arrange
            string data = "wrong";

            // act
            UriKind temp;
            var values = Enum<UriKind>.TryParse(data, true, out temp);

            // assert
            Assert.IsFalse(values);
        }

        [TestMethod]
        public void TestTryParse_dontignoreCase_Fail()
        {
            // arrange
            string data = "absolute";

            // act
            UriKind temp;
            var values = Enum<UriKind>.TryParse(data, out temp);

            // assert
            Assert.IsFalse(values);
        }

        [TestMethod]
        public void TestTryParse_dontignoreCaseSuccess()
        {
            // arrange
            string data = "Absolute";

            // act
            UriKind temp;
            var values = Enum<UriKind>.TryParse(data, out temp);

            // assert
            Assert.IsTrue(values);
            Assert.AreEqual(UriKind.Absolute, temp);
        }

        [TestMethod]
        public void TestEqualityObj()
        {
            // arrange
            object data = UriKind.Relative;
            Enum<UriKind> e = new Enum<UriKind>((UriKind)data);

            // act
            var values = e.Equals((object)data);

            // assert
            Assert.IsTrue(values);
        }
        [TestMethod]
        public void TestEqualityT()
        {
            // arrange
            UriKind data = UriKind.Relative;
            Enum<UriKind> e = new Enum<UriKind>(data);

            // act
            var values = e.Equals(data);

            // assert
            Assert.IsTrue(values);
        }

        [TestMethod]
        public void TestEqualityObjnot()
        {
            // arrange
            object data = UriKind.Relative;
            Enum<UriKind> e = new Enum<UriKind>((UriKind)UriKind.Absolute);

            // act
            var values = e.Equals((object)data);

            // assert
            Assert.IsFalse(values);
        }
        [TestMethod]
        public void TestEqualityTnot()
        {
            // arrange
            UriKind data = UriKind.Relative;
            Enum<UriKind> e = new Enum<UriKind>(UriKind.Absolute);

            // act
            var values = e.Equals(data);

            // assert
            Assert.IsFalse(values);
        }

        [TestMethod]
        public void TestToObject()
        {
            // arrange

            // act
            var byteT = Enum<UriKind>.ToObject((byte)1);
            var sbyteT = Enum<UriKind>.ToObject((sbyte)1);

            var i16T = Enum<UriKind>.ToObject((Int16)1);
            var i32T = Enum<UriKind>.ToObject((Int32)1);
            var i64T = Enum<UriKind>.ToObject((Int64)1);

            var iu16T = Enum<UriKind>.ToObject((UInt16)1);
            var iu32T = Enum<UriKind>.ToObject((UInt32)1);
            var iu64T = Enum<UriKind>.ToObject((UInt64)1);

            var objT = Enum<UriKind>.ToObject((object)1);

            // assert
            foreach (var t in new UriKind[]{byteT,
                                            sbyteT,
                                            i16T,
                                            i32T,
                                            i64T,
                                            iu16T,
                                            iu32T,
                                            iu64T,
                                            objT})
            {
                Assert.AreEqual(t, UriKind.Absolute);
            }
        }

        [TestMethod]
        public void TestToObject_not()
        {
            // arrange

            // act
            UriKind values = Enum<UriKind>.ToObject((byte)19);

            // assert
            Assert.AreEqual((UriKind)19, values);
            Assert.AreEqual("19", values.ToString("d"));
            Assert.AreEqual("19", values.ToString("g"));
            Assert.AreEqual("19", values.ToString("f"));

        }

        [TestMethod]
        public void TestCompareTo_works()
        {
            // arrange
            object data = UriKind.Absolute;

            // act
            var values = new Enum<UriKind>(UriKind.Absolute).CompareTo(data);

            // assert
            Assert.AreEqual(0, values);
        }

        [TestMethod]
        public void TestCompareTo_fails()
        {
            // arrange
            object data = UriKind.Relative;

            // act
            var values = new Enum<UriKind>(UriKind.Absolute).CompareTo(data);

            // assert
            Assert.AreNotEqual(0, values);
        }

        [TestMethod]
        public void TestTCompareTo_works()
        {
            // arrange
            UriKind data = UriKind.Absolute;

            // act
            var values = new Enum<UriKind>(UriKind.Absolute).CompareTo(data);

            // assert
            Assert.AreEqual(0, values);
        }

        [TestMethod]
        public void TestTCompareTo_fails()
        {
            // arrange
            UriKind data = UriKind.Relative;

            // act
            var values = new Enum<UriKind>(UriKind.Absolute).CompareTo(data);

            // assert
            Assert.AreNotEqual(0, values);
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            // arrange
            UriKind data = UriKind.Absolute;

            // act
            var values = new Enum<UriKind>(data).GetHashCode();

            // assert
            Assert.AreEqual(data.GetHashCode(), values);
        }

        [TestMethod]
        public void TestToString()
        {
            // arrange
            UriKind data = UriKind.Absolute;

            // act
            var values = new Enum<UriKind>(data).ToString();

            // assert
            Assert.AreEqual(data.ToString(), values);
        }

        [TestMethod]
        public void TestToString_Format()
        {
            // arrange
            var data = System.IO.FileOptions.DeleteOnClose | System.IO.FileOptions.Encrypted;

            // act
            var values = new Enum<System.IO.FileOptions>(data).ToString("G");

            // assert
            Assert.AreEqual("Encrypted, DeleteOnClose", values);
        }

        [TestMethod]
        public void TestToString_Format_FormatProvider()
        {
            // arrange
            var data = System.IO.FileOptions.DeleteOnClose | System.IO.FileOptions.Encrypted;

            // act
            var values = new Enum<System.IO.FileOptions>(data).ToString("G", System.Globalization.CultureInfo.CurrentCulture);

            // assert
            Assert.AreEqual("Encrypted, DeleteOnClose", values);
        }

        [TestMethod]
        public void TestToString_FormatProvider()
        {
            // arrange
            var data = System.IO.FileOptions.DeleteOnClose | System.IO.FileOptions.Encrypted;

            // act
            var values = new Enum<System.IO.FileOptions>(data).ToString(System.Globalization.CultureInfo.CurrentCulture);

            // assert
            Assert.AreEqual("Encrypted, DeleteOnClose", values);
        }

        [TestMethod]
        public void TestHasFlag()
        {
            // arrange
            var data = System.IO.FileOptions.DeleteOnClose | System.IO.FileOptions.Encrypted;

            // act
            var values = new Enum<System.IO.FileOptions>(data).HasFlag(System.IO.FileOptions.Encrypted);

            // assert
            Assert.IsTrue(values);
        }

        [TestMethod]
        public void TestHasFlag_not()
        {
            // arrange
            var data = System.IO.FileOptions.DeleteOnClose | System.IO.FileOptions.Encrypted;

            // act
            var values = new Enum<System.IO.FileOptions>(data).HasFlag(System.IO.FileOptions.Asynchronous);

            // assert
            Assert.IsFalse(values);
        }
    }
}
