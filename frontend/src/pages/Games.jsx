import { useEffect, useState } from 'react';
import { getAllGames } from '../api/gamesApi';
import './Games.css';

function Games() {
  const [games, setGames] = useState([]);
  const [filteredGames, setFilteredGames] = useState([]);
  const [selectedGenre, setSelectedGenre] = useState('all');

  async function loadGames() {
    try {
      const data = await getAllGames();
      setGames(data);
      setFilteredGames(data);
      console.log('Juegos cargados:', data.length);
    } catch (error) {
      console.error('Error al cargar juegos:', error);
    }
  }

  useEffect(() => {
    console.log('Componente montado');
    loadGames();
  }, []);

  // Obtener categorías únicas
  const genres = ['all', ...new Set(games.map((game) => game.genre))];

  // Filtrar juegos por género
  useEffect(() => {
    if (selectedGenre === 'all') {
      setFilteredGames(games);
    } else {
      setFilteredGames(games.filter((game) => game.genre === selectedGenre));
    }
  }, [selectedGenre, games]);

  return (
    <div className="games-container">
      <div className="games-header">
        <h1 className="games-title">Juegos Gratuitos</h1>
      </div>

      <div className="filters-container">
        <p className="filters-label">Filtrar por categoría:</p>
        <div className="filters-buttons">
          {genres.map((genre) => (
            <button
              key={genre}
              className={`filter-btn ${selectedGenre === genre ? 'active' : ''}`}
              onClick={() => setSelectedGenre(genre)}
            >
              {genre.charAt(0).toUpperCase() + genre.slice(1)}
            </button>
          ))}
        </div>
      </div>

      <div className="games-grid">
        {filteredGames.map((game, index) => (
          <div
            key={game.id}
            className="game-card"
            style={{ animationDelay: `${index * 0.05}s` }}
          >
            <img src={game.thumbnail} alt={game.title} />
            <h3>{game.title}</h3>
            <p>
              {game.genre} - {game.platform}
            </p>
          </div>
        ))}
      </div>
    </div>
  );
}

export default Games;
