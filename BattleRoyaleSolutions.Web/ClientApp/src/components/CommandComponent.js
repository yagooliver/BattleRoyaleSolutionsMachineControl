import React, { Component } from 'react';

class Command extends Component {
    constructor(props) {
        super(props);
        this.state = {
            value: ''
        };
    }

    render() {
        return (
            <div className="form-Control">
                <label className="form-control">
                    Command:
        </label>
                <textarea className="input-control" style={{ width: '100%' }} rows="5" value={this.state.value} className="input-control" onChange={this.props.handleChange} />
            </div>
        );
    }
}

export default Command;