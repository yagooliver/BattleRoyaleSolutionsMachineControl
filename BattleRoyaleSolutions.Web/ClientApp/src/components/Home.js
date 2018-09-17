import React, { Component } from 'react';
import Command from './CommandComponent'
import MachineTable from './TableComponent';

export class Home extends Component {

    render() {
        return (
            <div>
                <Command handleChange={() => { }} ></Command>
                <br />
                <MachineTable />
            </div>
        );
    }
}
