using System;
namespace LangageObjCours1.Exceptions
{
    public class MatriceException: Exception
    {
        public MatriceException()
        : base() { }

        public MatriceException(string message)
        : base(message) { }
    }
}
