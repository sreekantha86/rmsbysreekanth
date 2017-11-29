using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RigServiceSystem
{
    public class InpectionItemRemarks
    {
        public int ProdColorId { get;set; }
        public string PieceType { get; set; }
        public List<string> Remarks { get; set; }
        public bool isSaved { get; set; }
    }
}
