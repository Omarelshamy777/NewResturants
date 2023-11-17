﻿
using Resturants.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Contracts.ResturantApp.Dtos
{
    public class OrderRequestDto
    {

        public int OrderID { get; set; }
        public int CustomerId { get; set; }
        public string? OrderNumber { get; set; }

        public double? Price { get; set; }
        public OrderStatus OrderStaus { get; set; }


        public string? FoodName { get; set; }
        public string? Categories { get; set; }
        public int ResturantID { get; set; }
        public string? ResturantName { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
        public List<Item>? Items { get; set; }

    }
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
