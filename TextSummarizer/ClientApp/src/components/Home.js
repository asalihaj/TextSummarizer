import React, { Component } from 'react';
import { Container, Form, FormGroup, Input, Button} from 'reactstrap';
import './Home.css';

export class Home extends Component {
    static displayName = Home.name;
    summarize = () => {

    }
  render () {
    return (
        <div className="">
            <Container>
                <Form>
                    <FormGroup className="summary-fields">
                        <Input
                            id="user-text"
                            name="text"
                            type="textarea"
                            placeholder="Write here..."
                            />
                        <Input
                            id="summary-text"
                            name="text"
                            type="textarea"
                            placeholder="Summarized text appears here..."
                            disabled
                        />
                    </FormGroup>
                    <FormGroup className="summarize">
                        <Button
                            type="submit"
                            color="primary"
                        >
                            Summarize
                        </Button>
                    </FormGroup>
                </Form>
            </Container>
        </div>
    );
  }
}

/*
 <div>
            <form className="summary">
                <div className="summary-header">
                </div>
                <div className="summary-content">
                    <div className="user-text">
                        <textarea className="user-input" placeholder="Write here"></textarea>
                    </div>
                    <div id="summarization" className="summary-text">
                        <textarea className="user-input" placeholder="Summary..."></textarea>
                    </div>
                </div>
                <div className="submit-form">
                    <button className="submit">Summarize</button>
                </div>
            </form>
      </div>
 */
