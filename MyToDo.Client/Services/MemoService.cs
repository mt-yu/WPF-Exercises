﻿using MyToDo.Share.DataTransfers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Client.Services
{
    public class MemoService : BaseService<MemoDto>, IMemoService
    {
        public MemoService(HttpRestClient client) : base(client, "Memo")
        {
        }
    }
}
