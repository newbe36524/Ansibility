using System.Text;

namespace Ansibility.Web.Common
{
    public class CmdArgumentBuilder
    {
        private readonly StringBuilder _sb = new StringBuilder();

        public CmdArgumentBuilder(params string[] initParams)
        {
            foreach (var initParam in initParams)
            {
                Add(initParam);
            }
        }

        public CmdArgumentBuilder Add(string param)
        {
            _sb.Append($" {param}");
            return this;
        }

        public string Build()
        {
            return _sb.ToString();
        }
    }
}