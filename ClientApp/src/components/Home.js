import React, { useState } from 'react';


import "react-big-calendar/lib/css/react-big-calendar.css";
import { CreateNewTravelPlan } from './CreateNewTravelPlan';
import { CarpoolCalendar } from './CarpoolCalendar';
import { ButtonToolbar } from 'reactstrap';
import { Button} from 'reactstrap';




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