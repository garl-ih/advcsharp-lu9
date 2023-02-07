import React, { useState } from 'react';
import { Button } from '../Button/Button';
import './AddGameForm.css'

/* 
 * this component should be used to create a game object and add it to the 
 * database
 */

export const AddGameForm = () => {
    const [formData, setFormData] = useState({});
    const [state, setState] = useState("idle");

    const handleSubmit = async () => {
        // disables button before the first one ends
        if (state === "loading") return;

        //make a network request
        
        // handle success and eror
        
        alert("submit test");
    }

    let buttonText = "Submit";
    if (state === "loading") {
        buttonText === "Loading..."
    }

    if (state === "error") {
        alert("Error adding data")
    }

    return (
        <div>
            <h1>Add Game</h1>
            <form>
               
                <Button text={buttonText} onClick={handleSubmit} />
            </form>
        </div>
        )
}