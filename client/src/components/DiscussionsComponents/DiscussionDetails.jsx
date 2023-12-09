import React from 'react';
import { useState, useEffect } from "react";
import { useParams } from 'react-router-dom';
import Comment from '../CommentsComponents/Comment';
export default function DiscussionDetails(props){

      const params = useParams();

      const [isNewCreated, setIsNew] = useState(false);

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
        }
        else{
        console.log("HTTP-Error: "+response.status);
        }
    }
    useEffect(() => {
      GetDiscussion();
      setIsNew(false);
      }, [isNewCreated])
    return (
        <>
        <div>
      <h1>{discussion.title}</h1>
      <p style={{ fontSize: '14px', color: '#888' }}>by {discussion.userName}</p>
      
      <div style={{ marginTop: '20px' }}>
        <p className='paragraph'>{discussion.discussionText}</p>
      </div>

      <div style={{ marginTop: '30px' }}>
        <h2>Comments</h2>
        <Comment setIsNew={setIsNew} jwToken={props.jwToken} isLoggedIn={props.isLoggedIn} Comments={discussion.comments} discussionId={discussion.id}/>
      </div>
    </div>
        </>
    );
}