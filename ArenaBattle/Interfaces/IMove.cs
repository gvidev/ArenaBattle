using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaBattle.Interfaces
{
    public interface IMove
    {
        int horizontalSpeed { get; set; }

        void Move();
    }
}
