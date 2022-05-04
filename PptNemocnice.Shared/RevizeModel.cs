using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PptNemocnice.Shared
{
    public class RevizeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public Guid VybaveniID { get; set; }

        public DateTime? DateTime { get; set; }

        public static List<RevizeModel> GetTestList()
        {
            List<RevizeModel> list = new();
            Random rnd = new();
            for (int i = 0; i < 1000; i++)
            {
                RevizeModel model = new()
                {
                    Id = Guid.NewGuid(),
                    Name = RandomString(rnd.Next(5, 25), rnd)                    
                };
                //model.
                list.Add(model);
            }
            return list;

        }
        public static string RandomString(int length, Random rnd) =>
        new(Enumerable.Range(0, length).Select(_ => (char)rnd.Next('a', 'z')).ToArray());
    }
}
