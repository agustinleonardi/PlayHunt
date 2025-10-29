import './Home.css';
import { Link } from 'react-router-dom';

function Home() {
  return (
    <div className="home">
      <div className="hero-content">
        <div className="logo-container">
          <img src="/ps4.png" alt="Game Controller" className="logo-image" />
          <div className="glow-effect"></div>
        </div>
        <h1 className="title-animated">PlayHunt</h1>
        <p className="subtitle-animated">
          Descubre los mejores juegos gratuitos disponibles
        </p>
        <Link to="/games" className="cta-button">
          Explorar Juegos
        </Link>
      </div>

      <div className="features-grid">
        <div className="feature-card">
          <div className="feature-icon">🎮</div>
          <h3>100% Gratuito</h3>
          <p>Juegos totalmente gratuitos sin costos ocultos</p>
        </div>
        <div className="feature-card">
          <div className="feature-icon">⚡</div>
          <h3>Actualizado</h3>
          <p>Base de datos actualizada diariamente</p>
        </div>
        <div className="feature-card">
          <div className="feature-icon">🎯</div>
          <h3>Filtros Avanzados</h3>
          <p>Encuentra exactamente lo que buscas</p>
        </div>
      </div>
    </div>
  );
}

export default Home;
