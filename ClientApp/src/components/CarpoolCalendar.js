﻿import React, { useEffect, useState } from 'react';
import { Calendar } from 'react-big-calendar';

import { localizer } from './Home';
import  md5 from 'blueimp-md5';

const eventStyles = [
    { backgroundColor: "#0d6efd", color: "white" }, // primary
    { backgroundColor: "#6c757d", color: "white" }, // secondary
    { backgroundColor: "#198754", color: "white" }, // success
    { backgroundColor: "#dc3545", color: "white" }, // danger
    { backgroundColor: "#ffc107", color: "black" }, // warning
    { backgroundColor: "#0dcaf0", color: "black" }, // info
    { backgroundColor: "#e8e9fa", color: "black" }, // light
    { backgroundColor: "#212529", color: "white" }, // dark
    { backgroundColor: "#e9ecef", color: "black" }, // gray-200
    { backgroundColor: "#495057", color: "white" } // gray-600
];



function eventPropGetter(event) {
    console.log('eventPropGetter of', event);
    let hash = md5(event.title + event.start + event.end);
    let idx = parseInt(hash[0], 16)%eventStyles.length;
    return { style: eventStyles[idx] };
}

export function CarpoolCalendar({ onSelectEventOut }) {
    let [carpoolEvents, setCarpoolEvents] = useState([]);

    function onSelectEvent(event) {
        onSelectEventOut(event);

    }

    useEffect(
        () => {
            fetch("/api/travelplans/events", { method: "GET" })
                .then(data => {
                    return data.json();
                })
                .then(json => {
                    console.log("travel plan events=", json);
                    let events = json.map(x => ({ id: x.id, start: x.startDate, end: x.endDate, title: `Carpool ${x.startLocation}->${x.endLocation} w/ ${x.employees}` }));

                    setCarpoolEvents(events);
                });
        },
        []);
    
    return (
        <div>
            <Calendar
                localizer={localizer}
                views={['month', 'agenda']}
                events={carpoolEvents}
                startAccessor="start"
                endAccessor="end"
                eventPropGetter={eventPropGetter}
                onSelectEvent={onSelectEvent}
                style={{ height: 500 }} />

        </div>
    );
}
