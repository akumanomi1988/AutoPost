# AutoPost

AutoPost is a .NET 7 application designed to automate the creation, recording, and publishing of animated videos on various social platforms such as Youtube, Instagram, and TikTok. It uses OBS to record animations and provides functionality to split and publish videos.

## Features

- **AutoPost.AnimationCanva:** Generates on-screen animations with customizable parameters at runtime.
- **AutoPost.VideoRecorder:** Records a window using OBS through WebSocket.
- **Automated Publishing:** Publishes recorded videos on selected social platforms.
- **Video Download and Segmentation:** Downloads videos from social platforms and splits them according to the specified configuration.

## External Dependencies

For AutoPost to work correctly, the following dependencies and configurations must be met:

### OBS Studio

AutoPost uses OBS Studio for video recording:

- **OBS Installation:** Make sure you have OBS Studio installed on your machine. You can download it from [here](https://obsproject.com/).
- **OBS Configuration:** OBS must be configured to capture the desired animation window.
- WebSocket connection must be enabled to allow communication with AutoPost.VideoRecorder.
  - This may require the installation of the 'obs-websocket' plugin, which you can find [here](https://obsproject.com/forum/resources/obs-websocket-remote-control-obs-studio-from-websockets.466/).

### Python and Dependencies

AutoPost uses Python scripts for some operations, so the following is required:

- **Python 3 Installation:** Ensure you have Python 3 installed. You can download it from [here](https://www.python.org/downloads/).
- **Pip Installation:** Pip is used to manage Python libraries. The installation of Python should include Pip. You can find installation instructions [here](https://pip.pypa.io/en/stable/installation/).
- **tiktok-uploader Installation:** AutoPost requires the 'tiktok-uploader' package to publish videos on TikTok. [Link to the project](https://pypi.org/project/tiktok-uploader/)

Install it using pip:

```bash
pip install tiktok-uploader
```
### Supported Audio Formats

To ensure compatibility and proper system functioning, the following audio formats must be adhered to:

Sounds (Sound effects, alerts, etc.): Must be in .ogg format.
Music (Soundtrack, songs, etc.): Can be in .mp3 format.
## Project Setup

Clone the Repository:
````bash
Copy code
git clone https://github.com/akumanomi1988/AutoPost.git
````
Configure Environment Variables:
Set the necessary variables for the connection with OBS and social platform API credentials.

## Contribution

Contributions are what make the open-source community an incredible place to learn, inspire, and create. Any contribution you make will be highly appreciated.

````
Fork the project
Create your feature branch 
git checkout -b feature/AmazingFeature
Commit your changes (`git commit -m 'Add some AmazingFeature'`).
Push to the branch (`git push origin feature/AmazingFeature`).
Open a Pull Request.
````