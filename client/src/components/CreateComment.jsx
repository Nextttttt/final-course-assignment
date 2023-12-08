import React from "react";
import { useState, useEffect } from "react";
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import  Form  from "react-bootstrap/Form";

export default function CreateComment(props){
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const [text, setText] = useState("");

    async function CreateMyComment(){
        fetch('https://localhost:5001/api/Comment/CreateComment',{
            method: 'POST',
            headers:{
              'accept':'*/*',
              'Authorization': 'Bearer ' + props.jwToken,
              'Content-type':'application/json'
          },
              body: JSON.stringify({
                    "discussionId":props.discussionId,
                  "text": text
                })
          })
          setShow(false);
          //props.setIsNew(true);
          
        }

    return (
        <>
        <Button onClick={handleShow} className="d-flex" variant="custom2">Create New Comment</Button>

        <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Create Comment</Modal.Title>
        </Modal.Header>
        <Modal.Body>
            <Form>
            <Form.Group className="mb-3" controlId="exampleForm.ControlInput2">
                <Form.Label>Text</Form.Label>
                <Form.Control onChange={ev => setText(ev.target.value)} as="textarea" placeholder=". . ." />
            </Form.Group>
            </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="custom" onClick={CreateMyComment}>
            Create
          </Button>
        </Modal.Footer>
      </Modal>
      </>
    );
}