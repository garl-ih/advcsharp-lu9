import { getData } from 'ajv/dist/compile/validate';
import React, { Component } from 'react'
import { useNavigate } from 'react-router-dom'
import GameCard from '../GameCard/GameCard';
import { useState, useEffect } from 'react';
//import './GamesContainer.css'

//games2.push(dav);


export const GamesContainer = () => {


    const [game, setGame] = useState([]);

    useEffect(()=>{ // useEffect says "I want to run this function after the page loads..."
        getGameFromServer()
    }, []);

    const getGameFromServer = async () => {
        const resp = await fetch("https://localhost:7269/api/Games");

        setGame(await resp.json());
    }

    return (
        <div className="gamescontainer">
            {game.map((data) => (
                <GameCard key={data.id}  name={data.name} id={data.id} gameState={game} gameSetState={setGame} />
            ))}
        </div>
    )
}








