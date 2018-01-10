using System;

namespace YG.ViewLocation
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ViewModelAttribute : Attribute
    {
        public Type ViewType { get; }

        public ViewModelAttribute(Type viewType)
        {
            ViewType = viewType;
        }
    }
}
