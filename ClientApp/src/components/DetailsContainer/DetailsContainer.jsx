import React from 'react'
import './DetailsContainer.css'

export const DetailsContainer = ({ game }) => {
  const createDetails = () => {
    let keys = Object.keys(game)
    return keys.map((key) => {
        if (key === 'platforms') return;
      return (
        <div className='game-detail'>
          <strong>{key}</strong>
          <p>{game[key]}</p>
        </div>
      )
    })
  }

    const handleClick = async () => {
        console.log("loading")
        //event.preventDefault();
        let request = await fetch("https://localhost:7269/api/Games/", {
            method: "GET",
            mode: "no-cors",
            headers: {
                "Content-Type": "application/json",
            },
        })

        //console.log(data)
        let data = await request.json();
        console.log(data)
        console.log("not loading")
    }

  return (
      <section className='details-container'>
          <button onClick={ handleClick }></button>
      {createDetails()}

      <div className='game-detail'>
        <strong>platforms</strong>
        {game.platforms.map((platform) => {
          ;<p>{platform}</p>
        })}
      </div>
    </section>
  )
}
