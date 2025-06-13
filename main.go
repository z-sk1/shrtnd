package main

import (
	"encoding/json"
	"fmt"
	"log"
	"math/rand"
	"net/http"
	"sync"
	"time"
)

func main() {
	http.HandleFunc("/shorten", shortenHandler)
	http.HandleFunc("/", redirectHandler)

	fmt.Println("URL shortener running at http://localhost:8080")
	log.Fatal(http.ListenAndServe(":8080", nil))
}

var (
	urlStore = make(map[string]string)
	mutex    = sync.RWMutex{}
)

func redirectHandler(w http.ResponseWriter, r *http.Request) {
	enableCORS(w, r)
	if r.Method == "OPTIONS" {
		return
	}
	code := r.URL.Path[1:]

	mutex.RLock()
	longURL, exists := urlStore[code]
	mutex.RUnlock()

	if !exists {
		// Return proper HTML for Not Found
		w.WriteHeader(http.StatusNotFound)
		fmt.Fprintln(w, "<h1>404 - Short URL Not Found</h1>")
		return
	}

	// Add Location header and status code for redirect
	http.Redirect(w, r, longURL, http.StatusFound)
}

type ShortenRequest struct {
	URL string `json:"url"`
}

type ShortenRespose struct {
	URL string `json:"short_url"`
}

func enableCORS(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Access-Control-Allow-Origin", "*")
	w.Header().Set("Access-Control-Allow-Methods", "POST, GET, OPTIONS")
	w.Header().Set("Access-Control-Allow-Headers", "Content-Type")
}

func generateCode(n int) string {
	letters := []rune("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
	rand.Seed(time.Now().UnixNano())
	b := make([]rune, n)
	for i := range b {
		b[i] = letters[rand.Intn(len(letters))]
	}
	return string(b)
}

func shortenHandler(w http.ResponseWriter, r *http.Request) {
	enableCORS(w, r)
	if r.Method == "OPTIONS" {
		return
	}
	if r.Method != http.MethodPost {
		http.Error(w, "ONLY POST ALLOWED", http.StatusMethodNotAllowed)
		return
	}

	var req ShortenRequest
	err := json.NewDecoder(r.Body).Decode(&req)
	if err != nil || req.URL == "" {
		http.Error(w, "Invalid request", http.StatusBadRequest)
		return
	}

	code := generateCode(6)

	mutex.Lock()
	urlStore[code] = req.URL
	mutex.Unlock()

	resp := map[string]string{
		"short_url": fmt.Sprintf("http://localhost:8080/%s", code),
	}

	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(resp)
}
