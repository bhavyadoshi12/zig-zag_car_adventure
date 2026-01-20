# Zig-Zag_Car_Adventure

Welcome to **Zig Zag Car Game**! This is an exciting Unity-based mobile game where players navigate a car through zig-zag platforms, collect diamonds and stars, and compete for high scores. The game features Firebase authentication for user accounts, car selection, and integrated ads for monetization.

## 🎮 Project Description

Zig Zag Car is a fast-paced endless runner game built in Unity using C#. Players control a car that moves automatically, and they must tap to switch lanes to avoid obstacles and collect items. The game includes user authentication via Firebase, allowing players to sign up, log in, and track their progress.

## ✨ Features

- 🚗 **Car Selection**: Choose from multiple stylized vehicles to customize your gameplay experience.
- 🔐 **Firebase Authentication**: Secure user login, signup, and profile management with email/password.
- 💎 **Scoring System**: Collect diamonds and stars, track high scores, and replay with previous scores.
- 🎯 **Endless Gameplay**: Dynamic platform spawning for infinite fun.
- 📱 **Mobile Optimized**: Designed for touch controls and mobile devices.
- 📢 **Unity Ads Integration**: Monetize with rewarded and interstitial ads.
- 🎨 **Stylized Graphics**: High-quality assets including HDRI environments and TextMesh Pro UI.

## 🛠️ Setup Instructions

Follow these steps to set up and run the project on your local machine.

### Prerequisites
- **Unity Hub**: Download and install from [unity.com](https://unity.com/download).
- **Unity Version**: Ensure you have Unity 2021 or later (check ProjectSettings/ProjectVersion.txt for exact version).
- **Firebase Account**: Create a project at [Firebase Console](https://console.firebase.google.com/).
- **Git**: For cloning the repository (optional).

### Step-by-Step Setup

1. **Clone or Download the Project** 📥
   - Download the project zip or clone it using Git:
     ```
     git clone <repository-url>
     cd "Zig Zag Car"
     ```

2. **Open in Unity Hub** 🚀
   - Launch Unity Hub.
   - Click **Add** and select the project folder (`d:/Project Folder/Zig Zag Car`).
   - Open the project in Unity Editor.

3. **Configure Firebase** 🔥
   - In Firebase Console, create a new project or use an existing one.
   - Download `google-services.json` (for Android) and `GoogleService-Info.plist` (for iOS) from Firebase settings.
   - Place these files in `Assets/` (they are already present; update if needed).
   - Enable Authentication in Firebase Console (Email/Password provider).

4. **Install Dependencies** 📦
   - Unity will automatically resolve packages from `Packages/manifest.json`.
   - Key packages include:
     - Firebase SDK (via Assets/Firebase)
     - Unity Ads (com.unity.ads)
     - TextMesh Pro (com.unity.textmeshpro)

5. **Build the Project** 🏗️
   - Go to **File > Build Settings**.
   - Select your target platform (Android/iOS).
   - Click **Build** and choose an output folder.
   - For Android: Ensure Android SDK/NDK are installed via Unity Hub.
   - For iOS: Build to Xcode project and open in Xcode for deployment.

6. **Run in Editor** ▶️
   - Open the desired scene (e.g., `Assets/Scenes/FirebaseAuth.unity` for auth, `Assets/Scenes/SampleScene.unity` for gameplay).
   - Press Play to test in Unity Editor.

### Troubleshooting Tips
- If Firebase doesn't initialize, check console logs for dependency issues.
- Ensure internet connection for Firebase auth.
- For ads, configure Unity Ads dashboard with your game ID.

## 🎯 How to Play

1. **Launch the Game** 🎉
   - Start with the logo scene, then authenticate via Firebase.

2. **Choose Your Car** 🚙
   - Select a car in the ChooseCar scene.

3. **Play the Game** 🏁
   - Tap the screen to switch lanes.
   - Avoid obstacles and collect diamonds (💎) and stars (⭐).
   - Survive as long as possible for higher scores.

4. **Game Over & Replay** 🔄
   - When you crash, view your score and replay.
   - High scores are saved locally and can be resumed.

## 🛠️ Technologies Used

- **Unity Engine**: Game development platform.
- **C#**: Scripting language for game logic.
- **Firebase**: Authentication and backend services.
- **Unity Ads**: Monetization framework.
- **TextMesh Pro**: Advanced UI text rendering.
- **Stylized Vehicles Pack**: Free asset pack for cars.

## 📝 Notes

- This project is built for educational and entertainment purposes.
- Firebase config files contain sensitive data; do not commit them to public repos.
- For production, optimize builds and test on target devices.
- Contributions welcome! Feel free to fork and improve.

Enjoy the game! 🎊 If you have questions, check the scripts in `Assets/Scripts/` for more details.
