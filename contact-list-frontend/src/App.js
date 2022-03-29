import React, { Component } from "react";
import { Routes, Router, BrowserRouter, Route, Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";
import AddPerson from "./components/person/add-person.component";
import Person from "./components/person/person.component";
import PeopleList from "./components/person/people-list.component";

class App extends Component {
  render() {
    return (
      <div>
        <nav className="navbar navbar-expand navbar-dark bg-dark">
          <a href="/api/people" className="navbar-brand">
            Contacts
          </a>
          <div className="navbar-nav mr-auto">
            <li className="nav-item">
              <Link to={"/api/people"} className="nav-link">
                People
              </Link>
            </li>
            <li className="nav-item">
              <Link to={"/api/people"} className="nav-link">
                Add
              </Link>
            </li>
          </div>
        </nav>
        <div className="container mt-3">
          
            <Routes>
              <Route exact path="/api/people" element={<PeopleList />} />
              <Route exact path="/api/people" element={<AddPerson />} />
              <Route path="/api/people/:id" element={<Person />} />
            </Routes>
             
        </div>
      </div>
    );
  }
}
export default App;