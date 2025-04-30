﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbsrt
{
    public interface IServiceManger
    {
        public IProductService ProductService { get; }
        public IBasketService BasketService { get; }
    }
}
