using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _13_APM_1
{
    class Program
    {
        public delegate string TextProcessor(string inputText);

        static void Main(string[] args)
        {
            Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] (Main): Starting...");
            var del = new TextProcessor(ProcessText);

            string str = "Very important text";
            string stateContext = "some_context";

            Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] (Main): Сalling delegate asynchronously...");
            var ar = del.BeginInvoke(str, new AsyncCallback(Callback), stateContext);
            ar.AsyncWaitHandle.WaitOne();

            Console.ReadKey();
        }

        static string ProcessText(string inputText)
        {
            Console.WriteLine($"\n[Thread {Thread.CurrentThread.ManagedThreadId}] Processing given string...");
            Thread.Sleep(2000);
            return inputText.ToUpper();
        }

        static void Callback(IAsyncResult ar)
        {
            Console.WriteLine($"\n[Thread {Thread.CurrentThread.ManagedThreadId}] Callback method is being executed...");

            var resultObj = (AsyncResult)ar;
            string stateContext = (string)resultObj.AsyncState;
            Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Context data: {stateContext}");
            var originalDel = (TextProcessor)resultObj.AsyncDelegate;

            string result = originalDel.EndInvoke(ar);
            Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Result string: \"{result}\"");
        }
    }

}
