import { BrowserRouter, Route, Routes, Router } from 'react-router-dom';
import './App.css';
import UserLogin from './components/UserLogin';
import Home from './components/Home';
import NavigationMenu from './components/NavigationMenu';
import { useEffect, useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import ForumList from './components/ForumList';
import MyDiscussionsList from './components/MyDiscussionsList';
import DiscussionDetails from './components/DiscussionDetails';


function App() {

  const [loggedIn, setLoggedIn] = useState(false)

  const [jwToken, setToken] = useState("");

  const loggedToken = localStorage.getItem("jwToken");
  if(loggedToken)
  {
    setLoggedIn(true);
    setToken(loggedToken);
  }

  return (

    <div className="App">

      <BrowserRouter>
      <NavigationMenu isLoggedIn={loggedIn} setLoggedIn={setLoggedIn} jwToken={jwToken} setToken={setToken}/>
        <Routes>
          <Route path="/" element={<Home loggedIn={loggedIn}/>} />
          <Route path="*" element={<Home loggedIn={loggedIn}/>} />
          <Route path='/discussions/all' element={<ForumList isLoggedIn={loggedIn} jwToken={jwToken}/>}/>
          {loggedIn ? (
            <>
            <Route path='/discussions/my' element={<MyDiscussionsList isLoggedIn={loggedIn} jwToken={jwToken}/>}/>
            <Route path='/discussions/details/:discussionId' element={<DiscussionDetails isLoggedIn={loggedIn} jwToken={jwToken}/>}/>
            </>
          )
          : ("")}
        </Routes>

        
      </BrowserRouter>

    </div>

  );

}


export default App;