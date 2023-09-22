function Header() {
    return (
        <header className="bg-indigo-950 text-white py-4">
            <nav className="container mx-auto">
                <div className="flex justify-between items-baseline space-y-2 px-10">
                    <h1 className="text-2xl font-bold">Chatbot App</h1>
                    <ul className="flex space-x-4">
                        <li><a href="/main" className="text-white hover:text-blue-500 transition-colors">Main</a></li>
                        <li><a href="/export" className="text-white hover:text-blue-500 transition-colors">Export</a></li>
                        <li><a href="/import" className="text-white hover:text-blue-500 transition-colors">Import</a></li>
                    </ul>
                </div>
            </nav>
        </header>
    );
}

export default Header;
