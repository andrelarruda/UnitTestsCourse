using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsCourse.Tests
{
    public static class WorldsDumbestFunctionTests
    {
        // Naming Convention - ClassName_MethodName_ExpectedResult
        public static void WorldsDumbestFunction_ReturnsPikachuIfZero_ReturnString()
        {
            try
            {
                // Arrange
                int num = 0;
                WorldsDumbestFunction t = new WorldsDumbestFunction();

                // Act 
                string result = t.ReturnsPikachuIfZero(num);

                // Assert
                if (result == "PIKACHU!")
                {
                    Console.WriteLine("PASSED: WorldsDumbestFunction.ReturnsPikachuIfZero_ReturnsString");
                } else
                {
                    var message = "FAILED: WorldsDumbestFunction.ReturnsPikachuIfZero_ReturnsString";
                    Console.WriteLine(message);
                    throw new Exception(message);
                }


            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
