Static API
====

Static API is a program that generates TypeScript classes that map to a web server API defined in a DLL.

This allows you to take advantage of static typing across the web, and refactor your (internal) server API without worry of breaking anything.


Status
----

The project can successfully take a dll and convert it to a typescript definition. It does not generate the code to actually make the server call yet, nor does it generate interfaces for custom types (you could provide your own now, or just treat them as any).

The project is nearing a usable state, and an alpha will be made available soon.
Use
----

Call `staticAPI.exe` from the command line, passing in the path to the web server's DLL.

It will generate a file, `API.ts`. Inside this is modules with each of the controller methods as sub-modules.

The base module is `Server`. It exposes a module `Ajax` which contains the methods for making calls to the server. These methods can be overwritten by an application if it so needs.


	Server.Ajax.Get = (url, params) => //Your custom method here

The `Get` method takes in a URL and parameters. The `Post` method takes in the same, and the data as an object. Both methods return a "thenable" object (an object that has a way to register success and fail callbacks). 

The rest of the modules map to the server methods and simply call the appropriate Ajax method. The parameters are identical to the parameters to the server method, and the result is a promise object that allows register a callback. This callback is called once the method returns, and with the strongly typed result of the call.