import React from "react";
import Table from "react-bootstrap/Table";
import Button from "react-bootstrap/Button"
import { useState, useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import CreateDiscussion from "./CreateDiscussion";
export default function ForumList(props){

        const navigation = useNavigate();

        const [isNewCreated, setIsNew] = useState(false);

        const [discussions, setDiscussions] = useState([
            {
                id:'',
                title:'',
                discussionText:'',
                userId:'',
                userName:'',
                commentCount:''
            }]);
            async function GetDiscussions()
            {
            let response =await fetch('https://localhost:5001/api/Discussion/All',{
            method: 'GET',
            headers:{
            'accept':'*/*',
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


        const HandleDiscussonRowRouting = (id) => {
            navigation('/discussions/details/'+id);
        }

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
            <th>Author</th>
            <th>Comments</th>
          </tr>
        </thead>
        <tbody>
            {discussions.map(discussion =>
                <tr key={discussion.id} onClick={() => HandleDiscussonRowRouting(discussion.id)}>
                <td className="align-middle">{discussion.title}</td>
                <td className="align-middle">{discussion.userName}</td>
                <td className="align-middle">{discussion.commentCount}</td>
                </tr>
                )}
        </tbody>
      </Table>
      </div>
        </>
    );
}