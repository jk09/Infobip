import React, { useEffect, useState } from 'react';
import { Calendar } from 'react-big-calendar';
import { localizer } from './Home';

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
