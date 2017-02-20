var totalSeats = 120;
var seatsAvailable = 10;;
var bookingDetails = [];
var tempSeatArray = [];
var totalSelctedSeat = [];
var enableSelection = false;
var bookingObj = {};
var totalSeatToBeSelected = 0;
var sc;
$(document).ready(function () {
    debugger;
    enableSelection = false;
    totalSeatToBeSelected = 0;
    tempSeatArray = [];
    bookingObj = {};
    bindBookingDetails();
    debugger;
    //localStorage.setItem("total-selected-seat", JSON.stringify([]));
    //localStorage.setItem("booking-details", JSON.stringify([]))
    totalSelctedSeat = JSON.parse(localStorage.getItem("total-selected-seat"));
    try
    {
        seatsAvailable = totalSeats - totalSelctedSeat.length;
    }
    catch(e)
    {
        seatsAvailable = 120;
    }
    if (totalSelctedSeat === null || totalSelctedSeat === undefined)
        totalSelctedSeat = [];
    disableButton_Confirm();
    setSeats();
    //sold seat
    debugger;
    setUnavailability();

});

function setSeats() {
    sc = $('#seat-map').seatCharts({
        map: [  //Seating chart
			'aaaaaaaaaaaa',
            'aaaaaaaaaaaa',
            'aaaaaaaaaaaa',
            'aaaaaaaaaaaa',
            'aaaaaaaaaaaa',
			'aaaaaaaaaaaa',
			'aaaaaaaaaaaa',
			'aaaaaaaaaaaa',
			'aaaaaaaaaaaa',
            'aaaaaaaaaaaa'
        ],

        naming: {
            top: true,
            getLabel: function (character, row, column) {
                return column;
            },
            left: true,
            rows: ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'],
            getId: function (character, row, column) {
                return row + column;
            }
        },
        legend: { 
            node: $('#legend'),
            items: [
				['a', 'available', 'Available'],
				['a', 'unavailable', 'Sold']
            ]
        },
        click: function () { 
            debugger;
            var personName = $("#personName").val();
            var seatCount = $("#totalTicket").val();
            if (chkUnavailability(this.settings.id)) {
                return 'unavailable';
            }
            if (!enableSelection) {
                if (personName === undefined || personName === '') {
                    alert("Enter Person Name");
                    $("#personName").focus();
                    return;
                }
                if (seatCount === undefined || seatCount === '') {
                    alert("Enter No of seats");
                    $("#totalTicket").focus();
                    return;

                }
                alert("Click on 'Start Selecting'");
                return;
            }
            if (this.status() == 'available') { 
                if (tempSeatArray.length >= totalSeatToBeSelected) {
                    alert('You have already selected ' + totalSeatToBeSelected + ' seat(s). For more seat enter the no of seat and click on Start Selection');
                    debugger;
                    return;
                }
                debugger;
                bookingObj.name = personName;
                bookingObj.count = totalSeatToBeSelected;
                tempSeatArray.push(this.settings.id);
                return 'selected';
            } else if (this.status() == 'selected') { 
                debugger;
                var index = tempSeatArray.indexOf(this.settings.id);
                if (index > 0) {
                    tempSeatArray.splice(index, 1);
                }
                return 'available';
            } else if (this.status() == 'unavailable') { 
                return 'unavailable';
            } else {
                return this.style();
            }
        }
    });
}


function setBookingDetails() {
    debugger;
    bookingObj.details = tempSeatArray;
    bookingDetails = JSON.parse(localStorage.getItem("booking-details"));
    if (bookingDetails === undefined || bookingDetails === null)
        bookingDetails = [];
    bookingDetails.push(bookingObj);
    localStorage.setItem("booking-details", JSON.stringify(bookingDetails));

}

function setUnavailability() {
    debugger;
    sc.get(totalSelctedSeat).status('unavailable');
}

function chkUnavailability(seatid) {
    debugger;
    return totalSelctedSeat.indexOf(seatid) >= 0;
}

function confirmBooking() {
    debugger;
    totalSelctedSeat = totalSelctedSeat.concat(tempSeatArray);
    localStorage.setItem("total-selected-seat", JSON.stringify(totalSelctedSeat));
    setBookingDetails();
    enableSelection = false;
    tempSeatArray.length = 0;
    bindBookingDetails();
    setUnavailability();
    disableButton_Confirm();
    $("#totalTicket").val('');
    $("#personName").val('');
}

function disableButton_Confirm() {
    debugger;
    if (enableSelection) {
        $("#btnCnfrm").removeAttr("disabled");
    }
    else {
        $("#btnCnfrm").attr('disabled', 'disabled');
    }
}

function startSelection() {
    debugger;
    
    sc.find('selected').each(function () {
        debugger;
        sc.status(this.settings.id, 'available');
        tempSeatArray.length = 0;
    });

    var personName = $("#personName").val();
    var seatCount = $("#totalTicket").val();
    if (!enableSelection) {
        if (personName === undefined || personName === '') {
            alert("Enter Person Name");
            $("#personName").focus();
            return;
        }
        if (seatCount === undefined || seatCount === '') {
            alert("Enter No of seats");
            $("#totalTicket").focus();
            return;

        }
    }
    totalSeatToBeSelected = $("#totalTicket").val();
    if (seatsAvailable < totalSeatToBeSelected) {
        alert("Sorry , only" + seatsAvailable + " can be selected");
        return;
    }
    enableSelection = true;

    setSeats();
    disableButton_Confirm();
}



function checkSeat() {
    var val = $("#totalTicket").val();
    if (parseInt(val) < 1) {
        alert("Seat no cannot be less than 1");
        $("#totalTicket").val('');
        return;
    }
    if (parseInt(val) > 10) {
        alert("Seat no cannot be greater than 10");
        $("#totalTicket").val('');
        return;
    }
}


function bindBookingDetails() {
    var bookingDetails;
    try {
        bookingDetails = JSON.parse(localStorage.getItem("booking-details"));
    }
    catch (e) {
        console.log(e);
        bookingDetails = [];
    }
    if (bookingDetails === undefined || bookingDetails === null)
        bookingDetails = [];
    var table = "<table><tr>";
    table += "<th> Name </th>";
    table += "<th>Seat Count</th>";
    table += "<th>Seat Details</th></tr>";
    debugger
    for(var booking of bookingDetails)
    {
        table += "<tr><td>" + booking.name + "</td>";
        table += "<td>" + booking.count + "</td>";
        table += "<td>" + booking.details + "</td></tr>";
    }
    table += "</table>";
    $("#dvDetails").html(table);
}