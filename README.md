# Text-To-Speech Snipping Tool
---
![TTS Screenshot](https://github.com/Jacob-Lillywhite/TextReaderApp/blob/master/Screenshots/TTS.png)
---
#### This is a simple text-to-speech snipping tool made for windows devices. It allows for the user to take a screen shot of a selected area of their screen and then runs that image through the TesseractOCR library in order to try and extract any text found in the screenshot. That extracted text (and/or any user added text) is then sent to an API at ElevenLabs to generate an audio file to be read back to the user.

#### *This project was made with WinForms due to utilizing screen capture that can work across different programs on a Windows machine.

#### *This project was just for fun and was designed for my own amusement.
---
### Room For Improvement
- [ ] Better Trained Tesseract Data Set
- [ ] More Precise Screenshot Capturing
- [ ] UI Adjustments (The Spinner, in particular, could use some work.)
- [ ] Unit Testing (for long term support)
