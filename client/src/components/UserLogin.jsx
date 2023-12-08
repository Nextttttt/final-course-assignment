import React, { useState } from "react";
import { useNavigate, Link } from "react-router-dom";
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import  Form  from "react-bootstrap/Form";

export default function UserLogin(props){
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const [email, setEmail] = useState("");

    const [password, setPassword] = useState("");

    const navigate = useNavigate();

        

    const LoginUser = async () => {

        let response =await fetch('https://localhost:5001/api/User/Login',{
      method: 'POST',
      headers:{
        'accept':'*/*',
        'Content-type':'application/json'
    },
        body: JSON.stringify({
            "email": email,
            "password": password 
          })
    });
        if(response.ok)
        {
          props.setToken(await response.json());
          props.setLoggedIn(true);
        }
        else{
          console.log("HTTP-Error: "+response.status);
        }
        setShow(false);
    }

    return (
        <>
        <li onClick={handleShow}><Link className='right-side-menu-links'>Login</Link></li>

        <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Login</Modal.Title>
        </Modal.Header>
        <Modal.Body>
            <Form>
            <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
                <Form.Label>Email address</Form.Label>
                <Form.Control onChange={ev => setEmail(ev.target.value)} type="email" placeholder="name@example.com" />
            </Form.Group>
            <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
                <Form.Label>Password</Form.Label>
                <Form.Control onChange={ev => setPassword(ev.target.value)} type="password" placeholder="*******" />
            </Form.Group>
            </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="custom" onClick={LoginUser}>
            Login
          </Button>
        </Modal.Footer>
      </Modal>
      </>
      );

}