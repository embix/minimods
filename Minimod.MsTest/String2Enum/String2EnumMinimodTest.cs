using System;
using Minimod.String2Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Minimod.MsTest.String2Enum
{
    /// <summary>
    /// <h1>Minimod.MsTest.String2Enum, Version 0.9.2, Copyright © Michel Bretschneider 2012</h1>
    /// <para>A minimod for parsing Strings as Enums - the tests.</para>
    /// This class is inteded to hold all test cases for the String2Enum Minimod.
    /// </summary>
    /// <remarks>
    /// Licensed under the Apache License, Version 2.0; you may not use this file except in compliance with the License.
    /// http://www.apache.org/licenses/LICENSE-2.0
    /// </remarks>
    [TestClass]
    public class String2EnumMinimodTest
    {
        [TestMethod]
        public void CorrectlySpelledNamesAreCorrectlyParsed()
        {
            Assert.AreEqual(Weekday.Monday, "Monday".ToEnum<Weekday>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IncorrectlyCasedNamesCauseArgumentException()
        {
            "monday".ToEnum<Weekday>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WrongValuesCauseArgumentException()
        {
            "xxx".ToEnum<Weekday>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "TEnum must be an enum.")]
        public void GenericTypeMustBeAnEnum()
        {
            "Monday".ToEnum<Enumlike>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullCausesArgumentNullException()
        {
            String weekday = null;
            weekday.ToEnum<Weekday>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyStringCausesArgumentNullException()
        {
            String weekday = String.Empty;
            weekday.ToEnum<Weekday>();
        }
    }
}
