import React, { Component } from 'react';
import Command from './CommandComponent';
import ResultCommand from './ResultCommandComponent';
import MachineTable from './TableComponent';

export class Home extends Component {
    constructor(props) {
        super(props);
        this.state = { machineIds: [], command: "", result: "" };
        this.handleChange = this.handleChange.bind(this);
        this.handleClick = this.handleClick.bind(this);
    }
    handleChange(e) {
        let change = {};
        console.log(e.target.name);
        change[e.target.name] = e.target.value;
        this.setState(change);
    }

    handleClick(e) {
        e.preventDefault();
        return fetch('api/Machine/SendCommand', {
            method: 'POST',
            body: { machineIds: this.state.machineIds, command: this.state.command },
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(res => res.json())
          .then(data => {
            this.setState({ result: data.json() });
        }).catch(err => err);
    }

    handleCheckBox(e, id) {
        let ids = this.state.machineIds;
        if (!ids.indexOf(id) > -1 && e.target.checked) {
            ids.push(id);
        } else {
            if (ids.indexOf(id) > - 1 && !e.target.checked) {
                let index = ids.indexOf(id);
                this.setState({ machineIds: ids.splice(index, 1) });
            }
        }
        this.setState({ machineIds: id });
    }

    render() {
        return (
            <div>
                <MachineTable handleChange={() => { }} />
                <br />
                <br />
                <Command handleChange={this.handleChange} command={this.state.command} onClick={this.handleClick} />
                <br />
                <br />
                <ResultCommand Result={this.state.result} />
                <br />
            </div>
        );
    }
}
