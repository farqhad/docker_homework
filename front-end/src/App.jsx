import { useState } from 'react';
import Login from './pages/Login';
import Register from './pages/Register';
import './App.css';

function App() {
  const [isLoginView, setIsLoginView] = useState(true);

  return (
    <div className="app-container">
      <div className="auth-switcher">
        <button
          className={`switch-btn ${isLoginView ? 'active' : ''}`}
          onClick={() => setIsLoginView(true)}
        >
          Login
        </button>
        <button
          className={`switch-btn ${!isLoginView ? 'active' : ''}`}
          onClick={() => setIsLoginView(false)}
        >
          Register
        </button>
      </div>
      
      {isLoginView ? <Login /> : <Register />}
    </div>
  );
}

export default App;
