﻿using GNB_Data.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB_Service.Services
{
    public interface IConversionRate
    {
        Task<RateResponseDTO> GetConversionRates();
        Task GetDefaultConversion(GNBTransactionResponse gNBTransactionResponse, string defaultCoin);
    }
}
