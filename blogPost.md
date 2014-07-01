Static API
====


Static, type safe languages are nice. They are like the auto-correct of programming, and you don't even realize how hard it is to spell until you don't have something checking for you.

Server side languages have long enjoyed static typing .NET, while web clients traditionally lacked static typing.

Recently languages like TypeScript have introduced static typing to web browsers. Finally both your client and server could be type safe, you'd never have to worry about mistyping a variable name.


Or would you?

See the web server exposes an API, and the client takes that API and uses it. And while patterns like REST have emerged to alleviate some of the problems with the server-client disconnect, the problems are still there.

When calling the API, you can essentially think of it as a library for the client. Except this client is not statically typed, and loses all the benefits of static typing. You can't confidently change a parameter to a server function without worrying about breaking something.

The Static API project seeks to solve this problem. By reading the server DLL it can create an interface for the server in TypeScript. The client then simply codes against this API, and benefits from the static typing that TypeScript has, even with server methods.