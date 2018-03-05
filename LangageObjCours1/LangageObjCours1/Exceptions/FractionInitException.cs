using System;
namespace LangageObjCours1
{
    public class FractionInitException:Exception
    {
        public FractionInitException()
        : base() { }

        public FractionInitException(string message)
        : base(message) { }

    }
}
