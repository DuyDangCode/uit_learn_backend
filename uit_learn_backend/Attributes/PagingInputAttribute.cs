using System.ComponentModel.DataAnnotations;

namespace uit_learn_backend.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class PagingInputAttribute : RangeAttribute
    {
        public PagingInputAttribute() : base(1, int.MaxValue)
        {
        }
    }
}
