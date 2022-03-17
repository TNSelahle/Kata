using Kata.Core.Contracts;

namespace Kata.Core
{
    public class Copier
    {
        private ISource _source;

        public Copier(ISource source)
        {
            this._source = source;
        }

        public void Copy()
        {
            char readChar = _source.ReadChar();
        }
    }
}