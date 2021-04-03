import React from 'react';
import appConfig from '../config/appConfig';
const Footer = () => {
    return (
        <div className='appdetails'>
            <h6 className='appDescription mt-5' >{appConfig.Description}. developed by
                <a href="https://nicksoftware.co.za" style={{ color: 'cyan' }} target='_blank' rel="noopener noreferrer"> Nicolas Maluleke</a></h6>
            <p className='appVersion'>version : {appConfig.Version}</p>
        </div>);
}

export default Footer;