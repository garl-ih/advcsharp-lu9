import React from 'react'
import { useNavigate } from 'react-router-dom'
import './GameCard.css'

/* 
  This component is used to represent a video game
*/

const GameCard = ({ name, id, onClick }) => {
  let navigate = useNavigate()

  const handleRoutes = () => {
    navigate(`details/${id}`)
  }

  return (
    <div className='gamecard' onClick={handleRoutes}>
      GameCard<p></p>
    </div>
  )
}

export default GameCard
