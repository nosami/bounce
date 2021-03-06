using System.Collections.Generic;

namespace Bounce.Framework.NUnit {
    public interface INUnit {
        void Test(string dllPath, IEnumerable<string> excludeCategories = null, IEnumerable<string> includeCategories = null);
        void Test(IEnumerable<string> dllPaths, IEnumerable<string> excludeCategories = null, IEnumerable<string> includeCategories = null);

        /// <summary>
        /// Full path to nunit-console.exe
        /// </summary>
        string NUnitConsolePath { get; set; }
    }
}