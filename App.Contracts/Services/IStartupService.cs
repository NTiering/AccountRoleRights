using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Contracts.Services
{
    public interface IStartupService
    {
        /// <summary>
        /// Called when App starts up
        /// </summary>
        void Startup();
    }
}
