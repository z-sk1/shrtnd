# shrtnd

shrtnd is a simple and fast URL shortener I built — with a Go backend and a frontend using HTML, JavaScript, and CSS.

Both the backend and frontend are deployed on Render, a free hosting service that lets you run web apps and static sites easily. I chose Render because it’s free and straightforward — no AWS accounts or complicated setup needed!

You can check it out live here: shrtnd.onrender.com

When you create a short URL, it looks like this:
shrturl-u17c.onrender.com/random-code

 ## Usage
Go to the website: shrtnd.onrender.com

Paste your long URL into the input box.

Click the Shorten button.

Your short URL will be generated — just copy it and share!

 ## Deployment
If you want to deploy your own instance:

### Backend
Built with Go

To run locally:

go run main.go
Or build an executable:

go build -o shrtnd-backend main.go
### Frontend
Static site in the frontend folder

Can be deployed on any static hosting (like Render, Netlify, GitHub Pages, etc.)

## Contributing
Contributions are welcome! If you want to help improve the project:

Fork the repo

Make your changes

Submit a pull request

Please keep code clean and add comments where needed.
