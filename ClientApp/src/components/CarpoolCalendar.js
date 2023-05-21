import React, { useEffect, useState } from 'react';
import { Calendar } from 'react-big-calendar';

import { localizer } from './Home';

const bootstrapColors = [
    '#0275d8', // primary blue
    '#5cb85c', // success green
    '#5bc0de', // info cyan
    '#f0ad4e', // warning orange
    '#d9534f', // danger red
    '#292b2c', // dark gray
    '#f7f7f7', // light gray
    '#6c757d', // secondary gray
    '#28a745', // success green (Bootstrap 5)
    '#dc3545' // danger red (Bootstrap 5)
];

export function CarpoolCalendar(props) {
    let [carpoolEvents, setCarpoolEvents] = useState([]);

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
                events={carpoolEvents}
                startAccessor="start"
                endAccessor="end"
                style={{ height: 500 }} />
        </div>
    );
}
