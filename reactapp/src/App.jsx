import { useState, useEffect } from 'react';
import ChatMessage from './Components/ChatMessage';
import { sendUserMessage, fetchChatbotAnswer } from './Components/ChatFunctions';
import Header from './Components/Header';
import Footer from './Components/Footer';

function App() {
    const [messages, setMessages] = useState([]);
    const [inputMessage, setInputMessage] = useState('');
    const [, setChatbotAnswer] = useState('');

    const handleInputChange = (event) => {
        setInputMessage(event.target.value);
    };

    const handleSendUserMessage = async () => {
        if (inputMessage.trim() === '') return;

        try {
            const botResponse = await sendUserMessage(inputMessage);
            updateChat([...messages, { text: inputMessage, user: 'You' }, { text: botResponse, user: 'Chatbot' }]);
            setInputMessage('');
        } catch (error) {
            console.error('Error sending user message:', error);
        }
    };

    useEffect(() => {
        fetchChatbotAnswer().then((botResponse) => setChatbotAnswer(botResponse)).catch((error) => {
            console.error('Error fetching chatbot answer:', error);
        });
    }, []);

    const updateChat = (newMessages) => {
        setMessages(newMessages);
    };

    return (
        <div className="min-h-screen bg-gray-100 flex flex-col">
            <Header />
        <main className="flex-grow flex justify-center items-center">
            <div className="chatbot-container p-8 rounded-lg shadow-lg w-full max-w-xl">
                        <ChatMessage messages={messages} />
                        <div className="chat-input flex items-center space-x-4 mt-4">
                            <input
                                type="text"
                                placeholder="Type your message..."
                                value={inputMessage}
                                onChange={handleInputChange}
                                className="w-full py-2 px-4 rounded-lg border focus:ring focus:ring-blue-200"
                            />
                            <button
                                onClick={handleSendUserMessage}
                                className="bg-blue-500 text-white py-2 px-4 rounded-lg hover:bg-blue-600 transition-colors focus:outline-none focus:ring focus:ring-blue-200"
                            >
                                Send
                            </button>
                        </div>
                    </div>
            </main>
            <Footer />
        </div>
    );
}

export default App;
