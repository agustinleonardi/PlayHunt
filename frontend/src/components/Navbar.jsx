import { Link, useLocation } from 'react-router-dom';
import './Navbar.css';

function Navbar() {
  const location = useLocation();

  const handleHomeClick = () => {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  };

  const isHome = location.pathname === '/';

  return (
    <nav className="navbar">
      <div className="nav-content">
        <Link to="/" className="nav-logo" onClick={handleHomeClick}>
          PlayHunt
        </Link>
        <div className="nav-links">
          <Link to="/" onClick={handleHomeClick}>
            Home
          </Link>
          <Link to="/games">Juegos</Link>
        </div>
      </div>
    </nav>
  );
}

export default Navbar;
