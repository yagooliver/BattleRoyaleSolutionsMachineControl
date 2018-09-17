import React, { Component } from 'react';

class ResultCommand extends Component {

    render() {
        return (
            <div className="form-Control">
                <label className="form-control">
                    Result:
                </label>
                <textarea style={{ width: '100%' }} rows="5" name="result" value={this.props.Result} className="input-control" disabled />
            </div>
        );
    }
}

export default ResultCommand;