import React, { useState } from 'react'
import Constants from '../Utilities/Constants'

export default function UserUpdateForm(props) {
    const initialFormData = Object.freeze({
        tckn: props.user.tckn,
        name: props.user.name,
        lastname: props.user.lastname
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
        const userToUpdate = {
            userId: props.user.userId,
            tckn: props.user.tckn,
            name: formData.name,
            lastname: formData.lastname
        };

        const url = Constants.API_URL_UPDATE_USER;

        fetch(url, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userToUpdate)
        })
            .then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert("Noob");
                alert(error);
            }); //Async javascript apparently (then)

        props.onUserUpdated(userToUpdate);

    };

    return (
        <form className='w-100 px-5'>
            <h1 className='mt-5'>Updating the User: "{props.user.name}".</h1>
            <div className='mt-5'>
                <label className='h3 form-label'>User Name</label>
                <input value={formData.name} name="name" type="text" className='form-control' onChange={handleChange} />
            </div>

            <div className='mt-4'>
                <label className='h3 form-label'>User Last Name</label>
                <input value={formData.lastname} name="lastname" type="text" className='form-control' onChange={handleChange} />
            </div>

            <button onClick={handleSubmit} className='btn btn-dark btn-lg w-100 mt-5'>Submit</button>
            <button onClick={() => props.onUserUpdated(null)} className='btn btn-secondary btn-lg w-100 mt-3'>Cancel</button>
        </form>
    );
}
