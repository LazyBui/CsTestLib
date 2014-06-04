CsTestProj
==========

A vanilla C# test suite project that includes an Assert class that provides assertions very similar to popular testing frameworks.

Usage is pretty much what you'd expect.
# Drop CsTestProj folder into solution folder (I would just prefer to call it "Test" though).
# Add existing project through Visual Studio.
# Add project reference(s) to your code project(s) in the Test project.
# Optionally: `Add [assembly: InternalsVisibleTo("Test")]` to AssemblyInfo.cs in your project(s).
# Start creating tests by affixing the vanilla .NET testing attributes of TestClass and TestMethod. Included is a self-test of the assertion framework that can be used as a model.
