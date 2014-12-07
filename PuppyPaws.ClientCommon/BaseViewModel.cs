using GalaSoft.MvvmLight;
using PuppyPaws.Contracts;
using PuppyPaws.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyPaws.ClientCommon
{
    public class BaseViewModel : ViewModelBase
    {
        public IContractFactory Factory { get; set; }

        public BaseViewModel()
        {
            this.Factory = new Factory.ContractFactory();
        }
    }
}
