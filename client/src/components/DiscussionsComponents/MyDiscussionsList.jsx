import React from "react";
import Table from "react-bootstrap/Table";
import Button from "react-bootstrap/Button"
import { useState, useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import CreateDiscussion from "./CreateDiscussion";
import EditDiscussion from "./EditDiscussion";

export default function MyDiscussionsList(props){

        const navigation = useNavigate();

        const [isNewCreated, setIsNew] = useState(0);

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
              alert(await response.text());
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
              alert(await response.text());
            }
        }

        useEffect(() => {
        GetDiscussions();
        setIsNew(0);
        }, [isNewCreated]);

        const HandleDiscussonRowRouting = (id) => {
          if(props.isLoggedIn)
            navigation('/discussions/details/'+id);
        }
    return (
        <>
        <div className='wrapper-body'> {props.isLoggedIn ?
            (
            <>
            <CreateDiscussion jwToken={props.jwToken} setIsNew={setIsNew}/>            
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
                <EditDiscussion setIsNew={setIsNew} jwToken={props.jwToken} DiscussionId={discussion.id} discussionTitle={discussion.title} discussionText={discussion.discussionText}/>
                <Button onClick={() => HandleDiscussonRowRouting(discussion.id)} className="action-btn" variant="custom">Open</Button>
                </td>
              </tr>
                )}
        </tbody>
      </Table>
      </div>
        </>
    );
}