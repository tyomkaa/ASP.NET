using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_2.Models
{
    public interface IOchroniarz
    {
        bool PrzepracowaneDopCzas { get; set; }
        decimal ObliczWyplateZaDopCzas(); 
    }
}
