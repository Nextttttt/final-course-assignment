import React from "react";
import { useState } from "react";
import { useNavigate, Link } from "react-router-dom";
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import  Form  from "react-bootstrap/Form";

export default function CreateDiscussion(props){
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const [discussionTitle, setTitle] = useState("");
    const [discussionText, setText] = useState("");

    async function CreateMyDiscussion(){
        fetch('https://localhost:5001/api/Discussion/CreateDiscussion',{
            method: 'POST',
            headers:{
              'accept':'*/*',
              'Authorization': 'Bearer ' + props.jwToken,
              'Content-type':'application/json'
          },
              body: JSON.stringify({
                  "Title": discussionTitle,
                  "discussionText": discussionText,
                })
          })
          setShow(false);
          props.setIsNew(true);
          
        }
    
    return (
        <>
        <Button onClick={handleShow} className="create-discussion" variant="custom">Create Discussion</Button>

        <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Create Discussion</Modal.Title>
        </Modal.Header>
        <Modal.Body>
            <Form>
            <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
                <Form.Label>Title</Form.Label>
                <Form.Control onChange={ev => setTitle(ev.target.value)} type="title" placeholder="Discussion Title" />
            </Form.Group>
            <Form.Group className="mb-3" controlId="exampleForm.ControlInput2">
                <Form.Label>Text</Form.Label>
                <Form.Control onChange={ev => setText(ev.target.value)} as="textarea" placeholder=". . ." />
            </Form.Group>
            </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="custom" onClick={CreateMyDiscussion}>
            Create
          </Button>
        </Modal.Footer>
      </Modal>
      </>
    );
}