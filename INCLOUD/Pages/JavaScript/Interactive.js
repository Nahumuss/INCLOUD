function Clock() {
    var today = new Date();
    var hours = today.getHours();
    var mins = today.getMinutes();
    if (mins < 10)
        var mins = "0" + mins;
    var time = "AM";
    if (hours > 12) {
        time = "PM";
        hours -= 12;
    }
    document.getElementById('clock').innerHTML = hours + ":" + mins + " " + time;
    var t = setTimeout(Clock, 500);
}