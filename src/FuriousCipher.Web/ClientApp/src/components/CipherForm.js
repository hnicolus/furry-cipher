import React from 'react';

const  CipherForm= ({enteredText,onTextChange,onKeyUp})=> {

    return (
        <div className="card shadow-sm" style={{ height: '480px' }}>
        <div className="card-body">
            <h5 className="card-title">Enter Message</h5>
            <div className="form-group">
                <textarea name="" id=""
                    cols="30" rows="16" 
                    value={enteredText}
                     onChange={onTextChange} onKeyUp={onKeyUp}
                    className="form-control h-100"></textarea>
            </div>
        </div>
    </div>
    );
}

export default CipherForm;