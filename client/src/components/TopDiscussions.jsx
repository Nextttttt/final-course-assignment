import React from "react";
import ListGroup from 'react-bootstrap/ListGroup';
export default function TopDiscussions() {
    const topDiscussions = [
        { id: 1, title: 'Discussion 1aaaaaaaaaaaaa', author: 'User1' },
        { id: 2, title: 'Discussion 2', author: 'User2' },
        { id: 3, title: 'Discussion 3', author: 'User3' },
        { id: 4, title: 'Discussion 4', author: 'User4' },
        { id: 5, title: 'Discussion 5', author: 'User5' },
      ];
    
      return (
        <div>

            <ListGroup>
                {topDiscussions.map((discussion) => (
                <ListGroup.Item variant="mydark" key={discussion.id}>
                    <h3>{discussion.title}</h3>
                </ListGroup.Item>
                ))}  
            </ListGroup>
        </div>
            );
}