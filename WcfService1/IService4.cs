﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService4" in both code and config file together.
    [ServiceContract(SessionMode=SessionMode.Required)]
    public interface IService4
    {
        [OperationContract(IsInitiating=true)]
        void Operation1();
        [OperationContract(IsInitiating =false)]
        void Operation2();
        [OperationContract(IsInitiating = false, IsTerminating= true)]
        void Operation3();
    }
}
