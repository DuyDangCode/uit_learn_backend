using System.ComponentModel.DataAnnotations;

namespace uit_learn_backend.Attributes
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class CodeAttribute : StringLengthAttribute
    {
        public CodeAttribute() : base(50)
        {
            MinimumLength = 2;
        }
    }
}
