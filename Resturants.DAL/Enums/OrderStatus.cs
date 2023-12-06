using System.ComponentModel.DataAnnotations;

namespace Resturants.DAL.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Open")]
        Open = 11,
        [Display(Name = "Waiting For Delivery")]
        WaitingForDelivery = 12,
        [Display(Name = "Cancelled")]
        Cancelled = 13
    }
}
