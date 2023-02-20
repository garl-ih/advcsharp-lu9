import React from 'react'
//import { AddGameForm } from '../../components/AddGameForm/AddGameForm'
// <AddGameForm /> was on line 7, but comments don't work down there... lol
export const AddMPage = () => {
  

  const addMerch = () =>{
    // fetch post request to add to server with data below...



    // on good, update parent state similar to the delete function
  }
  
  
  return (
    <div id="merch-container">
      <label htmlFor="id">ID</label><br/>
      <input type="number" name="id" id="id" required/>
      <br/><br/>
      <label htmlFor="name">Name2</label><br/>
      <input type="text" name="name" id="name" required/>
      <br/><br/>
      <label htmlFor="price">Price</label><br/>
      <input type="number" name="price" id="price" required/>
      <br/><br/>
      <label htmlFor="revenue">Revenue</label><br/>
      <input type="number" name="revenue" id="revenue" required/>
      <br/><br/>
      <label htmlFor="numberOfPlayers">Number of Players</label><br/>
      <input type="number" name="numberOfPlayers" id="numberOfPlayers" required/>
      <br/><br/>
      <label htmlFor="platforms">Platforms</label><br/>
      <input type="text" name="platforms" id="platforms" required/>
      <br/><br/>
      <label htmlFor="releaseDate">Release Date</label><br/>
      <input type="date" name="releaseDate" id="releaseDate" required/>
      <br/><br/>
      <button onClick={addMerch}>Add Game</button><p id="resultMessage"></p>

    </div>
  )
}
