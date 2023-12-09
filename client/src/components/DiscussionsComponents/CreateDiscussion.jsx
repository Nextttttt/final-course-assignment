import React from "react";
import { useState } from "react";
import { useNavigate, Link } from "react-router-dom";
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import  Form  from "react-bootstrap/Form";
import {useFormik} from 'formik';
import styled from 'styled-components'

const ErrorDiv = styled.div`
color: #d60000;
`

export default function CreateDiscussion(props){
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const formik = useFormik({
      initialValues: {
        title: '',
        text: ''
      },
      validate: (values) => {
        const errors = {};
  
        // Title validation
        if (!values.title.trim()) {
          errors.title = 'Title is required';
        } else if (values.title.length < 5) {
          errors.title = 'Title must be at least 5 characters';
        }
  
        // Text validation
        if (!values.text.trim()) {
          errors.text = 'Text is required';
        } else if (values.text.length < 20) {
          errors.text = 'Text must be at least 20 characters';
        }
        return errors;
      },
      onSubmit: (values) => {
        CreateMyDiscussion(values);
        values.text="";
        values.title="";
      },
    });

    const CreateMyDiscussion= async (values) =>{
        fetch('https://localhost:5001/api/Discussion/CreateDiscussion',{
            method: 'POST',
            headers:{
              'accept':'*/*',
              'Authorization': 'Bearer ' + props.jwToken,
              'Content-type':'application/json'
          },
              body: JSON.stringify({
                  "Title": values.title,
                  "discussionText": values.text,
                })
          })
          setShow(false);
          props.setIsNew(2);
          
        }
    
    return (
        <>
        <Button onClick={handleShow} className="create-discussion" variant="custom">Create Discussion</Button>

        <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Create Discussion</Modal.Title>
        </Modal.Header>
        <Modal.Body>
            <Form onSubmit={formik.handleSubmit}>
            <Form.Group className="mb-3" controlId="title">
                <Form.Label>Title</Form.Label>
                <Form.Control 
                type="text" 
                name="title"
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                value={formik.values.title}
                placeholder="Discussion Title" />
                {formik.touched.title && formik.errors.title && (
                <ErrorDiv className="error">{formik.errors.title}</ErrorDiv>
                )}
            </Form.Group>
            <Form.Group className="mb-3" controlId="text">
                <Form.Label>Text</Form.Label>
                <Form.Control 
                as="textarea"
                name="text"
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                value={formik.values.text}
                placeholder=". . ." />
                {formik.touched.text && formik.errors.text && (
                <ErrorDiv className="error">{formik.errors.text}</ErrorDiv>
                )}
            </Form.Group>
            <Modal.Footer>
            <Button type="submit" variant="custom">
              Create
            </Button>
        </Modal.Footer>
            </Form>
        </Modal.Body>
      </Modal>
      </>
    );
}