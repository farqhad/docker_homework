import axios from 'axios';

const API_URL = 'http://localhost:5243/Auth';

export const login = async (userId) => {
  try {
    const response = await axios.post(`${API_URL}/Login`, userId);
    return response.data;
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
