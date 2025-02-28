import React, { useState } from 'react'
import Constants from '../Utilities/Constants'

export default function UserCreateForm(props) {
    const initialFormData = Object.freeze({
        tckn: "59869263682", //TCKN kurallarına uygun bir placeholder tckn
        name: "Bartu",
        lastname: "Küçükçağlayan"
    });
    const [formData, setFormData] = useState(initialFormData);

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault(); // Prevent default action and reload, I will handle submit
        const userToCreate = {
            userId: 0,
            tckn: formData.tckn,
            name: formData.name,
            lastname: formData.lastname
        };

        const url = Constants.API_URL_CREATE_USER;

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userToCreate)
        })
            .then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error);
            }); //Async javascript apparently (then)

        props.onUserCreated(userToCreate);

    };

    return (
        <form className='w-100 px-5'>
            <h1 className='mt-5'>Create new User!</h1>
            <div className='mt-5'>
                <label className='h3 form-label'>User TCKN</label>
                <input value={formData.tckn} name="tckn" type="text" className='form-control' onChange={handleChange} />
            </div>

            <div className='mt-4'>
                <label className='h3 form-label'>User Name</label>
                <input value={formData.content} name="name" type="text" className='form-control' onChange={handleChange} />
            </div>

            <div className='mt-4'>
                <label className='h3 form-label'>User Last Name</label>
                <input value={formData.content} name="lastname" type="text" className='form-control' onChange={handleChange} />
            </div>

            <button onClick={handleSubmit} className='btn btn-dark btn-lg w-100 mt-5'>Submit</button>
            <button onClick={() => props.onUserCreated(null)} className='btn btn-secondary btn-lg w-100 mt-3'>Cancel</button>
        </form>
    );
}
