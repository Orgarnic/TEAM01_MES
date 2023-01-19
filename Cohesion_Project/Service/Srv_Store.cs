﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cohesion_DAO;
using Cohesion_DTO;

namespace Cohesion_Project
{
    public class Srv_Store
    {
        public List<Store_DTO> SelectStoreList()
        {
            Store_DAO db = new Store_DAO();
            List<Store_DTO> list = db.SelectStoreList();
            db.Dispose();

            return list;
        }
    }
}
