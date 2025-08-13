import * as Clipboard from 'expo-clipboard';
import React, { useState } from 'react';
import { View, StyleSheet, TouchableOpacity, Text, TextInput, Alert } from 'react-native';

export default function App() {
  const [text, setText] = useState('');
  const [textFocused, setTextFocused] = useState(false);
  const [btnPressed, setBtnPressed] = useState(false);
  const [copyBtnPressed, setCopyBtnPressed] = useState(false);
  const [copyBtnText, setCopyBtnText] = useState("Copy")
  const [displayData, setDisplayData] = useState(null);

  return (
    <View style = {styles.container}>
      <View>
        <Text style = {styles.header}>shrtnd</Text>
      </View>

      <View style = {styles.inputGroup}>
        <TextInput
          style = {[styles.textInput, textFocused && styles.textInputFocused]}
          onFocus = {(() => setTextFocused(true))}
          onBlur = {(() => setTextFocused(false))}
          placeholder = "Enter your Long URL..."
          value = {text}
          onChangeText = {setText}
        />

        <TouchableOpacity
          style = {[styles.button, btnPressed && styles.buttonPressed]}
          onPressIn = {(() => setBtnPressed(true))}
          onPressOut = {(() => setBtnPressed(false))}
          onPress = {shortenURL}>
          <Text style = {styles.buttonText}>Shorten</Text>
        </TouchableOpacity>
      </View>

      <View style = {styles.result}>
        {displayData ? (
          <>
            <Text style = {styles.resultText}>Short URL: {displayData.short_url}</Text>
            <TouchableOpacity
              style = {[styles.copyButton, copyBtnPressed && styles.buttonPressed]}
              onPressIn = {(() => setCopyBtnPressed(true))}
              onPressOut={(() => setCopyBtnPressed(false))}
              onPress = {copyURL}>
              <Text style = {styles.buttonText}>{copyBtnText}</Text>
            </TouchableOpacity>
          </>
        ) : (
          <Text style = {styles.resultText}>Short URL: </Text>
        )}
      </View>
    </View>
  );

  async function copyURL() {
    if (!displayData) {
      Alert.alert("Nothing to Copy", "Please shorten URL first");
      return;
    }

    const shortURL = displayData.short_url.trim();

    try {
      await Clipboard.setStringAsync(shortURL);
      setCopyBtnText("Copied!");
      setTimeout(() => setCopyBtnText("Copy"), 3000);
    } catch (err) {
      Alert.alert("Copy failure:", err.message || "Unknown error");
    }
  }

  async function shortenURL() {
    let longURL = text.trim();

    if (!longURL) {
      Alert.alert("Please enter a valid URL. e.g(google.com)");
      return;
    }

    if (!longURL.startsWith("http://") && !longURL.startsWith("https://")) {
      longURL = "https://" + longURL;
    }

    const urlPattern = /^(https?:\/\/)[^\s$.?#].[^\s]*$/i;

    if (!urlPattern.test(longURL)) {
      Alert.alert("Please enter a valid URl. e.g(google.com)");
      return;
    }

      try {
        const response = await fetch("https://shrturl-u17c.onrender.com/shorten", {
            method: "POST",
            headers: {
              "Content-Type": "application/json"
            },
            body: JSON.stringify({ url: longURL })
          });
      
        if (!response.ok) {
          Alert.alert("Failed to shorten URL: Network connection was not ok");
          return;
        } 
        const data = await response.json();
        setDisplayData(data);

    } catch (err) { 
      Alert.alert("Error:", err.message);
    }
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    flexDirection: 'column',
    alignItems: 'center',
    justifyContent: 'flex-start',
    paddingVertical: 80,
    paddingHorizontal: 20,
    backgroundColor: '#2b3e50', // fallback solid color if no gradient
  },

  header: {
    fontSize: 55,
    marginBottom: 40,
    fontWeight: 'bold',
    color: 'rgba(255, 255, 255, 0.47)', // #ffffff78 alpha
    textShadowColor: 'rgba(0, 0, 0, 0.3)',
    textShadowOffset: { width: 1, height: 1 },
    textShadowRadius: 3,
  },

  inputGroup: {
    flexDirection: 'column',
    flexWrap: 'wrap',
    justifyContent: 'center',
    marginBottom: 20,
  },

  textInput: {
    paddingVertical: 12,
    paddingHorizontal: 16,
    marginBottom: 25,
    borderRadius: 10,
    fontSize: 16,
    width: 260,
    maxWidth: '100%',
    backgroundColor: '#fff',

    //shadow
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.2,
    shadowRadius: 6,
    elevation: 3,
  },

  textInputFocused: {
    borderWidth: 1,
    borderColor: '#4CAF50',
    shadowColor: '#4CAF50',
    shadowOpacity: 0.9,
    shadowRadius: 10,
    elevation: 10,
  },

  button: {
    backgroundColor: '#667eb6ff',
    minWidth: 140,
    paddingVertical: 15,
    paddingHorizontal: 20, // increase horizontal padding
    borderRadius: 10,
    alignItems: 'center',
    justifyContent: 'center',  // add vertical centering
    alignSelf: 'center',
    flexGrow: 0,

    shadowColor: '#000',
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.2,
    shadowRadius: 6,
    elevation: 3,
  },

  copyButton: {
    backgroundColor: '#667eb6ff',
    minWidth: 140,
    marginTop: 15,
    paddingVertical: 15,
    paddingHorizontal: 20, // increase horizontal padding
    borderRadius: 10,
    alignItems: 'center',
    justifyContent: 'center',  // add vertical centering
    alignSelf: 'center',
    flexGrow: 0,

    shadowColor: '#000',
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.2,
    shadowRadius: 6,
    elevation: 3,
  },

  buttonPressed: {
    borderWidth: 2,
    borderColor: 'yellow',
    shadowColor: 'yellow',
    shadowOpacity: 0.9,
    shadowRadius: 10,
    elevation: 10,
  },

  buttonText: {
    color: '#fff',
    fontSize: 23,
    fontWeight: 'bold',
  },

  buttonToggleRow: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'center',
    marginTop: 10,
  },

  toggleContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    marginLeft: 10, // or whatever spacing you want
  },

  toggleLabel: {
    fontSize: 16,
    color: '#fff',
    marginLeft: 8,
  },

  result: {
    backgroundColor: 'rgba(255, 255, 255, 0.1)',
    borderRadius: 12,
    paddingVertical: 20,
    paddingHorizontal: 30,
    marginTop: 40,

    // shadows:
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 4 },
    shadowOpacity: 0.3,
    shadowRadius: 12,
    elevation: 5,
  },

  resultText: {
    color: 'rgba(255, 255, 255, 0.87)',
    textAlign: 'center',
    fontSize: 19,
  }
});