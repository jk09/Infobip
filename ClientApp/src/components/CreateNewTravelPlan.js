import React, { useRef, useEffect, useState } from 'react';
import { Button, Form, FormGroup, Label, Input, Col, Collapse, Card, CardBody } from 'reactstrap';

export function CreateNewTravelPlan(props) {

    let [isOpen, setIsOpen] = useState(false);
    let [cars, setCars] = useState([]);
    let [employees, setEmployees] = useState([]); 

    let [startLocation, setStartLocation] = useState(null);
    let [endLocation, setEndLocation] = useState(null);
    let [startDate, setStartDate] = useState(null);
    let [endDate, setEndDate] = useState(null);
    let [selectedCar, setSelectedCar] = useState(null);
    let [selectedEmployees, setSelectedEmployees] = useState(null);

    useEffect(() => {
        // fetch the data from the backend
        fetch("/api/createnewtravelplan/unallocatedcars",{method:"GET"})
            .then(data => {
                let json = data.json();
                console.log("cars data=", json);
                return json;
            })
            .then(json => setCars(json))
            .catch(err => console.error(err));

        fetch("/api/createnewtravelplan/unallocatedemployees", { method: "GET" })
            .then(data => {
                let json = data.json();
                console.log("employee data=", json);
                return json;
            })
            .then(json => setEmployees(json))
            .catch(err => console.error(err));
    }, []);

    function handleSubmit(event) {
        event.preventDefault();
        let data = new FormData(event.target);
        data.append("Id", 0);
        data.append("StartLocation", startLocation);
        data.append("EndLocation", endLocation);
        data.append("StartDate", startDate);
        data.append("EndDate", endDate);

        data.append("CarId", selectedCar);
        data.append("EmployeeIds", JSON.stringify(selectedEmployees));

        console.log("submitting new travel plan data=", data, startLocation, endLocation, startDate, endDate, selectedCar, JSON.stringify(selectedEmployees));
        fetch("/api/createnewtravelplan/submit", { method: "POST", body: data })
            .catch((error) => { console.error(error); });
    }

    function onSelectedCarChanged(event) {
        let q = [...event.target.querySelectorAll("option")];

        let carId = q.filter(x=>x.selected)[0].getAttribute("id");

        console.log("selected car id", carId);

        setSelectedCar(carId);
    }

    function onSelectedEmployeesChanged(event) {
        let q = [...event.target.querySelectorAll("option")];
        console.log("querySelectorAll('option'=)", q);
        let selectedOptions = q.filter(opt => opt.selected);
        console.log("selected employees options=", selectedOptions);
        let selEmps = selectedOptions.map(x => parseInt(x.id));

        setSelectedEmployees(selEmps);
    }

    return (
        <div>
            <Button color="primary" style={{ marginBottom: '1rem' }} onClick={() => setIsOpen(prev => !prev)}>Create new travel plan</Button>

            <Collapse isOpen={isOpen}>
                <Card>
                    <CardBody>
                        <Form onSubmit={handleSubmit}>

                            <FormGroup row>
                                <Label for="startLocation" sm={2}>Start location</Label>
                                <Col sm={5}>
                                    <Input id="startLocation" placeholder="The start location of the travel"  onChange={(event)=>setStartLocation(event.target.value) }></Input></Col>
                            </FormGroup>

                            <FormGroup row>
                                <Label for="endLocation" sm={2}>End location</Label>
                                <Col sm={5}>
                                    <Input id="endLocation" placeholder="The end location of the travel" onChange={(event)=>setEndLocation(event.target.value) }></Input></Col>
                            </FormGroup>

                            <FormGroup row>
                                <Label for="startDate" sm={2}>Start date</Label>
                                <Col sm={5}>
                                    <Input id="startDate" type="date" placeholder="The start date of the travel" onChange={(event)=>setStartDate(event.target.value) }></Input></Col>
                            </FormGroup>

                            <FormGroup row>
                                <Label for="endDate" sm={2}>End date</Label>
                                <Col sm={5}>
                                    <Input id="endDate" type="date" placeholder="The end date of the travel" onChange={(event)=>setEndDate(event.target.value) } ></Input></Col>
                            </FormGroup>

                            <FormGroup row>
                                <Label for="car" sm={2}>Car</Label>
                                <Col sm={5}>
                                    <Input id="car" type="select"  onChange={onSelectedCarChanged}>
                                        {cars.map(car => <option key={car.id} id={car.id}>{ car.name }</option>)}
                                   </Input>
                                </Col>
                            </FormGroup>


                            <FormGroup row>
                                <Label for="employees" sm={2}>Employees</Label>
                                <Col sm={5}>
                                    <Input id="employees" type="select" multiple onChange={onSelectedEmployeesChanged }>
                                        {employees.map(emp => <option key={emp.id} id={emp.id }>{emp.name}</option>) }
                                    </Input>
                                </Col>
                            </FormGroup>
                            <FormGroup row>
                                <Col>
                                    <Button>
                                        Submit
                                    </Button>
                                </Col>
                            </FormGroup>
                        </Form>
                    </CardBody>
                </Card>
            </Collapse>

        </div>

    );
}