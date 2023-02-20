import React from 'react'
import { useNavigate } from 'react-router-dom'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
//import './GameCard.css'

/* 
  This component is used to represent a video game
*/

const GameCard = ({ name, id, onClick, gameState, gameSetState }) => {
  let navigate = useNavigate()

  const handleRoutes = () => {
    navigate(`details/${id}`)
  }

  const dropMe = async () =>{// this is the code that can delete the games from the GamesContainer component
    
    const resp = await fetch("https://localhost:7269/api/Games?id=" + id,{method: "DELETE"})
    
    const status = await resp.json()

    if(status.status == "Okay"){
      gameState = gameState.filter(function (obj){
        return obj.id !== id;
      });
      gameSetState(gameState);
    }

    
  }

  return (
    <div className='gamecard' style={{display:"inline"}}>
      <p  onClick={handleRoutes} style={{display:"inline", paddingRight:"15px"}}>{name}</p> <i className="fa-sharp fa-solid fa-trash-can" onClick={dropMe}></i>
      <br/>
    </div>
  )
}

export default GameCard
