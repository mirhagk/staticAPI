Static API
====

Static API is a program that generates TypeScript classes that map to a web server API defined in a DLL.

This allows you to take advantage of static typing across the web, and refactor your (internal) server API without worry of breaking anything.


Status
----

This project is in the experimental phase, with a prototype currently being developed. Hopefully soon an alpha version can be released which should be mostly functional.

Use
----

Call `staticAPI.exe` from the command line, passing in the path to the web server's DLL.

It will generate a file, Server.ts