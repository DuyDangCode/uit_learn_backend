using System.ComponentModel.DataAnnotations;

namespace uit_learn_backend.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class IdStringAttribute : StringLengthAttribute
    {
        public IdStringAttribute() : base(50)
        {
            MinimumLength = 24;
        }
    }
}
