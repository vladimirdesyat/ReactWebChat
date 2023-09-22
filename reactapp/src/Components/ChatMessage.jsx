import { useState, useEffect } from 'react';
import PropTypes from 'prop-types';

function ChatMessage({ messages }) {
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        // Simulate a delay for receiving the chatbot's response
        setLoading(true);
        setTimeout(() => {
            setLoading(false);
        }, 2000); // Adjust the duration as needed

        // Your other useEffect logic for updating messages here
    }, []);

    return (
        <div className="chatbot-messages p-4 max-h-96 overflow-y-auto border border-gray-300 rounded-lg relative">
            {loading && (
                <div className="absolute inset-0 flex items-center justify-center">
                    <div className="animate-bounce">
                        <div className="w-4 h-4 bg-gray-600 rounded-full mx-1"></div>
                        <div className="w-4 h-4 bg-gray-600 rounded-full mx-1"></div>
                        <div className="w-4 h-4 bg-gray-600 rounded-full mx-1"></div>
                    </div>
                </div>
            )}
            {messages.map((message, index) => (
                <div
                    key={index}
                    className={`message ${message.user === 'You' ? 'user' : 'bot'} border-b border-gray-300 py-2`}
                >
                    <span className="message-sender text-gray-400">
                        {message.user === 'You' ? 'You:' : `${message.user}:`}
                    </span>
                    {message.user === 'You' && ' '}{/* Add a space before the query for 'You' messages */}
                    {message.text}
                </div>
            ))}
        </div>
    );
}

ChatMessage.propTypes = {
    messages: PropTypes.arrayOf(
        PropTypes.shape({
            user: PropTypes.string.isRequired,
            text: PropTypes.string.isRequired,
        })
    ).isRequired,
};

export default ChatMessage;
