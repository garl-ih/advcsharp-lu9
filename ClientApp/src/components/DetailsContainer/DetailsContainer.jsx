import React from 'react'
import './DetailsContainer.css'

export const DetailsContainer = ({ game }) => {
  const createDetails = () => {
    let keys = Object.keys(game)
    return keys.map((key) => {
      if (key === 'platforms') return
      return (
        <div className='game-detail'>
          <strong>{key}</strong>
          <p>{game[key]}</p>
        </div>
      )
    })
  }

  return (
    <section className='details-container'>
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
