document.getElementById("urlInput").addEventListener("keydown", function (event) {
	if (event.key === "Enter") {
		shortenURL();
	}
});

async function shortenURL() {
      let longUrl = document.getElementById("urlInput").value;

      const urlPattern = /^(https?:\/\/)[^\s$.?#].[^\s]*$/i;
      
      // Auto-fix: Add https:// if missing
      if (!longUrl.startsWith("http://") && !longUrl.startsWith("https://")) {
        longUrl = "https://" + longUrl;
      }   


      if (!urlPattern.test(longUrl)) {
        document.getElementById("result").innerText = "❌ Please enter a valid URL e.g(google.com)";
        return;
      }

      const response = await fetch("https://shrturl-u17c.onrender.com/shorten", {
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify({ url: longUrl })
      });

      if (!response.ok) {
        document.getElementById("result").innerText = "Failed to shorten URL.";
        return;
      }
    
      const data = await response.json();
      // Create result HTML with a copy button
      document.getElementById("result").innerHTML = `
        Short URL: <a id="shortLink" href="${data.short_url}" target="_blank">${data.short_url}</a>
        <button id = "copyButton" onclick="copyURL()">Copy</button>
      `;
}

function copyURL() {
  const url = document.getElementById("shortLink").href;
  navigator.clipboard.writeText(url)
    .then(() => {
      document.getElementById("copyButton").innerText = "Copied!";
      setTimeout(() => {document.getElementById("copyButton").innerText = "Copy!"}, 3000)})
    .catch(err => alert("Failed to copy, Error Message: " + err));
    }