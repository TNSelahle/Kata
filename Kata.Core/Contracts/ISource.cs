namespace Kata.Core.Contracts
{
    public interface ISource
    {
        public char ReadChar();

        public char[] ReadChars(int count);
    }
}