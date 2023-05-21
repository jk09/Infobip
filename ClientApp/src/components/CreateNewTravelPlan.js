import React, { useEffect, useState } from 'react';
import { Button, Form, FormGroup, Label, Input, Col, Collapse, Card, CardBody, FormFeedback,Alert } from 'reactstrap';


export function CreateNewTravelPlan(props) {

    let [isOpen, setIsOpen] = useState(false);
    let [cars, setCars] = useState([]);
    let [employees, setEmployees] = useState([]); 
    let [error, setError] = useState(null);
 

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
    }, []);

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

        let employeeOptions = event.target.querySelectorAll('#employees option');
        console.log('employeeOptions', employeeOptions);
        let selectedEmployeeIds = [...employeeOptions].filter(x => x.selected).map(x => parseInt(x.id));

        let data = new FormData(event.target);
        data.append("Id", 0);
        data.append("StartLocation", startLocation);
        data.append("EndLocation", endLocation);
        data.append("StartDate", startDate);
        data.append("EndDate", endDate);

        data.append("CarId", carId);
        data.append("EmployeeIds", JSON.stringify(selectedEmployeeIds));

        console.log("submitting new travel plan data=", data, startLocation, endLocation, startDate, endDate, carId, JSON.stringify(selectedEmployeeIds));
        fetch("/api/createnewtravelplan/submit", { method: "POST", body: data })
            .then(resp => {
                console.log('submit fetch response', resp);
                if (resp.ok) {
                    window.location.reload();        
                }
                else {
                    resp.json().then(function (data) {

                        console.log("submit fetch response data", data);
                        setError(data.detail);

                    });
                }

            })
            .catch(err=>console.error(err));
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
                                    <Input id="startLocation" placeholder="The start location of the travel"  ></Input></Col>
                            </FormGroup>

                            <FormGroup row>
                                <Label for="endLocation" sm={2}>End location</Label>
                                <Col sm={5}>
                                    <Input id="endLocation" placeholder="The end location of the travel" ></Input></Col>
                            </FormGroup>

                            <FormGroup row>
                                <Label for="startDate" sm={2}>Start date</Label>
                                <Col sm={5}>
                                    <Input id="startDate" type="date" placeholder="The start date of the travel" ></Input></Col>
                            </FormGroup>

                            <FormGroup row>
                                <Label for="endDate" sm={2}>End date</Label>
                                <Col sm={5}>
                                    <Input id="endDate" type="date" placeholder="The end date of the travel" ></Input></Col>
                            </FormGroup>

                            <FormGroup row>
                                <Label for="car" sm={2}>Car</Label>
                                <Col sm={5}>
                                    <Input id="car" type="select"  >
                                        {cars.map(car => <option key={car.id} id={car.id}>{ car.name }</option>)}
                                   </Input>
                                </Col>
                            </FormGroup>


                            <FormGroup row>
                                <Label for="employees" sm={2}>Employees</Label>
                                <Col sm={5}>
                                    <Input id="employees" type="select" multiple>
                                        {employees.map(emp => <option key={emp.id} id={emp.id }>{emp.name}</option>) }
                                    </Input>

                                </Col>


                            </FormGroup>


                            <Button type="submit">
                                Submit
                            </Button>

                            <Alert color="warning" style={{ marginTop: '1rem' }} isOpen={error !== null}>{error}</Alert>
                          
                        </Form>
                    </CardBody>
                </Card>
            </Collapse>

        </div>

    );
}