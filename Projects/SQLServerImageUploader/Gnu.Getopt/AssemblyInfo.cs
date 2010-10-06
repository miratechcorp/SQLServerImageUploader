using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: AssemblyTitle("GNU Getopt Argument Parser")]
[assembly: AssemblyDescription("This is a C# port of a Java port of GNU " +
	"Getopt, a class for parsing command line arguments passed to programs. " +
	"It is based on the C getopt() functions in glibc 2.0.6 and should " +
	"parse options in a 100% compatible manner.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Free Software Foundation, Inc.")]
[assembly: AssemblyProduct("GNU Getopt")]
[assembly: AssemblyCopyright("Copyright (c) 1987-1997 Free Software " +
	"Foundation, Inc., Java Port Copyright (c) 1998 by Aaron M. Renn " +
	"(arenn@urbanophile.com), C#.NET Port of the Java Port Copyright (c) " +
	"2004 by Klaus Pr�ckl (klaus.prueckl@aon.at)")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

[assembly: AssemblyVersion("0.9.1.*")]

//
// In order to sign your assembly you must specify a key to use. Refer to the 
// Microsoft .NET Framework documentation for more information on assembly signing.
//
// Use the attributes below to control which key is used for signing. 
//
// Notes: 
//   (*) If no key is specified, the assembly is not signed.
//   (*) KeyName refers to a key that has been installed in the Crypto Service
//       Provider (CSP) on your machine. KeyFile refers to a file which contains
//       a key.
//   (*) If the KeyFile and the KeyName values are both specified, the 
//       following processing occurs:
//       (1) If the KeyName can be found in the CSP, that key is used.
//       (2) If the KeyName does not exist and the KeyFile does exist, the key 
//           in the KeyFile is installed into the CSP and used.
//   (*) In order to create a KeyFile, you can use the sn.exe (Strong Name) utility.
//       When specifying the KeyFile, the location of the KeyFile should be
//       relative to the project output directory which is
//       %Project Directory%\obj\<configuration>. For example, if your KeyFile is
//       located in the project directory, you would specify the AssemblyKeyFile 
//       attribute as [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]
//   (*) Delay Signing is an advanced option - see the Microsoft .NET Framework
//       documentation for more information on this.
//
//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile(@"..\..\..\Gnu.Getopt.snk")]
//[assembly: AssemblyKeyName("")]

//[assembly:CLSCompliant(true)]
//[assembly:ComVisible(true)]
//[assembly:SecurityPermission(SecurityAction.RequestRefuse,Assertion=true)]
//[assembly:SecurityPermission(SecurityAction.RequestRefuse,ControlAppDomain=true)]
//[assembly:SecurityPermission(SecurityAction.RequestRefuse,ControlDomainPolicy=true)]
//[assembly:SecurityPermission(SecurityAction.RequestRefuse,ControlEvidence=true)]
//[assembly:SecurityPermission(SecurityAction.RequestRefuse,ControlPolicy=true)]
//[assembly:SecurityPermission(SecurityAction.RequestRefuse,ControlPrincipal=true)]
//[assembly:SecurityPermission(SecurityAction.RequestRefuse,ControlThread=true)]
//[assembly:SecurityPermission(SecurityAction.RequestRefuse,Execution=true)]
//[assembly:SecurityPermission(SecurityAction.RequestRefuse,Infrastructure=true)]
//[assembly:SecurityPermission(SecurityAction.RequestRefuse,RemotingConfiguration=true)]
//[assembly:SecurityPermission(SecurityAction.RequestRefuse,SerializationFormatter=true)]
//[assembly:SecurityPermission(SecurityAction.RequestRefuse,SkipVerification=true)]
//[assembly:SecurityPermission(SecurityAction.RequestRefuse,UnmanagedCode=true)]
//[assembly:SecurityPermission(SecurityAction.RequestRefuse,Unrestricted=true)]