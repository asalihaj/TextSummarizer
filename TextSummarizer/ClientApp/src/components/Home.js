import React, { Component } from 'react';
import './Home.css';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
        <div>
            <form className="summary">
                <div className="summary-header">
                </div>
                <div className="summary-content">
                    <div className="user-text">
                        <textarea className="user-input" rows="10" cols="15">Write here</textarea>
                    </div>
                    <div className="summary-text">
                        <textarea className="user-input">Write here</textarea>
                    </div>
                </div>
                <div className="submit-form">
                    <button>Summarize</button>
                </div>
            </form>
      </div>
    );
  }
}
