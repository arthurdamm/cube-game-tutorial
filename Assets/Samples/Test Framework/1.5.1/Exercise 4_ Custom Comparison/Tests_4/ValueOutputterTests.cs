using UnityEngine;
using MyExercise_4;
using NUnit.Framework;
using UnityEngine.TestTools.Utils;

namespace Tests_4
{
    internal class ValueOutputterTests
    {
        [Test]
        public void Test_Vector()
        {
            var vo = new ValueOutputter();
            var actual = vo.GetVector3();

            Assert.That(actual, Is.EqualTo(new Vector3(10.333f, 3f, 9.666f)).Using(new Vector3EqualityComparer(.0001f)));
            TestContext.Out.WriteLine($"Difference: X={Mathf.Abs(actual.x - 10.333f)}, Y={Mathf.Abs(actual.y - 3f)}, Z={Mathf.Abs(actual.z - 9.666f)}");
        }

        [Test]
        public void Test_Float()
        {
            var vo = new ValueOutputter();
            var actual = vo.GetFloat();

            var expected = 19.333f;

            Assert.That(actual, Is.EqualTo(expected).Using(new FloatEqualityComparer(.0001f)), $"Mydiff: {Mathf.Abs(expected - actual)}");

        }

        [Test]
        public void Test_Quat()
        {
            var vo = new ValueOutputter();
            var actual = vo.GetQuaternion();

            var expected = new Quaternion(10f, 0f, 7.33333f, 0f);

            Assert.That(actual, Is.EqualTo(expected).Using(QuaternionEqualityComparer.Instance), $"");

        }
    }
}