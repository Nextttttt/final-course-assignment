import React from 'react';
import { useState, useEffect } from "react";
import { useParams } from 'react-router-dom';
import Comment from './Comment';
export default function DiscussionDetails(props){

      const params = useParams();

      const [discussion, setDiscussion] = useState(
        {
            id:'',
            title:'',
            discussionText:'',
            userId:'',
            userName:'',
            comments:[{
              id:'',
              text:'',
              userName:'',
              userId:''
            }],
            commentCount:''
        });
        
        async function GetDiscussion()
        {
        let response =await fetch('https://localhost:5001/api/Discussion/GetDiscussion?id='+params.discussionId,{
        method: 'GET',
        headers:{
        'accept':'*/*',
        'Authorization': 'Bearer ' + props.jwToken,
        'Content-type':'application/json'
        }});
        if(response.ok)
        {
        let data = await response.json();
        setDiscussion(data);
        console.log(discussion);
        }
        else{
        console.log("HTTP-Error: "+response.status);
        }
    }
    useEffect(() => {
      GetDiscussion();
      }, [])
    return (
        <>
        <div>
      <h1>{discussion.title}</h1>
      <p style={{ fontSize: '14px', color: '#888' }}>by {discussion.userName}</p>
      
      <div style={{ marginTop: '20px' }}>
        <p>{discussion.discussionText}</p>
      </div>

      <div style={{ marginTop: '30px' }}>
        <h2>Comments</h2>
        <Comment jwToken={props.jwToken} isLoggedIn={props.isLoggedIn} Comments={discussion.comments} discussionId={discussion.id}/>
      </div>
    </div>
        </>
    );
}