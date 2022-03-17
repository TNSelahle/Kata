using Kata.Core.Contracts;

namespace Kata.Core
{
    public class Copier
    {
        private readonly ISource _source;
        private readonly IDestination _destination;

        public Copier(ISource source, IDestination destination)
        {
            this._source = source;
            this._destination = destination;
        }

        public void Copy()
        {
            char readChar = _source.ReadChar();

            while (readChar != '\n')
            {
                _destination.WriteChar(readChar);
                readChar = _source.ReadChar();
            }
        }
    }
}