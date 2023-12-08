import React from "react";
import {
  MDBCard,
  MDBCardBody,
  MDBCardImage,
  MDBCol,
  MDBContainer,
  MDBIcon,
  MDBRow,
  MDBSwitch,
  MDBTypography,
} from "mdb-react-ui-kit";
import CreateComment from "./CreateComment";

export default function Comment(props) {

    console.log(props.Comments);

    async function DeleteComment(id)
    {
        console.log(id);
        let response =await fetch('https://localhost:5001/api/Comment/DeleteComment?id='+id,{
    method: 'DELETE',
    headers:{
    'accept':'*/*',
    'Authorization': 'Bearer ' + props.jwToken,
    'Content-type':'application/json'
    }});
    if(response.ok)
    {
        //setIsNew(true);
    }
    else{
    console.log("HTTP-Error: "+response.status);
    }
    }
  return (
    <section className="comment-section">
        <CreateComment jwToken={props.jwToken} discussionId={props.discussionId} />
      <MDBContainer className="py-5 text-dark" style={{ maxWidth: "1000px" }}>
        <MDBRow className="justify-content-center">
          <MDBCol md="12" lg="10" xl="8">
            {props.Comments.map((comment) =>
            <MDBCard className="mb-3 comment-card">
            <MDBCardBody>
              <div className="d-flex flex-start">
                <div className="w-100">
                  <div className="d-flex justify-content-between align-items-center mb-3">
                    <MDBTypography
                      tag="h6"
                      className="fw-bold mb-0"
                    >
                      {comment.userName}:
                      <span className="ms-2">
                        {comment.text}
                      </span>
                    </MDBTypography>
                    
                  </div>
                  {props.isLoggedIn ?
                  (<div className="d-flex justify-content-end">
                  <p className="small mb-0" style={{ color: "#aaa" }}>
                    <a onClick={() => DeleteComment(comment.id)} href="#!" className="link-mydark">
                      Remove
                    </a>{" "}
                  </p>
                  <div className="d-flex flex-row">
                    <MDBIcon fas icon="star text-warning me-2" />
                    <MDBIcon
                      far
                      icon="check-circle"
                      style={{ color: "#aaa" }}
                    />
                  </div>
                </div>):
                  ("")}
                </div>
              </div>
            </MDBCardBody>
          </MDBCard>
            )}
          </MDBCol>
        </MDBRow>
      </MDBContainer>
    </section>
  );
}