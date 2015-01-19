CsTestProj
==========

A vanilla C# test suite project that includes an Assert class that provides assertions very similar to popular testing frameworks. The reason why this may be necessary is that the Express editions of Visual Studio do not allow for extensions. Most unit testing frameworks work on a plugin/extension basis. This project has no such requirement and can be used witih Express.

Usage
==========

It's pretty much what you'd expect for a project.

1. Drop CsTestProj folder into solution folder (I would just prefer to call it "Test" though).
2. Add existing project through Visual Studio.
3. Add project reference(s) to your code project(s) in the Test project.
4. Optionally: Add `[assembly: InternalsVisibleTo("Test")]` to AssemblyInfo.cs in your project(s).
5. Start creating tests by affixing the vanilla .NET testing attributes of TestClass and TestMethod. Included is a self-test of the assertion framework that can be used as a model.

Known Issues
==========

* Usage of the combined err/out process spawner classes causes an AppDomainUnloadedException if there is also input involved, this appears to be a problem with the VS test runner and there appears to be no way to fix it (cf https://connect.microsoft.com/VisualStudio/feedback/details/797525/unexplained-appdomainunloadedexception-when-running-a-unit-test-on-tfs-build-server).
