using System;
using System.Reflection;
using Xunit.Sdk;

namespace CdrAuthServer.IntegrationTests
{
    class DisplayTestMethodNameAttribute : BeforeAfterTestAttribute
    {
        static int count = 0;

        public override void Before(MethodInfo methodUnderTest)
        {
            Console.WriteLine($"Test #{++count} - {methodUnderTest.DeclaringType?.Name}.{methodUnderTest.Name}");
        }

    }
}