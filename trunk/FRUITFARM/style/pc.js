var calWindow;
var targetField;
var today = new Date();
var dayofmonth = today.getDate();
var startDate;
var selectDate;
var prevMonth;
var prevYear;
var currMonth;
var currYear;
var nextMonth;
var nextYear;
var days = new Array('Sun','Mon','Tue','Wed','Thr','Fri','Sat');
var months = new makeArray(12);

function makeArray(arrayLength) {   // create empty array
   this.length = arrayLength;

   for (var i = 1; i <= arrayLength; i++)
      this[i] = 0;

   return this;
}

function month(name, length, index) {   // create month object
   // properties
   this.name   = name;
   this.length = length;
   this.index  = index;

   // method
   this.getFirstMonthDay = getFirstMonthDay;
}

function makeMonthArray() {    // create array of 12 month objects
   months[1]  = new month("January", 31, 0);
   months[2]  = new month("February", 28, 1);
   months[3]  = new month("March", 31, 2);
   months[4]  = new month("April", 30, 3);
   months[5]  = new month("May", 31, 4);
   months[6]  = new month("June", 30, 5);
   months[7]  = new month("July", 31, 6);
   months[8]  = new month("August", 31, 7);
   months[9]  = new month("September", 30, 8);
   months[10] = new month("October", 31, 9);
   months[11] = new month("November", 30, 10);
   months[12] = new month("December", 31, 11);
}

function initCalendar() {
   makeMonthArray();
//   startDate='9/9/2002';
   if (selectDate == "") {
      if (startDate == "") {
         currMonth = today.getMonth() - 0 + 1;
         currYear = today.getFullYear();

         selectDate = currMonth + "/" + dayofmonth + "/" +  currYear;
      }
      else
         selectDate = startDate;
   }
	
   if (startDate == "")
      startDate = selectDate;
   curDat = new Date(startDate);
   if (isNaN(curDat)){curDat = new Date();} // if startDate not a valid date, set to current date

   currMonth = curDat.getMonth() - 0 + 1;
   currYear = curDat.getFullYear();
//   currMonth = startDate.substring(0, startDate.indexOf("/"));
//   currYear = startDate.substring(startDate.lastIndexOf("/")+1, startDate.length);
   if (currYear<1950) {currYear = currYear + 100;}
//     if (currYear < 51) {currYear = 20 + currYear;}
//     else               {currYear = 19 + currYear;} }

   //Determines previous month and year for Prev button on <strong class="highlight">calendar</strong>
   prevMonth = currMonth - 1;
   if (prevMonth == 0) {
      prevMonth = 12;
      prevYear = currYear - 1;
   }
   else  // set month to prev month
      prevYear = currYear;

   //Determines next month and year for Next button on <strong class="highlight">calendar</strong>
   nextMonth = currMonth - 0 + 1;
   if (nextMonth == 13) {
      nextMonth = 1;
      nextYear = currYear - 0 + 1;
   }
   else  // set month to next month
      nextYear = currYear;
}

function getFirstMonthDay(theYear) {    // get week-day of first day of month
   var firstDay = new Date(theYear, this.index, 1);
   return firstDay.getDay();
}

function getNumFebDays(theYear) {     // calc num days in February
   if ((theYear % 4 == 0 && theYear % 100 != 0) || theYear % 400 == 0)
      return 29;
   else
      return 28;
}

function calendarHref(direction) {
   var m;
   var y;

   switch (direction){
      case -1:
         m = prevMonth;
         y = prevYear;
         break;
      case 1:
         m = nextMonth;
         y = nextYear;
         break;
   }
   retVal = "javascript<b></b>:window.opener.popupCalendar('"+targetField+"','"+m+"/1/"+y+"','"+selectDate+"');"
   return retVal
}

