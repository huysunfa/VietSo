using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVietSo.Models
{
    public class ExcelPerson
    {
        
        public Cell MaCell { get; set; }
        public Cell NameCell { get; set; }
        public Cell YearCell { get; set; }
        public Cell GenderCell { get; set; }
        public Cell MenhCell { get; set; }
        public Cell SaoCell { get; set; }
        public Cell AddressCell { get; set; }
        public Cell NoteCell { get; set; }
    }
}