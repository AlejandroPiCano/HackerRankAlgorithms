using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Algorithms
{
    internal class Monarch
    {
        public int id;
        public string nm;
        public string cty;
        public string hse;
        public string yrs;
    }

    internal class NovaforiExercise
    {
        internal class Program
        {
            private const string ApiURL = "https://gist.githubusercontent.com/christianpanton/10d65ccef9f29de3acd49d97ed423736/raw/b09563bc0c4b318132c7a738e679d4f984ef0048/kings";
            static void MainExercise(string[] args)
            {
                try
                {
                    HttpClient httpClient = new HttpClient();

                    httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = httpClient.GetAsync(ApiURL).Result;

                    //another way
                    //var res = new WebClient().DownloadString(ApiURL);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        List<Monarch> list = JsonConvert.DeserializeObject<List<Monarch>>(result);

                        Console.WriteLine("Result of Method with For");
                        MethodWithFor(list);

                        Console.WriteLine("Result of Method with Linq");
                        MethodWithLinq(list);

                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message); ;
                }
            }

            private static void MethodWithFor(List<Monarch> list)
            {
                Console.WriteLine($"Monarchs count {list.Count}");

                Monarch monarch = null;
                int difyears = 0, maxDifYears = int.MinValue;
                Dictionary<string, int> dict = new Dictionary<string, int>();
                Dictionary<string, int> dictHouses = new Dictionary<string, int>();

                foreach (var m in list)
                {
                    var years = m.yrs.Split(new String[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                    int count = years.Count();

                    difyears = 0;
                    if (count == 2)
                    {
                        difyears = Math.Abs(int.Parse(years[1]) - int.Parse(years[0]));
                    }
                    else if (m.yrs.Contains("-"))
                    {
                        difyears = Math.Abs(DateTime.Now.Year - int.Parse(years[0]));
                    }

                    if (difyears > maxDifYears)
                    {
                        maxDifYears = difyears;
                        monarch = m;
                    }

                    var fristname = m.nm.Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0];

                    if (dict.ContainsKey(fristname))
                    {
                        dict[fristname]++;
                    }
                    else
                    {
                        dict.Add(fristname, 1);
                    }

                    if (dictHouses.ContainsKey(m.hse))
                    {
                        dictHouses[m.hse] += difyears;
                    }
                    else
                    {
                        dictHouses.Add(m.hse, difyears);
                    }
                }

                Console.WriteLine($"Monarch ruled the longest monarch {monarch.nm} and for time {maxDifYears}");

                Console.WriteLine($"Monarch longest house {monarch.hse} and for time {maxDifYears}");

                var house = dictHouses.FirstOrDefault(i => i.Value == dictHouses.Values.Max());

                Console.WriteLine($"House ruled the longest house total of diffs of years {house.Key} and for time {house.Value}");

                Console.WriteLine($"most common name {dict.FirstOrDefault(i => i.Value == dict.Values.Max()).Key}");

                Console.ReadLine();
            }

            static void MethodWithLinq(List<Monarch> list)
            {
                try
                {
                    Console.WriteLine($"Monarchs count {list.Count}");

                    var monarchMoreYears = list.Select
                        (
                          m => new Tuple<Monarch, int>
                          (
                            m,
                            Math.Abs
                            (
                                (
                                  m.yrs.Split(new String[] { "-" }, StringSplitOptions.RemoveEmptyEntries).Count() > 1 ? int.Parse(m.yrs.Split(new String[] { "-" }, StringSplitOptions.RemoveEmptyEntries)[1]) : (m.yrs.Contains("-") ? DateTime.Now.Year : int.Parse(m.yrs.Split(new String[] { "-" }, StringSplitOptions.RemoveEmptyEntries)[0]))
                                )
                                -
                                int.Parse(m.yrs.Split(new String[] { "-" }, StringSplitOptions.RemoveEmptyEntries)[0])
                            )
                         )
                       );

                    var monarch = monarchMoreYears.FirstOrDefault(m => m.Item2 == monarchMoreYears.Max(k => k.Item2));

                    Console.WriteLine($"Monarch ruled the longest monarch {monarch.Item1.nm} and for time {monarch.Item2}");

                    Console.WriteLine($"Monarch longest house {monarch.Item1.hse} and for time {monarch.Item2}");

                    var houses = monarchMoreYears.GroupBy(m => m.Item1.hse);
                    var houseMoreYears = houses.Select
                     (
                          m => new Tuple<string, int>
                          (
                              m.Key,
                              m.Sum(k => k.Item2)
                          )
                     );

                    var house = houseMoreYears.FirstOrDefault(m => m.Item2 == houseMoreYears.Max(k => k.Item2));
                    Console.WriteLine($"House ruled the longest house total of diffs of years {house.Item1} and for time {house.Item2}");
                    var names = list.Select
                        (

                          m => new Tuple<string, int>
                          (
                              m.nm.Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0],
                              list.Count(n => m.nm.Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0] == n.nm.Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0])
                          )
                        );
                    var name = names.FirstOrDefault(m => m.Item2 == names.Max(k => k.Item2));
                    Console.WriteLine($"most common name {name.Item1}");
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message); ;
                }

            }



        }
    }
}
