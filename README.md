# SharpDirectInput
This is a wrapper library for C#.
There are plenty of wrappers out there and this one is not unique.

This is a learning project used to understand DirectInput and P/Invoke a bit better.
Please note that the 'Bridge' dll is there to create 

*This library targets the unicode version of DirectInput because .Net strings auto-support unicode.*

*32-bit (x86) is the current target environment, 64-bit (x64) may be targeted later.*

**SharpDirectInput**

This is the core library which may be used by applications.
* Managed Library;
* Performs P/Invoke calls;
* Mimics DirectInput API (differs slightly to decrease complexity)

**DirectInputBridge**

This is an unmanaged library used for rerouting P/Invoke calls.
* Additional abstraction;
* Makes DirectInput methods accessibles as functions, P/Invoke does not support instance methods.

**TestApplication**

A demo application that shows how to use the API and a simple UI that visualizes values.

**UnitTest**

UnitTests for initialization of DirectInput and to check if methods function correctly.
