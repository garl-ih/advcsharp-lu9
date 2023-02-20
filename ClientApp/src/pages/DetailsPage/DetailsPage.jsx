import React, { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom'
import { Button } from '../../components/Button/Button'
import { DetailsContainer } from '../../components/DetailsContainer/DetailsContainer'
import GameCard from '../../components/GameCard/GameCard'
import './DetailsPage.css'

/* 
  This page should create a video game and make a network request to add it to the db
*/
const games = [
  {
    id: 'e5d1423a-1472-4224-8329-4cb321f5f42b ',
    name: 'Video Game 1',
    releaseData: '7/22/2001',
    price: 20.0,
    revenue: '$2,000,000.00',
    numberOfPlayers: '500,000',
    platforms: [],
  }
]

export const DetailsPage = () => {
  const params = useParams()
  //use the params.id to get the url data

  const [gameState, setGame] = useState({});

    useEffect(()=>{ // useEffect says "I want to run this function after the page loads..."
        getGameFromServer()
    }, []);

    const getGameFromServer = async () => {
        const resp = await fetch("https://localhost:7269/api/Games");
        const done = await resp.json();
        const done2 = done.filter(obj =>{
          //console.log(obj.id);
          return obj.id == params.id;
        });
        setGame(done2[0]);
    }


    const editGame = async () => {
      //let x = document.getElementById("id").value
      let x = params.id;
      let name = document.getElementById("name").value
      let price = document.getElementById("price").value
      let revenue = document.getElementById("revenue").value
      let numberOfPlayers = document.getElementById("numberOfPlayers").value
      let platforms = document.getElementById("platforms").value
      let releaseDate = document.getElementById("releaseDate").value

    //console.log(releaseDate);

      let data = {
        id: x,
        name: name,
        price: price,
        revenue: revenue,
        numberOfPlayers: numberOfPlayers,
        platforms: platforms,
        releaseDate: releaseDate
      }

      const resp = await fetch("https://localhost:7269/api/Games",
      {
        method: "PUT",
        headers: {'Content-Type': 'application/json', 'Accept': 'application/json'},
        body: JSON.stringify(data)
      })
      
      const status = await resp.json()
  
      if(status.status == "Okay"){
        document.getElementById("resultMessage").value = "Game Uploaded";
        alert("Game Updated");
      }else{
        document.getElementById("resultMessage").value = "Something Bad happened!";
        alert("Fail, please reload page");
      }








    }
  //console.log(game);

  return (
    <div>
      <p>You clicked: {params.id}</p>
      <section className='details-page-sec1'>
        <div className='details-card'>Bigger Game Card Here</div>
          <section className='details-container'>
          <div className='game-detail'>
            <strong>Id</strong>
            <p>{gameState.id}</p>
          </div>

          <div className='game-detail'>
            <strong>Name: </strong>
            <input type="text" name="name" id="name" required placeholder={gameState.name}/>
          </div>

          <div className='game-detail'>
            <strong>Price: </strong>
            <input type="number" name="price" id="price" required placeholder={gameState.price}/>
          </div>

          <div className='game-detail'>
            <strong>Revenue: </strong>
            
            <input type="number" name="revenue" id="revenue" required placeholder={gameState.revenue}/>
          </div>

          <div className='game-detail'>
            <strong>Number of Players: </strong>
            
            <input type="number" name="numberOfPlayers" id="numberOfPlayers" required placeholder={gameState.numberOfPlayers}/>
          </div>

          <div className='game-detail'>
            <strong>Platforms: </strong>
            
            <input type="text" name="platforms" id="platforms" required placeholder={gameState.platforms}/>
          </div>

          <div className='game-detail'>
            <strong>Release Date: </strong>
            
            <input type="date" name="releaseDate" id="releaseDate" required placeholder={gameState.releaseData}/>
          </div>

          <br/><br/>
          <button id="addBtn" onClick={editGame}>Update Game</button><p id="resultMessage"></p>

        </section>
      </section>
    </div>
  )
}
