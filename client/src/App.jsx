import { BrowserRouter, Route, Routes, Router } from 'react-router-dom';
import './App.css';
import UserLogin from './components/UserLogin';
import Home from './components/Home';
import NavigationMenu from './components/NavigationMenu';
import { useEffect, useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import ForumList from './components/ForumList';


function App() {

  const [loggedIn, setLoggedIn] = useState(false)

  const [jwToken, setToken] = useState("");



  return (

    <div className="App">

      <BrowserRouter>
      <NavigationMenu isLoggedIn={loggedIn} setLoggedIn={setLoggedIn} setToken={setToken}/>
        <Routes>
          <Route path="/" element={<Home loggedIn={loggedIn}/>} />
          <Route path='/discussions/all' element={<ForumList isLoggedIn={loggedIn} jwToken={jwToken}/>}/>
        </Routes>

        
      </BrowserRouter>

    </div>

  );

}


export default App;