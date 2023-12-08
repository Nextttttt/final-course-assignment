import React from "react";
import Table from "react-bootstrap/Table";
import Button from "react-bootstrap/Button"
import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import CreateDiscussion from "./CreateDiscussion";

export default function MyDiscussionsList(props){

        const [isNewCreated, setIsNew] = useState(false);

        const [discussions, setDiscussions] = useState([
            {
                id:'',
                title:'',
                discussionText:'',
                userId:''
            }]);
            async function DeleteDiscussion(id)
            {
                let response =await fetch('https://localhost:5001/api/Discussion/DeleteDiscussion?id='+id,{
            method: 'DELETE',
            headers:{
            'accept':'*/*',
            'Authorization': 'Bearer ' + props.jwToken,
            'Content-type':'application/json'
            }});
            if(response.ok)
            {
                setIsNew(true);
            }
            else{
            console.log("HTTP-Error: "+response.status);
            }
            }
            async function GetDiscussions()
            {
            let response =await fetch('https://localhost:5001/api/Discussion/My',{
            method: 'GET',
            headers:{
            'accept':'*/*',
            'Authorization': 'Bearer ' + props.jwToken,
            'Content-type':'application/json'
            }});
            if(response.ok)
            {
            let data = await response.json();
            setDiscussions(data);
            }
            else{
            console.log("HTTP-Error: "+response.status);
            }
        }

        useEffect(() => {
        GetDiscussions();
        setIsNew(false);
        }, [isNewCreated])
    return (
        <>
        <div>{props.isLoggedIn ?
            (
            <>
            <CreateDiscussion jwToken={props.jwToken} setIsNew={setIsNew}/>            
            <Link to={"/discussions/my"}><Button className="create-discussion" variant="custom">My Discussions</Button></Link>
            </>
            )
            :("")
            }
      <Table borderless hover variant="dark" responsive="sm">
        <thead>
          <tr>
            <th>Discussion Title</th>
            <th>Comments</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
            {discussions.map(discussion =>
                <tr key={discussion.id}>
                <td className="align-middle">{discussion.title}</td>
                <td className="align-middle">{discussion.commentCount}</td>
                <td className="align-middle">
                <Button onClick={() => DeleteDiscussion(discussion.id)} className="action-btn"  variant="custom">Delete</Button>
                <Button className="action-btn" variant="custom">Update</Button>
                <Button className="action-btn" variant="custom">Open</Button>
                </td>
              </tr>
                )}
        </tbody>
      </Table>
      </div>
        </>
    );
}