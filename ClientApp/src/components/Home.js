import React, { useState } from 'react';
import { Button, Form, FormGroup, Label, Input, Col, Collapse, Card, CardBody } from 'reactstrap';
import { Calendar, momentLocalizer } from 'react-big-calendar'
import moment from 'moment'

import "react-big-calendar/lib/css/react-big-calendar.css";


const myEventsList = [];
const localizer = momentLocalizer(moment)

const MyCalendar = (props) => (
    <div>
        <Calendar
            localizer={localizer}
            events={myEventsList}
            startAccessor="start"
            endAccessor="end"
            style={{ height: 500 }}
        />
    </div>);

function CreateNewTravelPlan(props) {

    let [isOpen, setIsOpen] = useState(false);
    return (
        <div>
            <Button color="primary" style={{ marginBottom: '1rem' }} onClick={()=>setIsOpen(prev=>!prev) }>Create new travel plan</Button>

            <Collapse isOpen={isOpen}>
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
                                        <option>1</option>
                                        <option>2</option>
                                    </Input>
                                </Col>
                            </FormGroup>


                            <FormGroup row>
                                <Label for="employees" sm={2}>Employees</Label>
                                <Col sm={5} >
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
                    <MyCalendar />
                </div>
            </div>



        );
    
}
