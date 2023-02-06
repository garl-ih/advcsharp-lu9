import React, { useEffect, useState } from 'react';

export const Todos = () => {
    const [todos, setTodos] = useState([]);
    const [state, setState] = useState("idle")

    useEffect(() => {
        const getData = async () => {
            setState("loading")
            let request = await fetch("https://jsonplaceholder.typicode.com/todos");
            if (request.ok) {
                let data = await request.json();
                setTodos(data);
                setState("idle")
            } else {
                setState("error")
            }
        }

        getData()
    }, [])

    if (state === "loading") {
        return <h3>Loading...</h3>
    }

    if (state === "error") {
        return <h3 style={{color: 'red'}}>An error occurred</h3>
    }

    return (
        <div>
            <p>Todos Here</p>
            {todos.map(todo => <p>{JSON.stringify(todo)}</p>) }
        </div>
        )

}


