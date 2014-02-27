using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpNTCIP.DMS;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiString example = new MultiString(@"THIS IS [cb3]A TEST [cb]WITH COLOR CHANGE");
            string xmlExample = example.MultiDocument.ToString();
            string textExample = example.ToString();
            string htmlExpect = @"<multi>THIS IS <cb3 />A TEST <cb />WITH COLOR CHANGE</multi>";
            string textExpect = @"THIS IS A TEST WITH COLOR CHANGE";
        }
    }
}
