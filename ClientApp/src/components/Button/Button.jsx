import React from 'react';
//import './Button.css'

export const Button = ({href, text, onClick}) => {
    return (
        <button
            className="gamebutton"
            href={href ? href : null}
            onClick={onClick}>
            {text}
        </button>
        )
}