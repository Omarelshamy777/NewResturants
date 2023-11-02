using System.ComponentModel.DataAnnotations;

namespace NewResturants.Enums
{
    public enum OrderStatusEnum
    {
        [Display (Name ="Open")]
        Open = 0,
        [Display(Name = "Waiting For Delivery")]
        WaitingForDelivery = 1,
        [Display(Name = "Cancelled")]
        Cancelled = 2
    }
}
