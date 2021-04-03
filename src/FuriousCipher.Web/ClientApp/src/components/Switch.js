import React from 'react';

function Switch({encrypt,onEncrypt,onDecrypt}) {
    return (
        <div className="row">
            <div className="custom-control custom-radio custom-control-inline">
                <input  type="radio" onClick={onEncrypt} id="customRadioInline1" name="customRadioInline" className="custom-control-input" />
                <label className="custom-control-label" htmlFor="customRadioInline1">Encrypt</label>
            </div>
            <div className="custom-control custom-radio custom-control-inline">
                <input type="radio" onClick={onDecrypt} id="customRadioInline2" name="customRadioInline" className="custom-control-input" />
                <label className="custom-control-label" htmlFor="customRadioInline2">Decrypt</label>
            </div>
        </div>
    );
}

export default Switch;