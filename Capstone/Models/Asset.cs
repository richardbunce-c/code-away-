﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Asset
    {
        public int PortfolioID { get; set; }
        public decimal QuantityHeld { get; set; }
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public decimal CurrentPrice { get; set; }
        public int AssetId { get; set; }

        


    }

    public class UpdateAsset
    {
        public int PortfolioID { get; set; }
        
        public decimal QuantityAdjustment { get; set; }
        public int AssetId { get; set; }
        public decimal USDAdjustment { get; set; }


    }


        //public class ReturnPortfolio
        //{
        //            public int UserGameID { get; set; }
        //    public decimal Balance { get; set; }
        //    public int QuantityHeld { get; set; }
        //    public string StockTicker { get; set; }
        //    public string CompanyName { get; set; }
        //    public decimal CurrentPrice { get; set; }
        //    public decimal CostBasis { get; set; }
        //    public DateTime Time { get; set; }
        //}


    }
