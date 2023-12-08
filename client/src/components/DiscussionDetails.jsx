import React from 'react';

export default function DiscussionDetails(){
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
    return (
        <>
        <div>
      <h1>{discussionData.title}</h1>
      <p style={{ fontSize: '14px', color: '#888' }}>by {discussionData.username}</p>
      
      <div style={{ marginTop: '20px' }}>
        <p>{discussionData.body}</p>
      </div>

      <div style={{ marginTop: '30px' }}>
        <h2>Comments</h2>
        <ul style={{ listStyle: 'none', padding: 0 }}>
          {discussionData.comments.map((comment) => (
            <li key={comment.id} style={{ marginBottom: '15px', border: '1px solid #ddd', padding: '10px', borderRadius: '4px' }}>
              <p style={{ fontSize: '12px', color: '#888' }}>by {comment.username}</p>
              <p>{comment.text}</p>
            </li>
          ))}
        </ul>
      </div>
    </div>
        </>
    );
}