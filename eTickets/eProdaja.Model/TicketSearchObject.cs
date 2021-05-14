namespace eTickets.Model
{
    public class TicketSearchObject
    {
        public string Naziv { get; set; }
        public int? PodKategorijaId { get; set; }
        public int? AdminId { get; set; }
        public int? ProdavacId { get; set; }
        public bool? IncludeGrad { get; set; }
        //public string[] IncludeList { get; set; }


    }
}
