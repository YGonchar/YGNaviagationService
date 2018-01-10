using System;
using YG.View;

namespace YG.ViewLocation
{
    public class InvalidViewTypeException : Exception
    {
        internal InvalidViewTypeException(Type viewType) 
            : base($"Type {viewType} is invalid, it has to implement {typeof(IView)} interface")
        { }
    }
}
