import React, { Component } from 'react';
import axios from 'axios';

import Switch from './Switch';
import Counter from './Counter';
import CipherForm from './CipherForm';

class CeasarCipher extends Component {
    state = {
        enteredText: '',
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
        this.doCipher();
    }
    handleDecrement = () => {
        this.setState({ secretKey: this.state.secretKey - 1 });
        this.doCipher();

    }
    handleOnDecrypt = () => {
        this.setState({ encrypt: false });
        this.doCipher();
    };
    handleOnEncrypt = () => {
        this.setState({ encrypt: true });
        this.doCipher();
    }


    doCipher = async () => {
        const { enteredText, secretKey: key, encrypt } = this.state;
        this.setState({ loading: true });
        
        if (!enteredText) return;

        const input = { message: enteredText, secretKey: key };

        if (encrypt) {
            const { data: message } = await axios
                .post(`CeasarCipher/encrypt`, input)
                .catch(err => {
                    console.error(err);
                });

            this.setState({ outputMessage: message, loading: false });
        } else {
            const { data: message } = await axios
                .post(`CeasarCipher/decrypt`, input)
                .catch(err => {
                    console.error(err);
                });
            this.setState({ outputMessage: message, loading: false });

        }
    }

    render() {
        const { enteredText, outputMessage, secretKey, encrypt } = this.state;
        return (
            <div className="row justify-content-center">
                <div className=" col-md-5 col-sm-12 col-xs-12">
                    <CipherForm enteredText={enteredText} onKeyUp={this.handleKeyUp} onTextChange={this.handleTextChange} />
                </div>
                <div className=" col-sm-12  col-md-2 col-xs-12 text-center  align-self-center">
                    <div className='row justify-content-center'>
                        <div className="col-12">
                        <Counter onIncrement={this.handleIncrement} currentCount={secretKey} onDecrement={this.handleDecrement} />
                        </div>
                        <div className="col-12">
                                <Switch encrypt={encrypt} onEncrypt={this.handleOnEncrypt} onDecrypt={this.handleOnDecrypt} />
                        </div>
                    </div>
                </div>
                <div className=" col-md-5  col-sm-12 col-xs-12" >
                    <div className="card shadow-sm" style={{ height: '480px' }}>
                        <div className="card-body">
                            <h5 className="card-title">Output Message</h5>
                            <hr />
                            {enteredText && (<p>{outputMessage}</p>)}
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

export default CeasarCipher;