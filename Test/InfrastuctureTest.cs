using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Infrastructure.JwtToken;

namespace WebAppTest
{
    public class InfrastuctureTest
    {
        [SetUp]
        public void SetUp()
        {
            IMock<JwtOptions> jwtOptions = new Mock<JwtOptions>();
            //jwtOptions.Behavior
        }

        [Test]
        public void JwtTokenProvider_TokenCreated()
        {
            
        }
    }
}
