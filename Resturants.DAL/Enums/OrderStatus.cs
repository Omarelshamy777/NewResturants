using System.ComponentModel.DataAnnotations;

namespace Resturants.DAL.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Open")]
        Open = 0,
        [Display(Name = "Waiting For Delivery")]
        WaitingForDelivery = 1,
        [Display(Name = "Cancelled")]
        Cancelled = 2
    }
}
