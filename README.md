CsTestProj
==========

A vanilla C# test suite project that includes an `Assert` class that provides assertions very similar to popular testing frameworks. The reason why this may be necessary is that the Express editions of Visual Studio do not allow for extensions. Most unit testing frameworks work on a plugin/extension basis. This project has no such requirement and can be used with Express.

Usage as Project
==========

1. Drop `TestLib` folder into solution folder.
2. Add the `TestLib` project through Visual Studio.
3. Optionally: Add `TestLib.Tests` project through Visual Studio. This is a self-test of the assertion framework and can be used as a template.
4. Create new project from the test C# template or copy/paste `TestLib.Tests` project and modify appropriately.
5. Optionally: Add `[assembly: InternalsVisibleTo("TestLib.Tests")]` (replacing project name as appropriate) to `AssemblyInfo.cs` in your project(s).
6. Start creating tests by affixing the vanilla .NET testing attributes of `TestClass` and `TestMethod`.

Usage as Binary
==========

1. Open `Test.sln`.
2. Switch build to `Release` and compile the `TestLib` project.
3. Optionally: Run the self-test of the assertion framework.
4. Place binary in your solution somewhere and reference from your test project(s).
5. Start creating tests by affixing the vanilla .NET testing attributes of `TestClass` and `TestMethod`.

Known Issues
==========

* VS2013: Usage of the combined err/out process spawner classes causes an `AppDomainUnloadedException` if there is also input involved, this appears to be a problem with the VS test runner and there appears to be no way to fix it (cf https://connect.microsoft.com/VisualStudio/feedback/details/797525/unexplained-appdomainunloadedexception-when-running-a-unit-test-on-tfs-build-server). This does not prevent the tests from passing successfully, it's only a message that shows up in the output.
