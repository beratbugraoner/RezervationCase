namespace ReservationCase.Models
{
    public class RequestModel 
    {
        public TrainModel Train { get; set; }
        public int TicketsNumber { get; set; }  
        public bool CanBeReplaceVagon { get; set; } = false; 
    }
}
