import React, { useState } from "react";
import Constants from "./Utilities/Constants";
import UserCreateForm from "./Components/UserCreateForm";
import UserUpdateForm from "./Components/UserUpdateForm";

export default function App() {
  const [users, setUsers] = useState([]);
  const [showingCreateNewUserForm, setShowingCreateNewUserForm] = useState(false);
  const [userCurrentlyBeingUpdated, setUserCurrentlyBeingUpdated] = useState(null);

  function getUsers() {
    const url = Constants.API_URL_GET_ALL_USERS;
    fetch(url, {
      method: 'GET',
    })
      .then(response => response.json())
      .then(usersFromServer => {
        //console.log(usersFromServer);
        setUsers(usersFromServer);
      })
      .catch((error) => {
        console.log('Error: ', error);
        alert('An error occurred while fetching users from the server.');
      });
  }

  function deleteUser(userId) {
    const url = `${Constants.API_URL_DELETE_USER_BY_ID}/${userId}`;
    fetch(url, {
      method: 'DELETE',
    })
      .then(response => response.json())
      .then(responseFromServer => {
        console.log(responseFromServer);
        onUserDeleted(userId);
      })
      .catch((error) => {
        console.log('Error: ', error);
        alert('An error occurred while deleting the user from the server.');
      });
  }

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          {(showingCreateNewUserForm === false && userCurrentlyBeingUpdated === null) && (
            <div>
              <h1>ASP.Net TCKN Users with React</h1>
              <div className="mt-5">
                <button onClick={getUsers} className="btn btn-dark btn-lg w-100">Get Users from the server</button>
                <button onClick={() => setShowingCreateNewUserForm(true)} className="btn btn-secondary btn-lg w-100 mt-4">Create new User</button>
              </div>
            </div>
          )}


          {(users.length > 0 && showingCreateNewUserForm === false && userCurrentlyBeingUpdated === null) && renderUsersTable()}

          {showingCreateNewUserForm && <UserCreateForm onUserCreated={onUserCreated} />}

          {userCurrentlyBeingUpdated !== null && <UserUpdateForm user={userCurrentlyBeingUpdated} onUserUpdated={onUserUpdated} />}
        </div>
      </div>
    </div>
  );

  function renderUsersTable() {
    return (
      <div className="table-responsive mt-5">
        <table className="table table-bordered border-light">
          <thead>
            <tr>
              <th scope="col">UserId</th>
              <th scope="col">TCKN (PK)</th>
              <th scope="col">Name</th>
              <th scope="col">Last Name</th>
              <th scope="col">CRUD Operations</th>
            </tr>
          </thead>
          <tbody>
            {users.map((user) => (
              <tr key={user.userId}>
                <th scope="row">{user.userId}</th>
                <td>{user.tckn}</td>
                <td>{user.name}</td>
                <td>{user.lastName}</td>
                <td>
                  <button onClick={() => setUserCurrentlyBeingUpdated(user)} className="btn btn-warning btn-sm me-4">Update</button>
                  <button onClick={() => { if(window.confirm(`Are you sure you want to delete user named "${user.name}"?`)) deleteUser(user.userId) } }className="btn btn-danger btn-sm">Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
        <button onClick={() => setUsers([])} className="btn btn-dark btn-lg w-100">Empty User List</button>
      </div>
    )
  }

  function onUserCreated(createdUser) {
    setShowingCreateNewUserForm(false);
    if (createdUser === null) {
      return;
    }
    alert(`User created: ${createdUser.name} ${createdUser.lastname}`);
    getUsers();
  }

  function onUserUpdated(updatedUser) {
    setUserCurrentlyBeingUpdated(null);
    if (updatedUser === null) {
      return;
    }

    let usersCopy = [...users]; //Users array memory'e kopyalanıyor, yeniden API call yapmıyoruz

    const index = usersCopy.findIndex((usersCopyUser, currentIndex) => {
      if (usersCopyUser.userId === updatedUser.userId) {
        return true;
      }
    });

    if (index !== -1) {
      usersCopy[index] = updatedUser;
    }

    setUsers(usersCopy);

    alert(`User updated: ${updatedUser.name} ${updatedUser.lastname}`);
  }

  function onUserDeleted(deletedUserUserId) {
    let usersCopy = [...users]; //Users array memory'e kopyalanıyor

    const index = usersCopy.findIndex((usersCopyUser, currentIndex) => {
      if (usersCopyUser.userId === deletedUserUserId) {
        return true;
      }
    });

    if (index !== -1) {
      usersCopy.splice(index, 1); //React client'tan siliniyor (index'ten itibaren 1 öge)
    }

    setUsers(usersCopy);

    alert(`User with UserId: ${deletedUserUserId} has been deleted.`);

  }

}

//export default App; // This is the alternative way to export the App component
