import React from 'react';
import { useState, useEffect } from "react";
import { useParams } from 'react-router-dom';

export default function DiscussionDetails(props){
    const discussionData = {
        title: 'Sample Discussion Title',
        username: 'JohnDoe123',
        body: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
        comments: [
          { id: 1, username: 'Commenter1', text: 'Great discussion!' },
          { id: 2, username: 'Commenter2', text: 'I have a different opinion.' },
          // Add more comments as needed
        ],
      };

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
        <ul style={{ listStyle: 'none', padding: 0 }}>
          {discussion.comments.map((comment) => (
            <li key={comment.id} style={{ marginBottom: '15px', border: '1px solid #ddd', padding: '10px', borderRadius: '4px' }}>
              <p style={{ fontSize: '12px', color: '#888' }}>by {comment.userName}</p>
              <p>{comment.text}</p>
            </li>
          ))}
        </ul>
      </div>
    </div>
        </>
    );
}