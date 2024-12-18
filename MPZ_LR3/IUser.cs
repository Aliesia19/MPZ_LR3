using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZ_LR3
{
    public interface IUser
    {
        string Role { get; }
        void DisplayActions();
    }

}
