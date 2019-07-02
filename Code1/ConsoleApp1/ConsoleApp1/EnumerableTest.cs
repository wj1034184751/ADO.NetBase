using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class EnumerableTest : IEnumerable<KeyValuePair<string, string>>
    {
        private IList<KeyValuePair<string, string>> _params;

        public EnumerableTest()
        {
            _params = new List<KeyValuePair<string, string>>();
        }

        public EnumerableTest(IEnumerable<KeyValuePair<string,string>>parameters)
        {
            _params = new List<KeyValuePair<string, string>>(parameters);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _params.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _params.GetEnumerator();
        }
    }
}
