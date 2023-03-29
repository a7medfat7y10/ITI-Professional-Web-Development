
class FlightTicket{
    
    constructor(_id, _s, _f, _d, _a, _tr){
        this.ticketId = _id;
        this.seatNum = _s;
        this.flightNum = _f;
        this.departureAirport = _d;
        this.arrivalAirport = _a;
        this.travellingDate = _tr;

    }
}


class FlightTicketsReservation{
    Tickets = [];
    AddTicket(_id, _s, _f, _d, _a, _tr) {
        let newTicket = new FlightTicket(_id, _s, _f, _d, _a, _tr);
        this.Tickets.push(newTicket);
    }

    DisplayAllTickets(){
        for(let i = 0; i < this.Tickets.length; i++){
            console.log(` This Ticket id ${this.Tickets[i].ticketId},
            Seat number: ${this.Tickets[i].seatNum},
            Departure Airport: ${this.Tickets[i].departureAirport}, 
            Arrival Airport: ${this.Tickets[i].arrivalAirport},
            Flight Number: ${this.Tickets[i].flightNum},
            Travelling Date: ${this.Tickets[i].travellingDate} ` );
        }
    }

    GetInfo(_id){
        for(let i = 0; i < this.Tickets.length; i++){
            if(this.Tickets[i].ticketId == _id){
                console.log(` This Ticket id ${this.Tickets[i].ticketId},
                Seat number: ${this.Tickets[i].seatNum},
                Departure Airport: ${this.Tickets[i].departureAirport}, 
                Arrival Airport: ${this.Tickets[i].arrivalAirport},
                Flight Number: ${this.Tickets[i].flightNum},
                Travelling Date: ${this.Tickets[i].travellingDate} ` );
            }
            else
                continue;
        }
    }

    UpdateTicket(_id, _s, _f, _d, _a, _tr){
        for(let i = 0; i < this.Tickets.length; i++){
            if(this.Tickets[i].ticketId == _id){
                this.Tickets[i].seatNum = _s;
                this.Tickets[i].flightNum = _f
                this.Tickets[i].departureAirport = _d
                this.Tickets[i].arrivalAirport = _a;
                this.Tickets[i].travellingDate = _tr;
                console.log(`Ticket No ${this.Tickets[i].ticketId} successfully updated`);
            }
            else
                continue;
        }
    }
}

module.exports = {
    FlightTicketsReservation
}