using System;

namespace Kata.Core.Tests
{
    public class Copier
    {
        private ISource _source;

        public Copier(ISource @object)
        {
            this._source = @object;
        }

        public void Copy()
        {
            char readChar = _source.ReadChar();
        }
    }
}