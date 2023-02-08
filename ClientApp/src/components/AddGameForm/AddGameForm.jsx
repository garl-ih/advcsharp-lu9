import React, { useState, useEffect } from 'react'
import { Button } from '../Button/Button'
import './AddGameForm.css'
import Input from '../Input/Input'

/*
 * this component should be used to create a game object and add it to the
 * database
 */

export const AddGameForm = () => {
  const [status, setStatus] = useState('idle')
  const [state, setState] = useState({
    name: '',
    releaseDate: new Date(),
    price: 0,
    revenue: 0,
    numOfPlayers: 0,
    platforms: [],
  })

  useEffect(() => {
    console.log(state)
  })

  // function to run on submit of the form
  const handleSubmit = async (e) => {
    //stops the refresh of the page
    e.preventDefault()

    // doesn't allow spamming of network requests
    if (state === 'loading') return

    //make a network request

    // handle success and eror

    alert('submit test')
  }

  // communicates to the user
  let buttonText = 'Submit'
  if (state === 'loading') {
    buttonText = 'Loading...'
  }

  // communicates to the user
  if (status === 'error') {
    alert('Error adding data')
  }

  // logic for the text inputs
  const handleChange = (e) => {
    let name = e.target.name
    let value = e.target.value
    setState((prevState) => ({ ...prevState, [name]: value }))
  }

  // logic for the platform checkboxes
  const handleCheck = (e) => {
    //add the checkbox value to the state
    if (e.target.checked) {
      // setState(prevState => ({ ...prevState, platforms: [...platforms, e.target.name] }))
      let newArr = state.platforms.slice()
      newArr.splice(0, 0, e.target.name)
      setState((prevState) => ({
        ...prevState,
        platforms: [...state.platforms, e.target.name],
      }))
    } else {
      // remove the checkbox value from the state
      let newArr = state.platforms.slice()
      let index = newArr.findIndex((elem) => elem === e.target.name)
      newArr.splice(index, 1)
      setState((prevState) => ({
        ...prevState,
        platforms: [...newArr],
      }))
    }
  }

  return (
    <div>
      <h1>Add Game</h1>
      <form className='addgame-form'>
        {/* Name */}
        <label htmlFor='name'>Name</label>
        <input
          type='text'
          name='name'
          value={state.name}
          onChange={handleChange}
        />
        {/* Release Date */}
        <label htmlFor='releaseDate'>Release Date</label>
        <input
          type='date'
          name='releaseDate'
          value={state.releaseDate}
          onChange={handleChange}
        />
        {/* Price */}
        <label htmlFor='price'>Price</label>
        <input
          type='number'
          name='price'
          value={state.price}
          onChange={handleChange}
        />
        {/* Revenue */}
        <label htmlFor='revenue'>Revenue</label>
        <input
          type='number'
          name='revenue'
          value={state.revenue}
          onChange={handleChange}
        />
        {/* Number of Players */}
        <label htmlFor='numOfPlayers'>Number of Players</label>
        <input
          type='number'
          name='numOfPlayers'
          value={state.numOfPlayers}
          onChange={handleChange}
        />
        {/* Platforms */}
        <label htmlFor='platform'>Platforms</label>
        {/*     playstation */}
        <label htmlFor='playstation'>Playstation</label>
        <input
          type='checkbox'
          name='playstation'
          checked={state.platforms.includes('playstation')}
          onChange={handleCheck}
        />
        {/*     xbox */}
        <label htmlFor='xbox'>Xbox</label>
        <input
          type='checkbox'
          name='xbox'
          checked={state.platforms.includes('xbox')}
          onChange={handleCheck}
        />
        {/*     pc */}
        <label htmlFor='pc'>PC</label>
        <input
          type='checkbox'
          name='pc'
          checked={state.platforms.includes('pc')}
          onChange={handleCheck}
        />

        <Button text={buttonText} onClick={handleSubmit} />
      </form>
    </div>
  )
}
