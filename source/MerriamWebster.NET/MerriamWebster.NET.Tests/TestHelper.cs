using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// parallelize everything! 
[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]

namespace MerriamWebster.NET.Tests
{

    public class TestHelper
    {
        public static string LoadResponseFromFile(string fileName)
        {
            var asm = Assembly.GetExecutingAssembly();
            using var resourceStream = asm.GetManifestResourceStream($"MerriamWebster.NET.Tests.Resources.{fileName}.json");

            using var reader = new StreamReader(resourceStream);
            string content = reader.ReadToEnd();

            return content;
        }

        public static Task<string> LoadResponseFromFileAsync(string fileName)
        {
            var asm = Assembly.GetExecutingAssembly();
            using var resourceStream = asm.GetManifestResourceStream($"MerriamWebster.NET.Tests.Resources.{fileName}.json");

            if (resourceStream != null)
            {
                using var reader = new StreamReader(resourceStream);
                return reader.ReadToEndAsync();
            }

            return Task.FromResult(string.Empty);
        }
    }
}
