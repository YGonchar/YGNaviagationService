using System;

namespace YG.ViewLocation
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ViewModelAttribute : Attribute
    {
        public Type ViewModeType { get; }

        public ViewModelAttribute(Type viewModeType)
        {
            ViewModeType = viewModeType;
        }
    }
}
