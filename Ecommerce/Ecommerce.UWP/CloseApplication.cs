using Ecommerce.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;

namespace Ecommerce.UWP
{
    public class CloseApplication : ICloseApplication
    {
        public void closeApplication()
        {
            CoreApplication.Exit();
        }
    }
}
