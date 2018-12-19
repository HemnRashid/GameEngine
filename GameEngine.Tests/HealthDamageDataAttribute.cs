using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace GameEngine.Tests
{
    public class HealthDamageDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {

            // Alt.1 Hard coded data to return 
            //yield return new object[] { 0, 100 };
            //yield return new object[] { 1, 99 };
            //yield return new object[] { 50, 50 };
            //yield return new object[] { 75, 25 };
            //yield return new object[] { 101, 1 };

            // Alt.2 External Data source to return as test data.
            // Kopiera logiken till denna metod istället.
            return ExternalHealthDamageTestData.TestData; 
            
        }
    }
}
