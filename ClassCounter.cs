using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ClassLibraryTest
{
         class ClassCounter
    {

         private  Dictionary<string, int> Counter(string str) 
        { 
        var pattern = @"[^а-я|a-z]+";
        var regex = new Regex(pattern, RegexOptions.IgnoreCase);



        var arr = regex.Split(str.ToLower()).Where(e => e.Length >= 1);
        Dictionary<string, int> statistics = arr.GroupBy(word => word).ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Count());

        var ordered = statistics.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        

            return ordered;
        }

         

    }

}
