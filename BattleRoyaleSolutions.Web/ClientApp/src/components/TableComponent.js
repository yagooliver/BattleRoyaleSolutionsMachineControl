import React, { Component } from 'react';

class MachineTable extends Component {
    constructor(props) {
        super(props);
        this.state = { machines: [] };
        fetch('api/Machine/GetAllMachines')
            .then(response => response.json())
            .then(data => {
                console.log(data);
                this.setState({ machines: data, loading: false });
            });
    }

    render() {
      return (
        <table className='table'>
          <thead>
            <tr>
              <th>Name</th>
              <th>Ip</th>
              <th>Firewall active</th>
              <th>Active</th>
              <th>Send</th>
            </tr>
          </thead>
            <tbody>
              {this.state.machines.map((machine, i) =>
                <tr key={i}>
                  <td>{machine.machineName}</td>
                  <td>{machine.ip}</td>
                  <td><input type="checkBox" checked={machine.isFirewallActive} disabled /></td>
                  <td><input type="checkBox" checked={machine.isActive} disabled /></td>
                  <td><input type="checkBox"></input></td>
                </tr>
               )}
            </tbody>
        </table>
      );
    }
}

export default MachineTable;