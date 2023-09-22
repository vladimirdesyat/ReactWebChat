function Footer() {
    return (
        <footer className="bg-indigo-950 text-white py-4">
            <div className="container mx-auto">
                <div className="flex flex-row-reverse items-baseline space-y-2 font-bold text-s">
                    <p><a href="https://t.me/vladdesyat" className="text-white hover:text-blue-500 transition-colors px-1 py-2 m-2">@vladdesyat</a></p>
                    <p><a href="mailto:vladimirdesyat@gmail.com" className="text-white hover:text-blue-500 transition-colors px-1 py-2 m-2">@email</a></p>                    
                    <p className="hover:text-blue-500 transition-colors px-1 py-2 m-2">Vladimir Desiaterikov</p>
                    <p className="">{new Date().getFullYear()}</p>
                </div>
            </div>
        </footer>
    );
}

export default Footer;
