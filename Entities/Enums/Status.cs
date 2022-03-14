using System.ComponentModel;

namespace Entities.Enums
{
    public enum Status
    {
        [Description("Заинтересован")]
        Interested,
        [Description("Обработано")]
        Processed,
        [Description("Отказ")]
        Rejected,
        [Description("Продано")]
        Sold
    }
}