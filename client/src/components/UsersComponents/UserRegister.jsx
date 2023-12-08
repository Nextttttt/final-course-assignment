import React, { useState } from "react";
import { useNavigate, Link } from "react-router-dom";
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import  Form  from "react-bootstrap/Form";

export default function UserLogin(){
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const [username, setUsername] = useState("");

    const [email, setEmail] = useState("")

    const [password, setPassword] = useState("")

    const [emailError, setEmailError] = useState("")

    const [passwordError, setPasswordError] = useState("")

    

    const navigate = useNavigate();

        

    const RegisterUser = () => {

        fetch('https://localhost:5001/api/User/Register',{
      method: 'POST',
      headers:{
        'accept':'*/*',
        'Content-type':'application/json'
    },
        body: JSON.stringify({
            "username": username,
            "email": email,
            "password": password 
          })
    })
      setShow(false);
    }


    return (
        <>
        <li onClick={handleShow}><Link className='right-side-menu-links'>Register</Link></li>

        <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Register</Modal.Title>
        </Modal.Header>
        <Modal.Body>
            <Form>
            <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
                <Form.Label>Username</Form.Label>
                <Form.Control onChange={ev => setUsername(ev.target.value)} type="email" placeholder="Username" />
            </Form.Group>
            <Form.Group className="mb-3" controlId="exampleForm.ControlInput2">
                <Form.Label>Email address</Form.Label>
                <Form.Control onChange={ev => setEmail(ev.target.value)} type="email" placeholder="name@example.com" />
            </Form.Group>
            <Form.Group className="mb-3" controlId="exampleForm.ControlInput3">
                <Form.Label>Password</Form.Label>
                <Form.Control onChange={ev => setPassword(ev.target.value)} type="password" placeholder="*******" />
            </Form.Group>
            </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="custom" onClick={RegisterUser}>
            Register
          </Button>
        </Modal.Footer>
      </Modal>
      </>
      );

}