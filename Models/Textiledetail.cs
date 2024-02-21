using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace INTEXAPP2.Models
{
    public partial class Textiledetail
    {
        
        public long? MainBurialmainid { get; set; }
        public string? Color { get; set; }
        public string? Locale { get; set; }
        public string? Description { get; set; }
        public string? Burialnumber { get; set; }
        public string? Estimatedperiod { get; set; }
        public DateTime? Sampledate { get; set; }
        public DateTime? Photographeddate { get; set; }
        public string? Direction { get; set; }
        public string? TextileFunction { get; set; }
        public string? TextileStructure { get; set; }
    }
}
