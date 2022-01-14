using System;

delegate int MyDel(int x, int y);

namespace TaskMyDel
{
    static class TestClass
    {
        public static int TestMethod(int x, int y)
        {
            return Math.Max(x, y);
        }
    }
    class TestClass2
    {
        public int TestMethod(int x, int y)
        {
            return x + y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyDel myDel1 = new MyDel(TestClass.TestMethod);
            Console.WriteLine(myDel1(1, 2));
            TestClass2 testClass2 = new TestClass2();
            MyDel myDel2 = new MyDel(testClass2.TestMethod);
            Console.WriteLine(myDel2(1, 2));
            MyDel myDel3 = myDel1 + myDel2;
            Console.WriteLine(myDel3(3, 4));
            Delegate[] invocationList = myDel3.GetInvocationList();
            Array.ForEach(invocationList, el => Console.WriteLine(el.Method));
        }
    }
}
