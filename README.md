CsTestProj
==========

A vanilla C# test suite project that includes an Assert class that provides assertions very similar to popular testing frameworks.

Usage is pretty much what you'd expect.
1. Drop CsTestProj folder into solution folder (I would just prefer to call it "Test" though).
2. Add existing project through Visual Studio.
3. Add project reference(s) to your code project(s) in the Test project.
4. Optionally: Add `[assembly: InternalsVisibleTo("Test")]` to AssemblyInfo.cs in your project(s).
5. Start creating tests by affixing the vanilla .NET testing attributes of TestClass and TestMethod. Included is a self-test of the assertion framework that can be used as a model.
