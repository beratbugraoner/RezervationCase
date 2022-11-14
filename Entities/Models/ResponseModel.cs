namespace ReservationCase.Models
{
    public class ResponseModel
    {
        public List<TicketModel> Ticket { get; set; }
        public bool IsSuccess { get; set; }
    }
}
