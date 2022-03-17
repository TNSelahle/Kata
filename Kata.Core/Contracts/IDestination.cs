namespace Kata.Core.Contracts
{
    public interface IDestination
    {
        public void WriteChar(char c);

        public void WriteChars(char[] chars);
    }
}