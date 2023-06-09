﻿import React, { useEffect, useState } from 'react';
import { Button, Form, FormGroup, Label, Input, Col, Collapse, Card, CardBody, FormFeedback, Alert, Badge, Modal, ModalHeader, ModalFooter, ModalBody } from 'reactstrap';
import { FaEdit } from 'react-icons/fa';

import moment from 'moment'

export function CreateNewTravelPlan({ mode, selectedEvent, isOpen, onSubmit, onCancel }) {

    let [cars, setCars] = useState([]);
    let [employees, setEmployees] = useState([]);
    let [error, setError] = useState(null);
    let [startLocation, setStartLocation] = useState("");
    let [startLocationInvalid, setStartLocationInvalid] = useState(null);

    let [endLocation, setEndLocation] = useState("");
    let [endLocationInvalid, setEndLocationInvalid] = useState(null);

    let [startDate, setStartDate] = useState("");
    let [startDateInvalid, setStartDateInvalid] = useState(null);
    let [endDate, setEndDate] = useState("");
    let [endDateInvalid, setEndDateInvalid] = useState(null);
    let [selectedCar, setSelectedCar] = useState("");
    let [selectedEmployees, setSelectedEmployees] = useState([]);
    let [selectedEmployeesInvalid, setSelectedEmployeesInvalid] = useState(null);

    const [deleteModalOpen, setDeleteModalOpen] = useState(false);

    useEffect(() => {

        // fetch the data from the backend
        fetch("/api/createnewtravelplan/cars", { method: "GET" })
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
                .then(data => { console.log("get travelplan", data); return data.json(); })
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

    useEffect(() => {
        console.log("run validation effect");

        const regex = /^(\p{Lu}\p{L}*)(\s+\p{L}+)*$/u;
        if (regex.test(startLocation)) {
            setStartLocationInvalid(null);
        } else {
            setStartLocationInvalid(true);

        }
        if (regex.test(endLocation)) {
            setEndLocationInvalid(null);
        } else {
            setEndLocationInvalid(true);
        }


        if (startDate) {
            setStartDateInvalid(null);
        } else {
            setStartDateInvalid(true);
        }


        if (endDate) {
            setEndDateInvalid(null);
        } else {
            setEndDateInvalid(true);
        }

        if (selectedEmployees) {
            if (selectedEmployees.length === 0) {
                setSelectedEmployeesInvalid(true);
            } else {
                setSelectedEmployeesInvalid(null);
            }
        } else {
            setSelectedEmployeesInvalid(true);
        }

    }, [startLocation, endLocation, startDate, endDate, selectedEmployees]);

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
        data.append("EndDate", endDate + "T23:59:59");

        data.append("CarId", carId);
        data.append("EmployeeIds", JSON.stringify(empIds));

        console.log(`${mode === 'new' ? 'submitting' : 'updating'}  travel plan data=`, data, startLocation, endLocation, startDate, endDate, carId, JSON.stringify(empIds));

        if (mode === "new") {

            fetch("/api/createnewtravelplan/submit", { method: "POST", body: data })
                .then(resp => {
                    console.log('submit fetch - response', resp);
                    if (resp.ok) {
                        window.location.reload();
                    }
                    else {
                        resp.json().then(function (data) {

                            console.log("submit fetch - response data", data);
                            setError(data.detail || JSON.stringify(data.errors));

                        });
                    }

                })
                .catch(err => console.error(err));
        } else if (mode === "edit") {
            fetch(`/api/createnewtravelplan/update/${selectedEvent.id}`, { method: "PUT", body: data })
                .then(resp => {
                    console.log('submit update - response', resp);
                    if (resp.ok) {
                        window.location.reload();
                    }
                    else {
                        resp.json().then(function (data) {

                            console.log("submit update - response data", data);
                            setError(data.detail || JSON.stringify(data.errors));

                        });
                    }

                })
                .catch(err => console.error(err));
        }
    }


    function handleDelete() {

        if (mode === "edit") {

            fetch(`/api/createnewtravelplan/delete/${selectedEvent.id}`, { method: "DELETE" })
                .then(resp => {
                    console.log("submit delete-response", resp);
                    if (resp.ok) {


                        window.location.reload();

                    } else {
                        resp.json().then(function (data) {
                            console.log("submit delete-response data", data);
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
                                    <Input id="startLocation" value={startLocation} onChange={onStartLocationChange} invalid={startLocationInvalid} placeholder="The start location of the travel"></Input></Col>
                            </FormGroup>

                            <FormGroup row>
                                <Label for="endLocation" sm={2}>End location</Label>
                                <Col sm={5}>
                                    <Input id="endLocation" placeholder="The end location of the travel" value={endLocation} invalid={endLocationInvalid} onChange={onEndLocationChange} onBl></Input></Col>
                            </FormGroup>

                            <FormGroup row>
                                <Label for="startDate" sm={2}>Start date</Label>
                                <Col sm={5}>
                                    <Input id="startDate" type="date" placeholder="The start date of the travel" value={startDate} onChange={onStartDateChanged} invalid={startDateInvalid}></Input></Col>
                            </FormGroup>

                            <FormGroup row>
                                <Label for="endDate" sm={2}>End date</Label>
                                <Col sm={5}>
                                    <Input id="endDate" type="date" placeholder="The end date of the travel" value={endDate} onChange={onEndDateChanged} invalid={endDateInvalid}></Input></Col>
                            </FormGroup>

                            <FormGroup row>
                                <Label for="car" sm={2}>Car</Label>
                                <Col sm={5}>
                                    <Input id="car" type="select" value={selectedCar} onChange={onSelectedCarChanged}>
                                        {cars.map(car => <option key={car.id} id={car.id} value={car.id}>{`${car.name} (${car.numberSeats} seats)`}</option>)}
                                    </Input>
                                </Col>
                            </FormGroup>


                            <FormGroup row>
                                <Label for="employees" sm={2}>Employees</Label>
                                <Col sm={5}>
                                    <Input id="employees" type="select" multiple value={selectedEmployees} onChange={onSelectedEmployeesChanged} invalid={selectedEmployeesInvalid }>
                                        {employees.map(emp => <option key={emp.id} id={emp.id} value={emp.id}>{emp.name} {emp.isDriver ? '- driver' : ''}</option>)}
                                    </Input>

                                </Col>


                            </FormGroup>
                            <FormGroup row>
                                <Col sm={2}>
                                    <Button type="submit" color="success" onClick={onSubmit}>
                                        Submit
                                    </Button>
                                    {" "}
                                    <Button type="reset" color="secondary" onClick={onCancel}>
                                        Cancel
                                    </Button>

                                </Col>
                                <Col sm={5} className="d-flex justify-content-end">
                                    {mode === "edit" ? (
                                        <Button color="danger" onClick={() => setDeleteModalOpen(true)} >
                                            Delete
                                        </Button>
                                    ) : null
                                    }
                                </Col>
                            </FormGroup>
                            <Alert color="warning" style={{ marginTop: '1rem' }} isOpen={error !== null}>{error}</Alert>

                            <Modal isOpen={deleteModalOpen}>
                                <ModalHeader>Delete a carpool event</ModalHeader>
                                <ModalBody>
                                    The selected carpool event will be deleted. Continue?
                                </ModalBody>
                                <ModalFooter>
                                    <Button color="primary" onClick={() => { handleDelete(); setDeleteModalOpen(false); }}>
                                        Delete
                                    </Button>{' '}
                                    <Button color="secondary" onClick={() => setDeleteModalOpen(false)}>
                                        Cancel
                                    </Button>
                                </ModalFooter>
                            </Modal>
                        </Form>
                    </CardBody>
                </Card>
            </Collapse>

        </div>

    );
}