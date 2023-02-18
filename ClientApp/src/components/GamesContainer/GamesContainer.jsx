import React, { Component } from 'react'
import { useNavigate } from 'react-router-dom'
import GameCard from '../GameCard/GameCard';
//import './GamesContainer.css'


const games = [
    {
        id: 'e5d1423a-1472-4224-8329-4cb321f5f42b ',
        name: 'Video Game 1',
        releaseData: '7/22/2001',
        price: 20.0,
        revenue: '$2,000,000.00',
        numberOfPlayers: '500,000',
        platforms: [],
    },
    {
        id: '4c29',
        name: 'Video Game 2',
        releaseData: '1/22/2001',
        price: 20.0,
        revenue: '$2,000,000.00',
        numberOfPlayers: '500,000',
        platforms: [],
    },
    {
        id: '8523-4032-11024829',
        name: 'Video Game 3',
        releaseData: '5/15/2001',
        price: 20.0,
        revenue: '$2,000,000.00',
        numberOfPlayers: '500,000',
        platforms: [],
    },
    {
        id: '-4b7e-ba31-1484c29',
        name: 'Video Game 4',
        releaseData: '6/16/2001',
        price: 20.0,
        revenue: '$2,000,000.00',
        numberOfPlayers: '500,000',
        platforms: [],
    },
    {
        id: '8522f102484c29',
        name: 'Video Game 5',
        releaseData: '4/20/2001',
        price: 20.0,
        revenue: '$2,000,000.00',
        numberOfPlayers: '500,000',
        platforms: [],
    },
    {
        id: '2f7f779',
        name: 'Video Game 6',
        releaseData: '7/22/2001',
        price: 20.0,
        revenue: '$2,000,000.00',
        numberOfPlayers: '500,000',
        platforms: [],
    },
    {
        id: 'a7b15b94-b416-4bb7-9475-ff87a22f7f77 ',
        name: 'Video Game 7',
        releaseData: '7/22/2001',
        price: 20.0,
        revenue: '$2,000,000.00',
        numberOfPlayers: '500,000',
        platforms: [],
    },
    {
        id: 'e434ba69-194e-4e3c-abbc-d6ff72388a39',
        name: 'Video Game 8',
        releaseData: '7/22/2001',
        price: 20.0,
        revenue: '$2,000,000.00',
        numberOfPlayers: '500,000',
        platforms: [],
    },
]

export const GamesContainer = () => {


    return (
        <div className="gamescontainer">
            {games.map((game) => (
                <GameCard key={game.id}  name={game.name} id={game.id} />
            ))}
        </div>
    )
}








