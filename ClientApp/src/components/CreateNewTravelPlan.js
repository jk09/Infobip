import React, { useEffect, useState } from 'react';
import { Button, Form, FormGroup, Label, Input, Col, Collapse, Card, CardBody } from 'reactstrap';

export function CreateNewTravelPlan(props) {

    let [isOpen, setIsOpen] = useState(false);
    let [cars, setCars] = useState([]);

    useEffect(() => {
        // fetch the data from the backend
        fetch('createnewtravelplan')
            .then(data => {
                let json = data.json();
                console.log("cars data=", json);
                return json;
            })
            .then(json=>setCars(json))
            .catch(err => console.error(err));
    }, []);

    
    return (
        <div>
            <Button color="primary" style={{ marginBottom: '1rem' }} onClick={() => setIsOpen(prev => !prev)}>Create new travel plan</Button>

            <Collapse isOpen={isOpen}>q
                <Card>
                    <CardBody>
                        <Form>

                            <FormGroup row>
                                <Label for="startLocation" sm={2}>Start location</Label>
                                <Col sm={5}>
                                    <Input id="startLocation" placeholder="The start location of the travel"></Input></Col>
                            </FormGroup>

                            <FormGroup row>
                                <Label for="endLocation" sm={2}>End location</Label>
                                <Col sm={5}>
                                    <Input id="endLocation" placeholder="The end location of the travel"></Input></Col>
                            </FormGroup>

                            <FormGroup row>
                                <Label for="startDate" sm={2}>Start date</Label>
                                <Col sm={5}>
                                    <Input id="startDate" type="date" placeholder="The start date of the travel"></Input></Col>
                            </FormGroup>

                            <FormGroup row>
                                <Label for="endDate" sm={2}>End date</Label>
                                <Col sm={5}>
                                    <Input id="endDate" type="date" placeholder="The end date of the travel"></Input></Col>
                            </FormGroup>

                            <FormGroup row>
                                <Label for="car" sm={2}>Car</Label>
                                <Col sm={5}>
                                    <Input id="car" type="select">
                                        {cars.map(car => <option key={car.id}>{ car.name }</option>)}
                                   </Input>
                                </Col>
                            </FormGroup>


                            <FormGroup row>
                                <Label for="employees" sm={2}>Employees</Label>
                                <Col sm={5}>
                                    <Input id="employees" type="select" multiple>
                                        <option>1</option>
                                        <option>2</option>
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