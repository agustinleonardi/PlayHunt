import { Routes, Route } from 'react-router-dom';
import Navbar from './components/Navbar';
import Home from './pages/Home';
import Games from './pages/Games';
import './App.css';

function App() {
  return (
    <div className="App">
      <Navbar />

      <main className="main-content">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/games" element={<Games />} />
        </Routes>
      </main>
    </div>
  );
}

export default App;
