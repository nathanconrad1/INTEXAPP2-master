namespace INTEXAPP2.Models.ViewModels
{
    public class PageDetails
    {
        public int totalBurials { get; set; }
        public int BurialsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling(((double)totalBurials / BurialsPerPage));
    }
}
