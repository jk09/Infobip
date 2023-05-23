import React, { useState } from 'react';


import "react-big-calendar/lib/css/react-big-calendar.css";
import { CreateNewTravelPlan } from './CreateNewTravelPlan';
import { CarpoolCalendar } from './CarpoolCalendar';
import { ButtonToolbar } from 'reactstrap';
import { Button, Form, FormGroup, Label, Input, Col, Collapse, Card, CardBody, FormFeedback, Alert } from 'reactstrap';




export function Home(props) {
    let [isOpen, setIsOpen] = useState(false);
    let [mode, setMode] = useState(null);
    let [selectedEvent, setSelectedEvent] = useState(null);
    let [createDisabled, setCreateDisabled] = useState(false);
    let [editDisabled, setEditDisabled] = useState(true);

    function onSelectEvent(event) {
        console.log("onSelectEvent", event);
        setSelectedEvent(event);
        setEditDisabled(false);
    }

   

    function onButtonCreateNewTravelPlan() {
        setEditDisabled(true);
        setSelectedEvent(null);
        setMode("new");
        setIsOpen(true);
    }


    function onButtonEditTravelPlan() {
        setCreateDisabled(true);

        setMode("edit");
        setIsOpen(true);

    }

    function onCancel(event) {
        window.location.reload();

    }

 
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
                <ButtonToolbar>
                    <Button color="primary" type="button" style={{ marginBottom: '1rem' }} disabled={ createDisabled} onClick={onButtonCreateNewTravelPlan}>Create new travel plan</Button>
                    &emsp;
                    <Button color="secondary" type="button" style={{ marginBottom: '1rem' }} disabled={editDisabled} onClick={onButtonEditTravelPlan}>Edit travel plan</Button>

                </ButtonToolbar>

                <CreateNewTravelPlan mode={mode} selectedEvent={selectedEvent} isOpen={isOpen} onCancel={onCancel}  />

                <CarpoolCalendar onSelectEvent={onSelectEvent} onCancel={onCancel} />
            </div>
        </div>



    );

}