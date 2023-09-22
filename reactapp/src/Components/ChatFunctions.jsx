/* eslint-disable no-useless-catch */
import axios from 'axios';

export const sendUserMessage = async (userMessage) => {
    try {
        const response = await axios.post('/api/chat/Send', {
            text: userMessage,
        });
        return response.data;
    } catch (error) {
        throw error;
    }
};

export const fetchChatbotAnswer = async () => {
    try {
        const response = await axios.get('/api/chat/ChatbotAnswer');
        return response.data;
    } catch (error) {
        throw error;
    }
};

// Add Tailwind CSS classes to your functions (optional)
sendUserMessage.twClass = 'text-blue-500'; // Example Tailwind CSS class
fetchChatbotAnswer.twClass = 'text-green-500'; // Example Tailwind CSS class
