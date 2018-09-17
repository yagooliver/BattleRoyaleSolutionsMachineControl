import React, { Component } from 'react';

class Command extends Component {
    constructor(props) {
        super(props);
        this.state = {
            value: props.Command
        };
    }

    render() {
        return (
            <div className="form-Control">
                <label className="form-control">
                    Command:
                </label>
                <textarea style={{ width: '100%' }} rows="5" name="command" value={this.state.value} className="input-control" onChange={this.props.handleChange.bind("command")} />
                <br />
                <input type="button" value="Send Command" className="btn btn-success" onClick={this.props.onClick.bind(this)} />
            </div>
        );
    }
}

export default Command;