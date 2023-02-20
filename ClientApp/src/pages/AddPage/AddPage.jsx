import React from 'react'
//import { AddGameForm } from '../../components/AddGameForm/AddGameForm'
// <AddGameForm /> was on line 7, but comments don't work down there... lol
export const AddPage = () => {
  

  const addGame = async () =>{
    // fetch post request to add to server with data below...
    document.getElementById("addBtn").disabled = true;

    let x = document.getElementById("id").value
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
      method: "POST",
      headers: {'Content-Type': 'application/json', 'Accept': 'application/json'},
      body: JSON.stringify(data)
    })
    
    const status = await resp.json()

    if(status.status == "Okay"){
      document.getElementById("resultMessage").value = "Game Uploaded";
      alert("Game Added");
    }else{
      document.getElementById("resultMessage").value = "Something Bad happened!";
      alert("Fail, please reload page");
    }


    // on good, update parent state similar to the delete function
  }
  
  
  return (
    <>
      <label htmlFor="id">ID</label><br/>
      <input type="number" name="id" id="id" defaultValue="53" required/>
      <br/><br/>
      <label htmlFor="name">Name</label><br/>
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
      <button id="addBtn" onClick={addGame}>Add Game</button><p id="resultMessage"></p>

    </>
  )
}
