import { BrowserRouter, Route, Routes, Router } from 'react-router-dom';
import './App.css';
import UserLogin from './components/UsersComponents/UserLogin';
import Home from './components/Home';
import NavigationMenu from './components/NavigationMenu';
import { useEffect, useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import ForumList from './components/DiscussionsComponents/ForumList';
import MyDiscussionsList from './components/DiscussionsComponents/MyDiscussionsList';
import DiscussionDetails from './components/DiscussionsComponents/DiscussionDetails';


function App() {

  const [loggedIn, setLoggedIn] = useState(false)

  const [jwToken, setToken] = useState(localStorage.getItem("jwToken"));

  useEffect(() =>{
    if(jwToken !== null)
  {
    setLoggedIn(true);
  }
  },[jwToken]);

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