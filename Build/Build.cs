﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bounce.Framework;

namespace Build
{
    public class Build
    {
        [Targets]
        public static object Targets(IParameters parameters)
        {
            var v4 = new VisualStudioSolution {SolutionPath = @"Bounce.sln", Configuration = "Debug"};
            var v35 = new VisualStudioSolution {SolutionPath = @"Bounce.sln", Configuration = "Debug_3_5"};
            var tests = new NUnitTests
            {
                DllPaths = v4.Projects.Where(p => p.Name.EndsWith("Tests")).Select(p => p.OutputFile),
                NUnitConsolePath = @"nunit-console.exe"
            };

            var nugetExe = @"References\NuGet\NuGet.exe";
            var nugetPackage = new NuGetPackage
            {
                NuGetExePath = nugetExe,
                Spec = v4.Projects["Bounce.Framework"].ProjectFile.WithDependencyOn(tests),
            };
            var nugetPush = new NuGetPush
            {
                ApiKey = @"8890f3e6-8806-45ba-8fb5-f78e1e0f0381",
                NuGetExePath = nugetExe,
                Package = nugetPackage.Package,
            };

            return new
            {
                Binaries = new All(v4, v35),
                Tests = tests,
                NuGet = nugetPush,
            };
        }
    }
}
