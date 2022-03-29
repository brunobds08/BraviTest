import React, { Component } from "react";
import PeopleDataService from "../../services/people.service";
import { Link } from "react-router-dom";

export default class PeopleList extends Component {
  constructor(props) {
    super(props);
    this.onChangeSearchName = this.onChangeSearchName.bind(this);
    this.retrievePeople = this.retrievePeople.bind(this);
    this.refreshList = this.refreshList.bind(this);
    this.setActivePerson = this.setActivePerson.bind(this);
    this.searchPerson = this.searchPerson.bind(this);
    this.state = {
      people: [],
      currentPerson: null,
      currentIndex: -1,
      searchName: ""
    };
  }
  componentDidMount() {
    this.retrievePeople();
  }
  onChangeSearchName(e) {
    const searchName = e.target.value;
    this.setState({
      searchName: searchName
    });
  }
  retrievePeople() {
    PeopleDataService.getAll()
      .then(response => {
        this.setState({
          people: response.data
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }
  refreshList() {
    this.retrievePeople();
    this.setState({
      currentPerson: null,
      currentIndex: -1
    });
  }
  setActivePerson(person, index) {
    this.setState({
      currentPerson: person,
      currentIndex: index
    });
  }
  
  searchPerson() {
    PeopleDataService.findByName(this.state.searchName)
      .then(response => {
        this.setState({
          people: response.data
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }
  render() {
    const { searchPerson, people, currentPerson, currentIndex } = this.state;
    return (
      <div className="list row">
        <div className="col-md-8">
          <div className="input-group mb-3">
            <input
              type="text"
              className="form-control"
              placeholder="Search people by Name"
              value={searchPerson}
              onChange={this.onChangeSearchName}
            />
            <div className="input-group-append">
              <button
                className="btn btn-outline-secondary"
                type="button"
                onClick={this.searchPerson}>
                Search Person
              </button>
            </div>
          </div>
        </div>
        <div className="col-md-6">
          <h4>People List</h4>
          <ul className="list-group">
            {people &&
              people.map((person, index) => (
                <li
                  className={
                    "list-group-item " +
                    (index === currentIndex ? "active" : "")
                  }
                  onClick={() => this.setActivePerson(person, index)}
                  key={index}>
                  {person.name}
                </li>
              ))}
          </ul>
          
        </div>
        <div className="col-md-6">
          {currentPerson ? (
            <div>
              <h4>Person</h4>
              <div>
                <label>
                  <strong>Name:</strong>
                </label>{" "}
                {currentPerson.name}
              </div>
              
              <Link
                to={"/people/" + currentPerson.id}
                className="badge badge-warning">
                Edit
              </Link>
            </div>
          ) : (
            <div>
              <br />
              <p>Please click on a contact name...</p>
            </div>
          )}
        </div>
      </div>
    );
  }
}