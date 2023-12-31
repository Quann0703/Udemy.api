﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ITeachRepository
    {
        List<teachModel> GetAll();
        teachModel GetDataById(string teachID);
        bool Create(teachModel model);
        bool Delete(string teachID);
    }
}
