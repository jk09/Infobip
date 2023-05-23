import React, { useEffect, useState } from 'react';
import { Button, Form, FormGroup, Label, Input, Col, Collapse, Card, CardBody, FormFeedback,Alert,Badge } from 'reactstrap';
import { FaEdit } from 'react-icons/fa';

import moment from 'moment'

export function CreateNewTravelPlan({ mode, selectedEvent,  isOpen, onSubmit, onCancel }) {

    let [cars, setCars] = useState([]);
    let [employees, setEmployees] = useState([]); 
    let [error, setError] = useState(null);
    let [startLocation, setStartLocation] = useState("");
    let [endLocation, setEndLocation] = useState("");
    let [startDate, setStartDate] = useState("");
    let [endDate, setEndDate] = useState("");
    let [selectedCar, setSelectedCar] = useState("");
    let [selectedEmployees, setSelectedEmployees] = useState([]);


    useEffect(() => {
        // fetch the data from the backend
        fetch("/api/createnewtravelplan/cars",{method:"GET"})
            .then(data => {
                return data.json();
            })
            .then(json => {
                console.log("cars data=", json);

                setCars(json);
            })
            .catch(err => console.error(err));

        fetch("/api/createnewtravelplan/employees", { method: "GET" })
            .then(data => {
                return data.json();
                
            })
            .then(json => {
                console.log("employee data=", json);
                setEmployees(json);
            })
            .catch(err => console.error(err));

        if (mode === "edit") {
            fetch(`/api/travelplans/travelplan/${selectedEvent.id}`, { method: "GET" })
                .then(data => data.json())
                .then(json => {
                    console.log("got editable travel plan", json);

                    setStartLocation(json.startLocation);
                    setEndLocation(json.endLocation);

                    function fmtdate(date) {
                        return moment(date).format("YYYY-MM-DD");
                    }


                    setStartDate(fmtdate(json.startDate));
                    setEndDate(fmtdate(json.endDate));

                    let car = json.carId;
                    setSelectedCar(car);
                    let emps = json.employees.map(x => x.id);
                    setSelectedEmployees(emps);
                    
                });
        }
    }, [mode, selectedEvent]);

    function handleSubmit(event) {
        event.preventDefault();

        let startLocation = event.target.querySelector('#startLocation').value;
        let endLocation = event.target.querySelector('#endLocation').value;
        let startDate = event.target.querySelector('#startDate').value;
        let endDate = event.target.querySelector('#endDate').value;

        let carOptions = event.target.querySelectorAll('#car option');
        console.log('carOptions', carOptions);
        let carId = [...carOptions].filter(x => x.selected)[0].getAttribute("id");
        console.log("selected car id", carId);

        let empOpts = event.target.querySelectorAll('#employees option');
        console.log('employeeOptions', empOpts);
        let empIds = [...empOpts].filter(x => x.selected).map(x => parseInt(x.id));

        let data = new FormData(event.target);
        data.append("Id", 0);
        data.append("StartLocation", startLocation);
        data.append("EndLocation", endLocation);
        data.append("StartDate", startDate);
        data.append("EndDate", endDate);

        data.append("CarId", carId);
        data.append("EmployeeIds", JSON.stringify(empIds));

        console.log(`${mode==='new' ? 'submitting':'updating'}  travel plan data=`, data, startLocation, endLocation, startDate, endDate, carId, JSON.stringify(empIds));

        if (mode === "new") {

            fetch("/api/createnewtravelplan/submit", { method: "POST", body: data })
                .then(resp => {
                    console.log('submit fetch response', resp);
                    if (resp.ok) {
                        window.location.reload();
                    }
                    else {
                        resp.json().then(function (data) {

                            console.log("submit fetch response data", data);
                            setError(data.detail || JSON.stringify(data.errors));

                        });
                    }

                })
                .catch(err => console.error(err));
        } else if (mode === "edit") {
            fetch(`/api/createnewtravelplan/update/${selectedEvent.id}`, { method: "PUT", body: data })
                .then(resp => {
                    console.log('submit fetch response', resp);
                    if (resp.ok) {
                        window.location.reload();
                    }
                    else {
                        resp.json().then(function (data) {

                            console.log("submit fetch response data", data);
                            setError(data.detail || JSON.stringify(data.errors));

                        });
                    }

                })
                .catch(err => console.error(err));
        }
    }

    function onStartLocationChange(e) {
        setStartLocation(e.target.value);
    }

    function onEndLocationChange(e) {
        setEndLocation(e.target.value);
    }

    function onStartDateChanged(e) {
        setStartDate(e.target.value);
    }

    function onEndDateChanged(e) {
        setEndDate(e.target.value);
    }

    function onSelectedCarChanged(e) {
        setSelectedCar(e.target.value);
    }

    function onSelectedEmployeesChanged(e) {
        const options = e.target.options; 
        const values = []; 
        for (let i = 0; i < options.length; i++) { 
            if (options[i].selected) { 
                values.push(options[i].value); 
            }
        }
        setSelectedEmployees(values);
    }


    return (
        <div>
         

            <Collapse isOpen={isOpen}>
                <Card>
                    <CardBody>
                        <Form onSubmit={handleSubmit}>

                            {(mode === "new") ? <Badge color="primary">Create a new carpool event</Badge> : <Badge color="secondary">Edit an existing  carpool event</Badge>}
                                
                            

                            <FormGroup row>
                                <Label for="startLocation" sm={2}>Start location</Label>
                                <Col sm={5}>
                                    <Input id="startLocation" value={startLocation} onChange={onStartLocationChange} placeholder="The start location of the travel"></Input></Col>
                            </FormGroup>

                            <FormGroup row>
                                <Label for="endLocation" sm={2}>End location</Label>
                                <Col sm={5}>
                                    <Input id="endLocation" placeholder="The end location of the travel" value={endLocation} onChange={onEndLocationChange}></Input></Col>
                            </FormGroup>

                            <FormGroup row>
                                <Label for="startDate" sm={2}>Start date</Label>
                                <Col sm={5}>
                                    <Input id="startDate" type="date" placeholder="The start date of the travel" value={startDate} onChange={onStartDateChanged}></Input></Col>
                            </FormGroup>

                            <FormGroup row>
                                <Label for="endDate" sm={2}>End date</Label>
                                <Col sm={5}>
                                    <Input id="endDate" type="date" placeholder="The end date of the travel" value={endDate} onChange={onEndDateChanged }></Input></Col>
                            </FormGroup>

                            <FormGroup row>
                                <Label for="car" sm={2}>Car</Label>
                                <Col sm={5}>
                                    <Input id="car" type="select" value={selectedCar} onChange={onSelectedCarChanged }>
                                        {cars.map(car => <option key={car.id} id={car.id} value={car.id }>{ car.name }</option>)}
                                   </Input>
                                </Col>
                            </FormGroup>


                            <FormGroup row>
                                <Label for="employees" sm={2}>Employees</Label>
                                <Col sm={5}>
                                    <Input id="employees" type="select" multiple value={selectedEmployees} onChange={onSelectedEmployeesChanged }>
                                        {employees.map(emp => <option key={emp.id} id={emp.id} value={emp.id}>{emp.name} { emp.isDriver ? '- driver' : '' }</option>) }
                                    </Input>

                                </Col>


                            </FormGroup>

                            <div>
                                <Button type="submit" color="success" onClick={onSubmit }>
                                    Submit
                                </Button>
                                    {" "}
                                <Button type="reset" color="secondary" onClick={onCancel }>
                                    Cancel
                                </Button>
                            </div>
                            <Alert color="warning" style={{ marginTop: '1rem' }} isOpen={error !== null}>{error}</Alert>
                          
                        </Form>
                    </CardBody>
                </Card>
            </Collapse>

        </div>

    );
}