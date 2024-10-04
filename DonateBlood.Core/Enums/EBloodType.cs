using System.ComponentModel;

namespace DonateBlood.Core.Enums
{
    public enum EBloodType
    {
        [Description("A")]
        A = 0,
        [Description("B")]
        B = 1,
        [Description("AB")]
        AB = 2,
        [Description("O")]
        O = 3,
    }
}
