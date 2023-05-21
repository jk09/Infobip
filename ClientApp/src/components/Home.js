import React, { useEffect, useState } from 'react';

import { Calendar, momentLocalizer } from 'react-big-calendar'
import moment from 'moment'

import "react-big-calendar/lib/css/react-big-calendar.css";
import { CreateNewTravelPlan } from './CreateNewTravelPlan';


const carpoolEvents = [];
const localizer = momentLocalizer(moment)

function CarpoolCalendar(props) {

    useEffect(
        () => {

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

export function Home(props) {


    return (
        <div>
            <h1>Infobip Carpool Management</h1>
            <p>Web application for visualizing carpool sharing, with the following
                functionalities:</p>
            <ol>
                <li>Carpool data</li>
                <li>Employee data</li>
                <li>Ride sharing data management</li>
                <li>Carpool and ride sharing view per month</li>
            </ol>
            <ul>
                <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
                <li><a href='https://facebook.github.io/react/'>React</a> for client-side code</li>
                <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
            </ul>
            <p>To help you get started, we have also set up:</p>
            <ul>
                <li><strong>Client-side navigation</strong>. For example, click <em>Counter</em> then <em>Back</em> to return here.</li>
                <li><strong>Development server integration</strong>. In development mode, the development server from <code>create-react-app</code> runs in the background automatically, so your client-side resources are dynamically built on demand and the page refreshes when you modify any file.</li>
                <li><strong>Efficient production builds</strong>. In production mode, development-time features are disabled, and your <code>dotnet publish</code> configuration produces minified, efficiently bundled JavaScript files.</li>
            </ul>
            <p>The <code>ClientApp</code> subdirectory is a standard React application based on the <code>create-react-app</code> template. If you open a command prompt in that directory, you can run <code>npm</code> commands such as <code>npm test</code> or <code>npm install</code>.</p>


            <div>
                <h2>Carpool</h2>

                <hr />
                <CreateNewTravelPlan />
                
                <CarpoolCalendar />
            </div>
        </div>



    );

}