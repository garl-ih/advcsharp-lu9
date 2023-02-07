import React from 'react'
import { useParams } from "react-router-dom";

/* 
  This page should create a video game and make a network request to add it to the db
*/

export const DetailsPage = () => {
    const params = useParams();
    return <div>DetailsPage - {params.id}</div>
}

