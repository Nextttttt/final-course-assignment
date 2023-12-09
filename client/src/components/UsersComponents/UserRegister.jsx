import React, { useState } from "react";
import { useNavigate, Link } from "react-router-dom";
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import  Form  from "react-bootstrap/Form";
import {useFormik} from 'formik';
import styled from 'styled-components'

const ErrorDiv = styled.div`
color: #d60000;
`

export default function UserRegister(){
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);


    const formik = useFormik({
      initialValues: {
        username: '',
        email: '',
        password: '',
      },
      validate: (values) => {
        const errors = {};
  
        // Username validation
        if (!values.username.trim()) {
          errors.username = 'Username is required';
        } else if (values.username.length < 3) {
          errors.username = 'Username must be at least 3 characters';
        }
  
        // Email validation
        if (!values.email.trim()) {
          errors.email = 'Email is required';
        } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(values.email)) {
          errors.email = 'Invalid email address';
        }
  
        // Password validation
        if (!values.password) {
          errors.password = 'Password is required';
        } else if (values.password.length < 6) {
          errors.password = 'Password must be at least 6 characters';
        }
        return errors;
      },
      onSubmit: (values) => {
        RegisterUser(values);
      },
    });

    const RegisterUser = async (values) => {

        fetch('https://localhost:5001/api/User/Register',{
      method: 'POST',
      headers:{
        'accept':'*/*',
        'Content-type':'application/json'
    },
        body: JSON.stringify({
            "username": values.username,
            "email": values.email,
            "password": values.password 
          })
    }).then(async response => alert(await response.text()));
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
            <Form onSubmit={formik.handleSubmit}>
            <Form.Group className="mb-3" controlId="username">
                <Form.Label>Username</Form.Label>
                <Form.Control
                type="text"
                name="username"
            	  onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                value={formik.values.username}
                placeholder="Username" />
                {formik.touched.username && formik.errors.username && (
                <ErrorDiv className="error">{formik.errors.username}</ErrorDiv>
                )}
            </Form.Group>
            <Form.Group className="mb-3" controlId="email">
                <Form.Label>Email address</Form.Label>
                <Form.Control 
                type="email"
                name="email"
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                value={formik.values.email}
                placeholder="name@example.com" />
                {formik.touched.email && formik.errors.email && (
                <ErrorDiv className="error">{formik.errors.email}</ErrorDiv>
                )}
            </Form.Group>
            <Form.Group className="mb-3" controlId="password">
                <Form.Label>Password</Form.Label>
                <Form.Control 
                type="password" 
                name="password"
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                value={formik.values.password}
                placeholder="*******" />
                {formik.touched.password && formik.errors.password && (
                <ErrorDiv className="error">{formik.errors.password}</ErrorDiv>
                )}
            </Form.Group>
            <Modal.Footer>
            <Button type="submit" variant="custom">
              Register
            </Button>
        </Modal.Footer>
            </Form>
        </Modal.Body>
      </Modal>
      </>
      );

}