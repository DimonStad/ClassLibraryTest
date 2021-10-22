using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibraryTest
{
          public class ClassCounter
    {


         private  Dictionary<string, int> Counter(string str) 
        { 
        var pattern = @"[^а-я|a-z]+";
        var regex = new Regex(pattern, RegexOptions.IgnoreCase);



        var arr = regex.Split(str.ToLower());
        Dictionary<string, int> statistics = arr.GroupBy(word => word).ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Count());

        var ordered = statistics.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        

            return ordered;
        }


        public static Dictionary<string, int> Counter_2(string str)
        {

            var pattern = @"[^а-я|a-z]+";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            var arr = regex.Split(str.ToLower());

            var wordCount = new Dictionary<string, int>();


            var result = new System.Collections.Concurrent.ConcurrentDictionary<string, int>();
            Parallel.ForEach(arr, line =>
            {
                result.AddOrUpdate(line, 1, (_, x) => x + 1);

            });

            var ordered = result.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return ordered;
        }
    }

}


