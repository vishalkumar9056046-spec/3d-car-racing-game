# 3D Car Racing Game - Release & Build Guide

Complete instructions for building an APK and publishing to Google Play Store.

## Prerequisites

### Unity Version
- **Recommended**: Unity 2020.3 LTS or later
- **Minimum**: Unity 2019.4 LTS
- **Latest Tested**: Unity 2021.3 LTS

### System Requirements
- **OS**: Windows 10/11, macOS 10.13+, or Linux
- **RAM**: 8GB minimum (16GB recommended)
- **Disk Space**: 30GB free space
- **Internet**: Fast connection for Google Play Store uploads

### Required Software
1. **Android SDK**
   - Android SDK Platform 31 (Android 12)
   - Android SDK Build-Tools 31.0.0+
   - Android NDK (optional but recommended)

2. **Java Development Kit (JDK)**
   - JDK 11 or later
   - OpenJDK or Oracle JDK

3. **Android Studio** (optional but recommended)
   - For managing SDK, emulators, and testing

4. **Google Play Console Account**
   - Developer account ($25 one-time fee)

---

## Getting Started

### Step 1: Install Unity Editor

1. Download **Unity Hub** from [unity.com](https://unity.com/download)
2. Install Unity Hub
3. Click **Installs** > **Install Editor**
4. Select **Unity 2020.3 LTS** (or later)
5. **Select Modules**:
   - ✅ Android Build Support
   - ✅ Android SDK & NDK Tools
   - ✅ OpenJDK
   - ✅ Visual Studio Community (or your preferred IDE)

### Step 2: Install Android Development Tools

#### Option A: Through Unity
1. Open **Edit** > **Preferences** > **External Tools** (macOS: Unity > Preferences)
2. Set paths to:
   - **Android SDK**: `C:\Android\sdk` (or your path)
   - **Android NDK**: `C:\Android\ndk` (or your path)
   - **JDK**: `C:\Program Files\Eclipse Adoptium\jdk-11.0.x` (or your path)

#### Option B: Manual Installation
1. Download Android SDK command-line tools
2. Extract to `C:\Android\sdk`
3. Run `sdkmanager.bat` to install:
   ```bash
   sdkmanager "platforms;android-31" "build-tools;31.0.0"
   ```

### Step 3: Clone/Open Project

1. **Clone Repository**:
   ```bash
   git clone https://github.com/vishalkumar9056046-spec/3d-car-racing-game.git
   cd 3d-car-racing-game
   git checkout develop
   ```

2. **Open in Unity Hub**:
   - Click **Add** > **Add project from disk**
   - Navigate to `3d-car-racing-game` folder
   - Select the folder
   - Click **Open** (wait for project to load - 2-5 minutes)

3. **Verify Installation**:
   - Check Console for any errors
   - Navigate to **Assets/Scenes** in Project window
   - Verify all 6 scenes are present
   - Open MainMenu.unity to test project loads

---

## Android Build Configuration

### Step 1: Switch Platform to Android

1. Open **File** > **Build Settings** (Ctrl+Shift+B)
2. In **Platform** list, select **Android**
3. Click **Switch Platform** (will take 1-2 minutes)
4. Verify status bar says "Android" at bottom right

### Step 2: Configure Player Settings

1. In Build Settings, click **Player Settings**
2. Configure the following:

#### Company & Product Name
- **Company Name**: `Racing Games Inc`
- **Product Name**: `3D Car Racing Game`

#### Identification (Android)
- **Bundle Identifier**: `com.racinggames.carracingame`
  - Format: `com.yourcompany.yourapp`
  - Must be unique globally
  - Must match Google Play Store listing

#### Orientation
- **Default Orientation**: `Landscape Left`
- **Allowed Orientations**: Check only `Landscape Left` and `Landscape Right`

#### Other Settings
- **Target API Level**: 31 (Android 12)
- **Minimum API Level**: 21 (Android 5.0)
- **Scripting Backend**: IL2CPP (default for Android)
- **ARM64**: ✅ Enabled (required for 64-bit)
- **ARMv7**: ✅ Enabled (for older devices)

#### Graphics Settings
- **Graphics APIs**: OpenGL ES 3.0
- **Rendering Path**: Forward
- **Color Space**: Gamma

#### Resolution & Presentation
- **Resolution Width**: 1280
- **Resolution Height**: 720
- **Default Screen Width**: 1280
- **Default Screen Height**: 720
- **Full Screen**: ✅ Enabled

### Step 3: Scene Setup in Build Settings

1. In **Build Settings**, under **Scenes In Build**:
   - Drag and drop in this order:
     - 0: Assets/Scenes/MainMenu.unity
     - 1: Assets/Scenes/Level_1.unity
     - 2: Assets/Scenes/Level_2.unity
     - 3: Assets/Scenes/Level_3.unity
     - 4: Assets/Scenes/Level_4.unity
     - 5: Assets/Scenes/Level_5.unity

2. Verify order in list (numbers 0-5)

### Step 4: Keystore Setup (For Signed APK)

#### Create Keystore File
1. In **Player Settings** > **Android** section, scroll down to **Publishing Settings**
2. Click **Keystore Manager** button
3. Select **Create New**
4. Fill in details:
   - **Keystore Name**: `game.keystore`
   - **Password**: Create strong password (12+ chars)
   - **Key Alias Name**: `gamekey`
   - **Key Password**: Same as keystore or different
   - **Validity (years)**: 25 (recommended)
   - **Full Name**: Your name
   - **Organizational Unit**: `Development`
   - **Organization**: `Racing Games Inc`
   - **City/Locality**: Your city
   - **State/Province**: Your state
   - **Country Code**: Your country code (e.g., US)

5. Click **Create**
6. **IMPORTANT**: Save keystore details in secure location
   - You'll need these for future app updates
   - Losing keystore = cannot update app on Play Store

#### Set Keystore in Publishing Settings
1. **Keystore**: Browse to `game.keystore` file
2. **Keystore Password**: Enter password
3. **Key Alias**: Select the key you created
4. **Key Password**: Enter key password

---

## Generating APK

### Method 1: Development Build (for testing)

1. Open **File** > **Build Settings**
2. Select **Android** as platform
3. Check these options:
   - ✅ **Development Build**
   - ✅ **Script Debugging**
   - ✅ **Graphics Debugging**
4. Click **Build**
5. Choose output folder (e.g., `Builds/Android`)
6. Name file: `CarRacingGame_dev.apk`
7. Wait for build to complete (2-5 minutes)

### Method 2: Release Build (for production)

1. Open **File** > **Build Settings**
2. Select **Android** as platform
3. **Uncheck** all Debug options:
   - ❌ Development Build
   - ❌ Script Debugging
4. Verify Keystore is configured
5. Click **Build**
6. Choose output folder: `Builds/Android`
7. Name file: `CarRacingGame_release.apk`
8. Wait for build (3-7 minutes, IL2CPP slower)

### Method 3: Android App Bundle (AAB - Recommended for Play Store)

1. Open **File** > **Build Settings**
2. Check **Build App Bundle (Google Play)**
3. Uncheck debug options
4. Click **Build**
5. Choose output: `Builds/Android/CarRacingGame.aab`
6. Wait for build (5-10 minutes)

**Why AAB over APK?**
- Play Store optimizes for each device
- Smaller download size (30-40% reduction)
- Automatic updates work better
- Required for new apps on Play Store

---

## Testing on Android Device

### Prerequisites
- Android phone/tablet with API 21+
- USB cable (USB 3.0 recommended)
- USB debugging enabled on device

### Enable USB Debugging

**Android 5.0 to 12:**
1. Open **Settings**
2. Go to **About phone** or **About device**
3. Find **Build number** (scroll down)
4. Tap **Build number** 7 times
5. Go back to **Settings**
6. Find **Developer options** (new menu)
7. Enable **USB Debugging**
8. Connect phone with USB cable
9. Allow USB debugging on phone prompt

### Install Development APK

**Method 1: Through Unity**
1. Open **File** > **Build Settings**
2. Check **Development Build**
3. Click **Build and Run**
4. Select your device from list
5. Unity automatically builds, installs, and launches app

**Method 2: Manual Installation**
```bash
# Navigate to Android SDK platform-tools
cd C:\Android\sdk\platform-tools

# Install APK
adb install -r C:\Builds\Android\CarRacingGame_dev.apk

# Launch app
adb shell am start -n com.racinggames.carracingame/.MainActivity
```

**Method 3: File Transfer**
1. Connect Android device via USB
2. Copy APK to device storage
3. Open file manager on phone
4. Navigate to Downloads folder
5. Tap APK file to install
6. Confirm installation

### Testing Checklist

- [ ] App launches without crashing
- [ ] Main menu displays correctly
- [ ] All buttons respond to touches
- [ ] Car controls work (accelerate, brake, steer)
- [ ] Nitro boost activates with spacebar (or multi-touch)
- [ ] Coins are collected and counted
- [ ] Pause menu opens with ESC
- [ ] Game over screen shows after finish/crash
- [ ] All 5 levels load without error
- [ ] Car shop displays 5 vehicles
- [ ] Settings menu saves volume and vibration
- [ ] Performance is smooth (no major lag)
- [ ] No memory leaks (check logcat for errors)

### Common Testing Issues

**App crashes on startup:**
```bash
# View crash logs
adb logcat | grep -i "crash\|exception"

# Save crash logs to file
adb logcat > crash_log.txt
```

**App not installing:**
```bash
# Clear data and reinstall
adb uninstall com.racinggames.carracingame
adb install -r CarRacingGame_dev.apk
```

**Can't find device:**
```bash
# List connected devices
adb devices

# Restart ADB server
adb kill-server
adb start-server
```

---

## Publishing to Google Play Store

### Step 1: Set Up Google Play Console Account

1. Go to [play.google.com/console](https://play.google.com/console)
2. Sign in with Google account
3. Pay $25 one-time registration fee
4. Complete account setup:
   - Accept agreements
   - Set payment method
   - Provide developer details

### Step 2: Create App Listing

1. Click **Create app** button
2. Fill in app details:
   - **App name**: `3D Car Racing Game`
   - **Default language**: English (United States)
   - **App or game**: Select `Game`
   - **Category**: Select `Racing`
   - **Type**: `Free`

3. Accept agreements and create

### Step 3: Complete App Store Listing

1. Navigate to **Store Listing** section

#### App Details
- **Short description** (50 chars): 
  "Fast-paced 3D racing with 5 levels and nitro boost"

- **Full description** (4000 chars):
  ```
  Experience the ultimate 3D car racing game! Race through 5 challenging 
  levels with realistic physics and exciting gameplay.
  
  Features:
  - 5 Different Cars: Sports Car, Truck, Formula, SUV, Hypercar
  - 5 Challenging Levels: Progressive difficulty
  - Nitro Boost: Temporary speed boost with recharge system
  - Coin Collection: Collect coins to unlock new vehicles
  - Smooth Controls: Touch & accelerometer support
  - Pause & Resume: Play at your own pace
  - Sound Effects: Immersive audio feedback
  
  Controls:
  - Accelerometer: Steer left/right
  - Touch Screen: Tap top half to accelerate, bottom half to brake
  - Multi-touch: Activate nitro boost
  
  Challenge yourself and try to complete all levels with maximum coins!
  ```

#### Graphics
- **App Icon** (512x512 px):
  - Create icon with car racing theme
  - Use bright colors
  - Include app name or car symbol
  - No transparent background

- **Feature Graphic** (1024x500 px):
  - Showcase main game features
  - Include app name
  - Show gameplay screenshot

- **Screenshots** (at least 2, max 8):
  - Capture 1080x1920 screenshots from app
  - Show: Main menu, gameplay, level complete, car shop
  - Include annotations if helpful

- **Video** (optional):
  - YouTube video showcasing gameplay (30 sec - 2 min)
  - Optional but increases download rate

#### Content Rating
1. Click **Content rating questionnaire**
2. Answer questions (mostly "No" for racing game)
3. Submit for rating
4. Receive content rating certificate

#### Target Audience
- **Primary Target Audience**: Teens or Mature
- **Implied Age**: 12+
- **Content Guidelines**: No violence, sexual content, or hate speech

### Step 4: Configure Release Settings

1. Go to **Testing** > **Closed Testing** or **Internal Testing**
2. Click **Create new release**
3. Upload your APK/AAB file
4. Add **Release notes**:
   ```
   Version 1.0.0 - Initial Release
   
   - Launch release with 5 levels
   - 5 unique cars to unlock
   - Nitro boost system
   - Coin collection gameplay
   - Pause/resume functionality
   - High-quality 3D graphics
   ```

### Step 5: Review App Policies

1. Go to **Setup** > **App content**
2. Complete all sections:
   - **App access**: Does not require special access
   - **Financial info**: No in-app purchases
   - **Ads**: Check if you have ads (you don't)
   - **Data safety**: No personal data collection

3. Sign **App developer agreement**
4. Accept **Google Play policies**

### Step 6: Submit for Review

1. Review all sections are complete (green checkmarks)
2. Go to **Production** > **Create new release**
3. Upload final APK/AAB
4. Add release notes
5. Click **Review and roll out to production**
6. Review summary
7. Click **Confirm rollout**
8. **Submit**

**Review Timeline:**
- First submission: 24-48 hours (sometimes up to 7 days)
- Updates: Usually 2-4 hours
- Can be rejected for policy violations

### Step 7: Monitor Review Status

1. Check **Releases** > **Production**
2. View status (Pending review → In review → Live)
3. Get email notifications
4. Address any issues immediately

---

## APK Build Statistics

### Expected File Sizes
- **Development APK**: 150-200 MB
- **Release APK**: 80-120 MB (IL2CPP)
- **AAB (App Bundle)**: 60-100 MB

### Build Times (approximate)
- **Development**: 2-3 minutes
- **Release (IL2CPP)**: 5-10 minutes
- **App Bundle**: 7-12 minutes
- First build always takes longer

### Optimization Tips
1. **Strip unused engine features** in Build Settings
2. **Use IL2CPP** for smaller APK
3. **Enable LZ4 compression** for resources
4. **Remove unused scripts** from build
5. **Compress textures** to ETC2 format

---

## Common Build Errors & Fixes

### Error 1: "Android SDK not found"

**Cause**: Unity can't find Android SDK path

**Fix**:
1. Go to **Edit** > **Preferences** > **External Tools**
2. Set correct path to Android SDK
   - Windows: `C:\Android\sdk`
   - macOS: `/Users/username/Library/Android/sdk`
   - Linux: `~/Android/sdk`
3. Restart Unity

### Error 2: "JDK not found"

**Cause**: Java Development Kit not installed or path wrong

**Fix**:
1. Install OpenJDK 11 from [adoptopenjdk.net](https://adoptopenjdk.net)
2. Set path in **Preferences** > **External Tools**
3. Restart Unity

### Error 3: "Build failed - gradle error"

**Cause**: Gradle build system error

**Fix**:
```bash
# Clear Gradle cache
rm -rf C:\Users\YourName\.gradle\caches

# On macOS/Linux:
rm -rf ~/.gradle/caches

# Clear Unity build cache
rm -rf ProjectSettings/AndroidResolverCache
```

### Error 4: "IL2CPP not installed"

**Cause**: IL2CPP compiler missing

**Fix**:
1. Open Unity Hub
2. Click settings icon on your Unity version
3. Click **Add Modules**
4. Find **Android Build Support**
5. Check **IL2CPP Scripting Backend**
6. Install

### Error 5: "Keystore file not found"

**Cause**: Signed build can't locate keystore file

**Fix**:
1. Ensure `game.keystore` file exists in project folder
2. In **Player Settings** > **Android**, set correct keystore path
3. Use absolute path: `C:\path\to\game.keystore`

### Error 6: "Bundle ID already in use"

**Cause**: Another app uses same bundle ID

**Fix**:
1. Change bundle ID in **Player Settings** > **Android**
2. Use format: `com.yourcompany.uniquename`
3. Make sure it matches Google Play Console listing

### Error 7: "Build succeeds but app crashes on startup"

**Cause**: Script compilation or scene loading error

**Fix**:
1. Check Console for error messages
2. Verify all scripts compile without errors
3. Ensure MainMenu scene is at index 0 in Build Settings
4. Check for missing component references
5. View device logs:
   ```bash
   adb logcat | grep -i "error\|exception"
   ```

### Error 8: "Permission denied" on Google Play upload

**Cause**: Account doesn't have upload permission

**Fix**:
1. In Google Play Console, go to **Users and permissions**
2. Add user email with **Release Manager** role
3. Wait 24 hours for permissions to sync
4. Retry upload

### Error 9: "App rejected by Google Play"

**Common Reasons & Fixes**:

| Issue | Fix |
|-------|-----|
| Low quality/placeholder graphics | Create proper game assets |
| Crashes on startup | Test on multiple devices |
| Misleading description | Ensure description matches functionality |
| Duplicate app | Choose different bundle ID |
| No gameplay | Ensure core game is playable |
| Contains malware | Run antivirus scan, rebuild from clean source |

**Response Process**:
1. Read rejection reason carefully
2. Fix the issue in code
3. Rebuild APK/AAB
4. Resubmit for review

---

## Post-Launch Support

### Monitor App Performance
1. Check **Analytics** > **Overview** in Google Play Console
2. Monitor:
   - Daily active users
   - Crash rate
   - Average rating
   - User reviews

### Respond to Reviews
1. Go to **Ratings & reviews**
2. Reply to user feedback
3. Fix reported issues
4. Release updates with fixes

### Update App
1. Update version in **Player Settings** > **Bundle Version Code**
2. Increase by 1 for each release
3. Update **Bundle Version Name** (e.g., 1.0.1)
4. Make changes to code
5. Build new APK/AAB
6. Upload to **Production** release
7. Add release notes
8. Submit for review (usually 2-4 hours)

---

## Useful Resources

- [Unity Android Development](https://docs.unity3d.com/Manual/android-building.html)
- [Google Play Console Help](https://support.google.com/googleplay/android-developer/)
- [Android Developer Docs](https://developer.android.com/docs)
- [Google Play Policy Center](https://play.google.com/about/developer-content-policy/)

---

## Version History

| Version | Date | Changes |
|---------|------|----------|
| 1.0.0 | 2026-06-12 | Initial release |

---

## Support

For issues or questions:
1. Check error messages in Console
2. View device logs with `adb logcat`
3. Check [GitHub Issues](https://github.com/vishalkumar9056046-spec/3d-car-racing-game/issues)
4. Review this guide again

**Last Updated**: June 12, 2026
**Guide Version**: 1.0
