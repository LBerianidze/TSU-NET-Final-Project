using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorationMarket.Domain.DBModel
{
    public class UploadedFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime CreateDate { get; set; }
        public Product Product { get; set; }
    }
}
