using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuto_Pattern_State
{
    public interface IState
    {
        void ChangeEtat(DistributeurAutomatique context);
    }
}
