﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TenmoClient.Data
{
    public class API_Transfer
    {
        public int TransferId { get; set; }

        public int TransferTypeId { get; set; }

        public int TransferStatusId { get; set; }

        public int AccountFrom { get; set; }

        public int AccountTo { get; set; }

        public decimal Amount { get; set; }

        public string TransferDescription { get; set; }
    }
}
