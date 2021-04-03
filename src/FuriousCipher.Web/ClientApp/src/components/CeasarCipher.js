import React, { Component } from 'react';
import axios from 'axios';

import Switch from './Switch';
import Counter from './Counter';
import CipherForm from './CipherForm';

class CeasarCipher extends Component {
    state = {
        enteredText: "",
        encrypt: true,
        outputMessage: '',
        secretKey: 2,
        loading: false

    }

    handleTextChange = ({ currentTarget }) => {
        this.setState({ enteredText: currentTarget.value });
    }

    handleKeyUp = () => {
        this.doCipher();
    }
    handleIncrement = () => {
        this.setState({ secretKey: this.state.secretKey + 1 });
    }
    handleDecrement = () => {
        this.setState({ secretKey: this.state.secretKey - 1 });
    }
    handleOnDecrypt = () => this.setState({ encrypt: false });
    handleOnEncrypt = () => this.setState({ encrypt: true });


    doCipher = async () => {
        const { enteredText, secretKey: key, encrypt } = this.state;
        this.setState({ loading: true });
        const input = { message: enteredText, secretKey: key };
        if (encrypt) {
            try {
                const { data: message } = await axios.post(`CeasarCipher/encrypt?message=${enteredText}&secretKey=${key}`);
                this.setState({ outputMessage: message, loading: false });
            } catch (error) {
                console.error(error);
            }

        } else {
            try {
                const { data: message } = await axios.post(`CeasarCipher/decrypt?message=${enteredText}&secretKey=${key}`);
                this.setState({ outputMessage: message, loading: false });
            } catch (error) {
                console.error(error);
            }
        }
    }

    render() {
        const { enteredText, outputMessage, secretKey,encrypt } = this.state;
        return (
            <div className="row justify-content-center">
                <div className="col-5  col-xs-12">
                    <CipherForm enteredText={enteredText} onKeyUp={this.handleKeyUp} onTextChange={this.handleTextChange} />
                </div>
                <div className="col-2 align-self-center">
                    <Counter onIncrement={this.handleIncrement} currentCount={secretKey} onDecrement={this.handleDecrement} />
                    <Switch encrypt={encrypt} onEncrypt={this.handleOnEncrypt} onDecrypt={this.handleOnDecrypt} />
                </div>
                <div className="col-5  col-xs-12" >
                    <div className="card shadow-sm" style={{ height: '480px' }}>
                        <div className="card-body">
                            <h5 className="card-title">Output Message</h5>
                            <hr />
                            <p>{outputMessage}</p>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

export default CeasarCipher;