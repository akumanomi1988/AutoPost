# AutoPost
[Read in English](README.md)

AutoPost es una aplicación .NET 7 diseñada para automatizar la creación, grabación y publicación de videos animados en varias plataformas sociales como Youtube, Instagram y TikTok. Utiliza OBS para grabar animaciones y proporciona funcionalidad para dividir y publicar videos.

## Características

- **AutoPost.AnimationCanva:** Genera animaciones en pantalla con parámetros personalizables en tiempo real.
- **AutoPost.VideoRecorder:** Graba una ventana usando OBS a través de WebSocket.
- **Publicación Automatizada:** Publica videos grabados en plataformas sociales seleccionadas.
- **Descarga y Segmentación de Videos:** Descarga videos de plataformas sociales y los divide según la configuración especificada.

## Dependencias Externas

Para que AutoPost funcione correctamente, se deben cumplir las siguientes dependencias y configuraciones:

### OBS Studio

AutoPost utiliza OBS Studio para la grabación de videos:

- **Instalación de OBS:** Asegúrate de tener OBS Studio instalado en tu máquina. Puedes descargarlo desde [aquí](https://obsproject.com/).
- **Configuración de OBS:** OBS debe estar configurado para capturar la ventana de animación deseada.
- **WebSocket:** La conexión WebSocket debe estar habilitada para permitir la comunicación con AutoPost.VideoRecorder.
  - Esto puede requerir la instalación del plugin 'obs-websocket', que puedes encontrar [aquí](https://obsproject.com/forum/resources/obs-websocket-remote-control-obs-studio-from-websockets.466/).

### Python y Dependencias

AutoPost utiliza scripts de Python para algunas operaciones, por lo que se requiere lo siguiente:

- **Instalación de Python 3:** Asegúrate de tener Python 3 instalado. Puedes descargarlo desde [aquí](https://www.python.org/downloads/).
- **Instalación de Pip:** Pip se usa para gestionar las bibliotecas de Python. La instalación de Python debe incluir Pip. Puedes encontrar instrucciones de instalación [aquí](https://pip.pypa.io/en/stable/installation/).
- **Instalación de tiktok-uploader:** AutoPost requiere el paquete 'tiktok-uploader' para publicar videos en TikTok. [Enlace al proyecto](https://pypi.org/project/tiktok-uploader/)

Instálalo usando pip:

```bash
pip install tiktok-uploader
```

### Formatos de Audio Soportados

Para garantizar la compatibilidad y el funcionamiento adecuado del sistema, se deben respetar los siguientes formatos de audio:

- **Sonidos (Efectos de sonido, alertas, etc.):** Deben estar en formato .ogg.
- **Música (Banda sonora, canciones, etc.):** Pueden estar en formato .mp3.

## Configuración del Proyecto

### Clonar el Repositorio

```bash
git clone https://github.com/akumanomi1988/AutoPost.git
```

### Configurar Variables de Entorno

Establece las variables necesarias para la conexión con OBS y las credenciales de API de las plataformas sociales.

### Instalación de Dependencias

Ejecuta el siguiente comando para restaurar las dependencias del proyecto .NET:

```bash
dotnet restore
```

## Ejemplos de Uso

### Generar Animaciones

Ejecuta el módulo AutoPost.AnimationCanva para generar animaciones personalizables. Aquí hay un ejemplo simple de cómo usarlo:

```csharp
var animation = new AnimationCanva();
animation.SetParameter("text", "Hello World");
animation.Start();
```

### Grabar Videos

Configura y ejecuta el módulo AutoPost.VideoRecorder para grabar una ventana específica:

```csharp
var recorder = new VideoRecorder();
recorder.ConnectToOBS("ws://localhost:4444");
recorder.StartRecording("WindowName");
```

### Publicar Videos

Utiliza el siguiente ejemplo para publicar un video grabado en TikTok:

```python
from tiktok_uploader import upload_video

video_path = "path/to/your/video.mp4"
description = "Check out my new video!"
upload_video(video_path, description)
```

## Contribuciones

Las contribuciones son lo que hacen que la comunidad de código abierto sea un lugar increíble para aprender, inspirar y crear. Cualquier contribución que hagas será muy apreciada.

```bash
# Bifurca el proyecto
# Crea tu rama de característica
git checkout -b feature/AmazingFeature
# Confirma tus cambios
git commit -m 'Add some AmazingFeature'
# Empuja a la rama
git push origin feature/AmazingFeature
# Abre un Pull Request
```

¡Gracias por contribuir!

