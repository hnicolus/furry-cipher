import React from 'react';

function Switch({encrypt,onEncrypt,onDecrypt}) {
    return (
        <div class="row">
            <div class="custom-control custom-radio custom-control-inline">
                <input toggled type="radio" onClick={onEncrypt} id="customRadioInline1" name="customRadioInline" class="custom-control-input" />
                <label class="custom-control-label" for="customRadioInline1">Encrypt</label>
            </div>
            <div class="custom-control custom-radio custom-control-inline">
                <input type="radio" onClick={onDecrypt} id="customRadioInline2" name="customRadioInline" class="custom-control-input" />
                <label class="custom-control-label" for="customRadioInline2">Decrypt</label>
            </div>
        </div>
    );
}

export default Switch;