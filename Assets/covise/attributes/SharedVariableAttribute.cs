using System;

namespace covise.attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class SharedVariableAttribute : Attribute
    {
        public string className { get; private set; } = null;
        public string variableName { get; private set; } = null;

        public SharedVariableAttribute()
        {
            className = null;
            variableName = null;
        }
        
        public SharedVariableAttribute(string variableName)
        {
            className = null;
            this.variableName = variableName;
        }

        public SharedVariableAttribute(string className, string variableName)
        {
            this.className = className;
            this.variableName = variableName;
        }

    }
}