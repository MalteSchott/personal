using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_example
{
    class TextConverter
    {
        private readonly Func<string, string> conversion;

        public TextConverter(Func<string, string> conversion)
        {
            this.conversion = conversion;
        }

        public string ConvertText(string inputText)
        {
            return conversion(inputText);
        }

    }
}
