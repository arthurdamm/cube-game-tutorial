using System.Text.RegularExpressions;
using MyExercise_5;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests_5
{
    internal class MyLoggingClassTests
    {
        [Test]
        public void Test_DoSomething()
        {
            var ObjUnderTest = new MyLoggingClass();

            ObjUnderTest.DoSomething();

            LogAssert.Expect(LogType.Log, "Doing something");
        }

        [Test]
        public void Test_DoSomethingElse()
        {
            var ObjUnderTest = new MyLoggingClass();

            ObjUnderTest.DoSomethingElse();
            
            // LogAssert does not respect RegexOptions, they must be included in string if possible
            LogAssert.Expect(LogType.Error, new Regex("^(?i)an eRrOr happened. Code: \\d+$"));
        }
    }
}