function drawCalendar() {             // draw day numbers in cal table
   var theYear = currYear;
   var month = currMonth;
   if (month == 2)
      months[2].length = getNumFebDays(theYear - 1900);
   var firstMonthDay = months[month].getFirstMonthDay(theYear);
   var numMonthDays  = months[month].length;

   // to keep count of how many days we have displayed in each month
   var daycounter = 1;

   // style sheet
   calWindow.document.write("<STYLE type=text/css>");
   calWindow.document.write(".TABLEHEAD {BACKGROUND-COLOR: #6666FF; COLOR: #FFFFFF;  FONT-FAMILY: Arial; FONT-SIZE: x-small; FONT-STYLE: normal; FONT-WEIGHT: bold}");
   calWindow.document.write(".DAYS {BACKGROUND-COLOR: #9999FF; COLOR: #000099; FONT-FAMILY: Arial; FONT-SIZE: x-small; FONT-STYLE: normal; FONT-WEIGHT: bold}");
   calWindow.document.write(".SELECTED {BACKGROUND-COLOR: #CCCCFF; COLOR: #0000FF; FONT-FAMILY: Arial; FONT-SIZE: x-small; FONT-STYLE: normal; FONT-WEIGHT: bold}");
   calWindow.document.write(".ANOTHERMONTH {BACKGROUND-COLOR: #EEEEFF; COLOR: #000000; FONT-FAMILY: Arial; FONT-SIZE: x-small; FONT-STYLE: normal; FONT-WEIGHT: normal}");
   calWindow.document.write(".TODAY {BACKGROUND-COLOR: #CCCCFF; COLOR: #FF0000; FONT-FAMILY: Arial; FONT-SIZE: x-small; FONT-STYLE: normal; FONT-WEIGHT: bold}");
   calWindow.document.write(".CURRENTMONTH {BACKGROUND-COLOR: #CCCCFF; COLOR: #000000; FONT-FAMILY: Arial; FONT-SIZE: x-small; FONT-STYLE: normal; FONT-WEIGHT: normal}");
   calWindow.document.write(".INPUT {BACKGROUND-COLOR: #3333FF; COLOR: #FFFFFF; FONT-FAMILY: Arial; FONT-SIZE: x-small; FONT-STYLE: normal; FONT-WEIGHT: bold}");
   calWindow.document.write("</STYLE>");

   // basic table html
   calWindow.document.write( "<TABLE border=1 borderColor=#ffffff cellPadding=4 cellSpacing=0");

   // writes a Prev link, month and year, and Next Link
   calWindow.document.write("<TR align=center>");
   calWindow.document.write("<TD colspan=1 CLASS=TABLEHEAD><A CLASS=TABLEHEAD HREF=" + calendarHref(-1) + "><<</a></td>");
   calWindow.document.write("<TD align=center colspan=5 CLASS=TABLEHEAD><B>" + months[month].name + " " + currYear + "</B></TD>");
   calWindow.document.write("<TD colspan=1 CLASS=TABLEHEAD><A CLASS=TABLEHEAD HREF=" + calendarHref(1) + ">>></a></td>");
   calWindow.document.write("</TR>");

   // writes the days of the week
   calWindow.document.write("<TR align=center bgcolor=#EEEEEE>");
   for(var d=0;d<7;d++)
      calWindow.document.write("<TD width=14% CLASS=DAYS><SMALL><B>&nbsp;" + days[d] + "&nbsp;</B></SMALL></TD>");
   calWindow.document.write("</TR>");

   // allows month to possibly span over 6 weeks
   for(var i=0; i<6; i++) {
      calWindow.document.write("<TR align=center>");

      // display each day of the week
      for(var j=0;j<7;j++) {
         var tMonth, tDay, tYear, tDate;

         // if we are not displaying the current month
         if( (i==0 && j<firstMonthDay) || daycounter>months[month].length ) {
            if (daycounter>months[month].length) {
               tMonth = nextMonth;
               tDay = daycounter-months[month].length;
               tYear = nextYear;
               daycounter++;
            }
            else {
               tMonth = prevMonth;
               tDay = months[prevMonth].length-firstMonthDay+1+j;
               tYear = prevYear;
            }
            tDate = tMonth + "/" + tDay + "/" +  tYear;
            tClass = "ANOTHERMONTH";
         //if we are displaying the current date
         }
         else if((daycounter==today.getDate()) && (currMonth==today.getMonth()-0+1) && (currYear==today.getYear())) {
            tDay = daycounter;
            tDate = currMonth + "/" + daycounter + "/" +  currYear;
            tClass = "TODAY";
            daycounter++;
         // if we are displaying the current month
         }
         else {
            tDay = daycounter;
            tDate = currMonth + "/" + daycounter + "/" +  currYear;
            tClass = "CURRENTMONTH";
            daycounter++;
         }

         if (selectDate == tDate)
            tClass = "SELECTED";

         calWindow.document.write("<TD width=14% CLASS=" + tClass + "><A CLASS=" + tClass + " HREF=" + "javascript<b></b>:window.opener.document."+targetField+".value='"+tDate+"';window.close();" + ">" + tDay + "</A></TD>");
      }
      calWindow.document.write("</TR>");
   }
   calWindow.document.write("</TABLE>");
}

function popupCalendar(target, start, select) {
   targetField = target;
   startDate = start;
   selectDate = select;

   var w=250; var h=230; var t; var l;
   if (navigator.appName=="Microsoft Internet Explorer"){
     t = (document.calimg.offsetTop + window.screenTop) -60;
     l = (document.calimg.offsetLeft + window.screenLeft) -10;
   } else {
     t = (document.calimg.offsetTop + screenY)-400;
     l = (document.calimg.offsetLeft + screenX);
   }

   calWindow = window.open("", "<strong class="highlight">Calendar</strong>", "width="+w+",height="+h+",status=yes,resizable=no,top="+t+",left="+l);
   calWindow.opener = self;
   calWindow.focus();
   calWindow.document.close();

   initCalendar();
   drawCalendar();
}