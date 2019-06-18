/* Disclaimer: The examples and comments from this program are from
   C#7 in a Nutshell and are written for learning purposes only. */

using System;

namespace Static_Constructors
{
    /* A static constructor executes once per type, rather
      than once per instance. A type can define one static
      constructor, and it must be parameterless and have the
      same name as the type: */
    class Test
    {
        static Test() { Console.WriteLine("Type Initialized"); }
    }
    /* The runtime automatically invokes a static constructor just
     prior to the type being used. Two things trigger this: 
     1. Instantiating the type
     2. Accessing a static member in the type 
     
       The only modifier allowed by static constructors are unsafe
     and extern. If a static constructor throws an unhandled
     exception, that type becomes unusable for the life of the 
     application. */

    /* FIELD INITIALIZATION ORDER:
     
       Static field initializers run just BEFORE the static
     constructor is called. If a type has no static constructor,
     field initialers will execute just prior to the type being 
     used - or ANYTIME EARLIER at the whim of the runtime. 

       Static field initializers run in order in which the fields
       are declared. The following example illustrates this:
       X is initialized to 0 and Y is initialized to 3.   */
    class Foo
    {
        public static int X = Y;        // 0
        public static int Y = 3;        // 3
    }
    /* If we swap the two field initializers around, both 
      fields are initialized to 3. The next example prints
      0 followed by 3 because the field initializer that 
      instantiates a Foo executes before x is initialized
      to 3: */
      class Program
    {
        static void Main() { Console.WriteLine(Foo2.x); }   // 3
    }
    class Foo2
    {
        public static Foo2 Instance = new Foo2();   // Line A
        public static int x = 3;                    // Line B
        Foo2 () { Console.WriteLine(x); }   // 0
        /* If we swap the lines A and B, the example prints 3
          followed by a 3. */
    }
}