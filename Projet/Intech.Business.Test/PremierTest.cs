using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Intech.Business.Test
{
        [TestFixture]
        public class PremierTest
        {
            [Test]
            public void TestMethod1()
            {
                int x1 = 1;
                int x2 = 2;
                int sum;

                sum = x1 + x2;

                Assert.That(sum == 3);

            }
        }
}
