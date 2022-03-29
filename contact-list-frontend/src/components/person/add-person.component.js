import React, { Component } from "react";
import PeopleDataService from "../../services/people.service";

export default class AddPerson extends Component {
  constructor(props) {
    super(props);

    this.onChangeName = this.onChangeName.bind(this);
    
    this.savePerson = this.savePerson.bind(this);
    this.newPerson = this.newPerson.bind(this);
    this.state = {
      id: null,
      name: ""
    };
  }
  onChangeName(e) {
    this.setState({
      name: e.target.value
    });
  }
  
  savePerson() {
    var data = {
      name: this.state.name
      // ... contact list
    };

    PeopleDataService.create(data)
      .then(response => {
        this.setState({
          id: response.data.id,
          name: response.data.name
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }
  newPerson() {
    this.setState({
      id: null,
      name: ""
    });
  }
  render() {
    return (
      <div className="submit-form">
        {this.state.submitted ? (
          <div>
            <h4>You submitted successfully!</h4>
            <button className="btn btn-success" onClick={this.newPerson}>
              Add Person
            </button>
          </div>
        ) : (
          <div>
            <div className="form-group">
              <label htmlFor="title">Contact</label>
              <input
                type="text"
                className="form-control"
                id="name"
                required
                value={this.state.name}
                onChange={this.onChangeName}
                name="name"
              />
            </div>

            <button onClick={this.savePerson} className="btn btn-success">
              Save contact
            </button>
          </div>
        )}
      </div>
    );
  }
}