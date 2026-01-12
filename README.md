# C# Simple Server

A lightweight TCP socket-based client-server application written in C# demonstrating basic network communication using the .NET Socket API. This project consists of a multithreaded echo server that can handle multiple concurrent client connections.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Project Structure](#project-structure)
- [Installation](#installation)
- [Usage](#usage)
- [Architecture](#architecture)
- [Configuration](#configuration)
- [How It Works](#how-it-works)
- [Contributing](#contributing)

## Overview

This project demonstrates fundamental concepts of network programming in C#, including:
- TCP socket communication
- Multithreaded server design
- Client-server architecture
- Echo protocol implementation

The server accepts multiple client connections simultaneously and echoes back any message sent by the client, making it an excellent starting point for learning network programming or building more complex communication protocols.

## Features

- **Multithreaded Server**: Handles multiple client connections concurrently using threads
- **Echo Protocol**: Echoes back all messages received from clients
- **Simple Console Interface**: Easy-to-use command-line interface for both server and client
- **Connection Tracking**: Displays the number of connected clients
- **Localhost Communication**: Pre-configured for local testing on `127.0.0.1:13000`

## Prerequisites

Before running this project, ensure you have the following installed:

- **.NET Core 3.1** or later (Currently targets .NET Core 3.1)
- **Visual Studio 2019/2022** (optional, for development)
- **Command line tools**: .NET CLI (dotnet command)

> **Note**: .NET Core 3.1 is out of support. Consider upgrading to a supported version like .NET 6 or later for production use.

## Project Structure

```
C-Sharp_simple_server/
├── README.md
├── ServerOne/
│   ├── ServerOne.sln
│   └── ServerOne/
│       ├── ServerOne.csproj
│       └── Program.cs        # Server implementation
└── ClientOne/
    ├── ClientOne.sln
    └── ClientOne/
        ├── ClientOne.csproj
        └── Program.cs        # Client implementation
```

## Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/NanaBright/C-Sharp_simple_server.git
   cd C-Sharp_simple_server
   ```

2. **Build the Server**:
   ```bash
   cd ServerOne/ServerOne
   dotnet build
   ```

3. **Build the Client**:
   ```bash
   cd ../../ClientOne/ClientOne
   dotnet build
   ```

## 💻 Usage

### Running the Server

1. Navigate to the server directory:
   ```bash
   cd ServerOne/ServerOne
   ```

2. Run the server:
   ```bash
   dotnet run
   ```

3. You should see:
   ```
   Server is Up...
   ```

The server is now listening on `127.0.0.1:13000` and ready to accept client connections.

### Running the Client

1. Open a **new terminal window**

2. Navigate to the client directory:
   ```bash
   cd ClientOne/ClientOne
   ```

3. Run the client:
   ```bash
   dotnet run
   ```

4. You should see:
   ```
   Client is Connected
   Enter Your Message
   ```

5. Type a message and press Enter. The server will echo it back:
   ```
   Enter Your Message
   Hello, Server!
   Server Hello, Server!
   ```

### Testing Multiple Clients

You can run multiple client instances simultaneously to test the server's multithreading capabilities. Simply open additional terminal windows and repeat the client running steps.

## Architecture

### Server Architecture

The server uses a **thread-per-client** model:

1. **Main Thread**: Listens for incoming connections on a TCP socket
2. **Worker Threads**: Each client connection spawns a new thread to handle communication
3. **Echo Handler**: Each worker thread runs the `User()` method that receives messages and echoes them back

**Key Components**:
- `Socket ServerListener`: Listens for incoming connections
- `IPEndPoint`: Binds to IP address and port
- `Thread`: Handles each client in a separate thread
- `byte[] buffer`: Receives and sends message data

### Client Architecture

The client uses a simple blocking I/O model:

1. Connects to the server
2. Reads user input from console
3. Sends message to server
4. Receives and displays echoed response
5. Repeats in a loop

## Configuration

Both server and client use the following default configuration:

| Parameter | Value | Description |
|-----------|-------|-------------|
| IP Address | `127.0.0.1` | Localhost (loopback address) |
| Port | `13000` | TCP port number |
| Buffer Size | `1024` bytes | Maximum message size |
| Backlog | `100` | Maximum pending connections queue |

To modify these settings, edit the values in `Program.cs` of the respective projects:

```csharp
// In ServerOne/ServerOne/Program.cs or ClientOne/ClientOne/Program.cs
int port = 13000;
string IpAddress = "127.0.0.1";
```

## How It Works

### Server Flow

1. **Initialize**: Create a TCP socket and bind it to `127.0.0.1:13000`
2. **Listen**: Start listening for incoming connections (max queue: 100)
3. **Accept Loop**: Continuously accept new client connections
4. **Thread Creation**: For each client, spawn a new thread running the `User()` method
5. **Echo Loop**: In each thread:
   - Receive message from client (up to 1024 bytes)
   - Send the same message back to the client
   - Repeat indefinitely

### Client Flow

1. **Connect**: Establish TCP connection to `127.0.0.1:13000`
2. **Input Loop**: Continuously:
   - Prompt user for input
   - Send message to server
   - Receive echoed response
   - Display the response to console

### Message Format

Messages are sent as ASCII-encoded byte arrays. The protocol is simple:
- Client sends: ASCII bytes of the message
- Server echoes: Same bytes received
- Client decodes: Converts bytes back to string for display

## Contributing

Contributions are welcome! Here are some ways you can improve this project:

- Add error handling and connection recovery
- Implement a more sophisticated protocol (e.g., commands, authentication)
- Add logging capabilities
- Upgrade to a supported .NET version
- Add unit tests
- Implement graceful shutdown
- Add configuration file support
- Implement async/await patterns for better scalability

**To contribute**:
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request
