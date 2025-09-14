function copyURL() {
  const url = document.getElementById("shortLink").href;
  navigator.clipboard.writeText(url)
    .then(() => {
      document.getElementById("copyButton").innerText = "Copied!";
      setTimeout(() => {document.getElementById("copyButton").innerText = "Copy!"}, 3000)})
    .catch(err => alert("Failed to copy, Error Message: " + err));
    }