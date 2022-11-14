using Business.Abstract;
using ReservationCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TicketManager : ITicketService
    {
        public ResponseModel CheckReservation(RequestModel request)
        {
            
            var vagons = request.Train.Vagon;
            List<TicketModel> ticketList = new List<TicketModel>();

            if (vagons.Count() < 1) return new ResponseModel { IsSuccess = false }; // gecerli vagon sayısı yoksa

            if (request.CanBeReplaceVagon)
            {
                var ticketsLeft = request.TicketsNumber;
                int ticketCount = 0;
              

                if (ticketsLeft == 0) return new ResponseModel { IsSuccess = false }; // yerlesen sayisi yoksa
                for (int i = 0; i < vagons.Count(); i++)
                {
                    int ticketBooked = 0;
                    if (ticketCount == request.TicketsNumber) break;
                    
                    for (int k = 0; k < ticketsLeft; k++)
                    {
                       
                        if (((double)vagons[i].VagonOccupancy / (double)vagons[i].VagonCapacity)<0.7)
                        {
                            ticketsLeft--;
                            ticketCount++;
                            ticketBooked++;
                            request.Train.Vagon[i].VagonOccupancy++;
                        }
                    }
                    
                    ticketList.Add(new TicketModel { VagonName = vagons[i].VagonName, TicketsNumber = ticketBooked });
                  
                  
                }
                if (ticketCount == request.TicketsNumber) // tüm biletler yerlestiyse
                {
                    return new ResponseModel { IsSuccess = true, Ticket = ticketList };

                }

            }

            for (int i = 0; i < vagons.Count(); i++)
            {
                if ((((double)vagons[i].VagonOccupancy+ (double)request.TicketsNumber)/ (double)vagons[i].VagonCapacity)<0.7)
                {
                    ticketList.Add(new TicketModel { VagonName = vagons[i].VagonName, TicketsNumber = request.TicketsNumber });
                    return new ResponseModel { IsSuccess = true, Ticket = ticketList };
                }
            }

            return new ResponseModel { IsSuccess = false};

        }
    }
}
