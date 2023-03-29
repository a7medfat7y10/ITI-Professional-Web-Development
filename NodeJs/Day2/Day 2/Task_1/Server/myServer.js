
let {FlightTicketsReservation} = require("../Modules/myModule");

let FTR = new FlightTicketsReservation();
FTR.AddTicket(1, 4, 2, 'cairo', 'paris', '12/4/2008');
FTR.AddTicket(2, 6, 2, 'italy', 'germany', '12/4/2008');
FTR.AddTicket(3, 4, 2, 'mosko', 'london', '12/4/2008');

console.log('Display all tickets:');
FTR.DisplayAllTickets();

console.log('Get ticket info:');
FTR.GetInfo(2);

FTR.UpdateTicket(3, 4, 6, 'tokyo', 'london', '12/8/2008');
FTR.GetInfo(3);