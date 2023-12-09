import React, { useEffect } from 'react';
import { Link } from 'react-router-dom';
import UserLogin from './UsersComponents/UserLogin';
import UserRegister from './UsersComponents/UserRegister';
import { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import './NavigationMenu.css'

export default function NavigationMenu(props) {
    function updatemenu() {
        if (document.getElementById('responsive-menu').checked == true) {
          document.getElementById('menu').style.borderBottomRightRadius = '0';
          document.getElementById('menu').style.borderBottomLeftRadius = '0';
        }else{
          document.getElementById('menu').style.borderRadius = '0px';
        }
      }
      function Logout(){
        localStorage.removeItem("jwToken");
        props.setLoggedIn(false);
      }

      useEffect(() =>{
        const loggedToken = localStorage.getItem("jwToken");
        if(loggedToken !== null)
        {
          props.setLoggedIn(false);
          props.setToken(loggedToken);
        }
      },[]);
      
  return (
    <nav id='menu' className='sticky'>
  <input type='checkbox' id='responsive-menu' onClick={updatemenu} /><label></label>
  <ul>
    <li><Link to={'/'}>Home</Link></li>
    <li><Link className={'dropdown-arrow'} >Discussions</Link>
      <ul className={'sub-menus'}>
        <li><Link to={'discussions/all'}>All Discussions</Link></li>
        {props.isLoggedIn ?
            <li><Link to={'discussions/my'}>My Discussions</Link></li>
        : <></>}
      </ul>
    </li>
    {props.isLoggedIn ?
        <li><Link to={'/users'}>Users</Link></li>
    : <></>}
    <li><Link to={'/about'}>About</Link></li>
  
  <li className='right-side-menu'>
    <ul>
    {props.isLoggedIn ? (
    <>
    <li><Link onClick={Logout} to={'/'}>Logout</Link></li>
    </>
    ):(
    <>
    <UserLogin jwToken={props.jwToken} setToken={props.setToken} setLoggedIn={props.setLoggedIn}/>
    <span>/</span>
    <UserRegister />
    </>
    )
    }
    </ul>
  </li>
  </ul>
</nav>
  );
};