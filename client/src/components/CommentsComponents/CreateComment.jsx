import React from "react";
import { useState, useEffect } from "react";
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import  Form  from "react-bootstrap/Form";
import {useFormik} from 'formik';
import styled from 'styled-components'

const ErrorDiv = styled.div`
color: #d60000;
`

export default function CreateComment(props){
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const formik = useFormik({
      initialValues: {
        text: ''
      },
      validate: (values) => {
        const errors = {};
  
        // Text validation
        if (!values.text.trim()) {
          errors.text = 'Text is required';
        } else if (values.text.length < 20) {
          errors.text = 'Text must be at least 20 characters';
        }
        return errors;
      },
      onSubmit: (values) => {
        CreateMyComment(values);
        values.text="";
      },
    });

    async function CreateMyComment(values){
        fetch('https://localhost:5001/api/Comment/CreateComment',{
            method: 'POST',
            headers:{
              'accept':'*/*',
              'Authorization': 'Bearer ' + props.jwToken,
              'Content-type':'application/json'
          },
              body: JSON.stringify({
                    "discussionId":props.discussionId,
                  "text": values.text
                })
          })
          setShow(false);
          props.setIsNew(1);
          
        }

    return (
        <>
        <Button onClick={handleShow} className="d-flex" variant="custom2">Create New Comment</Button>

        <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Create Comment</Modal.Title>
        </Modal.Header>
        <Modal.Body>
            <Form onSubmit={formik.handleSubmit}>
            <Form.Group className="mb-3" controlId="exampleForm.ControlInput2">
                <Form.Label>Text</Form.Label>
                <Form.Control 
               as="textarea"
               name="text"
               onChange={formik.handleChange}
               onBlur={formik.handleBlur}
               value={formik.values.text}
               placeholder={props.discussionText} />
               {formik.touched.text && formik.errors.text && (
               <ErrorDiv className="error">{formik.errors.text}</ErrorDiv>
               )}
            </Form.Group>
            <Modal.Footer>
            <Button variant="custom" type="submit">
              Create
            </Button>
            </Modal.Footer>
            </Form>
        </Modal.Body>
        
      </Modal>
      </>
    );
}