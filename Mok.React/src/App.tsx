import React, { useState, useEffect } from 'react';
import './App.css';

function App() {
  const initialState = {
    isColored: false,
    sortByCountryAsc: true,
    filterCountry: ''
  };

  const [users, setUsers] = useState([]);
  const [initialUsers, setInitialUsers] = useState([]);
  const [isColored, setIsColored] = useState(initialState.isColored);
  const [sortByCountryAsc, setSortByCountryAsc] = useState(initialState.sortByCountryAsc);
  const [sortBy, setSortBy] = useState({ column: null, order: 'asc' });
  const [filterCountry, setFilterCountry] = useState(initialState.filterCountry);

  // Efecto para cargar los usuarios al montar el componente
  useEffect(() => {
    fetch('https://randomuser.me/api/?results=100')
      .then(response => response.json())
      .then(data => {
        setUsers(data.results);
        setInitialUsers(data.results);
      })
      .catch(error => console.error('Error fetching data:', error));
  }, []);

  // Función para eliminar un usuario por su índice
  const deleteUser = (index) => {
    const updatedUsers = [...users];
    updatedUsers.splice(index, 1);
    setUsers(updatedUsers);
  };

  // Función para colorear las filas
  const handleColorRows = () => {
    setIsColored(prevState => !prevState);
  };

  // Función para ordenar por país
  const handleSortByCountry = () => {
    const sortedUsers = [...users];
    sortedUsers.sort((a, b) => {
      if (sortByCountryAsc) {
        return a.location.country.localeCompare(b.location.country);
      } else {
        return b.location.country.localeCompare(a.location.country);
      }
    });
    setUsers(sortedUsers);
    setSortByCountryAsc(prevState => !prevState);
  };

  // Función para restaurar el estado inicial
  const handleRestoreInitialState = () => {
    setUsers(initialUsers);
    setIsColored(false);
    setSortByCountryAsc(true);
    setFilterCountry('');
  };

  // Función para ordenar por columna
  const handleSortByColumn = (column) => {
    const order = sortBy.column === column && sortBy.order === 'asc' ? 'desc' : 'asc';
    const sortedUsers = [...users];
    sortedUsers.sort((a, b) => {
      let aValue, bValue;
      if (column === 'firstname') {
        aValue = a.name.first;
        bValue = b.name.first;
      } else if (column === 'lastname') {
        aValue = a.name.last;
        bValue = b.name.last;
      } else if (column === 'country') {
        aValue = a.location.country;
        bValue = b.location.country;
      }
      return order === 'asc' ? aValue.localeCompare(bValue) : bValue.localeCompare(aValue);
    });
    setUsers(sortedUsers);
    setSortBy({ column, order });
  };

  // Función para filtrar por país
  const handleFilterByCountry = (event) => {
    const country = event.target.value;
    setFilterCountry(country);
    const filteredUsers = initialUsers.filter(user => user.location.country.toLowerCase().includes(country.toLowerCase()));
    setUsers(filteredUsers);
  };

  // Función para obtener el icono de ordenamiento
  const getSortIcon = (column) => {
    if (sortBy.column === column) {
      return sortBy.order === 'asc' ? '▲' : '▼';
    }
    return '';
  };

  return (
    <div className="App">
      <h1>Lista de Usuarios</h1>
      <header style={{ marginBottom: '20px' }}>
        <button onClick={handleColorRows} style={{ marginRight: '10px' }}>
          {isColored ? 'Restaurar color' : 'Colorea filas'}
        </button>
        <button onClick={handleSortByCountry} style={{ marginRight: '10px' }}>
          {sortByCountryAsc ? 'Ordena por país (asc)' : 'Ordena por país (desc)'}
        </button>
        <button onClick={handleRestoreInitialState} style={{ marginRight: '10px' }}>
          Restaurar estado inicial
        </button>
        <input
          type="text"
          className="filter-input"
          placeholder="Filtrar por país"
          value={filterCountry}
          onChange={handleFilterByCountry}
        />
      </header>

      <table style={{ width: '100%' }}>
        <thead>
          <tr>
            <th onClick={() => handleSortByColumn('picture')} className="sortable-column">Foto {getSortIcon('picture')}</th>
            <th onClick={() => handleSortByColumn('firstname')} className="sortable-column">Nombre {getSortIcon('firstname')}</th>
            <th onClick={() => handleSortByColumn('lastname')} className="sortable-column">Apellido {getSortIcon('lastname')}</th>
            <th onClick={() => handleSortByColumn('country')} className="sortable-column">País {getSortIcon('country')}</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {users.map((user, index) => (
            <tr key={index} className={`hoverable-row ${isColored ? 'colored-row' : ''}`}>
              <td><img src={user.picture.thumbnail} alt="Foto de perfil" /></td>
              <td>{user.name.first}</td>
              <td>{user.name.last}</td>
              <td>{user.location.country}</td>
              <td>
                <button onClick={() => deleteUser(index)}>Eliminar</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default App;
