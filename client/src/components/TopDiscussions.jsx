import React, { useEffect } from "react";
import ListGroup from 'react-bootstrap/ListGroup';
import { useState } from "react";
export default function TopDiscussions() {
    
    const topDiscussions = [
        { id: 1, title: 'Discussion 1aaaaaaaaaaaaa', author: 'User1' },
        { id: 2, title: 'Discussion 2', author: 'User2' },
        { id: 3, title: 'Discussion 3', author: 'User3' },
        { id: 4, title: 'Discussion 4', author: 'User4' },
        { id: 5, title: 'Discussion 5', author: 'User5' },
      ];

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
      let response =await fetch('https://localhost:5001/api/Discussion/Top',{
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
        useEffect(() =>
        {
            GetDiscussions();
        },[]);
      return (
        <div>

            <ListGroup>
                {discussions.map((discussion) => (
                <ListGroup.Item variant="mydark" key={discussion.id}>
                    <h3>{discussion.title}</h3>
                </ListGroup.Item>
                ))}  
            </ListGroup>
        </div>
            );
}