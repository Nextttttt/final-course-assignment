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

export default function EditDiscussion(props){
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
        UpdateMyDiscussion(values);
        values.text="";
      },
    });

    async function UpdateMyDiscussion(values){
        fetch('https://localhost:5001/api/Discussion/UpdateDiscussion',{
            method: 'PUT',
            headers:{
              'accept':'*/*',
              'Authorization': 'Bearer ' + props.jwToken,
              'Content-type':'application/json'
          },
              body: JSON.stringify({
                  "id":props.DiscussionId,
                  "discussionText": values.text
                })
          })
          setShow(false);
          props.setIsNew(true);
          
        }
    
    return (
        <>
        <Button onClick={handleShow} className="action-btn" variant="custom">Update</Button>

        <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Create Discussion</Modal.Title>
        </Modal.Header>
        <Modal.Body>
            <Form onSubmit={formik.handleSubmit}>
            <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
                <Form.Label>Title</Form.Label>
                <Form.Control disabled type="title" placeholder={props.discussionTitle} />
            </Form.Group>
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
            Update
          </Button>
        </Modal.Footer>
            </Form>
        </Modal.Body>
      </Modal>
      </>
    );
}