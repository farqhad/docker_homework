import axios from 'axios';

const API_URL = 'http://localhost:5243/Auth';

export const login = async (userId) => {
  try {
    // const response = await axios.post(`${API_URL}/Login`, userId);
    const response = await fetch(`${API_URL}/Login`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body : JSON.stringify(userId)
        });
    return await response.json();
  } catch (error) {
    throw error.response.data;
  }
};

export const register = async (userData) => {
  try {
    const response = await axios.post(`${API_URL}/Register`, userData);
    return response.data;
  } catch (error) {
    throw error.response.data;
  }
};
