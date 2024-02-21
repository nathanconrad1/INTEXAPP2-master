using Microsoft.CodeAnalysis;

namespace INTEXAPP2.Models
{
    public class SummaryView
    {
        public long? Id { get; set; }
        public List<Textiledetail>? TextileList { get; set; }

        public string? sex { get; set; }
        //WHY?!?!?!?!??!?!! Who decided to set depth to string in the database?!?!?!?!!
        public string? depth { get; set; }
        public double? stature { get; set; }
        public string? age { get; set; }
        public string? headdirection { get; set; }
        public string? haircolor { get; set; }
    }

    public class Cleaned_Textile
    {
        public string? color { get; set; }
        public string? structure { get; set; }
        public string? textile_function { get; set; }

    }
}
